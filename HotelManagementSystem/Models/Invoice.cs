using System;

namespace HotelManagementSystem.Models
{
    /// <summary>
    /// Invoice model class representing an invoice for a booking
    /// </summary>
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int BookingId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string Status { get; set; } // Pending, Paid, PartiallyPaid, Cancelled
        public string PaymentTerms { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Constructor - initializes default values
        /// </summary>
        public Invoice()
        {
            IssueDate = DateTime.Now;
            DueDate = DateTime.Now;
            TaxRate = 10.00m; // Default 10% tax
            Status = "Pending";
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Calculate tax amount based on subtotal and tax rate
        /// </summary>
        public void CalculateTax()
        {
            TaxAmount = SubTotal * (TaxRate / 100);
        }

        /// <summary>
        /// Calculate total amount (subtotal + tax - discount)
        /// </summary>
        public void CalculateTotal()
        {
            TotalAmount = SubTotal + TaxAmount - Discount;
        }

        /// <summary>
        /// Calculate balance amount (total - paid)
        /// </summary>
        public void CalculateBalance()
        {
            BalanceAmount = TotalAmount - PaidAmount;
        }

        /// <summary>
        /// Generate a unique invoice number based on date and booking ID
        /// </summary>
        /// <param name="bookingId">The booking ID</param>
        /// <returns>Generated invoice number</returns>
        public static string GenerateInvoiceNumber(int bookingId)
        {
            // Format: INV-YYYYMMDD-XXXXX (e.g., INV-20250219-00001)
            return $"INV-{DateTime.Now:yyyyMMdd}-{bookingId:D5}";
        }

        /// <summary>
        /// Check if invoice is fully paid
        /// </summary>
        public bool IsFullyPaid()
        {
            return PaidAmount >= TotalAmount && Status == "Paid";
        }

        /// <summary>
        /// Check if invoice is partially paid
        /// </summary>
        public bool IsPartiallyPaid()
        {
            return PaidAmount > 0 && PaidAmount < TotalAmount && Status == "PartiallyPaid";
        }

        /// <summary>
        /// Check if invoice is pending
        /// </summary>
        public bool IsPending()
        {
            return PaidAmount == 0 && Status == "Pending";
        }
    }
}
