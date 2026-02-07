using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Generate a random salt
        /// </summary>
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Hash password with salt using SHA256
        /// </summary>
        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string saltedPassword = password + salt;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Verify password against stored hash
        /// </summary>
        public static bool VerifyPassword(string password, string salt, string storedHash)
        {
            string computedHash = HashPassword(password, salt);
            return computedHash.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
