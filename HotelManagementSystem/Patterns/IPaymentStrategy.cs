using System;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Strategy Pattern - Payment Strategy Interface
    /// Defines the contract for different payment methods
    /// </summary>
    public interface IPaymentStrategy
    {
        /// <summary>
        /// Process a payment using the specific payment method
        /// </summary>
        /// <param name="invoice">Invoice to process payment for</param>
        /// <param name="amount">Amount to pay</param>
        /// <param name="userId">User processing the payment</param>
        /// <returns>Payment object if successful, null otherwise</returns>
        Payment ProcessPayment(Invoice invoice, decimal amount, int userId);

        /// <summary>
        /// Validate payment details before processing
        /// </summary>
        /// <param name="amount">Amount to validate</param>
        /// <returns>True if valid, false otherwise</returns>
        bool ValidatePayment(decimal amount);

        /// <summary>
        /// Get the payment method name
        /// </summary>
        /// <returns>Name of the payment method</returns>
        string GetPaymentMethodName();
    }
}
