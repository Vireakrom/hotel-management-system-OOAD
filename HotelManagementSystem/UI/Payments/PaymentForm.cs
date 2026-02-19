using System;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Patterns;
using HotelManagementSystem.Helpers;

namespace HotelManagementSystem.UI.Payments
{
    public partial class PaymentForm : Form
    {
        private Invoice _invoice;
        private PaymentContext _paymentContext;
        private InvoiceRepository _invoiceRepository;
        private int _lastPaymentId = 0;

        public PaymentForm(Invoice invoice)
        {
            InitializeComponent();
            _invoice = invoice;
            _paymentContext = new PaymentContext();
            _invoiceRepository = new InvoiceRepository();
            LoadInvoiceDetails();
        }

        private void LoadInvoiceDetails()
        {
            // Display invoice information
            lblInvoiceNumber.Text = _invoice.InvoiceNumber;
            lblSubTotal.Text = _invoice.SubTotal.ToString("C");
            lblTax.Text = _invoice.TaxAmount.ToString("C");
            lblTotal.Text = _invoice.TotalAmount.ToString("C");
            lblPaidAmount.Text = _invoice.PaidAmount.ToString("C");
            lblBalanceAmount.Text = _invoice.BalanceAmount.ToString("C");
            lblStatus.Text = _invoice.Status;

            // Set default payment amount to balance
            txtAmount.Text = _invoice.BalanceAmount.ToString("F2");

            // Set default payment method to Cash
            rbCash.Checked = true;
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCash.Checked)
            {
                // Show cash-specific controls
                lblAmountReceived.Visible = true;
                txtAmountReceived.Visible = true;
                lblChange.Visible = true;
                txtChange.Visible = true;

                // Hide credit card controls
                grpCreditCard.Visible = false;

                // Set payment strategy
                _paymentContext.SetPaymentStrategy("Cash");
            }
        }

        private void rbCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCreditCard.Checked)
            {
                // Hide cash-specific controls
                lblAmountReceived.Visible = false;
                txtAmountReceived.Visible = false;
                lblChange.Visible = false;
                txtChange.Visible = false;

                // Show credit card controls
                grpCreditCard.Visible = true;

                // Set payment strategy
                _paymentContext.SetPaymentStrategy("CreditCard");
            }
        }

        private void txtAmountReceived_TextChanged(object sender, EventArgs e)
        {
            // Calculate change for cash payments
            if (rbCash.Checked)
            {
                if (decimal.TryParse(txtAmount.Text, out decimal amountDue) &&
                    decimal.TryParse(txtAmountReceived.Text, out decimal amountReceived))
                {
                    decimal change = CashPaymentStrategy.CalculateChange(amountDue, amountReceived);
                    txtChange.Text = change.ToString("F2");

                    // Validate sufficient amount
                    if (change < 0)
                    {
                        txtChange.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        txtChange.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            try
            {
                string errorMessage;

                // Validate payment amount - Enhanced Day 30
                if (!ValidationHelper.ValidateDecimal(txtAmount, "Payment amount", out decimal amount, out errorMessage))
                {
                    ValidationHelper.ShowValidationError(errorMessage);
                    return;
                }

                if (!ValidationHelper.ValidatePositive(amount, "Payment amount", out errorMessage))
                {
                    ValidationHelper.ShowValidationError(errorMessage);
                    return;
                }

                // Validate amount doesn't exceed balance
                if (amount > _invoice.BalanceAmount)
                {
                    ValidationHelper.ShowValidationError(
                        $"Payment amount (${amount:F2}) cannot exceed the balance amount (${_invoice.BalanceAmount:F2}).");
                    txtAmount.Focus();
                    return;
                }

                Payment payment = null;

                if (rbCash.Checked)
                {
                    // Process cash payment with enhanced validation
                    if (!ValidationHelper.ValidateDecimal(txtAmountReceived, "Amount received", out decimal amountReceived, out errorMessage))
                    {
                        ValidationHelper.ShowValidationError(errorMessage);
                        return;
                    }

                    if (!ValidationHelper.ValidatePositive(amountReceived, "Amount received", out errorMessage))
                    {
                        ValidationHelper.ShowValidationError(errorMessage);
                        return;
                    }

                    if (amountReceived < amount)
                    {
                        ValidationHelper.ShowValidationError(
                            $"Amount received (${amountReceived:F2}) is less than the payment amount (${amount:F2}).\n" +
                            $"Insufficient amount: ${amount - amountReceived:F2} short.");
                        txtAmountReceived.Focus();
                        return;
                    }

                    decimal change;
                    payment = _paymentContext.ProcessCashPayment(_invoice, amountReceived, 
                        SessionManager.CurrentUser.UserId, out change);

                    if (payment != null)
                    {
                        _lastPaymentId = payment.PaymentId;
                        DialogResult result = MessageBox.Show(
                            $"Payment processed successfully!\n\n" +
                            $"Amount Paid: ${amount:F2}\n" +
                            $"Amount Received: ${amountReceived:F2}\n" +
                            $"Change: ${change:F2}\n\n" +
                            $"Would you like to view the receipt?", 
                            "Payment Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            ShowReceipt(_lastPaymentId);
                        }
                    }
                }
                else if (rbCreditCard.Checked)
                {
                    // Validate credit card details - Enhanced Day 30
                    if (!ValidationHelper.ValidateRequired(txtCardNumber, "Card number", out errorMessage))
                    {
                        ValidationHelper.ShowValidationError(errorMessage);
                        return;
                    }

                    if (!ValidationHelper.ValidateRequired(txtCardHolderName, "Card holder name", out errorMessage))
                    {
                        ValidationHelper.ShowValidationError(errorMessage);
                        return;
                    }

                    if (!ValidationHelper.ValidateRequired(txtCVV, "CVV", out errorMessage))
                    {
                        ValidationHelper.ShowValidationError(errorMessage);
                        return;
                    }

                    // Validate card number format
                    if (!ValidationHelper.ValidateCreditCardNumber(txtCardNumber.Text, out errorMessage))
                    {
                        ValidationHelper.ShowValidationError(errorMessage);
                        txtCardNumber.Focus();
                        return;
                    }

                    // Validate CVV format
                    if (!ValidationHelper.ValidateCVV(txtCVV.Text, out errorMessage))
                    {
                        ValidationHelper.ShowValidationError(errorMessage);
                        txtCVV.Focus();
                        return;
                    }

                    // Validate card holder name
                    if (!ValidationHelper.ValidateMinLength(txtCardHolderName, "Card holder name", 3, out errorMessage))
                    {
                        ValidationHelper.ShowValidationError(errorMessage);
                        return;
                    }

                    // Simulate gateway authorization
                    if (!CreditCardPaymentStrategy.SimulateGatewayAuthorization(
                        txtCardNumber.Text, txtCVV.Text, txtExpiryDate.Text, amount))
                    {
                        ValidationHelper.ShowValidationError(
                            "Payment authorization failed.\n\n" +
                            "Please check your card details and try again.\n" +
                            "If the problem persists, please contact your card issuer.",
                            "Payment Authorization Failed");
                        return;
                    }

                    // Process credit card payment
                    payment = _paymentContext.ProcessCreditCardPayment(_invoice, amount, 
                        SessionManager.CurrentUser.UserId);

                    if (payment != null)
                    {
                        // Update payment with card details (store only last 4 digits)
                        payment.CardNumber = CreditCardPaymentStrategy.GetLast4Digits(txtCardNumber.Text);
                        payment.CardHolderName = txtCardHolderName.Text;

                        PaymentRepository paymentRepo = new PaymentRepository();
                        paymentRepo.Update(payment);

                        _lastPaymentId = payment.PaymentId;
                        DialogResult result = MessageBox.Show(
                            $"Payment processed successfully!\n\n" +
                            $"Amount Paid: ${amount:F2}\n" +
                            $"Card: **** **** **** {payment.CardNumber}\n\n" +
                            $"Would you like to view the receipt?", 
                            "Payment Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            ShowReceipt(_lastPaymentId);
                        }
                    }
                }

                if (payment != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ValidationHelper.ShowValidationError(
                        "Payment processing failed.\n\nPlease verify all information and try again.",
                        "Payment Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment:\n\n{ex.Message}\n\nPlease try again or contact support.", 
                    "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowReceipt(int paymentId)
        {
            try
            {
                ReceiptForm receiptForm = new ReceiptForm(paymentId);
                receiptForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying receipt: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
