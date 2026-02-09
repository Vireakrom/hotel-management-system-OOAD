using System;
using System.Collections.Generic;
using System.Text;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Testing
{
    /// <summary>
    /// Comprehensive test suite for Booking Repository
    /// Day 13: Testing Booking CRUD Operations
    /// Tests Repository Pattern implementation for Bookings
    /// </summary>
    public class BookingRepositoryTests
    {
        private static BookingRepository bookingRepo = new BookingRepository();
        private static GuestRepository guestRepo = new GuestRepository();
        private static RoomRepository roomRepo = new RoomRepository();

        /// <summary>
        /// Runs all booking repository tests
        /// </summary>
        public static string RunAllTests()
        {
            StringBuilder report = new StringBuilder();
            int passedTests = 0;
            int totalTests = 0;

            report.AppendLine("=".PadRight(80, '='));
            report.AppendLine("DAY 13: BOOKING REPOSITORY TESTING");
            report.AppendLine("Hotel Management System - Repository Pattern Tests");
            report.AppendLine("=".PadRight(80, '='));
            report.AppendLine();

            // Test 1: Create Booking (INSERT)
            report.AppendLine("TEST 1: Create New Booking (INSERT)");
            report.AppendLine("-".PadRight(80, '-'));
            int testBookingId = 0;
            if (TestCreateBooking(report, out testBookingId)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 2: Read Booking (SELECT by ID)
            report.AppendLine("TEST 2: Read Booking by ID (SELECT)");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestReadBooking(report, testBookingId)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 3: Update Booking
            report.AppendLine("TEST 3: Update Booking (UPDATE)");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestUpdateBooking(report, testBookingId)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 4: Get All Bookings
            report.AppendLine("TEST 4: Get All Bookings");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestGetAllBookings(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 5: Get Bookings by Guest
            report.AppendLine("TEST 5: Get Bookings by Guest");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestGetBookingsByGuest(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 6: Get Bookings by Status
            report.AppendLine("TEST 6: Get Bookings by Status");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestGetBookingsByStatus(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 7: Check-In Functionality
            report.AppendLine("TEST 7: Check-In Booking");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestCheckIn(report, testBookingId)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 8: Check-Out Functionality
            report.AppendLine("TEST 8: Check-Out Booking");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestCheckOut(report, testBookingId)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 9: Cancel Booking
            report.AppendLine("TEST 9: Cancel Booking (DELETE)");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestCancelBooking(report, testBookingId)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 10: Calculate Number of Nights
            report.AppendLine("TEST 10: Calculate Number of Nights");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestNumberOfNights(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Final Summary
            report.AppendLine("=".PadRight(80, '='));
            report.AppendLine($"TEST RESULTS: {passedTests}/{totalTests} Tests Passed");
            double successRate = (double)passedTests / totalTests * 100;
            report.AppendLine($"Success Rate: {successRate:F1}%");
            report.AppendLine("=".PadRight(80, '='));

            if (passedTests == totalTests)
            {
                report.AppendLine();
                report.AppendLine("? ALL TESTS PASSED! Booking Repository is working correctly!");
                report.AppendLine("? Repository Pattern implementation validated!");
            }
            else
            {
                report.AppendLine();
                report.AppendLine($"?? {totalTests - passedTests} test(s) failed. Please review the errors above.");
            }

            return report.ToString();
        }

        /// <summary>
        /// Test 1: Create a new booking
        /// </summary>
        private static bool TestCreateBooking(StringBuilder report, out int bookingId)
        {
            bookingId = 0;
            try
            {
                // Get first guest and available room for testing
                List<Guest> guests = guestRepo.GetAll();
                List<Room> availableRooms = roomRepo.GetAvailableRooms(DateTime.Now, DateTime.Now.AddDays(3));

                if (guests.Count == 0 || availableRooms.Count == 0)
                {
                    report.AppendLine("?? Prerequisite Error: Need at least 1 guest and 1 available room");
                    report.AppendLine("Result: SKIPPED - Create sample data first");
                    return false;
                }

                int userId = SessionManager.CurrentUser != null ? SessionManager.CurrentUser.UserId : 1;

                Booking newBooking = new Booking
                {
                    GuestId = guests[0].GuestId,
                    RoomId = availableRooms[0].RoomId,
                    CreatedByUserId = userId,
                    CheckInDate = DateTime.Now.AddDays(1),
                    CheckOutDate = DateTime.Now.AddDays(3),
                    NumberOfGuests = 2,
                    RoomCharges = availableRooms[0].BasePrice * 2, // 2 nights
                    ServiceCharges = 0,
                    TotalAmount = availableRooms[0].BasePrice * 2,
                    SpecialRequests = "Test booking - early check-in requested",
                    Notes = "Created during Day 13 testing",
                    Status = "Pending"
                };

                bookingId = bookingRepo.Insert(newBooking);

                if (bookingId > 0)
                {
                    report.AppendLine($"? Booking created successfully!");
                    report.AppendLine($"   Booking ID: {bookingId}");
                    report.AppendLine($"   Guest ID: {newBooking.GuestId}");
                    report.AppendLine($"   Room ID: {newBooking.RoomId}");
                    report.AppendLine($"   Check-In: {newBooking.CheckInDate:yyyy-MM-dd}");
                    report.AppendLine($"   Check-Out: {newBooking.CheckOutDate:yyyy-MM-dd}");
                    report.AppendLine($"   Nights: {newBooking.NumberOfNights}");
                    report.AppendLine($"   Total: ${newBooking.TotalAmount:F2}");
                    report.AppendLine($"   Status: {newBooking.Status}");
                    report.AppendLine("Result: PASSED ?");
                    return true;
                }
                else
                {
                    report.AppendLine("? Failed to create booking - returned ID is 0");
                    report.AppendLine("Result: FAILED ?");
                    return false;
                }
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 2: Read booking by ID
        /// </summary>
        private static bool TestReadBooking(StringBuilder report, int bookingId)
        {
            try
            {
                if (bookingId == 0)
                {
                    report.AppendLine("?? Prerequisite Error: No booking ID from previous test");
                    report.AppendLine("Result: SKIPPED");
                    return false;
                }

                Booking booking = bookingRepo.GetById(bookingId);

                if (booking != null)
                {
                    report.AppendLine($"? Booking retrieved successfully!");
                    report.AppendLine($"   Booking ID: {booking.BookingId}");
                    report.AppendLine($"   Guest ID: {booking.GuestId}");
                    report.AppendLine($"   Room ID: {booking.RoomId}");
                    report.AppendLine($"   Status: {booking.Status}");
                    report.AppendLine($"   Check-In: {booking.CheckInDate:yyyy-MM-dd}");
                    report.AppendLine($"   Check-Out: {booking.CheckOutDate:yyyy-MM-dd}");
                    report.AppendLine($"   Total Amount: ${booking.TotalAmount:F2}");
                    report.AppendLine("Result: PASSED ?");
                    return true;
                }
                else
                {
                    report.AppendLine($"? Failed to retrieve booking with ID: {bookingId}");
                    report.AppendLine("Result: FAILED ?");
                    return false;
                }
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 3: Update booking
        /// </summary>
        private static bool TestUpdateBooking(StringBuilder report, int bookingId)
        {
            try
            {
                if (bookingId == 0)
                {
                    report.AppendLine("?? Prerequisite Error: No booking ID from previous test");
                    report.AppendLine("Result: SKIPPED");
                    return false;
                }

                Booking booking = bookingRepo.GetById(bookingId);
                if (booking == null)
                {
                    report.AppendLine($"? Booking {bookingId} not found");
                    report.AppendLine("Result: FAILED ?");
                    return false;
                }

                // Update booking details
                string oldNotes = booking.Notes;
                booking.Notes = "Updated during Day 13 testing - changes applied";
                booking.SpecialRequests = "Updated special request - need airport pickup";
                booking.NumberOfGuests = 3;

                bool updated = bookingRepo.Update(booking);

                if (updated)
                {
                    // Verify the update
                    Booking verifyBooking = bookingRepo.GetById(bookingId);
                    if (verifyBooking.Notes == booking.Notes &&
                        verifyBooking.NumberOfGuests == 3)
                    {
                        report.AppendLine($"? Booking updated successfully!");
                        report.AppendLine($"   Booking ID: {bookingId}");
                        report.AppendLine($"   Old Notes: {oldNotes}");
                        report.AppendLine($"   New Notes: {booking.Notes}");
                        report.AppendLine($"   Number of Guests: {booking.NumberOfGuests}");
                        report.AppendLine("Result: PASSED ?");
                        return true;
                    }
                    else
                    {
                        report.AppendLine("? Update executed but verification failed");
                        report.AppendLine("Result: FAILED ?");
                        return false;
                    }
                }
                else
                {
                    report.AppendLine("? Failed to update booking");
                    report.AppendLine("Result: FAILED ?");
                    return false;
                }
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 4: Get all bookings
        /// </summary>
        private static bool TestGetAllBookings(StringBuilder report)
        {
            try
            {
                List<Booking> bookings = bookingRepo.GetAll();

                report.AppendLine($"? Retrieved {bookings.Count} booking(s) from database");

                if (bookings.Count > 0)
                {
                    report.AppendLine($"   Sample bookings:");
                    int displayCount = Math.Min(bookings.Count, 3);
                    for (int i = 0; i < displayCount; i++)
                    {
                        report.AppendLine($"   {i + 1}. ID: {bookings[i].BookingId}, " +
                                        $"Guest: {bookings[i].GuestId}, " +
                                        $"Room: {bookings[i].RoomId}, " +
                                        $"Status: {bookings[i].Status}");
                    }
                }

                report.AppendLine("Result: PASSED ?");
                return true;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 5: Get bookings by guest
        /// </summary>
        private static bool TestGetBookingsByGuest(StringBuilder report)
        {
            try
            {
                List<Guest> guests = guestRepo.GetAll();
                if (guests.Count == 0)
                {
                    report.AppendLine("?? No guests found in database");
                    report.AppendLine("Result: SKIPPED");
                    return false;
                }

                int guestId = guests[0].GuestId;
                List<Booking> bookings = bookingRepo.GetBookingsByGuest(guestId);

                report.AppendLine($"? Retrieved {bookings.Count} booking(s) for Guest ID: {guestId}");

                if (bookings.Count > 0)
                {
                    foreach (var booking in bookings)
                    {
                        report.AppendLine($"   - Booking ID: {booking.BookingId}, " +
                                        $"Status: {booking.Status}, " +
                                        $"Check-In: {booking.CheckInDate:yyyy-MM-dd}");
                    }
                }

                report.AppendLine("Result: PASSED ?");
                return true;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 6: Get bookings by status
        /// </summary>
        private static bool TestGetBookingsByStatus(StringBuilder report)
        {
            try
            {
                string[] statuses = { "Pending", "Confirmed", "CheckedIn", "Cancelled" };
                bool anyFound = false;

                foreach (string status in statuses)
                {
                    List<Booking> bookings = bookingRepo.GetBookingsByStatus(status);
                    if (bookings.Count > 0)
                    {
                        report.AppendLine($"   Status '{status}': {bookings.Count} booking(s)");
                        anyFound = true;
                    }
                }

                if (!anyFound)
                {
                    report.AppendLine("   No bookings found for any status");
                }

                report.AppendLine("? GetBookingsByStatus method working correctly");
                report.AppendLine("Result: PASSED ?");
                return true;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 7: Check-In booking
        /// </summary>
        private static bool TestCheckIn(StringBuilder report, int bookingId)
        {
            try
            {
                if (bookingId == 0)
                {
                    report.AppendLine("?? Prerequisite Error: No booking ID from previous test");
                    report.AppendLine("Result: SKIPPED");
                    return false;
                }

                // First, set status to Confirmed so we can check-in
                bookingRepo.UpdateBookingStatus(bookingId, "Confirmed");

                bool checkedIn = bookingRepo.CheckIn(bookingId);

                if (checkedIn)
                {
                    Booking booking = bookingRepo.GetById(bookingId);
                    if (booking.Status == "CheckedIn" && booking.ActualCheckInDate != null)
                    {
                        report.AppendLine($"? Booking checked-in successfully!");
                        report.AppendLine($"   Booking ID: {bookingId}");
                        report.AppendLine($"   Status: {booking.Status}");
                        report.AppendLine($"   Actual Check-In: {booking.ActualCheckInDate:yyyy-MM-dd HH:mm}");
                        report.AppendLine("Result: PASSED ?");
                        return true;
                    }
                    else
                    {
                        report.AppendLine("? Check-in executed but verification failed");
                        report.AppendLine("Result: FAILED ?");
                        return false;
                    }
                }
                else
                {
                    report.AppendLine("? Failed to check-in booking");
                    report.AppendLine("Result: FAILED ?");
                    return false;
                }
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 8: Check-Out booking
        /// </summary>
        private static bool TestCheckOut(StringBuilder report, int bookingId)
        {
            try
            {
                if (bookingId == 0)
                {
                    report.AppendLine("?? Prerequisite Error: No booking ID from previous test");
                    report.AppendLine("Result: SKIPPED");
                    return false;
                }

                bool checkedOut = bookingRepo.CheckOut(bookingId);

                if (checkedOut)
                {
                    Booking booking = bookingRepo.GetById(bookingId);
                    if (booking.Status == "CheckedOut" && booking.ActualCheckOutDate != null)
                    {
                        report.AppendLine($"? Booking checked-out successfully!");
                        report.AppendLine($"   Booking ID: {bookingId}");
                        report.AppendLine($"   Status: {booking.Status}");
                        report.AppendLine($"   Actual Check-Out: {booking.ActualCheckOutDate:yyyy-MM-dd HH:mm}");
                        report.AppendLine("Result: PASSED ?");
                        return true;
                    }
                    else
                    {
                        report.AppendLine("? Check-out executed but verification failed");
                        report.AppendLine("Result: FAILED ?");
                        return false;
                    }
                }
                else
                {
                    report.AppendLine("? Failed to check-out booking");
                    report.AppendLine("Result: FAILED ?");
                    return false;
                }
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 9: Cancel booking
        /// </summary>
        private static bool TestCancelBooking(StringBuilder report, int bookingId)
        {
            try
            {
                if (bookingId == 0)
                {
                    report.AppendLine("?? Prerequisite Error: No booking ID from previous test");
                    report.AppendLine("Result: SKIPPED");
                    return false;
                }

                string cancellationReason = "Test cancellation during Day 13 testing";
                bool cancelled = bookingRepo.CancelBooking(bookingId, cancellationReason);

                if (cancelled)
                {
                    Booking booking = bookingRepo.GetById(bookingId);
                    if (booking.Status == "Cancelled" && booking.CancelledDate != null)
                    {
                        report.AppendLine($"? Booking cancelled successfully!");
                        report.AppendLine($"   Booking ID: {bookingId}");
                        report.AppendLine($"   Status: {booking.Status}");
                        report.AppendLine($"   Cancelled Date: {booking.CancelledDate:yyyy-MM-dd HH:mm}");
                        report.AppendLine($"   Reason: {booking.CancellationReason}");
                        report.AppendLine("Result: PASSED ?");
                        return true;
                    }
                    else
                    {
                        report.AppendLine("? Cancellation executed but verification failed");
                        report.AppendLine("Result: FAILED ?");
                        return false;
                    }
                }
                else
                {
                    report.AppendLine("? Failed to cancel booking");
                    report.AppendLine("Result: FAILED ?");
                    return false;
                }
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }

        /// <summary>
        /// Test 10: Number of nights calculation
        /// </summary>
        private static bool TestNumberOfNights(StringBuilder report)
        {
            try
            {
                Booking testBooking = new Booking
                {
                    CheckInDate = new DateTime(2025, 2, 15),
                    CheckOutDate = new DateTime(2025, 2, 18)
                };

                int nights = testBooking.NumberOfNights;
                int expectedNights = 3;

                if (nights == expectedNights)
                {
                    report.AppendLine($"? Number of nights calculated correctly!");
                    report.AppendLine($"   Check-In: {testBooking.CheckInDate:yyyy-MM-dd}");
                    report.AppendLine($"   Check-Out: {testBooking.CheckOutDate:yyyy-MM-dd}");
                    report.AppendLine($"   Calculated Nights: {nights}");
                    report.AppendLine("Result: PASSED ?");
                    return true;
                }
                else
                {
                    report.AppendLine($"? Number of nights calculation incorrect!");
                    report.AppendLine($"   Expected: {expectedNights}, Got: {nights}");
                    report.AppendLine("Result: FAILED ?");
                    return false;
                }
            }
            catch (Exception ex)
            {
                report.AppendLine($"? Exception: {ex.Message}");
                report.AppendLine("Result: FAILED ?");
                return false;
            }
        }
    }
}
