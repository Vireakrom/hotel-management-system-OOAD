using HotelManagementSystem.Helpers;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DAL
{
    public class UserRepository : IRepository<User>
    {
        public int Insert(User user)
        {
            string salt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.HashPassword(user.PasswordHash, salt);

            string query = @"
                INSERT INTO Users (Username, PasswordHash, Salt, FirstName, LastName, Email, Phone, Role, LastPasswordChange)
                VALUES (@Username, @PasswordHash, @Salt, @FirstName, @LastName, @Email, @Phone, @Role, GETDATE());
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@Salt", salt);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public User GetById(int id)
        {
            string query = "SELECT * FROM Users WHERE UserId = @UserId AND IsActive = 1";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return MapReaderToUser(reader);
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users WHERE IsActive = 1 ORDER BY FirstName, LastName";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        users.Add(MapReaderToUser(reader));
                }
            }
            return users;
        }

        public bool Update(User user)
        {
            string query = @"
                UPDATE Users 
                SET FirstName = @FirstName, LastName = @LastName, Email = @Email,
                    Phone = @Phone, Role = @Role, ModifiedDate = GETDATE()
                WHERE UserId = @UserId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            string query = "UPDATE Users SET IsActive = 0, ModifiedDate = GETDATE() WHERE UserId = @UserId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ========== AUTHENTICATION METHOD ==========
        public User Authenticate(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND IsActive = 1";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = MapReaderToUser(reader);

                        if (PasswordHelper.VerifyPassword(password, user.Salt, user.PasswordHash))
                        {
                            UpdateLastLogin(user.UserId);
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        private void UpdateLastLogin(int userId)
        {
            string query = "UPDATE Users SET LastLogin = GETDATE() WHERE UserId = @UserId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private User MapReaderToUser(SqlDataReader reader)
        {
            return new User
            {
                UserId = (int)reader["UserId"],
                Username = reader["Username"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                Salt = reader["Salt"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null,
                Role = reader["Role"].ToString(),
                IsActive = (bool)reader["IsActive"],
                LastLogin = reader["LastLogin"] != DBNull.Value ? (DateTime?)reader["LastLogin"] : null,
                CreatedDate = (DateTime)reader["CreatedDate"]
            };
        }
    }
}
