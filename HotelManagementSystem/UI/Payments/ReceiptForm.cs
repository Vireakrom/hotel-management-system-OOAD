using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.UI.Payments
{
    public partial class ReceiptForm : Form
    {
        private Payment _payment;
        private Invoice _invoice;
        private Booking _booking;
        private Guest _guest;
        private Room _room;

        public ReceiptForm(int paymentId)
        {
            InitializeComponent();
            LoadPaymentDetails(paymentId);
            GenerateReceipt();
        }

        private void LoadPaymentDetails(int paymentId)
        {
            PaymentRepository paymentRepo = new PaymentRepository();
            _payment = paymentRepo.GetById(paymentId);

            if (_payment == null)
            {
                MessageBox.Show("Payment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            InvoiceRepository invoiceRepo = new InvoiceRepository();
            _invoice = invoiceRepo.GetById(_payment.InvoiceId);

            if (_invoice != null)
            {
                BookingRepository bookingRepo = new BookingRepository();
                _booking = bookingRepo.GetById(_invoice.BookingId);

                if (_booking != null)
                {
                    GuestRepository guestRepo = new GuestRepository();
                    _guest = guestRepo.GetById(_booking.GuestId);

                    RoomRepository roomRepo = new RoomRepository();
                    _room = roomRepo.GetById(_booking.RoomId);
                }
            }
        }

        private void GenerateReceipt()
        {
            StringBuilder receipt = new StringBuilder();

            // Header
            receipt.AppendLine("═══════════════════════════════════════════════════");
            receipt.AppendLine("           HOTEL MANAGEMENT SYSTEM");
            receipt.AppendLine("                 PAYMENT RECEIPT");
            receipt.AppendLine("═══════════════════════════════════════════════════");
            receipt.AppendLine();

            // Receipt Information
            receipt.AppendLine($"Receipt Number:     {_payment.PaymentId.ToString("D8")}");
            receipt.AppendLine($"Payment Date:       {_payment.PaymentDate:dd/MM/yyyy HH:mm}");
            receipt.AppendLine($"Payment Method:     {_payment.PaymentMethod}");
            receipt.AppendLine();

            // Invoice Information
            receipt.AppendLine("───────────────────────────────────────────────────");
            receipt.AppendLine("INVOICE DETAILS");
            receipt.AppendLine("───────────────────────────────────────────────────");
            receipt.AppendLine($"Invoice Number:     {_invoice?.InvoiceNumber}");
            receipt.AppendLine($"Invoice Date:       {_invoice?.IssueDate:dd/MM/yyyy}");
            receipt.AppendLine();

            // Guest Information
            if (_guest != null)
            {
                receipt.AppendLine("───────────────────────────────────────────────────");
                receipt.AppendLine("GUEST INFORMATION");
                receipt.AppendLine("───────────────────────────────────────────────────");
                receipt.AppendLine($"Name:               {_guest.FirstName} {_guest.LastName}");
                receipt.AppendLine($"Email:              {_guest.Email}");
                receipt.AppendLine($"Phone:              {_guest.Phone}");
                receipt.AppendLine();
            }

            // Booking Information
            if (_booking != null && _room != null)
            {
                receipt.AppendLine("───────────────────────────────────────────────────");
                receipt.AppendLine("BOOKING DETAILS");
                receipt.AppendLine("───────────────────────────────────────────────────");
                receipt.AppendLine($"Booking ID:         #{_booking.BookingId}");
                receipt.AppendLine($"Room Number:        {_room.RoomNumber}");
                receipt.AppendLine($"Room Type:          {_room.RoomType}");
                receipt.AppendLine($"Check-In:           {_booking.CheckInDate:dd/MM/yyyy}");
                receipt.AppendLine($"Check-Out:          {_booking.CheckOutDate:dd/MM/yyyy}");
                int nights = (_booking.CheckOutDate - _booking.CheckInDate).Days;
                receipt.AppendLine($"Number of Nights:   {nights}");
                receipt.AppendLine();
            }

            // Financial Details
            if (_invoice != null)
            {
                receipt.AppendLine("───────────────────────────────────────────────────");
                receipt.AppendLine("FINANCIAL BREAKDOWN");
                receipt.AppendLine("───────────────────────────────────────────────────");
                receipt.AppendLine($"Subtotal:           {_invoice.SubTotal,15:C}");
                receipt.AppendLine($"Tax (10%):          {_invoice.TaxAmount,15:C}");
                if (_invoice.Discount > 0)
                {
                    receipt.AppendLine($"Discount:           {_invoice.Discount,15:C}");
                }
                receipt.AppendLine($"                    ────────────────");
                receipt.AppendLine($"Total Amount:       {_invoice.TotalAmount,15:C}");
                receipt.AppendLine();
            }

            // Payment Details
            receipt.AppendLine("───────────────────────────────────────────────────");
            receipt.AppendLine("PAYMENT INFORMATION");
            receipt.AppendLine("───────────────────────────────────────────────────");
            receipt.AppendLine($"Amount Paid:        {_payment.Amount,15:C}");

            if (_payment.PaymentMethod == "CreditCard" && !string.IsNullOrEmpty(_payment.CardNumber))
            {
                receipt.AppendLine($"Card Number:        **** **** **** {_payment.CardNumber}");
                if (!string.IsNullOrEmpty(_payment.CardHolderName))
                {
                    receipt.AppendLine($"Card Holder:        {_payment.CardHolderName}");
                }
            }

            if (!string.IsNullOrEmpty(_payment.TransactionId))
            {
                receipt.AppendLine($"Transaction ID:     {_payment.TransactionId}");
            }

            receipt.AppendLine();

            // Invoice Balance
            if (_invoice != null)
            {
                receipt.AppendLine($"Previous Balance:   {(_invoice.BalanceAmount + _payment.Amount),15:C}");
                receipt.AppendLine($"Amount Paid:        {_payment.Amount,15:C}");
                receipt.AppendLine($"                    ────────────────");
                receipt.AppendLine($"Remaining Balance:  {_invoice.BalanceAmount,15:C}");
                receipt.AppendLine();
                receipt.AppendLine($"Invoice Status:     {_invoice.Status}");
                receipt.AppendLine();
            }

            // Footer
            receipt.AppendLine("═══════════════════════════════════════════════════");
            receipt.AppendLine("         THANK YOU FOR YOUR PAYMENT!");
            receipt.AppendLine("       For inquiries: info@hotelms.com");
            receipt.AppendLine("              Phone: +1-234-567-8900");
            receipt.AppendLine("═══════════════════════════════════════════════════");
            receipt.AppendLine();
            receipt.AppendLine($"Processed by: {_payment.ProcessedByUserId} on {_payment.PaymentDate:dd/MM/yyyy HH:mm}");

            // Display in RichTextBox
            txtReceipt.Text = receipt.ToString();
            txtReceipt.Font = new Font("Courier New", 9);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("Receipt sent to printer successfully!", "Print", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Print Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtReceipt.Text, 
                new Font("Courier New", 10), 
                Brushes.Black, 
                new PointF(100, 100));
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            // Placeholder for PDF export functionality
            // In a real application, you would use a library like iTextSharp or PdfSharp
            MessageBox.Show("PDF export functionality will be implemented in a future version.\n\n" +
                "For now, you can use the Print button and select 'Print to PDF' if available on your system.",
                "PDF Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtReceipt.Text);
                MessageBox.Show("Receipt copied to clipboard!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying to clipboard: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
