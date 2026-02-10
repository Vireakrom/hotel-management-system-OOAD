using System;
using HotelManagementSystem.Models;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Concrete Strategy - Credit Card Payment Implementation
    /// Handles credit card payment processing
    /// </summary>
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        private readonly PaymentRepository _paymentRepository;
        private readonly InvoiceRepository _invoiceRepository;

        public CreditCardPaymentStrategy()
        {
            _paymentRepository = new PaymentRepository();
            _invoiceRepository = new InvoiceRepository();
        }

        /// <summary>
        /// Process a credit card payment
        /// </summary>
        /// <param name="invoice">Invoice to process payment for</param>
        /// <param name="amount">Amount to charge</param>
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

                // In a real system, this would integrate with a payment gateway
                // For now, we'll simulate the process

                // Create payment record
                Payment payment = new Payment
                {
                    InvoiceId = invoice.InvoiceId,
                    Amount = amount,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = "CreditCard",
                    TransactionId = GenerateCreditCardTransactionId(),
                    Status = "Completed",
                    Notes = "Credit card payment processed",
                    ProcessedByUserId = userId,
                    PaymentGateway = "SimulatedGateway",
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
                Console.WriteLine($"Error processing credit card payment: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Validate credit card payment
        /// </summary>
        /// <param name="amount">Amount to validate</param>
        /// <returns>True if valid, false otherwise</returns>
        public bool ValidatePayment(decimal amount)
        {
            // Credit card payment must be positive
            return amount > 0;
        }

        /// <summary>
        /// Get the payment method name
        /// </summary>
        /// <returns>Payment method name</returns>
        public string GetPaymentMethodName()
        {
            return "Credit Card";
        }

        /// <summary>
        /// Validate credit card number (basic Luhn algorithm)
        /// </summary>
        /// <param name="cardNumber">Card number to validate</param>
        /// <returns>True if valid, false otherwise</returns>
        public static bool ValidateCardNumber(string cardNumber)
        {
            // Remove spaces and dashes
            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

            // Check if all characters are digits
            if (!System.Text.RegularExpressions.Regex.IsMatch(cardNumber, @"^\d+$"))
                return false;

            // Check length (typically 13-19 digits)
            if (cardNumber.Length < 13 || cardNumber.Length > 19)
                return false;

            // Luhn algorithm
            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cardNumber[i].ToString());

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                alternate = !alternate;
            }

            return (sum % 10 == 0);
        }

        /// <summary>
        /// Validate CVV code
        /// </summary>
        /// <param name="cvv">CVV code</param>
        /// <returns>True if valid, false otherwise</returns>
        public static bool ValidateCVV(string cvv)
        {
            // CVV should be 3 or 4 digits
            return System.Text.RegularExpressions.Regex.IsMatch(cvv, @"^\d{3,4}$");
        }

        /// <summary>
        /// Mask credit card number (show only last 4 digits)
        /// </summary>
        /// <param name="cardNumber">Full card number</param>
        /// <returns>Masked card number (e.g., **** **** **** 1234)</returns>
        public static string MaskCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 4)
                return "****";

            string lastFour = cardNumber.Substring(cardNumber.Length - 4);
            return $"**** **** **** {lastFour}";
        }

        /// <summary>
        /// Get last 4 digits of card number
        /// </summary>
        /// <param name="cardNumber">Full card number</param>
        /// <returns>Last 4 digits</returns>
        public static string GetLast4Digits(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 4)
                return "";

            return cardNumber.Substring(cardNumber.Length - 4);
        }

        /// <summary>
        /// Generate a simulated credit card transaction ID
        /// </summary>
        /// <returns>Transaction ID</returns>
        private string GenerateCreditCardTransactionId()
        {
            // Format: CC-YYYYMMDDHHMMSS-XXXXXX (e.g., CC-20250219143025-123456)
            Random random = new Random();
            return $"CC-{DateTime.Now:yyyyMMddHHmmss}-{random.Next(100000, 999999)}";
        }

        /// <summary>
        /// Simulate payment gateway authorization
        /// In a real system, this would call an external API
        /// </summary>
        /// <param name="cardNumber">Credit card number</param>
        /// <param name="cvv">CVV code</param>
        /// <param name="expiryDate">Expiry date (MM/YY)</param>
        /// <param name="amount">Amount to authorize</param>
        /// <returns>True if authorized, false otherwise</returns>
        public static bool SimulateGatewayAuthorization(string cardNumber, string cvv, string expiryDate, decimal amount)
        {
            // Simulate payment gateway validation
            if (!ValidateCardNumber(cardNumber))
                return false;

            if (!ValidateCVV(cvv))
                return false;

            if (amount <= 0)
                return false;

            // Simulate: 95% success rate
            Random random = new Random();
            return random.Next(100) < 95;
        }
    }
}
