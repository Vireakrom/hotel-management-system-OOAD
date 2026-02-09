using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.DAL
{
    /// <summary>
    /// Repository for Payment data access operations
    /// Implements CRUD operations for payments
    /// </summary>
    public class PaymentRepository : IRepository<Payment>
    {
        /// <summary>
        /// Create a new payment
        /// </summary>
        /// <param name="entity">Payment entity to insert</param>
        /// <returns>Payment ID if successful, 0 otherwise</returns>
        public int Insert(Payment entity)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"INSERT INTO Payments 
                    (InvoiceId, Amount, PaymentDate, PaymentMethod, TransactionId, CardNumber, 
                     CardHolderName, PaymentGateway, Status, Notes, CreatedDate, ProcessedByUserId)
                    VALUES 
                    (@InvoiceId, @Amount, @PaymentDate, @PaymentMethod, @TransactionId, @CardNumber, 
                     @CardHolderName, @PaymentGateway, @Status, @Notes, GETDATE(), @ProcessedByUserId);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@InvoiceId", entity.InvoiceId);
                cmd.Parameters.AddWithValue("@Amount", entity.Amount);
                cmd.Parameters.AddWithValue("@PaymentDate", entity.PaymentDate);
                cmd.Parameters.AddWithValue("@PaymentMethod", entity.PaymentMethod);
                cmd.Parameters.AddWithValue("@TransactionId", (object)entity.TransactionId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CardNumber", (object)entity.CardNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CardHolderName", (object)entity.CardHolderName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PaymentGateway", (object)entity.PaymentGateway ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@Notes", (object)entity.Notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ProcessedByUserId", (object)entity.ProcessedByUserId ?? DBNull.Value);

                conn.Open();
                entity.PaymentId = (int)cmd.ExecuteScalar();
                return entity.PaymentId;
            }
        }

        /// <summary>
        /// Get payment by ID
        /// </summary>
        /// <param name="id">Payment ID</param>
        /// <returns>Payment entity or null</returns>
        public Payment GetById(int id)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Payments WHERE PaymentId = @PaymentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PaymentId", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapReaderToPayment(reader);
                }

                return null;
            }
        }

        /// <summary>
        /// Get all payments
        /// </summary>
        /// <returns>List of all payments</returns>
        public List<Payment> GetAll()
        {
            List<Payment> payments = new List<Payment>();

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Payments ORDER BY PaymentDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    payments.Add(MapReaderToPayment(reader));
                }
            }

            return payments;
        }

        /// <summary>
        /// Update an existing payment
        /// </summary>
        /// <param name="entity">Payment entity to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool Update(Payment entity)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"UPDATE Payments SET 
                    Amount = @Amount, 
                    PaymentMethod = @PaymentMethod, 
                    Status = @Status, 
                    Notes = @Notes
                    WHERE PaymentId = @PaymentId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PaymentId", entity.PaymentId);
                cmd.Parameters.AddWithValue("@Amount", entity.Amount);
                cmd.Parameters.AddWithValue("@PaymentMethod", entity.PaymentMethod);
                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@Notes", (object)entity.Notes ?? DBNull.Value);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Delete a payment (not typically used - payments are usually kept for audit)
        /// </summary>
        /// <param name="id">Payment ID to delete</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool Delete(int id)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"UPDATE Payments SET Status = 'Refunded' WHERE PaymentId = @PaymentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PaymentId", id);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Get payments by invoice ID
        /// </summary>
        /// <param name="invoiceId">Invoice ID</param>
        /// <returns>List of payments for the invoice</returns>
        public List<Payment> GetPaymentsByInvoiceId(int invoiceId)
        {
            List<Payment> payments = new List<Payment>();

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Payments 
                                 WHERE InvoiceId = @InvoiceId 
                                 ORDER BY PaymentDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    payments.Add(MapReaderToPayment(reader));
                }
            }

            return payments;
        }

        /// <summary>
        /// Get payments by payment method
        /// </summary>
        /// <param name="paymentMethod">Payment method (Cash, CreditCard, etc.)</param>
        /// <returns>List of payments with specified method</returns>
        public List<Payment> GetPaymentsByMethod(string paymentMethod)
        {
            List<Payment> payments = new List<Payment>();

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Payments 
                                 WHERE PaymentMethod = @PaymentMethod 
                                 ORDER BY PaymentDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    payments.Add(MapReaderToPayment(reader));
                }
            }

            return payments;
        }

        /// <summary>
        /// Get payments by date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>List of payments in date range</returns>
        public List<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Payment> payments = new List<Payment>();

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Payments 
                                 WHERE PaymentDate >= @StartDate AND PaymentDate <= @EndDate 
                                 ORDER BY PaymentDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    payments.Add(MapReaderToPayment(reader));
                }
            }

            return payments;
        }

        /// <summary>
        /// Get total payments amount for a specific invoice
        /// </summary>
        /// <param name="invoiceId">Invoice ID</param>
        /// <returns>Total amount paid</returns>
        public decimal GetTotalPaidAmountByInvoiceId(int invoiceId)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT ISNULL(SUM(Amount), 0) FROM Payments 
                                 WHERE InvoiceId = @InvoiceId AND Status = 'Completed'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0m;
            }
        }

        /// <summary>
        /// Map SqlDataReader to Payment entity
        /// </summary>
        private Payment MapReaderToPayment(SqlDataReader reader)
        {
            return new Payment
            {
                PaymentId = reader.GetInt32(reader.GetOrdinal("PaymentId")),
                InvoiceId = reader.GetInt32(reader.GetOrdinal("InvoiceId")),
                Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                PaymentDate = reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
                PaymentMethod = reader.GetString(reader.GetOrdinal("PaymentMethod")),
                TransactionId = reader.IsDBNull(reader.GetOrdinal("TransactionId")) ? null : reader.GetString(reader.GetOrdinal("TransactionId")),
                CardNumber = reader.IsDBNull(reader.GetOrdinal("CardNumber")) ? null : reader.GetString(reader.GetOrdinal("CardNumber")),
                CardHolderName = reader.IsDBNull(reader.GetOrdinal("CardHolderName")) ? null : reader.GetString(reader.GetOrdinal("CardHolderName")),
                PaymentGateway = reader.IsDBNull(reader.GetOrdinal("PaymentGateway")) ? null : reader.GetString(reader.GetOrdinal("PaymentGateway")),
                Status = reader.GetString(reader.GetOrdinal("Status")),
                Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")),
                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                ProcessedByUserId = reader.IsDBNull(reader.GetOrdinal("ProcessedByUserId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ProcessedByUserId"))
            };
        }
    }
}
