namespace HotelManagementSystem.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomStatusDashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guestManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.housekeepingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchGuestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatusBar = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.roomsToolStripMenuItem,
            this.guestsToolStripMenuItem,
            this.bookingsToolStripMenuItem,
            this.billingToolStripMenuItem,
            this.housekeepingToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.administrationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1184, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.fileColor;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomManagementToolStripMenuItem,
            this.roomStatusDashboardToolStripMenuItem});
            this.roomsToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.room;
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.roomsToolStripMenuItem.Text = "Rooms";
            // 
            // roomManagementToolStripMenuItem
            // 
            this.roomManagementToolStripMenuItem.Name = "roomManagementToolStripMenuItem";
            this.roomManagementToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.roomManagementToolStripMenuItem.Text = "Room Management";
            this.roomManagementToolStripMenuItem.Click += new System.EventHandler(this.roomManagementToolStripMenuItem_Click_1);
            // 
            // roomStatusDashboardToolStripMenuItem
            // 
            this.roomStatusDashboardToolStripMenuItem.Name = "roomStatusDashboardToolStripMenuItem";
            this.roomStatusDashboardToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.roomStatusDashboardToolStripMenuItem.Text = "Room Status Dashboard";
            this.roomStatusDashboardToolStripMenuItem.Click += new System.EventHandler(this.roomStatusDashboardToolStripMenuItem_Click);
            // 
            // guestsToolStripMenuItem
            // 
            this.guestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guestManagementToolStripMenuItem});
            this.guestsToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.guest;
            this.guestsToolStripMenuItem.Name = "guestsToolStripMenuItem";
            this.guestsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.guestsToolStripMenuItem.Text = "Guests";
            // 
            // guestManagementToolStripMenuItem
            // 
            this.guestManagementToolStripMenuItem.Name = "guestManagementToolStripMenuItem";
            this.guestManagementToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.guestManagementToolStripMenuItem.Text = "Guest Management";
            this.guestManagementToolStripMenuItem.Click += new System.EventHandler(this.guestManagementToolStripMenuItem_Click_1);
            // 
            // bookingsToolStripMenuItem
            // 
            this.bookingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllBookingsToolStripMenuItem});
            this.bookingsToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.booking;
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.bookingsToolStripMenuItem.Text = "Booking";
            // 
            // viewAllBookingsToolStripMenuItem
            // 
            this.viewAllBookingsToolStripMenuItem.Name = "viewAllBookingsToolStripMenuItem";
            this.viewAllBookingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.viewAllBookingsToolStripMenuItem.Text = "Manage Booking";
            this.viewAllBookingsToolStripMenuItem.Click += new System.EventHandler(this.viewAllBookingsToolStripMenuItem_Click);
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoiceManagementToolStripMenuItem});
            this.billingToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.billing;
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.billingToolStripMenuItem.Text = "Billing";
            // 
            // invoiceManagementToolStripMenuItem
            // 
            this.invoiceManagementToolStripMenuItem.Name = "invoiceManagementToolStripMenuItem";
            this.invoiceManagementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.invoiceManagementToolStripMenuItem.Text = "Invoices & Payments";
            this.invoiceManagementToolStripMenuItem.Click += new System.EventHandler(this.invoiceManagementToolStripMenuItem_Click);
            // 
            // housekeepingToolStripMenuItem
            // 
            this.housekeepingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTasksToolStripMenuItem});
            this.housekeepingToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.housekeeping;
            this.housekeepingToolStripMenuItem.Name = "housekeepingToolStripMenuItem";
            this.housekeepingToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.housekeepingToolStripMenuItem.Text = "HouseKeeping";
            // 
            // viewTasksToolStripMenuItem
            // 
            this.viewTasksToolStripMenuItem.Name = "viewTasksToolStripMenuItem";
            this.viewTasksToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.viewTasksToolStripMenuItem.Text = "View Tasks";
            this.viewTasksToolStripMenuItem.Click += new System.EventHandler(this.viewTasksToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyOperationToolStripMenuItem});
            this.reportsToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.report;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // dailyOperationToolStripMenuItem
            // 
            this.dailyOperationToolStripMenuItem.Name = "dailyOperationToolStripMenuItem";
            this.dailyOperationToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.dailyOperationToolStripMenuItem.Text = "Daily Operations Report";
            this.dailyOperationToolStripMenuItem.Click += new System.EventHandler(this.dailyOperationsToolStripMenuItem_Click);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffManagementToolStripMenuItem});
            this.administrationToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.administration;
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.administrationToolStripMenuItem.Text = "Administration";
            // 
            // staffManagementToolStripMenuItem
            // 
            this.staffManagementToolStripMenuItem.Name = "staffManagementToolStripMenuItem";
            this.staffManagementToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.staffManagementToolStripMenuItem.Text = "Staff Management";
            this.staffManagementToolStripMenuItem.Click += new System.EventHandler(this.staffManagementToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuideToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::HotelManagementSystem.Properties.Resources.help;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.userGuideToolStripMenuItem.Text = "User Guide";
            this.userGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // searchGuestsToolStripMenuItem
            // 
            this.searchGuestsToolStripMenuItem.Name = "searchGuestsToolStripMenuItem";
            this.searchGuestsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // separatorToolStripMenuItem
            // 
            this.separatorToolStripMenuItem.Name = "separatorToolStripMenuItem";
            this.separatorToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.separatorToolStripMenuItem.Text = "Separator";
            // 
            // checkInToolStripMenuItem
            // 
            this.checkInToolStripMenuItem.Name = "checkInToolStripMenuItem";
            this.checkInToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // checkOutToolStripMenuItem
            // 
            this.checkOutToolStripMenuItem.Name = "checkOutToolStripMenuItem";
            this.checkOutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // processPaymentToolStripMenuItem
            // 
            this.processPaymentToolStripMenuItem.Name = "processPaymentToolStripMenuItem";
            this.processPaymentToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelUser.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(139, 17);
            this.toolStripStatusLabelTime.Text = "toolStripStatusLabelTime";
            // 
            // timerStatusBar
            // 
            this.timerStatusBar.Enabled = true;
            this.timerStatusBar.Interval = 1000;
            this.timerStatusBar.Tick += new System.EventHandler(this.timerStatusBar_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Hotel Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomStatusDashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guestManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchGuestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem housekeepingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timerStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
    }
}