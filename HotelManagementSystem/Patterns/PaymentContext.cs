using System;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Context class for Payment Strategy Pattern
    /// Uses different payment strategies based on payment method
    /// </summary>
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        /// <summary>
        /// Constructor - initializes with default cash payment strategy
        /// </summary>
        public PaymentContext()
        {
            _paymentStrategy = new CashPaymentStrategy();
        }

        /// <summary>
        /// Constructor with specific payment strategy
        /// </summary>
        /// <param name="strategy">Payment strategy to use</param>
        public PaymentContext(IPaymentStrategy strategy)
        {
            _paymentStrategy = strategy;
        }

        /// <summary>
        /// Set the payment strategy at runtime
        /// </summary>
        /// <param name="strategy">Payment strategy to use</param>
        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            _paymentStrategy = strategy;
        }

        /// <summary>
        /// Set payment strategy based on payment method name
        /// </summary>
        /// <param name="paymentMethod">Payment method name (Cash, CreditCard)</param>
        public void SetPaymentStrategy(string paymentMethod)
        {
            switch (paymentMethod.ToLower())
            {
                case "cash":
                    _paymentStrategy = new CashPaymentStrategy();
                    break;
                case "creditcard":
                case "credit card":
                    _paymentStrategy = new CreditCardPaymentStrategy();
                    break;
                default:
                    _paymentStrategy = new CashPaymentStrategy();
                    break;
            }
        }

        /// <summary>
        /// Execute payment using the current strategy
        /// </summary>
        /// <param name="invoice">Invoice to process payment for</param>
        /// <param name="amount">Amount to pay</param>
        /// <param name="userId">User processing the payment</param>
        /// <returns>Payment object if successful, null otherwise</returns>
        public Payment ExecutePayment(Invoice invoice, decimal amount, int userId)
        {
            if (_paymentStrategy == null)
            {
                throw new InvalidOperationException("Payment strategy is not set.");
            }

            return _paymentStrategy.ProcessPayment(invoice, amount, userId);
        }

        /// <summary>
        /// Validate payment amount using current strategy
        /// </summary>
        /// <param name="amount">Amount to validate</param>
        /// <returns>True if valid, false otherwise</returns>
        public bool ValidatePayment(decimal amount)
        {
            if (_paymentStrategy == null)
            {
                throw new InvalidOperationException("Payment strategy is not set.");
            }

            return _paymentStrategy.ValidatePayment(amount);
        }

        /// <summary>
        /// Get the current payment method name
        /// </summary>
        /// <returns>Payment method name</returns>
        public string GetPaymentMethodName()
        {
            if (_paymentStrategy == null)
            {
                return "None";
            }

            return _paymentStrategy.GetPaymentMethodName();
        }

        /// <summary>
        /// Process a cash payment with change calculation
        /// </summary>
        /// <param name="invoice">Invoice to process</param>
        /// <param name="amountReceived">Amount received from customer</param>
        /// <param name="userId">User processing the payment</param>
        /// <param name="change">Out parameter for change amount</param>
        /// <returns>Payment object if successful, null otherwise</returns>
        public Payment ProcessCashPayment(Invoice invoice, decimal amountReceived, int userId, out decimal change)
        {
            SetPaymentStrategy("Cash");
            
            decimal amountDue = invoice.BalanceAmount;
            change = amountReceived - amountDue;

            // Process payment for the full balance
            return ExecutePayment(invoice, amountDue, userId);
        }

        /// <summary>
        /// Process a credit card payment
        /// </summary>
        /// <param name="invoice">Invoice to process</param>
        /// <param name="amount">Amount to charge</param>
        /// <param name="userId">User processing the payment</param>
        /// <returns>Payment object if successful, null otherwise</returns>
        public Payment ProcessCreditCardPayment(Invoice invoice, decimal amount, int userId)
        {
            SetPaymentStrategy("CreditCard");
            return ExecutePayment(invoice, amount, userId);
        }
    }
}
