using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public class DailyOperationsReportData
    {
        public int CheckIns { get; set; }
        public int CheckOuts { get; set; }
        public decimal TodayRevenue { get; set; }
        public decimal OccupancyRate { get; set; }
        public int OccupiedRooms { get; set; }
        public int TotalRooms { get; set; }
        public bool ShowingLatestBookings { get; set; }
        public List<RoomStatusSummary> RoomStatuses { get; set; } = new List<RoomStatusSummary>();
        public List<PaymentMethodSummary> RevenueBreakdown { get; set; } = new List<PaymentMethodSummary>();
        public List<RecentBookingSummary> RecentBookings { get; set; } = new List<RecentBookingSummary>();
    }

    public class RoomStatusSummary
    {
        public string Status { get; set; }
        public int Count { get; set; }
        public decimal Percentage { get; set; }
        public string RoomNumbers { get; set; }
    }

    public class PaymentMethodSummary
    {
        public string PaymentMethod { get; set; }
        public int TransactionCount { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }

    public class RecentBookingSummary
    {
        public int BookingId { get; set; }
        public string GuestName { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Nights { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
