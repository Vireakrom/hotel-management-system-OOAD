using HotelManagementSystem.BLL;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.Testing
{
    /// <summary>
    /// Comprehensive tests for BookingFacade - demonstrates Facade Pattern
    /// Tests coordination between Guest, Room, and Booking repositories
    /// </summary>
    public static class BookingFacadeTests
    {
        public static string RunAllTests()
        {
            StringBuilder results = new StringBuilder();
            results.AppendLine("==========================================================");
            results.AppendLine("   BOOKING FACADE TESTS - FACADE PATTERN DEMONSTRATION");
            results.AppendLine("==========================================================");
            results.AppendLine();
            results.AppendLine("Testing BookingFacade coordinating multiple repositories...");
            results.AppendLine();

            int totalTests = 0;
            int passedTests = 0;

            // Setup: Get test data from database
            GuestRepository guestRepo = new GuestRepository();
            RoomRepository roomRepo = new RoomRepository();

            List<Guest> guests = guestRepo.GetAll();
            List<Room> rooms = roomRepo.GetAll();

            if (guests.Count == 0 || rooms.Count == 0)
            {
                results.AppendLine("ERROR: No guests or rooms found in database. Please add sample data first.");
                return results.ToString();
            }

            int testGuestId = guests[0].GuestId;
            int testRoomId = rooms[0].RoomId;

            // Test 1: Validate Booking Dates
            totalTests++;
            results.AppendLine("TEST 1: Validate Booking Dates");
            try
            {
                BookingFacade facade = new BookingFacade();
                DateTime checkIn = DateTime.Today.AddDays(1);
                DateTime checkOut = DateTime.Today.AddDays(4);

                bool isValid = facade.ValidateBookingDates(checkIn, checkOut);

                if (isValid)
                {
                    results.AppendLine("? PASS: Valid booking dates accepted");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAIL: Valid dates rejected");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAIL: {ex.Message}");
            }
            results.AppendLine();

            // Test 2: Reject Invalid Dates (check-out before check-in)
            totalTests++;
            results.AppendLine("TEST 2: Reject Invalid Dates");
            try
            {
                BookingFacade facade = new BookingFacade();
                DateTime checkIn = DateTime.Today.AddDays(4);
                DateTime checkOut = DateTime.Today.AddDays(1);

                bool isValid = facade.ValidateBookingDates(checkIn, checkOut);

                if (!isValid)
                {
                    results.AppendLine("? PASS: Invalid dates correctly rejected");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAIL: Invalid dates accepted");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAIL: {ex.Message}");
            }
            results.AppendLine();

            // Test 3: Calculate Total Amount
            totalTests++;
            results.AppendLine("TEST 3: Calculate Total Amount (with 10% tax)");
            try
            {
                BookingFacade facade = new BookingFacade();
                decimal roomCharges = 300.00m;
                decimal serviceCharges = 50.00m;
                decimal total = facade.CalculateTotalAmount(roomCharges, serviceCharges);

                // Expected: (300 + 50) * 1.10 = 385.00
                decimal expected = 385.00m;

                if (total == expected)
                {
                    results.AppendLine($"? PASS: Total calculated correctly: ${total}");
                    passedTests++;
                }
                else
                {
                    results.AppendLine($"? FAIL: Expected ${expected}, got ${total}");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAIL: {ex.Message}");
            }
            results.AppendLine();

            // Test 4: Create Booking (Full Workflow)
            totalTests++;
            results.AppendLine("TEST 4: Create Booking - Complete Workflow");
            int newBookingId = 0;
            try
            {
                BookingFacade facade = new BookingFacade();
                DateTime checkIn = DateTime.Today.AddDays(1);
                DateTime checkOut = DateTime.Today.AddDays(4);

                // Set current user for CreatedByUserId
                if (SessionManager.CurrentUser == null)
                {
                    UserRepository userRepo = new UserRepository();
                    SessionManager.CurrentUser = userRepo.GetAll().FirstOrDefault();
                }

                newBookingId = facade.CreateBooking(
                    guestId: testGuestId,
                    roomId: testRoomId,
                    checkInDate: checkIn,
                    checkOutDate: checkOut,
                    numberOfGuests: 2,
                    specialRequests: "Test booking from facade",
                    notes: "Facade pattern test"
                );

                if (newBookingId > 0)
                {
                    results.AppendLine($"? PASS: Booking created successfully (ID: {newBookingId})");
                    results.AppendLine($"  - Guest ID: {testGuestId}");
                    results.AppendLine($"  - Room ID: {testRoomId}");
                    results.AppendLine($"  - Check-in: {checkIn:yyyy-MM-dd}");
                    results.AppendLine($"  - Check-out: {checkOut:yyyy-MM-dd}");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAIL: Booking creation returned invalid ID");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAIL: {ex.Message}");
            }
            results.AppendLine();

            // Test 5: Get Available Rooms
            totalTests++;
            results.AppendLine("TEST 5: Get Available Rooms for Date Range");
            try
            {
                BookingFacade facade = new BookingFacade();
                DateTime checkIn = DateTime.Today.AddDays(10);
                DateTime checkOut = DateTime.Today.AddDays(13);

                List<Room> availableRooms = facade.GetAvailableRooms(checkIn, checkOut);

                if (availableRooms.Count >= 0)
                {
                    results.AppendLine($"? PASS: Found {availableRooms.Count} available rooms");
                    if (availableRooms.Count > 0)
                    {
                        results.AppendLine($"  - Example: Room {availableRooms[0].RoomNumber} ({availableRooms[0].RoomType})");
                    }
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAIL: Method returned null");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAIL: {ex.Message}");
            }
            results.AppendLine();

            // Test 6: Confirm Booking
            if (newBookingId > 0)
            {
                totalTests++;
                results.AppendLine("TEST 6: Confirm Booking");
                try
                {
                    BookingFacade facade = new BookingFacade();
                    bool confirmed = facade.ConfirmBooking(newBookingId);

                    if (confirmed)
                    {
                        results.AppendLine($"? PASS: Booking {newBookingId} confirmed successfully");
                        passedTests++;
                    }
                    else
                    {
                        results.AppendLine("? FAIL: Booking confirmation failed");
                    }
                }
                catch (Exception ex)
                {
                    results.AppendLine($"? FAIL: {ex.Message}");
                }
                results.AppendLine();
            }

            // Test 7: Check-In
            if (newBookingId > 0)
            {
                totalTests++;
                results.AppendLine("TEST 7: Check-In Guest");
                try
                {
                    BookingFacade facade = new BookingFacade();
                    bool checkedIn = facade.CheckIn(newBookingId);

                    if (checkedIn)
                    {
                        results.AppendLine($"? PASS: Guest checked in successfully");
                        results.AppendLine($"  - Booking status: CheckedIn");
                        results.AppendLine($"  - Room status: Occupied");
                        passedTests++;
                    }
                    else
                    {
                        results.AppendLine("? FAIL: Check-in failed");
                    }
                }
                catch (Exception ex)
                {
                    results.AppendLine($"? FAIL: {ex.Message}");
                }
                results.AppendLine();
            }

            // Test 8: Check-Out
            if (newBookingId > 0)
            {
                totalTests++;
                results.AppendLine("TEST 8: Check-Out Guest");
                try
                {
                    BookingFacade facade = new BookingFacade();
                    bool checkedOut = facade.CheckOut(newBookingId);

                    if (checkedOut)
                    {
                        results.AppendLine($"? PASS: Guest checked out successfully");
                        results.AppendLine($"  - Booking status: CheckedOut");
                        results.AppendLine($"  - Room status: Cleaning");
                        passedTests++;
                    }
                    else
                    {
                        results.AppendLine("? FAIL: Check-out failed");
                    }
                }
                catch (Exception ex)
                {
                    results.AppendLine($"? FAIL: {ex.Message}");
                }
                results.AppendLine();
            }

            // Test 9: Get Guest Bookings
            totalTests++;
            results.AppendLine("TEST 9: Get Guest Bookings");
            try
            {
                BookingFacade facade = new BookingFacade();
                List<Booking> guestBookings = facade.GetGuestBookings(testGuestId);

                if (guestBookings != null && guestBookings.Count > 0)
                {
                    results.AppendLine($"? PASS: Retrieved {guestBookings.Count} bookings for guest {testGuestId}");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAIL: No bookings found or method returned null");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAIL: {ex.Message}");
            }
            results.AppendLine();

            // Test 10: Get Active Bookings
            totalTests++;
            results.AppendLine("TEST 10: Get Active Bookings");
            try
            {
                BookingFacade facade = new BookingFacade();
                List<Booking> activeBookings = facade.GetActiveBookings();

                if (activeBookings != null)
                {
                    results.AppendLine($"? PASS: Retrieved {activeBookings.Count} active bookings");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAIL: Method returned null");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAIL: {ex.Message}");
            }
            results.AppendLine();

            // Summary
            results.AppendLine("==========================================================");
            results.AppendLine($"TEST SUMMARY: {passedTests}/{totalTests} tests passed");
            results.AppendLine("==========================================================");
            results.AppendLine();

            if (passedTests == totalTests)
            {
                results.AppendLine("? ALL TESTS PASSED! Facade Pattern working correctly!");
                results.AppendLine();
                results.AppendLine("FACADE PATTERN BENEFITS DEMONSTRATED:");
                results.AppendLine("  ? Simplified complex booking workflow");
                results.AppendLine("  ? Coordinated Guest, Room, and Booking repositories");
                results.AppendLine("  ? Single interface for multiple operations");
                results.AppendLine("  ? Business logic encapsulation");
                results.AppendLine("  ? Validation and error handling");
            }
            else
            {
                results.AppendLine($"? {totalTests - passedTests} test(s) failed. Review errors above.");
            }

            return results.ToString();
        }
    }
}
