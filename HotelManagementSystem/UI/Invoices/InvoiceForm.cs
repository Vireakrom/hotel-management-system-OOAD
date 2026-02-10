using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.UI.Invoices
{
    /// <summary>
    /// Comprehensive invoice form for viewing and editing invoice details
    /// Day 24 - Invoice Management with edit capabilities
    /// </summary>
    public partial class InvoiceForm : Form
    {
        private Invoice invoice;
        private Booking booking;
        private Guest guest;
        private Room room;
        private InvoiceRepository invoiceRepository;
        private BookingRepository bookingRepository;
        private GuestRepository guestRepository;
        private RoomRepository roomRepository;
        private bool isEditMode = false;

        /// <summary>
        /// Constructor for viewing an existing invoice
        /// </summary>
        public InvoiceForm(int invoiceId)
        {
            InitializeComponent();
            InitializeRepositories();
            LoadInvoice(invoiceId);
            SetupFormControls();
        }

        /// <summary>
        /// Initialize repositories
        /// </summary>
        private void InitializeRepositories()
        {
            invoiceRepository = new InvoiceRepository();
            bookingRepository = new BookingRepository();
            guestRepository = new GuestRepository();
            roomRepository = new RoomRepository();
        }

        /// <summary>
        /// Load invoice data
        /// </summary>
        private void LoadInvoice(int invoiceId)
        {
            try
            {
                // Load invoice
                invoice = invoiceRepository.GetById(invoiceId);
                if (invoice == null)
                {
                    MessageBox.Show("Invoice not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Load related data
                booking = bookingRepository.GetById(invoice.BookingId);
                if (booking != null)
                {
                    guest = guestRepository.GetById(booking.GuestId);
                    room = roomRepository.GetById(booking.RoomId);
                }

                // Display invoice details
                DisplayInvoiceDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoice: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Display invoice details in the form
        /// </summary>
        private void DisplayInvoiceDetails()
        {
            // Invoice information
            lblInvoiceNumber.Text = invoice.InvoiceNumber;
            dtpIssueDate.Value = invoice.IssueDate;
            dtpDueDate.Value = invoice.DueDate;
            lblStatus.Text = invoice.Status;
            SetStatusColor(invoice.Status);

            // Guest information
            if (guest != null)
            {
                txtGuestName.Text = guest.FullName;
                txtGuestEmail.Text = guest.Email;
                txtGuestPhone.Text = guest.Phone;
            }

            // Booking information
            if (booking != null)
            {
                txtBookingId.Text = booking.BookingId.ToString();
                dtpCheckIn.Value = booking.CheckInDate;
                dtpCheckOut.Value = booking.CheckOutDate;
                
                // Calculate number of nights
                int nights = (booking.CheckOutDate - booking.CheckInDate).Days;
                txtNights.Text = nights.ToString();

                if (room != null)
                {
                    txtRoomNumber.Text = room.RoomNumber;
                    txtRoomType.Text = room.RoomType;
                    txtRoomPrice.Text = room.GetPrice().ToString("C");
                }
            }

            // Financial details
            txtSubTotal.Text = invoice.SubTotal.ToString("F2");
            txtTaxRate.Text = invoice.TaxRate.ToString("F2");
            txtTaxAmount.Text = invoice.TaxAmount.ToString("F2");
            txtDiscount.Text = invoice.Discount.ToString("F2");
            txtTotalAmount.Text = invoice.TotalAmount.ToString("F2");
            txtPaidAmount.Text = invoice.PaidAmount.ToString("F2");
            txtBalanceAmount.Text = invoice.BalanceAmount.ToString("F2");

            // Payment terms and notes
            txtPaymentTerms.Text = invoice.PaymentTerms;
            txtNotes.Text = invoice.Notes;

            // Set form title
            this.Text = $"Invoice Details - {invoice.InvoiceNumber}";
        }

        /// <summary>
        /// Set status label color based on invoice status
        /// </summary>
        private void SetStatusColor(string status)
        {
            switch (status)
            {
                case "Paid":
                    lblStatus.BackColor = Color.LightGreen;
                    lblStatus.ForeColor = Color.DarkGreen;
                    break;
                case "Pending":
                    lblStatus.BackColor = Color.LightYellow;
                    lblStatus.ForeColor = Color.DarkOrange;
                    break;
                case "PartiallyPaid":
                    lblStatus.BackColor = Color.LightBlue;
                    lblStatus.ForeColor = Color.DarkBlue;
                    break;
                case "Cancelled":
                    lblStatus.BackColor = Color.LightGray;
                    lblStatus.ForeColor = Color.DarkGray;
                    break;
                default:
                    lblStatus.BackColor = Color.White;
                    lblStatus.ForeColor = Color.Black;
                    break;
            }
        }

        /// <summary>
        /// Setup form controls and event handlers
        /// </summary>
        private void SetupFormControls()
        {
            // Make fields read-only initially
            SetFieldsReadOnly(true);

            // Attach event handlers
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnPrint.Click += BtnPrint_Click;
            btnClose.Click += BtnClose_Click;

            // Discount change event for recalculation
            txtDiscount.TextChanged += TxtDiscount_TextChanged;
        }

        /// <summary>
        /// Set fields read-only or editable
        /// </summary>
        private void SetFieldsReadOnly(bool readOnly)
        {
            // Only these fields should be editable
            txtDiscount.ReadOnly = readOnly;
            txtPaymentTerms.ReadOnly = readOnly;
            txtNotes.ReadOnly = readOnly;

            // Show/hide buttons
            btnSave.Visible = !readOnly;
            btnCancel.Visible = !readOnly;
            btnEdit.Visible = readOnly;
        }

        /// <summary>
        /// Edit button click - enable editing mode
        /// </summary>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            isEditMode = true;
            SetFieldsReadOnly(false);
            MessageBox.Show("You can now edit discount, payment terms, and notes.", 
                "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Save button click - save changes
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate discount
                if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount < 0)
                {
                    MessageBox.Show("Please enter a valid discount amount.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update invoice
                invoice.Discount = discount;
                invoice.PaymentTerms = txtPaymentTerms.Text.Trim();
                invoice.Notes = txtNotes.Text.Trim();
                invoice.ModifiedDate = DateTime.Now;

                // Recalculate totals
                invoice.CalculateTotal();
                invoice.CalculateBalance();

                // Save to database
                bool success = invoiceRepository.Update(invoice);

                if (success)
                {
                    MessageBox.Show("Invoice updated successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh display
                    DisplayInvoiceDetails();
                    
                    // Exit edit mode
                    isEditMode = false;
                    SetFieldsReadOnly(true);
                }
                else
                {
                    MessageBox.Show("Failed to update invoice.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving invoice: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancel button click - cancel editing
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Reload original data
            DisplayInvoiceDetails();
            
            // Exit edit mode
            isEditMode = false;
            SetFieldsReadOnly(true);
        }

        /// <summary>
        /// Print button click - print invoice (placeholder)
        /// </summary>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print functionality will be implemented in a future update.", 
                "Print Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // TODO: Implement print functionality
            // This could use Crystal Reports or generate a PDF
        }

        /// <summary>
        /// Close button click - close form
        /// </summary>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                DialogResult result = MessageBox.Show(
                    "You have unsaved changes. Are you sure you want to close?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            this.Close();
        }

        /// <summary>
        /// Discount text changed - recalculate totals
        /// </summary>
        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (!isEditMode) return;

            if (decimal.TryParse(txtDiscount.Text, out decimal discount) && discount >= 0)
            {
                // Recalculate totals
                decimal newTotal = invoice.SubTotal + invoice.TaxAmount - discount;
                decimal newBalance = newTotal - invoice.PaidAmount;

                txtTotalAmount.Text = newTotal.ToString("F2");
                txtBalanceAmount.Text = newBalance.ToString("F2");
            }
        }

        /// <summary>
        /// Form closing event - check for unsaved changes
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isEditMode)
            {
                DialogResult result = MessageBox.Show(
                    "You have unsaved changes. Are you sure you want to close?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

            base.OnFormClosing(e);
        }
    }
}
