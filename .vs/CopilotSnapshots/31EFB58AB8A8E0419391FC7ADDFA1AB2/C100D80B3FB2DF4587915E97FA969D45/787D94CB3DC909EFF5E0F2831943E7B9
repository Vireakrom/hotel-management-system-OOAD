using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DAL
{
    /// <summary>
    /// Repository for Booking entity - handles all booking operations
    /// Implements Repository Pattern
    /// </summary>
    public class BookingRepository : IRepository<Booking>
    {
        public int Insert(Booking booking)
        {
            string query = @"
                INSERT INTO Bookings (
                    GuestId, RoomId, CreatedByUserId, CheckInDate, CheckOutDate,
                    NumberOfGuests, RoomCharges, ServiceCharges, TotalAmount, 
                    SpecialRequests, Notes, Status
                )
                VALUES (
                    @GuestId, @RoomId, @CreatedByUserId, @CheckInDate, @CheckOutDate,
                    @NumberOfGuests, @RoomCharges, @ServiceCharges, @TotalAmount,
                    @SpecialRequests, @Notes, @Status
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@GuestId", booking.GuestId);
                cmd.Parameters.AddWithValue("@RoomId", booking.RoomId);
                cmd.Parameters.AddWithValue("@CreatedByUserId", booking.CreatedByUserId);
                cmd.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);
                cmd.Parameters.AddWithValue("@NumberOfGuests", booking.NumberOfGuests);
                cmd.Parameters.AddWithValue("@RoomCharges", booking.RoomCharges);
                cmd.Parameters.AddWithValue("@ServiceCharges", booking.ServiceCharges);
                cmd.Parameters.AddWithValue("@TotalAmount", booking.TotalAmount);
                cmd.Parameters.AddWithValue("@SpecialRequests", booking.SpecialRequests ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", booking.Notes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", booking.Status);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public Booking GetById(int id)
        {
            string query = "SELECT * FROM Bookings WHERE BookingId = @BookingId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookingId", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return MapReaderToBooking(reader);
                }
            }
            return null;
        }

        public List<Booking> GetAll()
        {
            List<Booking> bookings = new List<Booking>();
            string query = "SELECT * FROM Bookings ORDER BY BookingDate DESC";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        bookings.Add(MapReaderToBooking(reader));
                }
            }
            return bookings;
        }

        public bool Update(Booking booking)
        {
            string query = @"
                UPDATE Bookings 
                SET GuestId = @GuestId, RoomId = @RoomId,
                    CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate,
                    NumberOfGuests = @NumberOfGuests, RoomCharges = @RoomCharges,
                    ServiceCharges = @ServiceCharges, TotalAmount = @TotalAmount,
                    SpecialRequests = @SpecialRequests, Notes = @Notes,
                    Status = @Status, ModifiedDate = GETDATE()
                WHERE BookingId = @BookingId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookingId", booking.BookingId);
                cmd.Parameters.AddWithValue("@GuestId", booking.GuestId);
                cmd.Parameters.AddWithValue("@RoomId", booking.RoomId);
                cmd.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);
                cmd.Parameters.AddWithValue("@NumberOfGuests", booking.NumberOfGuests);
                cmd.Parameters.AddWithValue("@RoomCharges", booking.RoomCharges);
                cmd.Parameters.AddWithValue("@ServiceCharges", booking.ServiceCharges);
                cmd.Parameters.AddWithValue("@TotalAmount", booking.TotalAmount);
                cmd.Parameters.AddWithValue("@SpecialRequests", booking.SpecialRequests ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", booking.Notes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", booking.Status);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            return CancelBooking(id, "Cancelled by system");
        }

        // ========== CUSTOM BOOKING METHODS ==========

        /// <summary>
        /// Get bookings by guest ID
        /// </summary>
        public List<Booking> GetBookingsByGuest(int guestId)
        {
            List<Booking> bookings = new List<Booking>();
            string query = "SELECT * FROM Bookings WHERE GuestId = @GuestId ORDER BY BookingDate DESC";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@GuestId", guestId);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        bookings.Add(MapReaderToBooking(reader));
                }
            }
            return bookings;
        }

        /// <summary>
        /// Get bookings by status
        /// </summary>
        public List<Booking> GetBookingsByStatus(string status)
        {
            List<Booking> bookings = new List<Booking>();
            string query = "SELECT * FROM Bookings WHERE Status = @Status ORDER BY CheckInDate";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Status", status);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        bookings.Add(MapReaderToBooking(reader));
                }
            }
            return bookings;
        }

        /// <summary>
        /// Get active bookings (not cancelled or checked out)
        /// </summary>
        public List<Booking> GetActiveBookings()
        {
            List<Booking> bookings = new List<Booking>();
            string query = @"
                SELECT * FROM Bookings 
                WHERE Status IN ('Pending', 'Confirmed', 'CheckedIn') 
                ORDER BY CheckInDate";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        bookings.Add(MapReaderToBooking(reader));
                }
            }
            return bookings;
        }

        /// <summary>
        /// Get bookings for a specific room within a date range (for availability checking)
        /// Returns active bookings that overlap with the specified date range
        /// </summary>
        public List<Booking> GetBookingsByDateRange(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            List<Booking> bookings = new List<Booking>();
            string query = @"
                SELECT * FROM Bookings 
                WHERE RoomId = @RoomId
                AND Status IN ('Pending', 'Confirmed', 'CheckedIn')
                AND (
                    (CheckInDate <= @CheckOutDate AND CheckOutDate >= @CheckInDate)
                )
                ORDER BY CheckInDate";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RoomId", roomId);
                cmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        bookings.Add(MapReaderToBooking(reader));
                }
            }
            return bookings;
        }

        /// <summary>
        /// Update booking status
        /// </summary>
        public bool UpdateBookingStatus(int bookingId, string status)
        {
            string query = "UPDATE Bookings SET Status = @Status, ModifiedDate = GETDATE() WHERE BookingId = @BookingId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                cmd.Parameters.AddWithValue("@Status", status);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Cancel booking with reason
        /// </summary>
        public bool CancelBooking(int bookingId, string reason)
        {
            string query = @"
                UPDATE Bookings 
                SET Status = 'Cancelled',
                    CancelledDate = GETDATE(),
                    CancellationReason = @Reason,
                    ModifiedDate = GETDATE()
                WHERE BookingId = @BookingId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                cmd.Parameters.AddWithValue("@Reason", reason ?? (object)DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Check-in booking
        /// </summary>
        public bool CheckIn(int bookingId)
        {
            string query = @"
                UPDATE Bookings 
                SET Status = 'CheckedIn',
                    ActualCheckInDate = GETDATE(),
                    ModifiedDate = GETDATE()
                WHERE BookingId = @BookingId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Check-out booking
        /// </summary>
        public bool CheckOut(int bookingId)
        {
            string query = @"
                UPDATE Bookings 
                SET Status = 'CheckedOut',
                    ActualCheckOutDate = GETDATE(),
                    ModifiedDate = GETDATE()
                WHERE BookingId = @BookingId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private Booking MapReaderToBooking(SqlDataReader reader)
        {
            return new Booking
            {
                BookingId = (int)reader["BookingId"],
                GuestId = (int)reader["GuestId"],
                RoomId = (int)reader["RoomId"],
                CreatedByUserId = (int)reader["CreatedByUserId"],
                CheckInDate = (DateTime)reader["CheckInDate"],
                CheckOutDate = (DateTime)reader["CheckOutDate"],
                ActualCheckInDate = reader["ActualCheckInDate"] != DBNull.Value ? (DateTime?)reader["ActualCheckInDate"] : null,
                ActualCheckOutDate = reader["ActualCheckOutDate"] != DBNull.Value ? (DateTime?)reader["ActualCheckOutDate"] : null,
                Status = reader["Status"].ToString(),
                NumberOfGuests = (int)reader["NumberOfGuests"],
                RoomCharges = (decimal)reader["RoomCharges"],
                ServiceCharges = (decimal)reader["ServiceCharges"],
                TotalAmount = (decimal)reader["TotalAmount"],
                SpecialRequests = reader["SpecialRequests"] != DBNull.Value ? reader["SpecialRequests"].ToString() : null,
                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null,
                BookingDate = (DateTime)reader["BookingDate"],
                CancelledDate = reader["CancelledDate"] != DBNull.Value ? (DateTime?)reader["CancelledDate"] : null,
                CancellationReason = reader["CancellationReason"] != DBNull.Value ? reader["CancellationReason"].ToString() : null,
                CreatedDate = (DateTime)reader["CreatedDate"],
                ModifiedDate = (DateTime)reader["ModifiedDate"]
            };
        }
    }
}
