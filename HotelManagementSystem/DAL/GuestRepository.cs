using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DAL
{
    public class GuestRepository : IRepository<Guest>
    {
        /// <summary>
        /// Insert a new guest into the database
        /// </summary>
        public int Insert(Guest guest)
        {
            string query = @"
                INSERT INTO Guests (FirstName, LastName, Email, Phone, IDNumber, DateOfBirth, Address, Nationality)
                VALUES (@FirstName, @LastName, @Email, @Phone, @IDNumber, @DateOfBirth, @Address, @Nationality);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", guest.LastName);
                    cmd.Parameters.AddWithValue("@Email", guest.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", guest.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IDNumber", guest.IDNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", guest.DateOfBirth.HasValue ? (object)guest.DateOfBirth.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", guest.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nationality", guest.Nationality ?? (object)DBNull.Value);

                    conn.Open();
                    int newId = (int)cmd.ExecuteScalar();
                    return newId;
                }
            }
        }

        /// <summary>
        /// Get guest by ID
        /// </summary>
        public Guest GetById(int id)
        {
            string query = "SELECT * FROM Guests WHERE GuestId = @GuestId AND IsActive = 1";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GuestId", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToGuest(reader);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get all active guests
        /// </summary>
        public List<Guest> GetAll()
        {
            List<Guest> guests = new List<Guest>();
            string query = "SELECT * FROM Guests WHERE IsActive = 1 ORDER BY LastName, FirstName";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guests.Add(MapReaderToGuest(reader));
                        }
                    }
                }
            }
            return guests;
        }

        /// <summary>
        /// Update existing guest
        /// </summary>
        public bool Update(Guest guest)
        {
            string query = @"
                UPDATE Guests 
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    Email = @Email,
                    Phone = @Phone,
                    IDNumber = @IDNumber,
                    DateOfBirth = @DateOfBirth,
                    Address = @Address,
                    Nationality = @Nationality,
                    ModifiedDate = GETDATE()
                WHERE GuestId = @GuestId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GuestId", guest.GuestId);
                    cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", guest.LastName);
                    cmd.Parameters.AddWithValue("@Email", guest.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", guest.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IDNumber", guest.IDNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", guest.DateOfBirth.HasValue ? (object)guest.DateOfBirth.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", guest.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nationality", guest.Nationality ?? (object)DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Soft delete guest (set IsActive = 0)
        /// </summary>
        public bool Delete(int id)
        {
            string query = "UPDATE Guests SET IsActive = 0, ModifiedDate = GETDATE() WHERE GuestId = @GuestId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GuestId", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Search guests by name, email, or phone
        /// </summary>
        public List<Guest> Search(string searchTerm)
        {
            List<Guest> guests = new List<Guest>();
            string query = @"
                SELECT * FROM Guests 
                WHERE IsActive = 1 
                AND (
                    FirstName LIKE @Search OR 
                    LastName LIKE @Search OR 
                    Email LIKE @Search OR 
                    Phone LIKE @Search
                )
                ORDER BY LastName, FirstName";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guests.Add(MapReaderToGuest(reader));
                        }
                    }
                }
            }
            return guests;
        }

        /// <summary>
        /// Helper method to map SqlDataReader to Guest object
        /// </summary>
        private Guest MapReaderToGuest(SqlDataReader reader)
        {
            return new Guest
            {
                GuestId = (int)reader["GuestId"],
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null,
                IDNumber = reader["IDNumber"] != DBNull.Value ? reader["IDNumber"].ToString() : null,
                DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime?)reader["DateOfBirth"] : null,
                Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                Nationality = reader["Nationality"] != DBNull.Value ? reader["Nationality"].ToString() : null,
                CreatedDate = (DateTime)reader["CreatedDate"],
                ModifiedDate = reader["ModifiedDate"] != DBNull.Value ? (DateTime?)reader["ModifiedDate"] : null,
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}
