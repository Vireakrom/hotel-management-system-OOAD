using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.UI.Payments
{
    public partial class PaymentHistoryForm : Form
    {
        private int _invoiceId;
        private Invoice _invoice;
        private List<Payment> _payments;

        public PaymentHistoryForm(int invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;
            LoadInvoiceDetails();
            LoadPaymentHistory();
            UpdateStatistics();
        }

        private void LoadInvoiceDetails()
        {
            InvoiceRepository invoiceRepo = new InvoiceRepository();
            _invoice = invoiceRepo.GetById(_invoiceId);

            if (_invoice != null)
            {
                lblInvoiceNumber.Text = _invoice.InvoiceNumber;
                lblInvoiceDate.Text = _invoice.IssueDate.ToString("dd/MM/yyyy");
                lblTotalAmount.Text = _invoice.TotalAmount.ToString("C");
                lblStatus.Text = _invoice.Status;

                // Color code status
                switch (_invoice.Status)
                {
                    case "Paid":
                        lblStatus.ForeColor = Color.FromArgb(46, 204, 113);
                        break;
                    case "Pending":
                        lblStatus.ForeColor = Color.FromArgb(241, 196, 15);
                        break;
                    case "PartiallyPaid":
                        lblStatus.ForeColor = Color.FromArgb(52, 152, 219);
                        break;
                    case "Cancelled":
                        lblStatus.ForeColor = Color.Gray;
                        break;
                    default:
                        lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                        break;
                }

                // Load booking details
                BookingRepository bookingRepo = new BookingRepository();
                Booking booking = bookingRepo.GetById(_invoice.BookingId);

                if (booking != null)
                {
                    GuestRepository guestRepo = new GuestRepository();
                    Guest guest = guestRepo.GetById(booking.GuestId);

                    if (guest != null)
                    {
                        lblGuestName.Text = $"{guest.FirstName} {guest.LastName}";
                    }

                    RoomRepository roomRepo = new RoomRepository();
                    Room room = roomRepo.GetById(booking.RoomId);

                    if (room != null)
                    {
                        lblRoomInfo.Text = $"Room {room.RoomNumber} - {room.RoomType}";
                    }
                }
            }
        }

        private void LoadPaymentHistory()
        {
            PaymentRepository paymentRepo = new PaymentRepository();
            _payments = paymentRepo.GetPaymentsByInvoiceId(_invoiceId);

            dgvPayments.Rows.Clear();

            foreach (Payment payment in _payments)
            {
                int rowIndex = dgvPayments.Rows.Add();
                DataGridViewRow row = dgvPayments.Rows[rowIndex];

                row.Cells["colPaymentId"].Value = payment.PaymentId;
                row.Cells["colPaymentDate"].Value = payment.PaymentDate.ToString("dd/MM/yyyy HH:mm");
                row.Cells["colMethod"].Value = payment.PaymentMethod;
                row.Cells["colAmount"].Value = payment.Amount.ToString("C");
                row.Cells["colTransactionId"].Value = payment.TransactionId ?? "-";
                row.Cells["colStatus"].Value = payment.Status;

                // Add receipt button
                DataGridViewButtonCell receiptButton = row.Cells["colReceipt"] as DataGridViewButtonCell;
                if (receiptButton != null)
                {
                    receiptButton.Value = "View Receipt";
                }

                // Color code status
                if (payment.Status == "Completed")
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(46, 204, 113);
                }
                else if (payment.Status == "Refunded")
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(231, 76, 60);
                }
            }
        }

        private void UpdateStatistics()
        {
            if (_invoice != null)
            {
                lblTotalPaid.Text = _invoice.PaidAmount.ToString("C");
                lblBalance.Text = _invoice.BalanceAmount.ToString("C");
                lblPaymentCount.Text = _payments.Count.ToString();

                // Calculate payment progress
                if (_invoice.TotalAmount > 0)
                {
                    int progress = (int)((_invoice.PaidAmount / _invoice.TotalAmount) * 100);
                    progressBar.Value = Math.Min(progress, 100);
                    lblProgress.Text = $"{progress}%";
                }
            }
        }

        private void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Check if Receipt button was clicked
                if (dgvPayments.Columns[e.ColumnIndex].Name == "colReceipt")
                {
                    int paymentId = Convert.ToInt32(dgvPayments.Rows[e.RowIndex].Cells["colPaymentId"].Value);
                    ShowReceipt(paymentId);
                }
            }
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoiceDetails();
            LoadPaymentHistory();
            UpdateStatistics();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            // Placeholder for Excel export functionality
            MessageBox.Show("Excel export functionality will be implemented in a future version.\n\n" +
                "For now, you can copy the data from the grid manually.",
                "Excel Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Make Receipt button look clickable
            if (dgvPayments.Columns[e.ColumnIndex].Name == "colReceipt")
            {
                e.CellStyle.BackColor = Color.FromArgb(52, 152, 219);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new Font(dgvPayments.Font, FontStyle.Bold);
            }
        }
    }
}
