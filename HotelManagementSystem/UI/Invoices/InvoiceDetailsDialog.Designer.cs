namespace HotelManagementSystem.UI.Invoices
{
    partial class InvoiceDetailsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxPaymentHistory = new System.Windows.Forms.GroupBox();
            this.lblPaymentTotal = new System.Windows.Forms.Label();
            this.lblPaymentCount = new System.Windows.Forms.Label();
            this.dgvPaymentHistory = new System.Windows.Forms.DataGridView();
            this.groupBoxFinancial = new System.Windows.Forms.GroupBox();
            this.lblBalanceAmount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.lblTaxRate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxBooking = new System.Windows.Forms.GroupBox();
            this.lblNights = new System.Windows.Forms.Label();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.lblBookingId = new System.Windows.Forms.Label();
            this.groupBoxGuest = new System.Windows.Forms.GroupBox();
            this.lblGuestPhone = new System.Windows.Forms.Label();
            this.lblGuestEmail = new System.Windows.Forms.Label();
            this.lblGuestName = new System.Windows.Forms.Label();
            this.groupBoxInvoice = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInvoiceStatus = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupBoxPaymentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.groupBoxFinancial.SuspendLayout();
            this.groupBoxBooking.SuspendLayout();
            this.groupBoxGuest.SuspendLayout();
            this.groupBoxInvoice.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Invoice Details";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.groupBoxPaymentHistory);
            this.panelContent.Controls.Add(this.groupBoxFinancial);
            this.panelContent.Controls.Add(this.groupBoxBooking);
            this.panelContent.Controls.Add(this.groupBoxGuest);
            this.panelContent.Controls.Add(this.groupBoxInvoice);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelContent.Size = new System.Drawing.Size(900, 690);
            this.panelContent.TabIndex = 1;
            // 
            // groupBoxPaymentHistory
            // 
            this.groupBoxPaymentHistory.Controls.Add(this.lblPaymentTotal);
            this.groupBoxPaymentHistory.Controls.Add(this.lblPaymentCount);
            this.groupBoxPaymentHistory.Controls.Add(this.dgvPaymentHistory);
            this.groupBoxPaymentHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxPaymentHistory.Location = new System.Drawing.Point(13, 470);
            this.groupBoxPaymentHistory.Name = "groupBoxPaymentHistory";
            this.groupBoxPaymentHistory.Size = new System.Drawing.Size(860, 200);
            this.groupBoxPaymentHistory.TabIndex = 4;
            this.groupBoxPaymentHistory.TabStop = false;
            this.groupBoxPaymentHistory.Text = "Payment History";
            // 
            // lblPaymentTotal
            // 
            this.lblPaymentTotal.AutoSize = true;
            this.lblPaymentTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTotal.ForeColor = System.Drawing.Color.Green;
            this.lblPaymentTotal.Location = new System.Drawing.Point(250, 175);
            this.lblPaymentTotal.Name = "lblPaymentTotal";
            this.lblPaymentTotal.Size = new System.Drawing.Size(148, 15);
            this.lblPaymentTotal.TabIndex = 2;
            this.lblPaymentTotal.Text = "Total Amount Paid: $0.00";
            // 
            // lblPaymentCount
            // 
            this.lblPaymentCount.AutoSize = true;
            this.lblPaymentCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentCount.Location = new System.Drawing.Point(10, 175);
            this.lblPaymentCount.Name = "lblPaymentCount";
            this.lblPaymentCount.Size = new System.Drawing.Size(102, 15);
            this.lblPaymentCount.TabIndex = 1;
            this.lblPaymentCount.Text = "Total Payments: 0";
            // 
            // dgvPaymentHistory
            // 
            this.dgvPaymentHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentHistory.Location = new System.Drawing.Point(10, 25);
            this.dgvPaymentHistory.Name = "dgvPaymentHistory";
            this.dgvPaymentHistory.Size = new System.Drawing.Size(840, 140);
            this.dgvPaymentHistory.TabIndex = 0;
            // 
            // groupBoxFinancial
            // 
            this.groupBoxFinancial.Controls.Add(this.lblBalanceAmount);
            this.groupBoxFinancial.Controls.Add(this.label14);
            this.groupBoxFinancial.Controls.Add(this.lblPaidAmount);
            this.groupBoxFinancial.Controls.Add(this.label12);
            this.groupBoxFinancial.Controls.Add(this.lblTotalAmount);
            this.groupBoxFinancial.Controls.Add(this.label10);
            this.groupBoxFinancial.Controls.Add(this.lblDiscount);
            this.groupBoxFinancial.Controls.Add(this.label8);
            this.groupBoxFinancial.Controls.Add(this.lblTaxAmount);
            this.groupBoxFinancial.Controls.Add(this.lblTaxRate);
            this.groupBoxFinancial.Controls.Add(this.label7);
            this.groupBoxFinancial.Controls.Add(this.lblSubTotal);
            this.groupBoxFinancial.Controls.Add(this.label5);
            this.groupBoxFinancial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxFinancial.Location = new System.Drawing.Point(13, 310);
            this.groupBoxFinancial.Name = "groupBoxFinancial";
            this.groupBoxFinancial.Size = new System.Drawing.Size(860, 150);
            this.groupBoxFinancial.TabIndex = 3;
            this.groupBoxFinancial.TabStop = false;
            this.groupBoxFinancial.Text = "Financial Details";
            // 
            // lblBalanceAmount
            // 
            this.lblBalanceAmount.AutoSize = true;
            this.lblBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBalanceAmount.ForeColor = System.Drawing.Color.Red;
            this.lblBalanceAmount.Location = new System.Drawing.Point(730, 110);
            this.lblBalanceAmount.Name = "lblBalanceAmount";
            this.lblBalanceAmount.Size = new System.Drawing.Size(45, 20);
            this.lblBalanceAmount.TabIndex = 12;
            this.lblBalanceAmount.Text = "$0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label14.Location = new System.Drawing.Point(620, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 19);
            this.label14.TabIndex = 11;
            this.label14.Text = "Balance Due:";
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaidAmount.ForeColor = System.Drawing.Color.Green;
            this.lblPaidAmount.Location = new System.Drawing.Point(730, 75);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(45, 19);
            this.lblPaidAmount.TabIndex = 10;
            this.lblPaidAmount.Text = "$0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(620, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 19);
            this.label12.TabIndex = 9;
            this.label12.Text = "Paid Amount:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(730, 35);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(45, 20);
            this.lblTotalAmount.TabIndex = 8;
            this.lblTotalAmount.Text = "$0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.Location = new System.Drawing.Point(620, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 19);
            this.label10.TabIndex = 7;
            this.label10.Text = "Total Amount:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscount.Location = new System.Drawing.Point(470, 75);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(45, 19);
            this.lblDiscount.TabIndex = 6;
            this.lblDiscount.Text = "$0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(320, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Discount:";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxAmount.Location = new System.Drawing.Point(470, 37);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(45, 19);
            this.lblTaxAmount.TabIndex = 4;
            this.lblTaxAmount.Text = "$0.00";
            // 
            // lblTaxRate
            // 
            this.lblTaxRate.AutoSize = true;
            this.lblTaxRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTaxRate.ForeColor = System.Drawing.Color.Gray;
            this.lblTaxRate.Location = new System.Drawing.Point(395, 40);
            this.lblTaxRate.Name = "lblTaxRate";
            this.lblTaxRate.Size = new System.Drawing.Size(35, 15);
            this.lblTaxRate.TabIndex = 3;
            this.lblTaxRate.Text = "(10%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(320, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tax:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTotal.Location = new System.Drawing.Point(150, 37);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(45, 19);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "$0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(20, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sub Total:";
            // 
            // groupBoxBooking
            // 
            this.groupBoxBooking.Controls.Add(this.lblNights);
            this.groupBoxBooking.Controls.Add(this.lblCheckOut);
            this.groupBoxBooking.Controls.Add(this.lblCheckIn);
            this.groupBoxBooking.Controls.Add(this.lblRoomNumber);
            this.groupBoxBooking.Controls.Add(this.lblBookingId);
            this.groupBoxBooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxBooking.Location = new System.Drawing.Point(450, 155);
            this.groupBoxBooking.Name = "groupBoxBooking";
            this.groupBoxBooking.Size = new System.Drawing.Size(423, 145);
            this.groupBoxBooking.TabIndex = 2;
            this.groupBoxBooking.TabStop = false;
            this.groupBoxBooking.Text = "Booking Information";
            // 
            // lblNights
            // 
            this.lblNights.AutoSize = true;
            this.lblNights.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNights.Location = new System.Drawing.Point(20, 115);
            this.lblNights.Name = "lblNights";
            this.lblNights.Size = new System.Drawing.Size(68, 19);
            this.lblNights.TabIndex = 4;
            this.lblNights.Text = "Nights: 0";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckOut.Location = new System.Drawing.Point(20, 90);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(167, 19);
            this.lblCheckOut.TabIndex = 3;
            this.lblCheckOut.Text = "Check-Out: Mar 01, 2025";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckIn.Location = new System.Drawing.Point(20, 65);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(154, 19);
            this.lblCheckIn.TabIndex = 2;
            this.lblCheckIn.Text = "Check-In: Feb 28, 2025";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoomNumber.Location = new System.Drawing.Point(20, 40);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(87, 19);
            this.lblRoomNumber.TabIndex = 1;
            this.lblRoomNumber.Text = "Room: 101";
            // 
            // lblBookingId
            // 
            this.lblBookingId.AutoSize = true;
            this.lblBookingId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookingId.Location = new System.Drawing.Point(20, 15);
            this.lblBookingId.Name = "lblBookingId";
            this.lblBookingId.Size = new System.Drawing.Size(99, 19);
            this.lblBookingId.TabIndex = 0;
            this.lblBookingId.Text = "Booking ID: 1";
            // 
            // groupBoxGuest
            // 
            this.groupBoxGuest.Controls.Add(this.lblGuestPhone);
            this.groupBoxGuest.Controls.Add(this.lblGuestEmail);
            this.groupBoxGuest.Controls.Add(this.lblGuestName);
            this.groupBoxGuest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxGuest.Location = new System.Drawing.Point(13, 155);
            this.groupBoxGuest.Name = "groupBoxGuest";
            this.groupBoxGuest.Size = new System.Drawing.Size(423, 145);
            this.groupBoxGuest.TabIndex = 1;
            this.groupBoxGuest.TabStop = false;
            this.groupBoxGuest.Text = "Guest Information";
            // 
            // lblGuestPhone
            // 
            this.lblGuestPhone.AutoSize = true;
            this.lblGuestPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGuestPhone.Location = new System.Drawing.Point(20, 90);
            this.lblGuestPhone.Name = "lblGuestPhone";
            this.lblGuestPhone.Size = new System.Drawing.Size(132, 19);
            this.lblGuestPhone.TabIndex = 2;
            this.lblGuestPhone.Text = "Phone: 555-0123";
            // 
            // lblGuestEmail
            // 
            this.lblGuestEmail.AutoSize = true;
            this.lblGuestEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGuestEmail.Location = new System.Drawing.Point(20, 60);
            this.lblGuestEmail.Name = "lblGuestEmail";
            this.lblGuestEmail.Size = new System.Drawing.Size(188, 19);
            this.lblGuestEmail.TabIndex = 1;
            this.lblGuestEmail.Text = "Email: guest@example.com";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGuestName.Location = new System.Drawing.Point(20, 30);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(125, 19);
            this.lblGuestName.TabIndex = 0;
            this.lblGuestName.Text = "Guest: John Smith";
            // 
            // groupBoxInvoice
            // 
            this.groupBoxInvoice.Controls.Add(this.txtNotes);
            this.groupBoxInvoice.Controls.Add(this.label4);
            this.groupBoxInvoice.Controls.Add(this.lblInvoiceStatus);
            this.groupBoxInvoice.Controls.Add(this.lblDueDate);
            this.groupBoxInvoice.Controls.Add(this.lblIssueDate);
            this.groupBoxInvoice.Controls.Add(this.lblInvoiceNumber);
            this.groupBoxInvoice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxInvoice.Location = new System.Drawing.Point(13, 13);
            this.groupBoxInvoice.Name = "groupBoxInvoice";
            this.groupBoxInvoice.Size = new System.Drawing.Size(860, 130);
            this.groupBoxInvoice.TabIndex = 0;
            this.groupBoxInvoice.TabStop = false;
            this.groupBoxInvoice.Text = "Invoice Information";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(450, 55);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(390, 60);
            this.txtNotes.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(446, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Notes:";
            // 
            // lblInvoiceStatus
            // 
            this.lblInvoiceStatus.AutoSize = true;
            this.lblInvoiceStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceStatus.ForeColor = System.Drawing.Color.Green;
            this.lblInvoiceStatus.Location = new System.Drawing.Point(20, 95);
            this.lblInvoiceStatus.Name = "lblInvoiceStatus";
            this.lblInvoiceStatus.Size = new System.Drawing.Size(98, 20);
            this.lblInvoiceStatus.TabIndex = 3;
            this.lblInvoiceStatus.Text = "Status: Paid";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDueDate.Location = new System.Drawing.Point(20, 70);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(155, 19);
            this.lblDueDate.TabIndex = 2;
            this.lblDueDate.Text = "Due Date: Mar 01, 2025";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIssueDate.Location = new System.Drawing.Point(20, 45);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(162, 19);
            this.lblIssueDate.TabIndex = 1;
            this.lblIssueDate.Text = "Issue Date: Feb 28, 2025";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInvoiceNumber.Location = new System.Drawing.Point(20, 20);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(249, 19);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "Invoice #: INV-20250219-00001";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelButtons.Controls.Add(this.btnExport);
            this.panelButtons.Controls.Add(this.btnPrint);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 750);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(900, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(180, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 35);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export PDF";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(13, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 35);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print Invoice";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(770, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // InvoiceDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 810);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceDetailsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invoice Details";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.groupBoxPaymentHistory.ResumeLayout(false);
            this.groupBoxPaymentHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.groupBoxFinancial.ResumeLayout(false);
            this.groupBoxFinancial.PerformLayout();
            this.groupBoxBooking.ResumeLayout(false);
            this.groupBoxBooking.PerformLayout();
            this.groupBoxGuest.ResumeLayout(false);
            this.groupBoxGuest.PerformLayout();
            this.groupBoxInvoice.ResumeLayout(false);
            this.groupBoxInvoice.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupBoxInvoice;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblInvoiceStatus;
        private System.Windows.Forms.GroupBox groupBoxGuest;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.Label lblGuestEmail;
        private System.Windows.Forms.Label lblGuestPhone;
        private System.Windows.Forms.GroupBox groupBoxBooking;
        private System.Windows.Forms.Label lblBookingId;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.GroupBox groupBoxFinancial;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTaxAmount;
        private System.Windows.Forms.Label lblTaxRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblBalanceAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBoxPaymentHistory;
        private System.Windows.Forms.DataGridView dgvPaymentHistory;
        private System.Windows.Forms.Label lblPaymentCount;
        private System.Windows.Forms.Label lblPaymentTotal;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label4;
    }
}
