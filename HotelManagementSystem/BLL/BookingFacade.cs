using HotelManagementSystem.DAL;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.BLL
{
    /// <summary>
    /// BookingFacade - implements Facade Pattern (Design Pattern #4)
    /// Simplifies complex booking operations by coordinating multiple repositories
    /// Provides a unified interface for booking workflow
    /// </summary>
    public class BookingFacade
    {
        private readonly GuestRepository _guestRepository;
        private readonly RoomRepository _roomRepository;
        private readonly BookingRepository _bookingRepository;

        // Tax rate - in real system this would come from SystemSettings
        private const decimal TAX_RATE = 0.10m; // 10% tax

        public BookingFacade()
        {
            _guestRepository = new GuestRepository();
            _roomRepository = new RoomRepository();
            _bookingRepository = new BookingRepository();
        }

        /// <summary>
        /// Create a new booking with validation and coordination
        /// This method orchestrates multiple repositories and business logic
        /// </summary>
        public int CreateBooking(int guestId, int roomId, DateTime checkInDate, DateTime checkOutDate,
            int numberOfGuests, string specialRequests = null, string notes = null)
        {
            // Step 1: Validate dates
            if (!ValidateBookingDates(checkInDate, checkOutDate))
            {
                throw new ArgumentException("Check-out date must be after check-in date.");
            }

            // Step 2: Validate guest exists
            Guest guest = _guestRepository.GetById(guestId);
            if (guest == null)
            {
                throw new ArgumentException($"Guest with ID {guestId} not found.");
            }

            // Step 3: Validate room exists
            Room room = _roomRepository.GetById(roomId);
            if (room == null)
            {
                throw new ArgumentException($"Room with ID {roomId} not found.");
            }

            // Step 4: Check room capacity
            if (numberOfGuests > room.MaxOccupancy)
            {
                throw new ArgumentException($"Number of guests ({numberOfGuests}) exceeds room capacity ({room.MaxOccupancy}).");
            }

            // Step 5: Check room availability for the selected dates
            if (!IsRoomAvailable(roomId, checkInDate, checkOutDate))
            {
                throw new InvalidOperationException($"Room {room.RoomNumber} is not available for the selected dates.");
            }

            // Step 6: Calculate charges
            int numberOfNights = (checkOutDate - checkInDate).Days;
            decimal roomCharges = room.BasePrice * numberOfNights;
            decimal serviceCharges = 0m; // No additional services in this version
            decimal totalAmount = CalculateTotalAmount(roomCharges, serviceCharges);

            // Step 7: Create booking object
            Booking booking = new Booking
            {
                GuestId = guestId,
                RoomId = roomId,
                CreatedByUserId = SessionManager.CurrentUser?.UserId ?? 1, // Default to 1 if no user logged in
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                NumberOfGuests = numberOfGuests,
                RoomCharges = roomCharges,
                ServiceCharges = serviceCharges,
                TotalAmount = totalAmount,
                SpecialRequests = specialRequests,
                Notes = notes,
                Status = "Pending" // Initial status
            };

            // Step 8: Insert booking
            int bookingId = _bookingRepository.Insert(booking);

            // Step 9: Update room status to Reserved
            if (bookingId > 0)
            {
                _roomRepository.UpdateRoomStatus(roomId, "Reserved");
            }

            return bookingId;
        }

        /// <summary>
        /// Validate that check-out date is after check-in date
        /// </summary>
        public bool ValidateBookingDates(DateTime checkInDate, DateTime checkOutDate)
        {
            // Check-in must be today or in the future
            if (checkInDate.Date < DateTime.Today)
            {
                return false;
            }

            // Check-out must be after check-in
            if (checkOutDate <= checkInDate)
            {
                return false;
            }

            // At least one night
            if ((checkOutDate - checkInDate).Days < 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Calculate total amount including room charges, service charges, and tax
        /// </summary>
        public decimal CalculateTotalAmount(decimal roomCharges, decimal serviceCharges)
        {
            decimal subtotal = roomCharges + serviceCharges;
            decimal tax = subtotal * TAX_RATE;
            decimal total = subtotal + tax;
            return Math.Round(total, 2);
        }

        /// <summary>
        /// Check if a room is available for the specified date range
        /// </summary>
        public bool IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            // Get the room
            Room room = _roomRepository.GetById(roomId);
            if (room == null)
            {
                return false;
            }

            // Room must be Available or Reserved status
            if (room.Status != "Available" && room.Status != "Reserved")
            {
                return false;
            }

            // Check for conflicting bookings
            List<Booking> conflictingBookings = _bookingRepository.GetBookingsByDateRange(
                roomId, checkInDate, checkOutDate);

            // If there are any active bookings in this date range, room is not available
            return conflictingBookings.Count == 0;
        }

        /// <summary>
        /// Get available rooms for date range
        /// </summary>
        public List<Room> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            return _roomRepository.GetAvailableRooms(checkInDate, checkOutDate);
        }

        /// <summary>
        /// Confirm a pending booking
        /// </summary>
        public bool ConfirmBooking(int bookingId)
        {
            Booking booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
            {
                throw new ArgumentException($"Booking with ID {bookingId} not found.");
            }

            if (booking.Status != "Pending")
            {
                throw new InvalidOperationException($"Only pending bookings can be confirmed. Current status: {booking.Status}");
            }

            return _bookingRepository.UpdateBookingStatus(bookingId, "Confirmed");
        }

        /// <summary>
        /// Check-in a guest (confirms their arrival)
        /// </summary>
        public bool CheckIn(int bookingId)
        {
            Booking booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
            {
                throw new ArgumentException($"Booking with ID {bookingId} not found.");
            }

            if (booking.Status != "Confirmed")
            {
                throw new InvalidOperationException($"Only confirmed bookings can be checked in. Current status: {booking.Status}");
            }

            // Update booking to CheckedIn
            bool bookingUpdated = _bookingRepository.CheckIn(bookingId);

            // Update room status to Occupied
            if (bookingUpdated)
            {
                _roomRepository.UpdateRoomStatus(booking.RoomId, "Occupied");
            }

            return bookingUpdated;
        }

        /// <summary>
        /// Check-out a guest (ends their stay)
        /// </summary>
        public bool CheckOut(int bookingId)
        {
            Booking booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
            {
                throw new ArgumentException($"Booking with ID {bookingId} not found.");
            }

            if (booking.Status != "CheckedIn")
            {
                throw new InvalidOperationException($"Only checked-in bookings can be checked out. Current status: {booking.Status}");
            }

            // Update booking to CheckedOut
            bool bookingUpdated = _bookingRepository.CheckOut(bookingId);

            // Update room status to Cleaning
            if (bookingUpdated)
            {
                _roomRepository.UpdateRoomStatus(booking.RoomId, "Cleaning");
            }

            return bookingUpdated;
        }

        /// <summary>
        /// Cancel a booking
        /// </summary>
        public bool CancelBooking(int bookingId, string reason)
        {
            Booking booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
            {
                throw new ArgumentException($"Booking with ID {bookingId} not found.");
            }

            if (booking.Status == "CheckedOut" || booking.Status == "Cancelled")
            {
                throw new InvalidOperationException($"Cannot cancel booking with status: {booking.Status}");
            }

            // Cancel booking
            bool cancelled = _bookingRepository.CancelBooking(bookingId, reason);

            // Update room status back to Available (if it was Reserved or Cleaning)
            if (cancelled && (booking.Status == "Pending" || booking.Status == "Confirmed"))
            {
                _roomRepository.UpdateRoomStatus(booking.RoomId, "Available");
            }

            return cancelled;
        }

        /// <summary>
        /// Get all bookings for a specific guest
        /// </summary>
        public List<Booking> GetGuestBookings(int guestId)
        {
            return _bookingRepository.GetBookingsByGuest(guestId);
        }

        /// <summary>
        /// Get booking by ID with full details
        /// </summary>
        public Booking GetBookingById(int bookingId)
        {
            return _bookingRepository.GetById(bookingId);
        }

        /// <summary>
        /// Get all active bookings
        /// </summary>
        public List<Booking> GetActiveBookings()
        {
            return _bookingRepository.GetActiveBookings();
        }

        /// <summary>
        /// Get bookings by status
        /// </summary>
        public List<Booking> GetBookingsByStatus(string status)
        {
            return _bookingRepository.GetBookingsByStatus(status);
        }

        /// <summary>
        /// Update booking details (for modifications before check-in)
        /// </summary>
        public bool UpdateBooking(Booking booking)
        {
            // Can only update pending or confirmed bookings
            Booking existingBooking = _bookingRepository.GetById(booking.BookingId);
            if (existingBooking == null)
            {
                throw new ArgumentException($"Booking with ID {booking.BookingId} not found.");
            }

            if (existingBooking.Status == "CheckedIn" || existingBooking.Status == "CheckedOut" || existingBooking.Status == "Cancelled")
            {
                throw new InvalidOperationException($"Cannot update booking with status: {existingBooking.Status}");
            }

            // Validate new dates if they changed
            if (booking.CheckInDate != existingBooking.CheckInDate || booking.CheckOutDate != existingBooking.CheckOutDate)
            {
                if (!ValidateBookingDates(booking.CheckInDate, booking.CheckOutDate))
                {
                    throw new ArgumentException("Invalid booking dates.");
                }
            }

            // Recalculate charges if dates changed
            if (booking.CheckInDate != existingBooking.CheckInDate || booking.CheckOutDate != existingBooking.CheckOutDate)
            {
                Room room = _roomRepository.GetById(booking.RoomId);
                int numberOfNights = (booking.CheckOutDate - booking.CheckInDate).Days;
                booking.RoomCharges = room.BasePrice * numberOfNights;
                booking.TotalAmount = CalculateTotalAmount(booking.RoomCharges, booking.ServiceCharges);
            }

            return _bookingRepository.Update(booking);
        }
    }
}
