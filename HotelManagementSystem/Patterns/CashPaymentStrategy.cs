using System;
using HotelManagementSystem.Models;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Concrete Strategy - Cash Payment Implementation
    /// Handles cash payment processing
    /// </summary>
    public class CashPaymentStrategy : IPaymentStrategy
    {
        private readonly PaymentRepository _paymentRepository;
        private readonly InvoiceRepository _invoiceRepository;

        public CashPaymentStrategy()
        {
            _paymentRepository = new PaymentRepository();
            _invoiceRepository = new InvoiceRepository();
        }

        /// <summary>
        /// Process a cash payment
        /// </summary>
        /// <param name="invoice">Invoice to process payment for</param>
        /// <param name="amount">Amount received in cash</param>
        /// <param name="userId">User processing the payment</param>
        /// <returns>Payment object if successful, null otherwise</returns>
        public Payment ProcessPayment(Invoice invoice, decimal amount, int userId)
        {
            try
            {
                // Validate payment amount
                if (!ValidatePayment(amount))
                {
                    return null;
                }

                // Create payment record
                Payment payment = new Payment
                {
                    InvoiceId = invoice.InvoiceId,
                    Amount = amount,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = "Cash",
                    TransactionId = Payment.GenerateTransactionId(),
                    Status = "Completed",
                    Notes = "Cash payment received",
                    ProcessedByUserId = userId,
                    CreatedDate = DateTime.Now
                };

                // Save payment to database
                int paymentId = _paymentRepository.Insert(payment);
                
                if (paymentId > 0)
                {
                    payment.PaymentId = paymentId;

                    // Update invoice status and paid amount
                    invoice.PaidAmount += amount;
                    invoice.BalanceAmount = invoice.TotalAmount - invoice.PaidAmount;

                    // Update invoice status based on balance
                    if (invoice.BalanceAmount <= 0)
                    {
                        invoice.Status = "Paid";
                    }
                    else if (invoice.PaidAmount > 0 && invoice.BalanceAmount > 0)
                    {
                        invoice.Status = "PartiallyPaid";
                    }

                    _invoiceRepository.Update(invoice);

                    return payment;
                }

                return null;
            }
            catch (Exception ex)
            {
                // Log error (in production, use proper logging)
                Console.WriteLine($"Error processing cash payment: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Validate cash payment amount
        /// </summary>
        /// <param name="amount">Amount to validate</param>
        /// <returns>True if valid, false otherwise</returns>
        public bool ValidatePayment(decimal amount)
        {
            // Cash payment must be positive and not exceed reasonable limits
            return amount > 0 && amount <= 100000; // Max $100,000 cash payment
        }

        /// <summary>
        /// Get the payment method name
        /// </summary>
        /// <returns>Payment method name</returns>
        public string GetPaymentMethodName()
        {
            return "Cash";
        }

        /// <summary>
        /// Calculate change to return to customer
        /// </summary>
        /// <param name="amountDue">Amount due</param>
        /// <param name="amountReceived">Amount received from customer</param>
        /// <returns>Change amount</returns>
        public static decimal CalculateChange(decimal amountDue, decimal amountReceived)
        {
            return amountReceived - amountDue;
        }
    }
}
