using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAL
{
    public class ReportRepository
    {
        public DailyOperationsReportData GetDailyOperationsReportData(DateTime reportDate, int maxRecentBookings = 20)
        {
            DateTime startDate = reportDate.Date;
            DateTime endDate = startDate.AddDays(1);
            DailyOperationsReportData reportData = new DailyOperationsReportData();

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();

                LoadStatistics(conn, reportData, startDate, endDate);
                LoadRoomStatusBreakdown(conn, reportData);
                LoadRevenueBreakdown(conn, reportData, startDate, endDate);
                LoadRecentBookings(conn, reportData, startDate, endDate, maxRecentBookings);
            }

            return reportData;
        }

        private void LoadStatistics(SqlConnection conn, DailyOperationsReportData reportData, DateTime startDate, DateTime endDate)
        {
            const string query = @"
                SELECT
                    (SELECT COUNT(*) FROM Bookings WHERE CheckInDate >= @StartDate AND CheckInDate < @EndDate AND Status IN ('CheckedIn', 'CheckedOut')) AS ActualCheckIns,
                    (SELECT COUNT(*) FROM Bookings WHERE CheckInDate >= @StartDate AND CheckInDate < @EndDate AND Status = 'Confirmed') AS ConfirmedCheckIns,
                    (SELECT COUNT(*) FROM Bookings WHERE CheckOutDate >= @StartDate AND CheckOutDate < @EndDate AND Status = 'CheckedOut') AS ActualCheckOuts,
                    (SELECT COUNT(*) FROM Bookings WHERE CheckOutDate >= @StartDate AND CheckOutDate < @EndDate AND Status = 'CheckedIn') AS PendingCheckOuts,
                    (SELECT ISNULL(SUM(Amount), 0) FROM Payments WHERE PaymentDate >= @StartDate AND PaymentDate < @EndDate AND Status = 'Completed') AS TodayRevenue,
                    (SELECT COUNT(*) FROM Rooms WHERE Status = 'Occupied') AS OccupiedRooms,
                    (SELECT COUNT(*) FROM Rooms) AS TotalRooms";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return;
                    }

                    int actualCheckIns = reader.GetInt32(reader.GetOrdinal("ActualCheckIns"));
                    int confirmedCheckIns = reader.GetInt32(reader.GetOrdinal("ConfirmedCheckIns"));
                    int actualCheckOuts = reader.GetInt32(reader.GetOrdinal("ActualCheckOuts"));
                    int pendingCheckOuts = reader.GetInt32(reader.GetOrdinal("PendingCheckOuts"));

                    reportData.CheckIns = actualCheckIns > 0 ? actualCheckIns : confirmedCheckIns;
                    reportData.CheckOuts = actualCheckOuts > 0 ? actualCheckOuts : pendingCheckOuts;
                    reportData.TodayRevenue = reader.GetDecimal(reader.GetOrdinal("TodayRevenue"));
                    reportData.OccupiedRooms = reader.GetInt32(reader.GetOrdinal("OccupiedRooms"));
                    reportData.TotalRooms = reader.GetInt32(reader.GetOrdinal("TotalRooms"));
                    reportData.OccupancyRate = reportData.TotalRooms > 0
                        ? Math.Round((decimal)reportData.OccupiedRooms / reportData.TotalRooms * 100m, 1)
                        : 0m;
                }
            }
        }

        private void LoadRoomStatusBreakdown(SqlConnection conn, DailyOperationsReportData reportData)
        {
            const string query = @"
                SELECT
                    Status,
                    COUNT(*) AS RoomCount,
                    STRING_AGG(RoomNumber, ', ') WITHIN GROUP (ORDER BY RoomNumber) AS RoomNumbers
                FROM Rooms
                GROUP BY Status
                ORDER BY COUNT(*) DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int count = reader.GetInt32(reader.GetOrdinal("RoomCount"));
                    reportData.RoomStatuses.Add(new RoomStatusSummary
                    {
                        Status = reader.GetString(reader.GetOrdinal("Status")),
                        Count = count,
                        Percentage = reportData.TotalRooms > 0
                            ? Math.Round((decimal)count / reportData.TotalRooms * 100m, 1)
                            : 0m,
                        RoomNumbers = reader.IsDBNull(reader.GetOrdinal("RoomNumbers"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("RoomNumbers"))
                    });
                }
            }
        }

        private void LoadRevenueBreakdown(SqlConnection conn, DailyOperationsReportData reportData, DateTime startDate, DateTime endDate)
        {
            const string query = @"
                SELECT
                    PaymentMethod,
                    COUNT(*) AS TransactionCount,
                    SUM(Amount) AS Amount
                FROM Payments
                WHERE PaymentDate >= @StartDate AND PaymentDate < @EndDate
                    AND Status = 'Completed'
                GROUP BY PaymentMethod
                ORDER BY SUM(Amount) DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        decimal amount = reader.GetDecimal(reader.GetOrdinal("Amount"));
                        reportData.RevenueBreakdown.Add(new PaymentMethodSummary
                        {
                            PaymentMethod = reader.GetString(reader.GetOrdinal("PaymentMethod")),
                            TransactionCount = reader.GetInt32(reader.GetOrdinal("TransactionCount")),
                            Amount = amount,
                            Percentage = reportData.TodayRevenue > 0
                                ? Math.Round(amount / reportData.TodayRevenue * 100m, 1)
                                : 0m
                        });
                    }
                }
            }
        }

        private void LoadRecentBookings(SqlConnection conn, DailyOperationsReportData reportData, DateTime startDate, DateTime endDate, int maxRecentBookings)
        {
            List<RecentBookingSummary> relevantBookings = ExecuteRecentBookingsQuery(
                conn,
                @"
                    SELECT TOP (@MaxRecentBookings)
                        b.BookingId,
                        LTRIM(RTRIM(g.FirstName + ' ' + g.LastName)) AS GuestName,
                        r.RoomNumber,
                        r.RoomType,
                        b.CheckInDate,
                        b.CheckOutDate,
                        DATEDIFF(DAY, b.CheckInDate, b.CheckOutDate) AS Nights,
                        b.TotalAmount,
                        b.Status
                    FROM Bookings b
                    INNER JOIN Guests g ON g.GuestId = b.GuestId
                    INNER JOIN Rooms r ON r.RoomId = b.RoomId
                    WHERE
                        (b.CheckInDate >= @StartDate AND b.CheckInDate < @EndDate)
                        OR (b.CheckOutDate >= @StartDate AND b.CheckOutDate < @EndDate)
                        OR (b.CheckInDate < @EndDate AND b.CheckOutDate >= @StartDate AND b.Status <> 'Cancelled')
                    ORDER BY b.BookingDate DESC",
                startDate,
                endDate,
                maxRecentBookings);

            if (relevantBookings.Count > 0)
            {
                reportData.RecentBookings = relevantBookings;
                reportData.ShowingLatestBookings = false;
                return;
            }

            reportData.RecentBookings = ExecuteRecentBookingsQuery(
                conn,
                @"
                    SELECT TOP (@MaxRecentBookings)
                        b.BookingId,
                        LTRIM(RTRIM(g.FirstName + ' ' + g.LastName)) AS GuestName,
                        r.RoomNumber,
                        r.RoomType,
                        b.CheckInDate,
                        b.CheckOutDate,
                        DATEDIFF(DAY, b.CheckInDate, b.CheckOutDate) AS Nights,
                        b.TotalAmount,
                        b.Status
                    FROM Bookings b
                    INNER JOIN Guests g ON g.GuestId = b.GuestId
                    INNER JOIN Rooms r ON r.RoomId = b.RoomId
                    WHERE b.Status <> 'Cancelled'
                    ORDER BY b.BookingDate DESC",
                startDate,
                endDate,
                15);
            reportData.ShowingLatestBookings = true;
        }

        private List<RecentBookingSummary> ExecuteRecentBookingsQuery(SqlConnection conn, string query, DateTime startDate, DateTime endDate, int maxRecentBookings)
        {
            List<RecentBookingSummary> bookings = new List<RecentBookingSummary>();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaxRecentBookings", maxRecentBookings);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new RecentBookingSummary
                        {
                            BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                            GuestName = reader.GetString(reader.GetOrdinal("GuestName")),
                            RoomNumber = reader.GetString(reader.GetOrdinal("RoomNumber")),
                            RoomType = reader.GetString(reader.GetOrdinal("RoomType")),
                            CheckIn = reader.GetDateTime(reader.GetOrdinal("CheckInDate")),
                            CheckOut = reader.GetDateTime(reader.GetOrdinal("CheckOutDate")),
                            Nights = reader.GetInt32(reader.GetOrdinal("Nights")),
                            TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                            Status = reader.GetString(reader.GetOrdinal("Status"))
                        });
                    }
                }
            }

            return bookings;
        }
    }
}
