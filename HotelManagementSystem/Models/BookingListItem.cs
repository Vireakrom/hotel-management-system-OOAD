using System;

namespace HotelManagementSystem.Models
{
    public class BookingListItem
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public string GuestName { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }

        public int NumberOfNights
        {
            get { return (CheckOutDate.Date - CheckInDate.Date).Days; }
        }
    }
}
