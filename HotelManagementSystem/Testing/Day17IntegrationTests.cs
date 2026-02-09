using HotelManagementSystem.BLL;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Testing
{
    /// <summary>
    /// Day 17 Integration Tests - Complete Booking Creation Workflow
    /// Tests the complete booking flow including room status updates
    /// </summary>
    public static class Day17IntegrationTests
    {
        /// <summary>
        /// Run all Day 17 integration tests
        /// </summary>
        public static string RunAllTests()
        {
            StringBuilder results = new StringBuilder();
            results.AppendLine("=== DAY 17 INTEGRATION TESTS ===");
            results.AppendLine("Testing Complete Booking Creation Workflow");
            results.AppendLine("==========================================\n");

            int totalTests = 0;
            int passedTests = 0;

            // Test 1: Complete Booking Creation with Room Status Update
            totalTests++;
            results.AppendLine($"Test 1: Complete Booking Creation with Room Status Update");
            try
            {
                if (TestCompleteBookingCreation())
                {
                    results.AppendLine("? PASSED: Booking created and room status updated to Reserved\n");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAILED: Booking creation or room status update failed\n");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAILED: {ex.Message}\n");
            }

            // Test 2: Verify BookingFacade Coordination
            totalTests++;
            results.AppendLine($"Test 2: Verify BookingFacade Coordination");
            try
            {
                if (TestBookingFacadeCoordination())
                {
                    results.AppendLine("? PASSED: BookingFacade correctly coordinates all repositories\n");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAILED: BookingFacade coordination failed\n");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAILED: {ex.Message}\n");
            }

            // Test 3: Verify Room Status Changes Throughout Workflow
            totalTests++;
            results.AppendLine($"Test 3: Verify Room Status Changes Throughout Workflow");
            try
            {
                if (TestRoomStatusWorkflow())
                {
                    results.AppendLine("? PASSED: Room status changes correctly throughout booking workflow\n");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAILED: Room status workflow failed\n");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAILED: {ex.Message}\n");
            }

            // Test 4: Verify Booking Validation
            totalTests++;
            results.AppendLine($"Test 4: Verify Booking Validation");
            try
            {
                if (TestBookingValidation())
                {
                    results.AppendLine("? PASSED: Booking validation works correctly\n");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAILED: Booking validation failed\n");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAILED: {ex.Message}\n");
            }

            // Test 5: Verify Room Availability Check Before Booking
            totalTests++;
            results.AppendLine($"Test 5: Verify Room Availability Check Before Booking");
            try
            {
                if (TestRoomAvailabilityCheck())
                {
                    results.AppendLine("? PASSED: Room availability check works correctly\n");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAILED: Room availability check failed\n");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAILED: {ex.Message}\n");
            }

            // Test 6: Verify Total Amount Calculation with Tax
            totalTests++;
            results.AppendLine($"Test 6: Verify Total Amount Calculation with Tax");
            try
            {
                if (TestTotalAmountCalculation())
                {
                    results.AppendLine("? PASSED: Total amount calculation with 10% tax is correct\n");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAILED: Total amount calculation failed\n");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAILED: {ex.Message}\n");
            }

            // Test 7: Verify Multiple Bookings Don't Conflict
            totalTests++;
            results.AppendLine($"Test 7: Verify Multiple Bookings Don't Conflict");
            try
            {
                if (TestMultipleBookingsNoConflict())
                {
                    results.AppendLine("? PASSED: Multiple bookings on different rooms work correctly\n");
                    passedTests++;
                }
                else
                {
                    results.AppendLine("? FAILED: Multiple bookings test failed\n");
                }
            }
            catch (Exception ex)
            {
                results.AppendLine($"? FAILED: {ex.Message}\n");
            }

            // Summary
            results.AppendLine("==========================================");
            results.AppendLine($"SUMMARY: {passedTests}/{totalTests} tests passed");
            results.AppendLine("==========================================");

            if (passedTests == totalTests)
            {
                results.AppendLine("\n?? ALL DAY 17 TESTS PASSED! ??");
                results.AppendLine("Complete booking creation workflow is working perfectly!");
                results.AppendLine("? Booking creation logic complete");
                results.AppendLine("? BookingFacade used for coordination");
                results.AppendLine("? Room status updated to Reserved");
            }
            else
            {
                results.AppendLine($"\n?? {totalTests - passedTests} test(s) failed. Please review.");
            }

            return results.ToString();
        }

        /// <summary>
        /// Test 1: Complete Booking Creation with Room Status Update
        /// </summary>
        private static bool TestCompleteBookingCreation()
        {
            BookingFacade facade = new BookingFacade();
            RoomRepository roomRepo = new RoomRepository();

            // Get an available room
            List<Room> availableRooms = roomRepo.GetAvailableRooms(DateTime.Today.AddDays(1), DateTime.Today.AddDays(3));
            if (availableRooms.Count == 0)
            {
                throw new Exception("No available rooms for testing");
            }

            Room testRoom = availableRooms[0];
            string originalStatus = testRoom.Status;

            // Create booking (should be guest ID 1 and 2 from sample data)
            DateTime checkIn = DateTime.Today.AddDays(10);
            DateTime checkOut = DateTime.Today.AddDays(12);

            int bookingId = facade.CreateBooking(
                guestId: 1,
                roomId: testRoom.RoomId,
                checkInDate: checkIn,
                checkOutDate: checkOut,
                numberOfGuests: 1,
                specialRequests: "Test booking for Day 17",
                notes: "Day 17 Integration Test"
            );

            // Verify booking was created
            if (bookingId <= 0)
                return false;

            // Verify room status was updated to Reserved
            Room updatedRoom = roomRepo.GetById(testRoom.RoomId);
            if (updatedRoom.Status != "Reserved")
                return false;

            // Cleanup: Cancel the booking and reset room status
            BookingRepository bookingRepo = new BookingRepository();
            bookingRepo.CancelBooking(bookingId, "Test cleanup");
            roomRepo.UpdateRoomStatus(testRoom.RoomId, originalStatus);

            return true;
        }

        /// <summary>
        /// Test 2: Verify BookingFacade Coordination
        /// </summary>
        private static bool TestBookingFacadeCoordination()
        {
            BookingFacade facade = new BookingFacade();
            GuestRepository guestRepo = new GuestRepository();
            RoomRepository roomRepo = new RoomRepository();

            // Get test data
            List<Guest> guests = guestRepo.GetAll();
            List<Room> rooms = roomRepo.GetAvailableRooms(DateTime.Today.AddDays(1), DateTime.Today.AddDays(3));

            if (guests.Count == 0 || rooms.Count == 0)
                return false;

            Guest testGuest = guests[0];
            Room testRoom = rooms[0];

            // Verify guest exists
            Guest verifyGuest = guestRepo.GetById(testGuest.GuestId);
            if (verifyGuest == null)
                return false;

            // Verify room exists
            Room verifyRoom = roomRepo.GetById(testRoom.RoomId);
            if (verifyRoom == null)
                return false;

            // Create booking through facade (coordinates all 3 repositories)
            DateTime checkIn = DateTime.Today.AddDays(15);
            DateTime checkOut = DateTime.Today.AddDays(17);

            int bookingId = facade.CreateBooking(
                guestId: testGuest.GuestId,
                roomId: testRoom.RoomId,
                checkInDate: checkIn,
                checkOutDate: checkOut,
                numberOfGuests: 1
            );

            // Verify booking was created
            BookingRepository bookingRepo = new BookingRepository();
            Booking booking = bookingRepo.GetById(bookingId);

            if (booking == null)
                return false;

            // Cleanup
            bookingRepo.CancelBooking(bookingId, "Test cleanup");
            roomRepo.UpdateRoomStatus(testRoom.RoomId, "Available");

            return true;
        }

        /// <summary>
        /// Test 3: Verify Room Status Changes Throughout Workflow
        /// </summary>
        private static bool TestRoomStatusWorkflow()
        {
            RoomRepository roomRepo = new RoomRepository();
            BookingFacade facade = new BookingFacade();

            // Get an available room
            List<Room> rooms = roomRepo.GetAvailableRooms(DateTime.Today.AddDays(1), DateTime.Today.AddDays(3));
            if (rooms.Count == 0)
                return false;

            Room testRoom = rooms[0];

            // Step 1: Verify initial status is Available
            if (testRoom.Status != "Available")
                return false;

            // Step 2: Create booking
            DateTime checkIn = DateTime.Today.AddDays(20);
            DateTime checkOut = DateTime.Today.AddDays(22);

            int bookingId = facade.CreateBooking(
                guestId: 1,
                roomId: testRoom.RoomId,
                checkInDate: checkIn,
                checkOutDate: checkOut,
                numberOfGuests: 1
            );

            // Step 3: Verify status changed to Reserved
            Room reservedRoom = roomRepo.GetById(testRoom.RoomId);
            if (reservedRoom.Status != "Reserved")
                return false;

            // Cleanup
            BookingRepository bookingRepo = new BookingRepository();
            bookingRepo.CancelBooking(bookingId, "Test cleanup");
            roomRepo.UpdateRoomStatus(testRoom.RoomId, "Available");

            return true;
        }

        /// <summary>
        /// Test 4: Verify Booking Validation
        /// </summary>
        private static bool TestBookingValidation()
        {
            BookingFacade facade = new BookingFacade();

            // Test 1: Invalid dates (check-out before check-in)
            try
            {
                facade.CreateBooking(
                    guestId: 1,
                    roomId: 1,
                    checkInDate: DateTime.Today.AddDays(5),
                    checkOutDate: DateTime.Today.AddDays(3), // Before check-in!
                    numberOfGuests: 1
                );
                return false; // Should have thrown exception
            }
            catch (ArgumentException)
            {
                // Expected exception
            }

            // Test 2: Invalid guest ID
            try
            {
                facade.CreateBooking(
                    guestId: 99999, // Non-existent guest
                    roomId: 1,
                    checkInDate: DateTime.Today.AddDays(1),
                    checkOutDate: DateTime.Today.AddDays(3),
                    numberOfGuests: 1
                );
                return false; // Should have thrown exception
            }
            catch (ArgumentException)
            {
                // Expected exception
            }

            return true;
        }

        /// <summary>
        /// Test 5: Verify Room Availability Check Before Booking
        /// </summary>
        private static bool TestRoomAvailabilityCheck()
        {
            BookingFacade facade = new BookingFacade();
            RoomRepository roomRepo = new RoomRepository();

            // Get an available room
            List<Room> rooms = roomRepo.GetAvailableRooms(DateTime.Today.AddDays(1), DateTime.Today.AddDays(3));
            if (rooms.Count == 0)
                return false;

            Room testRoom = rooms[0];

            // Create first booking
            DateTime checkIn1 = DateTime.Today.AddDays(25);
            DateTime checkOut1 = DateTime.Today.AddDays(27);

            int bookingId1 = facade.CreateBooking(
                guestId: 1,
                roomId: testRoom.RoomId,
                checkInDate: checkIn1,
                checkOutDate: checkOut1,
                numberOfGuests: 1
            );

            // Try to create overlapping booking (should fail)
            try
            {
                DateTime checkIn2 = DateTime.Today.AddDays(26); // Overlaps with first booking
                DateTime checkOut2 = DateTime.Today.AddDays(28);

                facade.CreateBooking(
                    guestId: 2,
                    roomId: testRoom.RoomId,
                    checkInDate: checkIn2,
                    checkOutDate: checkOut2,
                    numberOfGuests: 1
                );

                // Cleanup
                BookingRepository bookingRepo = new BookingRepository();
                bookingRepo.CancelBooking(bookingId1, "Test cleanup");
                roomRepo.UpdateRoomStatus(testRoom.RoomId, "Available");

                return false; // Should have thrown exception
            }
            catch (InvalidOperationException)
            {
                // Expected exception - room not available
                // Cleanup
                BookingRepository bookingRepo = new BookingRepository();
                bookingRepo.CancelBooking(bookingId1, "Test cleanup");
                roomRepo.UpdateRoomStatus(testRoom.RoomId, "Available");
                return true;
            }
        }

        /// <summary>
        /// Test 6: Verify Total Amount Calculation with Tax
        /// </summary>
        private static bool TestTotalAmountCalculation()
        {
            BookingFacade facade = new BookingFacade();

            // Test calculation: $100 room charge + $0 service charge + 10% tax = $110
            decimal roomCharges = 100.00m;
            decimal serviceCharges = 0m;
            decimal expectedTotal = 110.00m;

            decimal actualTotal = facade.CalculateTotalAmount(roomCharges, serviceCharges);

            return actualTotal == expectedTotal;
        }

        /// <summary>
        /// Test 7: Verify Multiple Bookings Don't Conflict
        /// </summary>
        private static bool TestMultipleBookingsNoConflict()
        {
            BookingFacade facade = new BookingFacade();
            RoomRepository roomRepo = new RoomRepository();

            // Get at least 2 available rooms
            List<Room> rooms = roomRepo.GetAvailableRooms(DateTime.Today.AddDays(1), DateTime.Today.AddDays(3));
            if (rooms.Count < 2)
                return false;

            Room room1 = rooms[0];
            Room room2 = rooms[1];

            // Create booking for room 1
            DateTime checkIn = DateTime.Today.AddDays(30);
            DateTime checkOut = DateTime.Today.AddDays(32);

            int bookingId1 = facade.CreateBooking(
                guestId: 1,
                roomId: room1.RoomId,
                checkInDate: checkIn,
                checkOutDate: checkOut,
                numberOfGuests: 1
            );

            // Create booking for room 2 (same dates, different room - should work)
            int bookingId2 = facade.CreateBooking(
                guestId: 2,
                roomId: room2.RoomId,
                checkInDate: checkIn,
                checkOutDate: checkOut,
                numberOfGuests: 1
            );

            // Verify both bookings were created
            if (bookingId1 <= 0 || bookingId2 <= 0)
                return false;

            // Cleanup
            BookingRepository bookingRepo = new BookingRepository();
            bookingRepo.CancelBooking(bookingId1, "Test cleanup");
            bookingRepo.CancelBooking(bookingId2, "Test cleanup");
            roomRepo.UpdateRoomStatus(room1.RoomId, "Available");
            roomRepo.UpdateRoomStatus(room2.RoomId, "Available");

            return true;
        }
    }
}
