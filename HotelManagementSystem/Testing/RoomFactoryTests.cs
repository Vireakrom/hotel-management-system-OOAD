using System;
using System.Text;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Testing
{
    /// <summary>
    /// Comprehensive test suite for Factory Pattern implementation
    /// Day 6: Testing and Validation
    /// </summary>
    public class RoomFactoryTests
    {
        /// <summary>
        /// Runs all factory pattern tests
        /// </summary>
        public static string RunAllTests()
        {
            StringBuilder report = new StringBuilder();
            int passedTests = 0;
            int totalTests = 0;

            report.AppendLine("=".PadRight(80, '='));
            report.AppendLine("DAY 6: FACTORY PATTERN & ROOM MODEL TESTING");
            report.AppendLine("Hotel Management System - Comprehensive Test Suite");
            report.AppendLine("=".PadRight(80, '='));
            report.AppendLine();

            // Test 1: Basic Room Creation
            report.AppendLine("TEST 1: Basic Room Creation");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestBasicRoomCreation(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 2: Configured Room Creation
            report.AppendLine("TEST 2: Configured Room Creation");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestConfiguredRoomCreation(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 3: Room Type Validation
            report.AppendLine("TEST 3: Room Type Validation");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestRoomTypeValidation(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 4: Default Prices
            report.AppendLine("TEST 4: Default Pricing");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestDefaultPrices(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 5: Room Polymorphism
            report.AppendLine("TEST 5: Room Polymorphism (Abstract Methods)");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestRoomPolymorphism(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 6: Room Validation
            report.AppendLine("TEST 6: Room Data Validation");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestRoomValidation(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 7: Room Utility Methods
            report.AppendLine("TEST 7: Room Utility Methods");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestRoomUtilityMethods(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 8: Price Calculation
            report.AppendLine("TEST 8: Dynamic Price Calculation");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestPriceCalculation(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 9: Feature Detection
            report.AppendLine("TEST 9: Feature Detection");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestFeatureDetection(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Test 10: Error Handling
            report.AppendLine("TEST 10: Error Handling");
            report.AppendLine("-".PadRight(80, '-'));
            if (TestErrorHandling(report)) passedTests++;
            totalTests++;
            report.AppendLine();

            // Summary
            report.AppendLine("=".PadRight(80, '='));
            report.AppendLine("TEST SUMMARY");
            report.AppendLine("=".PadRight(80, '='));
            report.AppendLine($"Total Tests: {totalTests}");
            report.AppendLine($"Passed: {passedTests}");
            report.AppendLine($"Failed: {totalTests - passedTests}");
            report.AppendLine($"Success Rate: {(passedTests * 100.0 / totalTests):F1}%");
            report.AppendLine();

            if (passedTests == totalTests)
            {
                report.AppendLine("? ALL TESTS PASSED! Factory Pattern implementation is solid!");
            }
            else
            {
                report.AppendLine("?? Some tests failed. Review implementation.");
            }

            report.AppendLine("=".PadRight(80, '='));

            return report.ToString();
        }

        private static bool TestBasicRoomCreation(StringBuilder report)
        {
            try
            {
                // Test all room types
                Room single = RoomFactory.CreateRoom("Single");
                Room doubleRoom = RoomFactory.CreateRoom("Double");
                Room suite = RoomFactory.CreateRoom("Suite");
                Room deluxe = RoomFactory.CreateRoom("Deluxe");

                bool success = true;

                // Verify types
                if (!(single is SingleRoom)) { report.AppendLine("? Failed: Single room wrong type"); success = false; }
                else report.AppendLine($"? Single room created: {single.GetType().Name}");

                if (!(doubleRoom is DoubleRoom)) { report.AppendLine("? Failed: Double room wrong type"); success = false; }
                else report.AppendLine($"? Double room created: {doubleRoom.GetType().Name}");

                if (!(suite is SuiteRoom)) { report.AppendLine("? Failed: Suite room wrong type"); success = false; }
                else report.AppendLine($"? Suite room created: {suite.GetType().Name}");

                if (!(deluxe is DeluxeRoom)) { report.AppendLine("? Failed: Deluxe room wrong type"); success = false; }
                else report.AppendLine($"? Deluxe room created: {deluxe.GetType().Name}");

                // Verify properties
                if (single.MaxOccupancy != 1) { report.AppendLine("? Failed: Single room occupancy wrong"); success = false; }
                if (doubleRoom.MaxOccupancy != 2) { report.AppendLine("? Failed: Double room occupancy wrong"); success = false; }
                if (suite.MaxOccupancy != 4) { report.AppendLine("? Failed: Suite room occupancy wrong"); success = false; }
                if (deluxe.MaxOccupancy != 4) { report.AppendLine("? Failed: Deluxe room occupancy wrong"); success = false; }

                if (success)
                    report.AppendLine("? PASSED - All room types created successfully");
                else
                    report.AppendLine("? FAILED - Some room properties incorrect");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestConfiguredRoomCreation(StringBuilder report)
        {
            try
            {
                Room room101 = RoomFactory.CreateRoom("Single", "101", 1, 50.00m, "Available");
                Room room202 = RoomFactory.CreateRoom("Double", "202", 2, 80.00m, "Reserved");
                Room room303 = RoomFactory.CreateRoom("Suite", "303", 3, 150.00m);

                bool success = true;

                if (room101.RoomNumber != "101") { report.AppendLine("? Room number not set"); success = false; }
                if (room101.FloorNumber != 1) { report.AppendLine("? Floor number not set"); success = false; }
                if (room101.BasePrice != 50.00m) { report.AppendLine("? Base price not set"); success = false; }
                if (room101.Status != "Available") { report.AppendLine("? Status not set"); success = false; }

                if (room202.Status != "Reserved") { report.AppendLine("? Custom status not set"); success = false; }
                if (room303.Status != "Available") { report.AppendLine("? Default status not set"); success = false; }

                // Check defaults were applied
                if (string.IsNullOrEmpty(room101.Description)) { report.AppendLine("? Default description not set"); success = false; }
                if (room303.Area == 0) { report.AppendLine("? Default area not set"); success = false; }

                report.AppendLine($"? Room 101: {room101.RoomNumber}, Floor {room101.FloorNumber}, ${room101.BasePrice}");
                report.AppendLine($"? Room 202: {room202.RoomNumber}, Status: {room202.Status}");
                report.AppendLine($"? Room 303: Area: {room303.Area} sq.m, Description set: {!string.IsNullOrEmpty(room303.Description)}");

                if (success)
                    report.AppendLine("? PASSED - Configured rooms created correctly");
                else
                    report.AppendLine("? FAILED - Some properties not configured");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestRoomTypeValidation(StringBuilder report)
        {
            try
            {
                bool success = true;

                // Valid types
                if (!RoomFactory.IsValidRoomType("Single")) { report.AppendLine("? Single should be valid"); success = false; }
                if (!RoomFactory.IsValidRoomType("Double")) { report.AppendLine("? Double should be valid"); success = false; }
                if (!RoomFactory.IsValidRoomType("Suite")) { report.AppendLine("? Suite should be valid"); success = false; }
                if (!RoomFactory.IsValidRoomType("Deluxe")) { report.AppendLine("? Deluxe should be valid"); success = false; }

                // Invalid types
                if (RoomFactory.IsValidRoomType("Invalid")) { report.AppendLine("? Invalid should not be valid"); success = false; }
                if (RoomFactory.IsValidRoomType("")) { report.AppendLine("? Empty string should not be valid"); success = false; }
                if (RoomFactory.IsValidRoomType(null)) { report.AppendLine("? Null should not be valid"); success = false; }

                report.AppendLine("? Valid types: Single, Double, Suite, Deluxe");
                report.AppendLine("? Invalid types rejected correctly");

                string[] validTypes = RoomFactory.GetValidRoomTypes();
                report.AppendLine($"? GetValidRoomTypes returned {validTypes.Length} types");

                if (success)
                    report.AppendLine("? PASSED - Room type validation working");
                else
                    report.AppendLine("? FAILED - Validation issues detected");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestDefaultPrices(StringBuilder report)
        {
            try
            {
                decimal singlePrice = RoomFactory.GetDefaultPrice("Single");
                decimal doublePrice = RoomFactory.GetDefaultPrice("Double");
                decimal suitePrice = RoomFactory.GetDefaultPrice("Suite");
                decimal deluxePrice = RoomFactory.GetDefaultPrice("Deluxe");

                bool success = true;

                if (singlePrice != 50.00m) { report.AppendLine($"? Single price should be $50, got ${singlePrice}"); success = false; }
                if (doublePrice != 80.00m) { report.AppendLine($"? Double price should be $80, got ${doublePrice}"); success = false; }
                if (suitePrice != 150.00m) { report.AppendLine($"? Suite price should be $150, got ${suitePrice}"); success = false; }
                if (deluxePrice != 250.00m) { report.AppendLine($"? Deluxe price should be $250, got ${deluxePrice}"); success = false; }

                report.AppendLine($"? Single: ${singlePrice}/night");
                report.AppendLine($"? Double: ${doublePrice}/night");
                report.AppendLine($"? Suite: ${suitePrice}/night");
                report.AppendLine($"? Deluxe: ${deluxePrice}/night");

                if (success)
                    report.AppendLine("? PASSED - Default prices correct");
                else
                    report.AppendLine("? FAILED - Price mismatch");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestRoomPolymorphism(StringBuilder report)
        {
            try
            {
                Room[] rooms = new Room[]
                {
                    RoomFactory.CreateRoom("Single", "101", 1, 50.00m),
                    RoomFactory.CreateRoom("Double", "201", 2, 80.00m),
                    RoomFactory.CreateRoom("Suite", "301", 3, 150.00m),
                    RoomFactory.CreateRoom("Deluxe", "401", 4, 250.00m)
                };

                bool success = true;

                foreach (Room room in rooms)
                {
                    // Test polymorphic methods
                    decimal price = room.GetPrice();
                    string description = room.GetDescription();
                    string features = room.GetFeaturesSummary();
                    string info = room.GetDetailedInfo();

                    if (price <= 0) { report.AppendLine($"? {room.RoomType}: Invalid price"); success = false; }
                    if (string.IsNullOrEmpty(description)) { report.AppendLine($"? {room.RoomType}: No description"); success = false; }
                    if (string.IsNullOrEmpty(features)) { report.AppendLine($"? {room.RoomType}: No features"); success = false; }
                    if (string.IsNullOrEmpty(info)) { report.AppendLine($"? {room.RoomType}: No info"); success = false; }

                    report.AppendLine($"? {room.RoomType} - GetPrice(): ${price}, Features: {features.Length} chars");
                }

                if (success)
                    report.AppendLine("? PASSED - Polymorphism working correctly");
                else
                    report.AppendLine("? FAILED - Polymorphic methods not implemented");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestRoomValidation(StringBuilder report)
        {
            try
            {
                bool success = true;
                string errorMessage;

                // Valid room
                Room validRoom = RoomFactory.CreateRoom("Single", "101", 1, 50.00m);
                if (!validRoom.IsValid(out errorMessage))
                {
                    report.AppendLine($"? Valid room failed validation: {errorMessage}");
                    success = false;
                }
                else
                {
                    report.AppendLine("? Valid room passed validation");
                }

                // Invalid room - no room number
                Room invalidRoom1 = RoomFactory.CreateRoom("Double");
                invalidRoom1.RoomNumber = "";
                if (invalidRoom1.IsValid(out errorMessage))
                {
                    report.AppendLine("? Room with empty number should fail validation");
                    success = false;
                }
                else
                {
                    report.AppendLine($"? Empty room number rejected: {errorMessage}");
                }

                // Invalid room - negative price
                Room invalidRoom2 = RoomFactory.CreateRoom("Suite", "301", 3, -50.00m);
                if (invalidRoom2.IsValid(out errorMessage))
                {
                    report.AppendLine("? Room with negative price should fail validation");
                    success = false;
                }
                else
                {
                    report.AppendLine($"? Negative price rejected: {errorMessage}");
                }

                if (success)
                    report.AppendLine("? PASSED - Room validation working");
                else
                    report.AppendLine("? FAILED - Validation issues");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestRoomUtilityMethods(StringBuilder report)
        {
            try
            {
                bool success = true;

                Room room = RoomFactory.CreateRoom("Double", "201", 2, 80.00m, "Available");

                // Test IsAvailable
                if (!room.IsAvailable())
                {
                    report.AppendLine("? Available room should return true");
                    success = false;
                }
                else
                {
                    report.AppendLine("? IsAvailable() works for Available status");
                }

                room.Status = "Occupied";
                if (room.IsAvailable())
                {
                    report.AppendLine("? Occupied room should not be available");
                    success = false;
                }
                else
                {
                    report.AppendLine("? IsAvailable() works for Occupied status");
                }

                // Test CanAccommodate
                room = RoomFactory.CreateRoom("Double", "202", 2, 80.00m);
                if (!room.CanAccommodate(2))
                {
                    report.AppendLine("? Double room should accommodate 2 guests");
                    success = false;
                }
                else
                {
                    report.AppendLine("? CanAccommodate() works for valid count");
                }

                if (room.CanAccommodate(5))
                {
                    report.AppendLine("? Double room should not accommodate 5 guests");
                    success = false;
                }
                else
                {
                    report.AppendLine("? CanAccommodate() rejects over-capacity");
                }

                // Test CalculateTotalPrice
                decimal totalPrice = room.CalculateTotalPrice(3);
                if (totalPrice != 240.00m)
                {
                    report.AppendLine($"? Total price should be $240, got ${totalPrice}");
                    success = false;
                }
                else
                {
                    report.AppendLine($"? CalculateTotalPrice() works: 3 nights x $80 = ${totalPrice}");
                }

                if (success)
                    report.AppendLine("? PASSED - Utility methods working");
                else
                    report.AppendLine("? FAILED - Utility method issues");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestPriceCalculation(StringBuilder report)
        {
            try
            {
                bool success = true;

                // Suite with sea view - should have premium
                Room suite = RoomFactory.CreateRoom("Suite", "301", 3, 150.00m);
                suite.HasSeaView = true;
                decimal suitePrice = suite.GetPrice();
                decimal expectedSuitePrice = 150.00m * 1.15m; // 15% premium
                
                if (Math.Abs(suitePrice - expectedSuitePrice) > 0.01m)
                {
                    report.AppendLine($"? Suite with sea view: expected ${expectedSuitePrice:F2}, got ${suitePrice:F2}");
                    success = false;
                }
                else
                {
                    report.AppendLine($"? Suite with sea view: ${suitePrice:F2} (15% premium applied)");
                }

                // Deluxe with sea view and private pool
                Room deluxe = RoomFactory.CreateRoom("Deluxe", "401", 4, 250.00m);
                deluxe.HasSeaView = true;
                deluxe.HasPrivatePool = true;
                decimal deluxePrice = deluxe.GetPrice();
                decimal expectedDeluxePrice = 250.00m * 1.45m; // 20% + 25% premium
                
                if (Math.Abs(deluxePrice - expectedDeluxePrice) > 0.01m)
                {
                    report.AppendLine($"? Deluxe with extras: expected ${expectedDeluxePrice:F2}, got ${deluxePrice:F2}");
                    success = false;
                }
                else
                {
                    report.AppendLine($"? Deluxe with sea view + pool: ${deluxePrice:F2} (45% premium applied)");
                }

                if (success)
                    report.AppendLine("? PASSED - Dynamic pricing working");
                else
                    report.AppendLine("? FAILED - Price calculation issues");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestFeatureDetection(StringBuilder report)
        {
            try
            {
                bool success = true;

                // Suite should have balcony by default
                Room suite = RoomFactory.CreateRoom("Suite", "301", 3, 150.00m);
                if (!suite.HasBalcony)
                {
                    report.AppendLine("? Suite should have balcony by default");
                    success = false;
                }
                else
                {
                    report.AppendLine("? Suite has balcony by default");
                }

                // Deluxe should have balcony and jacuzzi
                Room deluxe = RoomFactory.CreateRoom("Deluxe", "401", 4, 250.00m);
                if (!deluxe.HasBalcony || !deluxe.HasJacuzzi)
                {
                    report.AppendLine("? Deluxe should have balcony and jacuzzi by default");
                    success = false;
                }
                else
                {
                    report.AppendLine("? Deluxe has balcony and jacuzzi by default");
                }

                // Test feature summary
                deluxe.HasSeaView = true;
                deluxe.HasPrivatePool = true;
                string features = deluxe.GetFeaturesSummary();
                
                if (!features.Contains("Balcony") || !features.Contains("Jacuzzi"))
                {
                    report.AppendLine($"? Feature summary incomplete: {features}");
                    success = false;
                }
                else
                {
                    report.AppendLine($"? Feature summary complete: {features}");
                }

                if (success)
                    report.AppendLine("? PASSED - Feature detection working");
                else
                    report.AppendLine("? FAILED - Feature detection issues");

                return success;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Exception: {ex.Message}");
                return false;
            }
        }

        private static bool TestErrorHandling(StringBuilder report)
        {
            try
            {
                bool success = true;
                int errorsCaught = 0;

                // Test invalid room type
                try
                {
                    Room invalid = RoomFactory.CreateRoom("InvalidType");
                    report.AppendLine("? Should throw exception for invalid type");
                    success = false;
                }
                catch (ArgumentException)
                {
                    report.AppendLine("? Invalid room type throws ArgumentException");
                    errorsCaught++;
                }

                // Test null room type
                try
                {
                    Room nullRoom = RoomFactory.CreateRoom(null);
                    report.AppendLine("? Should throw exception for null type");
                    success = false;
                }
                catch (ArgumentException)
                {
                    report.AppendLine("? Null room type throws ArgumentException");
                    errorsCaught++;
                }

                // Test empty room type
                try
                {
                    Room emptyRoom = RoomFactory.CreateRoom("");
                    report.AppendLine("? Should throw exception for empty type");
                    success = false;
                }
                catch (ArgumentException)
                {
                    report.AppendLine("? Empty room type throws ArgumentException");
                    errorsCaught++;
                }

                // Test negative nights in price calculation
                try
                {
                    Room room = RoomFactory.CreateRoom("Single", "101", 1, 50.00m);
                    decimal price = room.CalculateTotalPrice(-1);
                    report.AppendLine("? Should throw exception for negative nights");
                    success = false;
                }
                catch (ArgumentException)
                {
                    report.AppendLine("? Negative nights throws ArgumentException");
                    errorsCaught++;
                }

                report.AppendLine($"? Total errors caught: {errorsCaught}/4");

                if (success && errorsCaught == 4)
                    report.AppendLine("? PASSED - Error handling working correctly");
                else
                    report.AppendLine("? FAILED - Some errors not handled");

                return success && errorsCaught == 4;
            }
            catch (Exception ex)
            {
                report.AppendLine($"? FAILED - Unexpected exception: {ex.Message}");
                return false;
            }
        }
    }
}
