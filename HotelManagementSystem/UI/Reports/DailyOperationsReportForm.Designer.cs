namespace HotelManagementSystem.UI.Reports
{
    partial class DailyOperationsReportForm
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
            this.lblReportDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDateFilter = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateLabel = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelStatOccupancy = new System.Windows.Forms.Panel();
            this.lblOccupancyValue = new System.Windows.Forms.Label();
            this.lblOccupancyLabel = new System.Windows.Forms.Label();
            this.panelStatRevenue = new System.Windows.Forms.Panel();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenueLabel = new System.Windows.Forms.Label();
            this.panelStatCheckOuts = new System.Windows.Forms.Panel();
            this.lblCheckOutsValue = new System.Windows.Forms.Label();
            this.lblCheckOutsLabel = new System.Windows.Forms.Label();
            this.panelStatCheckIns = new System.Windows.Forms.Panel();
            this.lblCheckInsValue = new System.Windows.Forms.Label();
            this.lblCheckInsLabel = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panelRoomStatus = new System.Windows.Forms.Panel();
            this.dgvRoomStatus = new System.Windows.Forms.DataGridView();
            this.lblRoomStatusTitle = new System.Windows.Forms.Label();
            this.panelRevenueBreakdown = new System.Windows.Forms.Panel();
            this.dgvRevenueBreakdown = new System.Windows.Forms.DataGridView();
            this.lblRevenueBreakdownTitle = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.dgvRecentBookings = new System.Windows.Forms.DataGridView();
            this.lblRecentBookingsTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.panelDateFilter.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelStatOccupancy.SuspendLayout();
            this.panelStatRevenue.SuspendLayout();
            this.panelStatCheckOuts.SuspendLayout();
            this.panelStatCheckIns.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelRoomStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomStatus)).BeginInit();
            this.panelRevenueBreakdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueBreakdown)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentBookings)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTop.Controls.Add(this.lblReportDate);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblReportDate
            // 
            this.lblReportDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReportDate.ForeColor = System.Drawing.Color.White;
            this.lblReportDate.Location = new System.Drawing.Point(800, 20);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(290, 20);
            this.lblReportDate.TabIndex = 1;
            this.lblReportDate.Text = "Report Date";
            this.lblReportDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Daily Operations Report";
            // 
            // panelDateFilter
            // 
            this.panelDateFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDateFilter.Controls.Add(this.btnRefresh);
            this.panelDateFilter.Controls.Add(this.dtpReportDate);
            this.panelDateFilter.Controls.Add(this.lblDateLabel);
            this.panelDateFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDateFilter.Location = new System.Drawing.Point(0, 60);
            this.panelDateFilter.Name = "panelDateFilter";
            this.panelDateFilter.Padding = new System.Windows.Forms.Padding(10);
            this.panelDateFilter.Size = new System.Drawing.Size(1100, 45);
            this.panelDateFilter.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(360, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtpReportDate
            // 
            this.dtpReportDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportDate.Location = new System.Drawing.Point(120, 10);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(220, 23);
            this.dtpReportDate.TabIndex = 1;
            this.dtpReportDate.ValueChanged += new System.EventHandler(this.dtpReportDate_ValueChanged);
            // 
            // lblDateLabel
            // 
            this.lblDateLabel.AutoSize = true;
            this.lblDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateLabel.Location = new System.Drawing.Point(13, 14);
            this.lblDateLabel.Name = "lblDateLabel";
            this.lblDateLabel.Size = new System.Drawing.Size(80, 15);
            this.lblDateLabel.TabIndex = 0;
            this.lblDateLabel.Text = "Report Date:";
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.panelStatOccupancy);
            this.panelStats.Controls.Add(this.panelStatRevenue);
            this.panelStats.Controls.Add(this.panelStatCheckOuts);
            this.panelStats.Controls.Add(this.panelStatCheckIns);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 105);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelStats.Size = new System.Drawing.Size(1100, 90);
            this.panelStats.TabIndex = 2;
            // 
            // panelStatCheckIns
            // 
            this.panelStatCheckIns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelStatCheckIns.Controls.Add(this.lblCheckInsValue);
            this.panelStatCheckIns.Controls.Add(this.lblCheckInsLabel);
            this.panelStatCheckIns.Location = new System.Drawing.Point(15, 8);
            this.panelStatCheckIns.Name = "panelStatCheckIns";
            this.panelStatCheckIns.Size = new System.Drawing.Size(255, 72);
            this.panelStatCheckIns.TabIndex = 0;
            // 
            // lblCheckInsValue
            // 
            this.lblCheckInsValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckInsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCheckInsValue.ForeColor = System.Drawing.Color.White;
            this.lblCheckInsValue.Location = new System.Drawing.Point(0, 22);
            this.lblCheckInsValue.Name = "lblCheckInsValue";
            this.lblCheckInsValue.Size = new System.Drawing.Size(255, 50);
            this.lblCheckInsValue.TabIndex = 1;
            this.lblCheckInsValue.Text = "0";
            this.lblCheckInsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheckInsLabel
            // 
            this.lblCheckInsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckInsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCheckInsLabel.ForeColor = System.Drawing.Color.White;
            this.lblCheckInsLabel.Location = new System.Drawing.Point(0, 0);
            this.lblCheckInsLabel.Name = "lblCheckInsLabel";
            this.lblCheckInsLabel.Size = new System.Drawing.Size(255, 22);
            this.lblCheckInsLabel.TabIndex = 0;
            this.lblCheckInsLabel.Text = "TODAY\'S CHECK-INS";
            this.lblCheckInsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatCheckOuts
            // 
            this.panelStatCheckOuts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelStatCheckOuts.Controls.Add(this.lblCheckOutsValue);
            this.panelStatCheckOuts.Controls.Add(this.lblCheckOutsLabel);
            this.panelStatCheckOuts.Location = new System.Drawing.Point(285, 8);
            this.panelStatCheckOuts.Name = "panelStatCheckOuts";
            this.panelStatCheckOuts.Size = new System.Drawing.Size(255, 72);
            this.panelStatCheckOuts.TabIndex = 1;
            // 
            // lblCheckOutsValue
            // 
            this.lblCheckOutsValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckOutsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCheckOutsValue.ForeColor = System.Drawing.Color.White;
            this.lblCheckOutsValue.Location = new System.Drawing.Point(0, 22);
            this.lblCheckOutsValue.Name = "lblCheckOutsValue";
            this.lblCheckOutsValue.Size = new System.Drawing.Size(255, 50);
            this.lblCheckOutsValue.TabIndex = 1;
            this.lblCheckOutsValue.Text = "0";
            this.lblCheckOutsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheckOutsLabel
            // 
            this.lblCheckOutsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckOutsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCheckOutsLabel.ForeColor = System.Drawing.Color.White;
            this.lblCheckOutsLabel.Location = new System.Drawing.Point(0, 0);
            this.lblCheckOutsLabel.Name = "lblCheckOutsLabel";
            this.lblCheckOutsLabel.Size = new System.Drawing.Size(255, 22);
            this.lblCheckOutsLabel.TabIndex = 0;
            this.lblCheckOutsLabel.Text = "TODAY\'S CHECK-OUTS";
            this.lblCheckOutsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatRevenue
            // 
            this.panelStatRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelStatRevenue.Controls.Add(this.lblRevenueValue);
            this.panelStatRevenue.Controls.Add(this.lblRevenueLabel);
            this.panelStatRevenue.Location = new System.Drawing.Point(555, 8);
            this.panelStatRevenue.Name = "panelStatRevenue";
            this.panelStatRevenue.Size = new System.Drawing.Size(255, 72);
            this.panelStatRevenue.TabIndex = 2;
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblRevenueValue.ForeColor = System.Drawing.Color.White;
            this.lblRevenueValue.Location = new System.Drawing.Point(0, 22);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(255, 50);
            this.lblRevenueValue.TabIndex = 1;
            this.lblRevenueValue.Text = "$0.00";
            this.lblRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRevenueLabel
            // 
            this.lblRevenueLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRevenueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRevenueLabel.ForeColor = System.Drawing.Color.White;
            this.lblRevenueLabel.Location = new System.Drawing.Point(0, 0);
            this.lblRevenueLabel.Name = "lblRevenueLabel";
            this.lblRevenueLabel.Size = new System.Drawing.Size(255, 22);
            this.lblRevenueLabel.TabIndex = 0;
            this.lblRevenueLabel.Text = "TODAY\'S REVENUE";
            this.lblRevenueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatOccupancy
            // 
            this.panelStatOccupancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelStatOccupancy.Controls.Add(this.lblOccupancyValue);
            this.panelStatOccupancy.Controls.Add(this.lblOccupancyLabel);
            this.panelStatOccupancy.Location = new System.Drawing.Point(825, 8);
            this.panelStatOccupancy.Name = "panelStatOccupancy";
            this.panelStatOccupancy.Size = new System.Drawing.Size(255, 72);
            this.panelStatOccupancy.TabIndex = 3;
            // 
            // lblOccupancyValue
            // 
            this.lblOccupancyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOccupancyValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblOccupancyValue.ForeColor = System.Drawing.Color.White;
            this.lblOccupancyValue.Location = new System.Drawing.Point(0, 22);
            this.lblOccupancyValue.Name = "lblOccupancyValue";
            this.lblOccupancyValue.Size = new System.Drawing.Size(255, 50);
            this.lblOccupancyValue.TabIndex = 1;
            this.lblOccupancyValue.Text = "0%";
            this.lblOccupancyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOccupancyLabel
            // 
            this.lblOccupancyLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOccupancyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOccupancyLabel.ForeColor = System.Drawing.Color.White;
            this.lblOccupancyLabel.Location = new System.Drawing.Point(0, 0);
            this.lblOccupancyLabel.Name = "lblOccupancyLabel";
            this.lblOccupancyLabel.Size = new System.Drawing.Size(255, 22);
            this.lblOccupancyLabel.TabIndex = 0;
            this.lblOccupancyLabel.Text = "OCCUPANCY RATE";
            this.lblOccupancyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.panelRoomStatus);
            this.panelMiddle.Controls.Add(this.panelRevenueBreakdown);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 195);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(1100, 200);
            this.panelMiddle.TabIndex = 3;
            // 
            // panelRoomStatus
            // 
            this.panelRoomStatus.Controls.Add(this.dgvRoomStatus);
            this.panelRoomStatus.Controls.Add(this.lblRoomStatusTitle);
            this.panelRoomStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelRoomStatus.Location = new System.Drawing.Point(0, 0);
            this.panelRoomStatus.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.panelRoomStatus.Name = "panelRoomStatus";
            this.panelRoomStatus.Size = new System.Drawing.Size(550, 200);
            this.panelRoomStatus.TabIndex = 0;
            // 
            // dgvRoomStatus
            // 
            this.dgvRoomStatus.AllowUserToAddRows = false;
            this.dgvRoomStatus.AllowUserToDeleteRows = false;
            this.dgvRoomStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoomStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoomStatus.Location = new System.Drawing.Point(10, 30);
            this.dgvRoomStatus.Name = "dgvRoomStatus";
            this.dgvRoomStatus.ReadOnly = true;
            this.dgvRoomStatus.Size = new System.Drawing.Size(535, 165);
            this.dgvRoomStatus.TabIndex = 1;
            // 
            // lblRoomStatusTitle
            // 
            this.lblRoomStatusTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoomStatusTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoomStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRoomStatusTitle.Location = new System.Drawing.Point(10, 5);
            this.lblRoomStatusTitle.Name = "lblRoomStatusTitle";
            this.lblRoomStatusTitle.Size = new System.Drawing.Size(535, 25);
            this.lblRoomStatusTitle.TabIndex = 0;
            this.lblRoomStatusTitle.Text = "Room Status Breakdown";
            // 
            // panelRevenueBreakdown
            // 
            this.panelRevenueBreakdown.Controls.Add(this.dgvRevenueBreakdown);
            this.panelRevenueBreakdown.Controls.Add(this.lblRevenueBreakdownTitle);
            this.panelRevenueBreakdown.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRevenueBreakdown.Location = new System.Drawing.Point(550, 0);
            this.panelRevenueBreakdown.Padding = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.panelRevenueBreakdown.Name = "panelRevenueBreakdown";
            this.panelRevenueBreakdown.Size = new System.Drawing.Size(550, 200);
            this.panelRevenueBreakdown.TabIndex = 1;
            // 
            // dgvRevenueBreakdown
            // 
            this.dgvRevenueBreakdown.AllowUserToAddRows = false;
            this.dgvRevenueBreakdown.AllowUserToDeleteRows = false;
            this.dgvRevenueBreakdown.BackgroundColor = System.Drawing.Color.White;
            this.dgvRevenueBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRevenueBreakdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRevenueBreakdown.Location = new System.Drawing.Point(5, 30);
            this.dgvRevenueBreakdown.Name = "dgvRevenueBreakdown";
            this.dgvRevenueBreakdown.ReadOnly = true;
            this.dgvRevenueBreakdown.Size = new System.Drawing.Size(535, 165);
            this.dgvRevenueBreakdown.TabIndex = 1;
            // 
            // lblRevenueBreakdownTitle
            // 
            this.lblRevenueBreakdownTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRevenueBreakdownTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRevenueBreakdownTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRevenueBreakdownTitle.Location = new System.Drawing.Point(5, 5);
            this.lblRevenueBreakdownTitle.Name = "lblRevenueBreakdownTitle";
            this.lblRevenueBreakdownTitle.Size = new System.Drawing.Size(535, 25);
            this.lblRevenueBreakdownTitle.TabIndex = 0;
            this.lblRevenueBreakdownTitle.Text = "Revenue by Payment Method";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.dgvRecentBookings);
            this.panelBottom.Controls.Add(this.lblRecentBookingsTitle);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 395);
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1100, 220);
            this.panelBottom.TabIndex = 4;
            // 
            // dgvRecentBookings
            // 
            this.dgvRecentBookings.AllowUserToAddRows = false;
            this.dgvRecentBookings.AllowUserToDeleteRows = false;
            this.dgvRecentBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentBookings.Location = new System.Drawing.Point(10, 30);
            this.dgvRecentBookings.Name = "dgvRecentBookings";
            this.dgvRecentBookings.ReadOnly = true;
            this.dgvRecentBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentBookings.Size = new System.Drawing.Size(1080, 185);
            this.dgvRecentBookings.TabIndex = 1;
            // 
            // lblRecentBookingsTitle
            // 
            this.lblRecentBookingsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecentBookingsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecentBookingsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRecentBookingsTitle.Location = new System.Drawing.Point(10, 5);
            this.lblRecentBookingsTitle.Name = "lblRecentBookingsTitle";
            this.lblRecentBookingsTitle.Size = new System.Drawing.Size(1080, 25);
            this.lblRecentBookingsTitle.TabIndex = 0;
            this.lblRecentBookingsTitle.Text = "Recent Bookings";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Controls.Add(this.btnPrint);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 615);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1100, 45);
            this.panelButtons.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(990, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(880, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip1.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // DailyOperationsReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 682);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelDateFilter);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DailyOperationsReportForm";
            this.Text = "Daily Operations Report";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelDateFilter.ResumeLayout(false);
            this.panelDateFilter.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStatOccupancy.ResumeLayout(false);
            this.panelStatRevenue.ResumeLayout(false);
            this.panelStatCheckOuts.ResumeLayout(false);
            this.panelStatCheckIns.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.panelRoomStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomStatus)).EndInit();
            this.panelRevenueBreakdown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueBreakdown)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentBookings)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblReportDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelDateFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Label lblDateLabel;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelStatOccupancy;
        private System.Windows.Forms.Label lblOccupancyValue;
        private System.Windows.Forms.Label lblOccupancyLabel;
        private System.Windows.Forms.Panel panelStatRevenue;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblRevenueLabel;
        private System.Windows.Forms.Panel panelStatCheckOuts;
        private System.Windows.Forms.Label lblCheckOutsValue;
        private System.Windows.Forms.Label lblCheckOutsLabel;
        private System.Windows.Forms.Panel panelStatCheckIns;
        private System.Windows.Forms.Label lblCheckInsValue;
        private System.Windows.Forms.Label lblCheckInsLabel;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelRoomStatus;
        private System.Windows.Forms.DataGridView dgvRoomStatus;
        private System.Windows.Forms.Label lblRoomStatusTitle;
        private System.Windows.Forms.Panel panelRevenueBreakdown;
        private System.Windows.Forms.DataGridView dgvRevenueBreakdown;
        private System.Windows.Forms.Label lblRevenueBreakdownTitle;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.DataGridView dgvRecentBookings;
        private System.Windows.Forms.Label lblRecentBookingsTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
