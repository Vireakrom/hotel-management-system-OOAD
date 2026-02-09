using System;

namespace HotelManagementSystem.Models
{
    /// <summary>
    /// Payment model class representing a payment transaction for an invoice
    /// </summary>
    public class Payment
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // Cash, CreditCard, DebitCard, OnlineTransfer, Check
        public string TransactionId { get; set; }
        public string CardNumber { get; set; } // Last 4 digits only
        public string CardHolderName { get; set; }
        public string PaymentGateway { get; set; }
        public string Status { get; set; } // Pending, Completed, Failed, Refunded
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ProcessedByUserId { get; set; }

        /// <summary>
        /// Constructor - initializes default values
        /// </summary>
        public Payment()
        {
            PaymentDate = DateTime.Now;
            Status = "Completed";
            CreatedDate = DateTime.Now;
            PaymentMethod = "Cash"; // Default to Cash
        }

        /// <summary>
        /// Check if payment is completed
        /// </summary>
        public bool IsCompleted()
        {
            return Status == "Completed";
        }

        /// <summary>
        /// Check if payment is pending
        /// </summary>
        public bool IsPending()
        {
            return Status == "Pending";
        }

        /// <summary>
        /// Check if payment failed
        /// </summary>
        public bool IsFailed()
        {
            return Status == "Failed";
        }

        /// <summary>
        /// Check if payment was refunded
        /// </summary>
        public bool IsRefunded()
        {
            return Status == "Refunded";
        }

        /// <summary>
        /// Generate a transaction ID for cash payments
        /// </summary>
        /// <returns>Generated transaction ID</returns>
        public static string GenerateTransactionId()
        {
            // Format: TXN-YYYYMMDDHHMMSS-XXXX (e.g., TXN-20250219143025-1234)
            Random random = new Random();
            return $"TXN-{DateTime.Now:yyyyMMddHHmmss}-{random.Next(1000, 9999)}";
        }
    }
}
