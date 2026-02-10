using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.UI.Invoices
{
    /// <summary>
    /// Dialog form for displaying detailed invoice information
    /// Shows invoice details, booking info, guest info, and payment history
    /// Day 23 - Invoice Details Enhancement
    /// </summary>
    public partial class InvoiceDetailsDialog : Form
    {
        private Invoice invoice;
        private Booking booking;
        private Guest guest;
        private List<Payment> payments;
        private RoomRepository roomRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceDetailsDialog(Invoice invoice, Booking booking, Guest guest, List<Payment> payments)
        {
            InitializeComponent();

            this.invoice = invoice;
            this.booking = booking;
            this.guest = guest;
            this.payments = payments;
            this.roomRepository = new RoomRepository();

            LoadInvoiceDetails();
            LoadPaymentHistory();
        }

        /// <summary>
        /// Load invoice and booking details
        /// </summary>
        private void LoadInvoiceDetails()
        {
            try
            {
                // Invoice information
                lblInvoiceNumber.Text = $"Invoice #: {invoice.InvoiceNumber}";
                lblIssueDate.Text = $"Issue Date: {invoice.IssueDate:MMM dd, yyyy}";
                lblDueDate.Text = $"Due Date: {invoice.DueDate:MMM dd, yyyy}";
                lblInvoiceStatus.Text = $"Status: {invoice.Status}";

                // Set status color
                switch (invoice.Status)
                {
                    case "Paid":
                        lblInvoiceStatus.ForeColor = Color.Green;
                        break;
                    case "Pending":
                        lblInvoiceStatus.ForeColor = Color.Orange;
                        break;
                    case "PartiallyPaid":
                        lblInvoiceStatus.ForeColor = Color.Blue;
                        break;
                    case "Cancelled":
                        lblInvoiceStatus.ForeColor = Color.Gray;
                        break;
                }

                // Guest information
                lblGuestName.Text = $"Guest: {guest.FirstName} {guest.LastName}";
                lblGuestEmail.Text = $"Email: {guest.Email}";
                lblGuestPhone.Text = $"Phone: {guest.Phone}";

                // Booking information
                Room room = roomRepository.GetById(booking.RoomId);
                lblBookingId.Text = $"Booking ID: {booking.BookingId}";
                lblRoomNumber.Text = $"Room: {room?.RoomNumber ?? "N/A"}";
                lblCheckIn.Text = $"Check-In: {booking.CheckInDate:MMM dd, yyyy}";
                lblCheckOut.Text = $"Check-Out: {booking.CheckOutDate:MMM dd, yyyy}";
                int nights = (booking.CheckOutDate - booking.CheckInDate).Days;
                lblNights.Text = $"Nights: {nights}";

                // Financial information
                lblSubTotal.Text = $"{invoice.SubTotal:C2}";
                lblTaxRate.Text = $"{invoice.TaxRate}%";
                lblTaxAmount.Text = $"{invoice.TaxAmount:C2}";
                lblDiscount.Text = $"{invoice.Discount:C2}";
                lblTotalAmount.Text = $"{invoice.TotalAmount:C2}";
                lblPaidAmount.Text = $"{invoice.PaidAmount:C2}";
                lblBalanceAmount.Text = $"{invoice.BalanceAmount:C2}";

                // Highlight balance if unpaid
                if (invoice.BalanceAmount > 0)
                {
                    lblBalanceAmount.ForeColor = Color.Red;
                    lblBalanceAmount.Font = new Font(lblBalanceAmount.Font, FontStyle.Bold);
                }
                else
                {
                    lblBalanceAmount.ForeColor = Color.Green;
                    lblBalanceAmount.Font = new Font(lblBalanceAmount.Font, FontStyle.Bold);
                }

                // Notes
                txtNotes.Text = invoice.Notes ?? "No notes available.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoice details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load payment history into DataGridView
        /// </summary>
        private void LoadPaymentHistory()
        {
            try
            {
                dgvPaymentHistory.AutoGenerateColumns = false;
                dgvPaymentHistory.AllowUserToAddRows = false;
                dgvPaymentHistory.AllowUserToDeleteRows = false;
                dgvPaymentHistory.ReadOnly = true;
                dgvPaymentHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Define columns
                dgvPaymentHistory.Columns.Clear();

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PaymentId",
                    HeaderText = "Payment ID",
                    DataPropertyName = "PaymentId",
                    Width = 80
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PaymentDate",
                    HeaderText = "Date",
                    DataPropertyName = "PaymentDate",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "MMM dd, yyyy HH:mm" }
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Amount",
                    HeaderText = "Amount",
                    DataPropertyName = "Amount",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PaymentMethod",
                    HeaderText = "Method",
                    DataPropertyName = "PaymentMethod",
                    Width = 100
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TransactionId",
                    HeaderText = "Transaction ID",
                    DataPropertyName = "TransactionId",
                    Width = 180
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataPropertyName = "Status",
                    Width = 100
                });

                // Bind data
                dgvPaymentHistory.DataSource = payments;

                // Update summary
                if (payments != null && payments.Count > 0)
                {
                    lblPaymentCount.Text = $"Total Payments: {payments.Count}";
                    lblPaymentTotal.Text = $"Total Amount Paid: {payments.Sum(p => p.Amount):C2}";
                }
                else
                {
                    lblPaymentCount.Text = "Total Payments: 0";
                    lblPaymentTotal.Text = "Total Amount Paid: $0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Close dialog
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Print invoice (placeholder for future implementation)
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print functionality will be implemented in a future update.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Export invoice (placeholder for future implementation)
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export functionality will be implemented in a future update.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
