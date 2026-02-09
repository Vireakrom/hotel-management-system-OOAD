using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.DAL
{
    /// <summary>
    /// Repository for Invoice data access operations
    /// Implements CRUD operations for invoices
    /// </summary>
    public class InvoiceRepository : IRepository<Invoice>
    {
        /// <summary>
        /// Create a new invoice
        /// </summary>
        /// <param name="entity">Invoice entity to insert</param>
        /// <returns>Invoice ID if successful, 0 otherwise</returns>
        public int Insert(Invoice entity)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"INSERT INTO Invoices 
                    (BookingId, InvoiceNumber, IssueDate, DueDate, SubTotal, TaxRate, TaxAmount, 
                     Discount, TotalAmount, PaidAmount, BalanceAmount, Status, PaymentTerms, Notes, 
                     CreatedDate, ModifiedDate)
                    VALUES 
                    (@BookingId, @InvoiceNumber, @IssueDate, @DueDate, @SubTotal, @TaxRate, @TaxAmount, 
                     @Discount, @TotalAmount, @PaidAmount, @BalanceAmount, @Status, @PaymentTerms, @Notes, 
                     GETDATE(), GETDATE());
                    SELECT CAST(SCOPE_IDENTITY() as int);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingId", entity.BookingId);
                cmd.Parameters.AddWithValue("@InvoiceNumber", entity.InvoiceNumber);
                cmd.Parameters.AddWithValue("@IssueDate", entity.IssueDate);
                cmd.Parameters.AddWithValue("@DueDate", entity.DueDate);
                cmd.Parameters.AddWithValue("@SubTotal", entity.SubTotal);
                cmd.Parameters.AddWithValue("@TaxRate", entity.TaxRate);
                cmd.Parameters.AddWithValue("@TaxAmount", entity.TaxAmount);
                cmd.Parameters.AddWithValue("@Discount", entity.Discount);
                cmd.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
                cmd.Parameters.AddWithValue("@PaidAmount", entity.PaidAmount);
                cmd.Parameters.AddWithValue("@BalanceAmount", entity.BalanceAmount);
                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@PaymentTerms", (object)entity.PaymentTerms ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", (object)entity.Notes ?? DBNull.Value);

                conn.Open();
                entity.InvoiceId = (int)cmd.ExecuteScalar();
                return entity.InvoiceId;
            }
        }

        /// <summary>
        /// Get invoice by ID
        /// </summary>
        /// <param name="id">Invoice ID</param>
        /// <returns>Invoice entity or null</returns>
        public Invoice GetById(int id)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Invoices WHERE InvoiceId = @InvoiceId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@InvoiceId", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapReaderToInvoice(reader);
                }

                return null;
            }
        }

        /// <summary>
        /// Get all invoices
        /// </summary>
        /// <returns>List of all invoices</returns>
        public List<Invoice> GetAll()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Invoices ORDER BY IssueDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    invoices.Add(MapReaderToInvoice(reader));
                }
            }

            return invoices;
        }

        /// <summary>
        /// Update an existing invoice
        /// </summary>
        /// <param name="entity">Invoice entity to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool Update(Invoice entity)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"UPDATE Invoices SET 
                    SubTotal = @SubTotal, 
                    TaxRate = @TaxRate, 
                    TaxAmount = @TaxAmount, 
                    Discount = @Discount, 
                    TotalAmount = @TotalAmount, 
                    PaidAmount = @PaidAmount, 
                    BalanceAmount = @BalanceAmount, 
                    Status = @Status, 
                    PaymentTerms = @PaymentTerms, 
                    Notes = @Notes, 
                    ModifiedDate = GETDATE()
                    WHERE InvoiceId = @InvoiceId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@InvoiceId", entity.InvoiceId);
                cmd.Parameters.AddWithValue("@SubTotal", entity.SubTotal);
                cmd.Parameters.AddWithValue("@TaxRate", entity.TaxRate);
                cmd.Parameters.AddWithValue("@TaxAmount", entity.TaxAmount);
                cmd.Parameters.AddWithValue("@Discount", entity.Discount);
                cmd.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
                cmd.Parameters.AddWithValue("@PaidAmount", entity.PaidAmount);
                cmd.Parameters.AddWithValue("@BalanceAmount", entity.BalanceAmount);
                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@PaymentTerms", (object)entity.PaymentTerms ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", (object)entity.Notes ?? DBNull.Value);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Delete an invoice (not typically used - invoices are usually kept for records)
        /// </summary>
        /// <param name="id">Invoice ID to delete</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool Delete(int id)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"UPDATE Invoices SET Status = 'Cancelled', ModifiedDate = GETDATE() 
                                 WHERE InvoiceId = @InvoiceId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@InvoiceId", id);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Get invoice by booking ID
        /// </summary>
        /// <param name="bookingId">Booking ID</param>
        /// <returns>Invoice entity or null</returns>
        public Invoice GetByBookingId(int bookingId)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Invoices WHERE BookingId = @BookingId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingId", bookingId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapReaderToInvoice(reader);
                }

                return null;
            }
        }

        /// <summary>
        /// Get invoices by status
        /// </summary>
        /// <param name="status">Invoice status (Pending, Paid, PartiallyPaid, Cancelled)</param>
        /// <returns>List of invoices with specified status</returns>
        public List<Invoice> GetInvoicesByStatus(string status)
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Invoices WHERE Status = @Status ORDER BY IssueDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    invoices.Add(MapReaderToInvoice(reader));
                }
            }

            return invoices;
        }

        /// <summary>
        /// Get unpaid invoices (Pending and PartiallyPaid)
        /// </summary>
        /// <returns>List of unpaid invoices</returns>
        public List<Invoice> GetUnpaidInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT * FROM Invoices 
                                 WHERE Status IN ('Pending', 'PartiallyPaid') 
                                 ORDER BY IssueDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    invoices.Add(MapReaderToInvoice(reader));
                }
            }

            return invoices;
        }

        /// <summary>
        /// Update invoice payment status and amounts
        /// </summary>
        /// <param name="invoiceId">Invoice ID</param>
        /// <param name="paidAmount">Amount paid</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdatePaymentStatus(int invoiceId, decimal paidAmount)
        {
            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                // First get the invoice to calculate balance
                Invoice invoice = GetById(invoiceId);
                if (invoice == null) return false;

                decimal newPaidAmount = invoice.PaidAmount + paidAmount;
                decimal newBalance = invoice.TotalAmount - newPaidAmount;
                string newStatus = newBalance <= 0 ? "Paid" : (newPaidAmount > 0 ? "PartiallyPaid" : "Pending");

                string query = @"UPDATE Invoices SET 
                    PaidAmount = @PaidAmount, 
                    BalanceAmount = @BalanceAmount, 
                    Status = @Status, 
                    ModifiedDate = GETDATE()
                    WHERE InvoiceId = @InvoiceId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);
                cmd.Parameters.AddWithValue("@PaidAmount", newPaidAmount);
                cmd.Parameters.AddWithValue("@BalanceAmount", newBalance);
                cmd.Parameters.AddWithValue("@Status", newStatus);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Map SqlDataReader to Invoice entity
        /// </summary>
        private Invoice MapReaderToInvoice(SqlDataReader reader)
        {
            return new Invoice
            {
                InvoiceId = reader.GetInt32(reader.GetOrdinal("InvoiceId")),
                BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                InvoiceNumber = reader.GetString(reader.GetOrdinal("InvoiceNumber")),
                IssueDate = reader.GetDateTime(reader.GetOrdinal("IssueDate")),
                DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
                SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                TaxRate = reader.GetDecimal(reader.GetOrdinal("TaxRate")),
                TaxAmount = reader.GetDecimal(reader.GetOrdinal("TaxAmount")),
                Discount = reader.GetDecimal(reader.GetOrdinal("Discount")),
                TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                PaidAmount = reader.GetDecimal(reader.GetOrdinal("PaidAmount")),
                BalanceAmount = reader.GetDecimal(reader.GetOrdinal("BalanceAmount")),
                Status = reader.GetString(reader.GetOrdinal("Status")),
                PaymentTerms = reader.IsDBNull(reader.GetOrdinal("PaymentTerms")) ? null : reader.GetString(reader.GetOrdinal("PaymentTerms")),
                Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")),
                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"))
            };
        }
    }
}
