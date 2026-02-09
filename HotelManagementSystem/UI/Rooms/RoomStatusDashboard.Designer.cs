namespace HotelManagementSystem.UI.Rooms
{
    partial class RoomStatusDashboard
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
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panelStatusCounts = new System.Windows.Forms.Panel();
            this.lblMaintenance = new System.Windows.Forms.Label();
            this.lblCleaning = new System.Windows.Forms.Label();
            this.lblReserved = new System.Windows.Forms.Label();
            this.lblOccupied = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblTotalRooms = new System.Windows.Forms.Label();
            this.lblOccupancyRate = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.lblLegend = new System.Windows.Forms.Label();
            this.panelLegendAvailable = new System.Windows.Forms.Panel();
            this.lblLegendAvailable = new System.Windows.Forms.Label();
            this.panelLegendOccupied = new System.Windows.Forms.Panel();
            this.lblLegendOccupied = new System.Windows.Forms.Label();
            this.panelLegendReserved = new System.Windows.Forms.Panel();
            this.lblLegendReserved = new System.Windows.Forms.Label();
            this.panelLegendCleaning = new System.Windows.Forms.Panel();
            this.lblLegendCleaning = new System.Windows.Forms.Label();
            this.panelLegendMaintenance = new System.Windows.Forms.Panel();
            this.lblLegendMaintenance = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelStatusCounts.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Room Status Dashboard";
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.Controls.Add(this.btnClose);
            this.panelControls.Controls.Add(this.btnRefresh);
            this.panelControls.Controls.Add(this.cmbFilterStatus);
            this.panelControls.Controls.Add(this.lblFilter);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 60);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1200, 60);
            this.panelControls.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1070, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(940, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "All",
            "Available",
            "Occupied",
            "Reserved",
            "Cleaning",
            "Maintenance"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(130, 18);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(200, 25);
            this.cmbFilterStatus.TabIndex = 1;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilter.Location = new System.Drawing.Point(20, 21);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(104, 19);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter by Status:";
            // 
            // panelStatusCounts
            // 
            this.panelStatusCounts.BackColor = System.Drawing.Color.White;
            this.panelStatusCounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatusCounts.Controls.Add(this.lblOccupancyRate);
            this.panelStatusCounts.Controls.Add(this.lblMaintenance);
            this.panelStatusCounts.Controls.Add(this.lblCleaning);
            this.panelStatusCounts.Controls.Add(this.lblReserved);
            this.panelStatusCounts.Controls.Add(this.lblOccupied);
            this.panelStatusCounts.Controls.Add(this.lblAvailable);
            this.panelStatusCounts.Controls.Add(this.lblTotalRooms);
            this.panelStatusCounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatusCounts.Location = new System.Drawing.Point(0, 120);
            this.panelStatusCounts.Name = "panelStatusCounts";
            this.panelStatusCounts.Size = new System.Drawing.Size(1200, 80);
            this.panelStatusCounts.TabIndex = 2;
            // 
            // lblMaintenance
            // 
            this.lblMaintenance.AutoSize = true;
            this.lblMaintenance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaintenance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblMaintenance.Location = new System.Drawing.Point(20, 45);
            this.lblMaintenance.Name = "lblMaintenance";
            this.lblMaintenance.Size = new System.Drawing.Size(115, 19);
            this.lblMaintenance.TabIndex = 5;
            this.lblMaintenance.Text = "Maintenance: 0";
            // 
            // lblCleaning
            // 
            this.lblCleaning.AutoSize = true;
            this.lblCleaning.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCleaning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lblCleaning.Location = new System.Drawing.Point(680, 15);
            this.lblCleaning.Name = "lblCleaning";
            this.lblCleaning.Size = new System.Drawing.Size(87, 19);
            this.lblCleaning.TabIndex = 4;
            this.lblCleaning.Text = "Cleaning: 0";
            // 
            // lblReserved
            // 
            this.lblReserved.AutoSize = true;
            this.lblReserved.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReserved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(192)))), ((int)(((byte)(45)))));
            this.lblReserved.Location = new System.Drawing.Point(550, 15);
            this.lblReserved.Name = "lblReserved";
            this.lblReserved.Size = new System.Drawing.Size(87, 19);
            this.lblReserved.TabIndex = 3;
            this.lblReserved.Text = "Reserved: 0";
            // 
            // lblOccupied
            // 
            this.lblOccupied.AutoSize = true;
            this.lblOccupied.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOccupied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblOccupied.Location = new System.Drawing.Point(410, 15);
            this.lblOccupied.Name = "lblOccupied";
            this.lblOccupied.Size = new System.Drawing.Size(89, 19);
            this.lblOccupied.TabIndex = 2;
            this.lblOccupied.Text = "Occupied: 0";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblAvailable.Location = new System.Drawing.Point(270, 15);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(91, 19);
            this.lblAvailable.TabIndex = 1;
            this.lblAvailable.Text = "Available: 0";
            // 
            // lblTotalRooms
            // 
            this.lblTotalRooms.AutoSize = true;
            this.lblTotalRooms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.lblTotalRooms.Location = new System.Drawing.Point(20, 15);
            this.lblTotalRooms.Name = "lblTotalRooms";
            this.lblTotalRooms.Size = new System.Drawing.Size(127, 21);
            this.lblTotalRooms.TabIndex = 0;
            this.lblTotalRooms.Text = "Total Rooms: 0";
            // 
            // lblOccupancyRate
            // 
            this.lblOccupancyRate.AutoSize = true;
            this.lblOccupancyRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOccupancyRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.lblOccupancyRate.Location = new System.Drawing.Point(270, 45);
            this.lblOccupancyRate.Name = "lblOccupancyRate";
            this.lblOccupancyRate.Size = new System.Drawing.Size(180, 20);
            this.lblOccupancyRate.TabIndex = 6;
            this.lblOccupancyRate.Text = "Occupancy Rate: 0.0%";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.flowLayoutPanelRooms);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 200);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(1200, 500);
            this.panelMain.TabIndex = 3;
            // 
            // flowLayoutPanelRooms
            // 
            this.flowLayoutPanelRooms.AutoScroll = true;
            this.flowLayoutPanelRooms.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanelRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelRooms.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanelRooms.Name = "flowLayoutPanelRooms";
            this.flowLayoutPanelRooms.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelRooms.Size = new System.Drawing.Size(1180, 480);
            this.flowLayoutPanelRooms.TabIndex = 0;
            // 
            // panelLegend
            // 
            this.panelLegend.BackColor = System.Drawing.Color.White;
            this.panelLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLegend.Controls.Add(this.panelLegendMaintenance);
            this.panelLegend.Controls.Add(this.lblLegendMaintenance);
            this.panelLegend.Controls.Add(this.panelLegendCleaning);
            this.panelLegend.Controls.Add(this.lblLegendCleaning);
            this.panelLegend.Controls.Add(this.panelLegendReserved);
            this.panelLegend.Controls.Add(this.lblLegendReserved);
            this.panelLegend.Controls.Add(this.panelLegendOccupied);
            this.panelLegend.Controls.Add(this.lblLegendOccupied);
            this.panelLegend.Controls.Add(this.panelLegendAvailable);
            this.panelLegend.Controls.Add(this.lblLegendAvailable);
            this.panelLegend.Controls.Add(this.lblLegend);
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLegend.Location = new System.Drawing.Point(0, 700);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(1200, 50);
            this.panelLegend.TabIndex = 4;
            // 
            // lblLegend
            // 
            this.lblLegend.AutoSize = true;
            this.lblLegend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLegend.Location = new System.Drawing.Point(20, 15);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(63, 19);
            this.lblLegend.TabIndex = 0;
            this.lblLegend.Text = "Legend:";
            // 
            // panelLegendAvailable
            // 
            this.panelLegendAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panelLegendAvailable.Location = new System.Drawing.Point(100, 12);
            this.panelLegendAvailable.Name = "panelLegendAvailable";
            this.panelLegendAvailable.Size = new System.Drawing.Size(25, 25);
            this.panelLegendAvailable.TabIndex = 1;
            // 
            // lblLegendAvailable
            // 
            this.lblLegendAvailable.AutoSize = true;
            this.lblLegendAvailable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegendAvailable.Location = new System.Drawing.Point(130, 16);
            this.lblLegendAvailable.Name = "lblLegendAvailable";
            this.lblLegendAvailable.Size = new System.Drawing.Size(58, 15);
            this.lblLegendAvailable.TabIndex = 2;
            this.lblLegendAvailable.Text = "Available";
            // 
            // panelLegendOccupied
            // 
            this.panelLegendOccupied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelLegendOccupied.Location = new System.Drawing.Point(220, 12);
            this.panelLegendOccupied.Name = "panelLegendOccupied";
            this.panelLegendOccupied.Size = new System.Drawing.Size(25, 25);
            this.panelLegendOccupied.TabIndex = 3;
            // 
            // lblLegendOccupied
            // 
            this.lblLegendOccupied.AutoSize = true;
            this.lblLegendOccupied.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegendOccupied.Location = new System.Drawing.Point(250, 16);
            this.lblLegendOccupied.Name = "lblLegendOccupied";
            this.lblLegendOccupied.Size = new System.Drawing.Size(60, 15);
            this.lblLegendOccupied.TabIndex = 4;
            this.lblLegendOccupied.Text = "Occupied";
            // 
            // panelLegendReserved
            // 
            this.panelLegendReserved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(192)))), ((int)(((byte)(45)))));
            this.panelLegendReserved.Location = new System.Drawing.Point(340, 12);
            this.panelLegendReserved.Name = "panelLegendReserved";
            this.panelLegendReserved.Size = new System.Drawing.Size(25, 25);
            this.panelLegendReserved.TabIndex = 5;
            // 
            // lblLegendReserved
            // 
            this.lblLegendReserved.AutoSize = true;
            this.lblLegendReserved.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegendReserved.Location = new System.Drawing.Point(370, 16);
            this.lblLegendReserved.Name = "lblLegendReserved";
            this.lblLegendReserved.Size = new System.Drawing.Size(57, 15);
            this.lblLegendReserved.TabIndex = 6;
            this.lblLegendReserved.Text = "Reserved";
            // 
            // panelLegendCleaning
            // 
            this.panelLegendCleaning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.panelLegendCleaning.Location = new System.Drawing.Point(460, 12);
            this.panelLegendCleaning.Name = "panelLegendCleaning";
            this.panelLegendCleaning.Size = new System.Drawing.Size(25, 25);
            this.panelLegendCleaning.TabIndex = 7;
            // 
            // lblLegendCleaning
            // 
            this.lblLegendCleaning.AutoSize = true;
            this.lblLegendCleaning.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegendCleaning.Location = new System.Drawing.Point(490, 16);
            this.lblLegendCleaning.Name = "lblLegendCleaning";
            this.lblLegendCleaning.Size = new System.Drawing.Size(56, 15);
            this.lblLegendCleaning.TabIndex = 8;
            this.lblLegendCleaning.Text = "Cleaning";
            // 
            // panelLegendMaintenance
            // 
            this.panelLegendMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.panelLegendMaintenance.Location = new System.Drawing.Point(580, 12);
            this.panelLegendMaintenance.Name = "panelLegendMaintenance";
            this.panelLegendMaintenance.Size = new System.Drawing.Size(25, 25);
            this.panelLegendMaintenance.TabIndex = 9;
            // 
            // lblLegendMaintenance
            // 
            this.lblLegendMaintenance.AutoSize = true;
            this.lblLegendMaintenance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegendMaintenance.Location = new System.Drawing.Point(610, 16);
            this.lblLegendMaintenance.Name = "lblLegendMaintenance";
            this.lblLegendMaintenance.Size = new System.Drawing.Size(79, 15);
            this.lblLegendMaintenance.TabIndex = 10;
            this.lblLegendMaintenance.Text = "Maintenance";
            // 
            // RoomStatusDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLegend);
            this.Controls.Add(this.panelStatusCounts);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelTop);
            this.Name = "RoomStatusDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Status Dashboard";
            this.Load += new System.EventHandler(this.RoomStatusDashboard_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelStatusCounts.ResumeLayout(false);
            this.panelStatusCounts.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelLegend.ResumeLayout(false);
            this.panelLegend.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panelStatusCounts;
        private System.Windows.Forms.Label lblMaintenance;
        private System.Windows.Forms.Label lblCleaning;
        private System.Windows.Forms.Label lblReserved;
        private System.Windows.Forms.Label lblOccupied;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblTotalRooms;
        private System.Windows.Forms.Label lblOccupancyRate;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRooms;
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Panel panelLegendMaintenance;
        private System.Windows.Forms.Label lblLegendMaintenance;
        private System.Windows.Forms.Panel panelLegendCleaning;
        private System.Windows.Forms.Label lblLegendCleaning;
        private System.Windows.Forms.Panel panelLegendReserved;
        private System.Windows.Forms.Label lblLegendReserved;
        private System.Windows.Forms.Panel panelLegendOccupied;
        private System.Windows.Forms.Label lblLegendOccupied;
        private System.Windows.Forms.Panel panelLegendAvailable;
        private System.Windows.Forms.Label lblLegendAvailable;
        private System.Windows.Forms.Label lblLegend;
    }
}
