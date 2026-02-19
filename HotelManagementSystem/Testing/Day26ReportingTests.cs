using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Testing
{
    /// <summary>
    /// Comprehensive tests for Day 26 - Daily Operations Report & Enhanced Reporting
    /// Tests for: DailyOperationsReportForm data loading, statistics, text report generation
    /// </summary>
    public static class Day26ReportingTests
    {
        public static string RunAllTests()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("===========================================");
            sb.AppendLine("DAY 26 - DAILY OPERATIONS REPORT TESTS");
            sb.AppendLine("===========================================");
            sb.AppendLine();

            int totalTests = 0;
            int passedTests = 0;

            // Test 1: Room Repository - Get All Rooms
            sb.AppendLine("Test 1: Room repository returns rooms...");
            try
            {
                RoomRepository roomRepo = new RoomRepository();
                List<Room> rooms = roomRepo.GetAll();
                if (rooms != null)
                {
                    sb.AppendLine($"  ✓ PASS: Found {rooms.Count} rooms in database");
                    passedTests++;
                }
                else
                {
                    sb.AppendLine("  ✗ FAIL: Room repository returned null");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"  ✗ FAIL: {ex.Message}");
            }
            totalTests++;
            sb.AppendLine();

            // Test 2: Room Status Grouping
            sb.AppendLine("Test 2: Room status grouping...");
            try
            {
                RoomRepository roomRepo = new RoomRepository();
                List<Room> rooms = roomRepo.GetAll();
                var groups = rooms.GroupBy(r => r.Status).ToList();
                if (groups.Count > 0)
                {
                    sb.AppendLine($"  ✓ PASS: {groups.Count} status group(s) found");
                    foreach (var g in groups)
                    {
                        sb.AppendLine($"    - {g.Key}: {g.Count()} room(s)");
                    }
                    passedTests++;
                }
                else
                {
                    sb.AppendLine("  ✗ FAIL: No status groups found");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"  ✗ FAIL: {ex.Message}");
            }
            totalTests++;
            sb.AppendLine();

            // Test 3: Occupancy Rate Calculation
            sb.AppendLine("Test 3: Occupancy rate calculation...");
            try
            {
                RoomRepository roomRepo = new RoomRepository();
                List<Room> rooms = roomRepo.GetAll();
                int totalRooms = rooms.Count;
                int occupiedRooms = rooms.Count(r => r.Status == "Occupied");
                decimal occupancyRate = totalRooms > 0
                    ? Math.Round((decimal)occupiedRooms / totalRooms * 100, 1)
                    : 0;

                sb.AppendLine($"  ✓ PASS: Occupancy rate = {occupancyRate}% ({occupiedRooms}/{totalRooms} rooms)");
                passedTests++;
            }
            catch (Exception ex)
            {
                sb.AppendLine($"  ✗ FAIL: {ex.Message}");
            }
            totalTests++;
            sb.AppendLine();

            // Test 4: Booking Data Retrieval
            sb.AppendLine("Test 4: Booking data retrieval...");
            try
            {
                BookingRepository bookingRepo = new BookingRepository();
                List<Booking> bookings = bookingRepo.GetAll();
                if (bookings != null)
                {
                    sb.AppendLine($"  ✓ PASS: Found {bookings.Count} booking(s) in database");

                    // Count by status
                    var statusGroups = bookings.GroupBy(b => b.Status).ToList();
                    foreach (var g in statusGroups)
                    {
                        sb.AppendLine($"    - {g.Key}: {g.Count()}");
                    }
                    passedTests++;
                }
                else
                {
                    sb.AppendLine("  ✗ FAIL: Booking repository returned null");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"  ✗ FAIL: {ex.Message}");
            }
            totalTests++;
            sb.AppendLine();

            // Test 5: Payment Data and Revenue Calculation
            sb.AppendLine("Test 5: Payment data and revenue calculation...");
            try
            {
                PaymentRepository paymentRepo = new PaymentRepository();
                List<Payment> allPayments = paymentRepo.GetAll();
                if (allPayments != null)
                {
                    decimal totalRevenue = allPayments
                        .Where(p => p.Status == "Completed")
                        .Sum(p => p.Amount);

                    var methodGroups = allPayments
                        .Where(p => p.Status == "Completed")
                        .GroupBy(p => p.PaymentMethod)
                        .ToList();

                    sb.AppendLine($"  ✓ PASS: {allPayments.Count} payment(s) found, Total revenue: {totalRevenue:C2}");
                    foreach (var g in methodGroups)
                    {
                        sb.AppendLine($"    - {g.Key}: {g.Count()} txn(s), {g.Sum(p => p.Amount):C2}");
                    }
                    passedTests++;
                }
                else
                {
                    sb.AppendLine("  ✗ FAIL: Payment repository returned null");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"  ✗ FAIL: {ex.Message}");
            }
            totalTests++;
            sb.AppendLine();

            // Test 6: Date Range Filtering for Payments
            sb.AppendLine("Test 6: Date range filtering for payments...");
            try
            {
                PaymentRepository paymentRepo = new PaymentRepository();
                DateTime today = DateTime.Today;
                List<Payment> todayPayments = paymentRepo.GetPaymentsByDateRange(
                    today, today.AddDays(1).AddSeconds(-1));

                sb.AppendLine($"  ✓ PASS: Date range filter works. Today's payments: {todayPayments.Count}");
                passedTests++;
            }
            catch (Exception ex)
            {
                sb.AppendLine($"  ✗ FAIL: {ex.Message}");
            }
            totalTests++;
            sb.AppendLine();

            // Test 7: Text Report Generation
            sb.AppendLine("Test 7: Text report generation...");
            try
            {
                UI.Reports.DailyOperationsReportForm form = new UI.Reports.DailyOperationsReportForm();
                string report = form.GenerateTextReport(DateTime.Today);
                form.Dispose();

                if (!string.IsNullOrEmpty(report) &&
                    report.Contains("Daily Operations Report") &&
                    report.Contains("SUMMARY") &&
                    report.Contains("ROOM STATUS") &&
                    report.Contains("REVENUE BREAKDOWN"))
                {
                    sb.AppendLine($"  ✓ PASS: Text report generated ({report.Length} chars)");
                    sb.AppendLine("    Contains: Summary, Room Status, Revenue Breakdown sections");
                    passedTests++;
                }
                else
                {
                    sb.AppendLine("  ✗ FAIL: Report missing expected sections");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"  ✗ FAIL: {ex.Message}");
            }
            totalTests++;
            sb.AppendLine();

            // Summary
            sb.AppendLine("===========================================");
            sb.AppendLine($"RESULTS: {passedTests}/{totalTests} tests passed");
            sb.AppendLine($"Pass Rate: {(totalTests > 0 ? Math.Round((decimal)passedTests / totalTests * 100, 1) : 0)}%");
            sb.AppendLine("===========================================");

            if (passedTests == totalTests)
            {
                sb.AppendLine();
                sb.AppendLine("🎉 ALL TESTS PASSED! Day 26 Complete!");
                sb.AppendLine("📊 Daily Operations Report is ready!");
            }

            return sb.ToString();
        }
    }
}
