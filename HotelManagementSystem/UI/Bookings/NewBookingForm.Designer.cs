namespace HotelManagementSystem.UI.Bookings
{
    partial class NewBookingForm
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
            this.grpGuestSelection = new System.Windows.Forms.GroupBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearchGuest = new System.Windows.Forms.Button();
            this.txtSearchGuest = new System.Windows.Forms.TextBox();
            this.lblSearchGuest = new System.Windows.Forms.Label();
            this.lblGuestCount = new System.Windows.Forms.Label();
            this.cmbGuest = new System.Windows.Forms.ComboBox();
            this.lblGuest = new System.Windows.Forms.Label();
            this.grpBookingDates = new System.Windows.Forms.GroupBox();
            this.lblNights = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.grpRoomSelection = new System.Windows.Forms.GroupBox();
            this.lblRoomPrice = new System.Windows.Forms.Label();
            this.lblRoomCount = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.grpBookingDetails = new System.Windows.Forms.GroupBox();
            this.txtSpecialRequests = new System.Windows.Forms.TextBox();
            this.lblSpecialRequests = new System.Windows.Forms.Label();
            this.numGuests = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfGuests = new System.Windows.Forms.Label();
            this.grpBookingSummary = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.btnCreateBooking = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpGuestSelection.SuspendLayout();
            this.grpBookingDates.SuspendLayout();
            this.grpRoomSelection.SuspendLayout();
            this.grpBookingDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGuests)).BeginInit();
            this.grpBookingSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGuestSelection
            // 
            this.grpGuestSelection.Controls.Add(this.btnClearSearch);
            this.grpGuestSelection.Controls.Add(this.btnSearchGuest);
            this.grpGuestSelection.Controls.Add(this.txtSearchGuest);
            this.grpGuestSelection.Controls.Add(this.lblSearchGuest);
            this.grpGuestSelection.Controls.Add(this.lblGuestCount);
            this.grpGuestSelection.Controls.Add(this.cmbGuest);
            this.grpGuestSelection.Controls.Add(this.lblGuest);
            this.grpGuestSelection.Location = new System.Drawing.Point(12, 12);
            this.grpGuestSelection.Name = "grpGuestSelection";
            this.grpGuestSelection.Size = new System.Drawing.Size(760, 120);
            this.grpGuestSelection.TabIndex = 0;
            this.grpGuestSelection.TabStop = false;
            this.grpGuestSelection.Text = "Guest Selection";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(650, 44);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(90, 25);
            this.btnClearSearch.TabIndex = 6;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnSearchGuest
            // 
            this.btnSearchGuest.Location = new System.Drawing.Point(540, 44);
            this.btnSearchGuest.Name = "btnSearchGuest";
            this.btnSearchGuest.Size = new System.Drawing.Size(90, 25);
            this.btnSearchGuest.TabIndex = 5;
            this.btnSearchGuest.Text = "Search";
            this.btnSearchGuest.UseVisualStyleBackColor = true;
            this.btnSearchGuest.Click += new System.EventHandler(this.btnSearchGuest_Click);
            // 
            // txtSearchGuest
            // 
            this.txtSearchGuest.Location = new System.Drawing.Point(100, 46);
            this.txtSearchGuest.Name = "txtSearchGuest";
            this.txtSearchGuest.Size = new System.Drawing.Size(420, 22);
            this.txtSearchGuest.TabIndex = 4;
            this.txtSearchGuest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchGuest_KeyDown);
            // 
            // lblSearchGuest
            // 
            this.lblSearchGuest.AutoSize = true;
            this.lblSearchGuest.Location = new System.Drawing.Point(20, 49);
            this.lblSearchGuest.Name = "lblSearchGuest";
            this.lblSearchGuest.Size = new System.Drawing.Size(53, 16);
            this.lblSearchGuest.TabIndex = 3;
            this.lblSearchGuest.Text = "Search:";
            // 
            // lblGuestCount
            // 
            this.lblGuestCount.AutoSize = true;
            this.lblGuestCount.ForeColor = System.Drawing.Color.Gray;
            this.lblGuestCount.Location = new System.Drawing.Point(540, 88);
            this.lblGuestCount.Name = "lblGuestCount";
            this.lblGuestCount.Size = new System.Drawing.Size(108, 16);
            this.lblGuestCount.TabIndex = 2;
            this.lblGuestCount.Text = "0 guests available";
            // 
            // cmbGuest
            // 
            this.cmbGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuest.FormattingEnabled = true;
            this.cmbGuest.Location = new System.Drawing.Point(100, 82);
            this.cmbGuest.Name = "cmbGuest";
            this.cmbGuest.Size = new System.Drawing.Size(420, 24);
            this.cmbGuest.TabIndex = 1;
            // 
            // lblGuest
            // 
            this.lblGuest.AutoSize = true;
            this.lblGuest.Location = new System.Drawing.Point(20, 85);
            this.lblGuest.Name = "lblGuest";
            this.lblGuest.Size = new System.Drawing.Size(46, 16);
            this.lblGuest.TabIndex = 0;
            this.lblGuest.Text = "Guest:";
            // 
            // grpBookingDates
            // 
            this.grpBookingDates.Controls.Add(this.lblNights);
            this.grpBookingDates.Controls.Add(this.dtpCheckOut);
            this.grpBookingDates.Controls.Add(this.lblCheckOut);
            this.grpBookingDates.Controls.Add(this.dtpCheckIn);
            this.grpBookingDates.Controls.Add(this.lblCheckIn);
            this.grpBookingDates.Location = new System.Drawing.Point(12, 138);
            this.grpBookingDates.Name = "grpBookingDates";
            this.grpBookingDates.Size = new System.Drawing.Size(760, 100);
            this.grpBookingDates.TabIndex = 1;
            this.grpBookingDates.TabStop = false;
            this.grpBookingDates.Text = "Booking Dates";
            // 
            // lblNights
            // 
            this.lblNights.AutoSize = true;
            this.lblNights.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblNights.Location = new System.Drawing.Point(540, 40);
            this.lblNights.Name = "lblNights";
            this.lblNights.Size = new System.Drawing.Size(77, 20);
            this.lblNights.TabIndex = 4;
            this.lblNights.Text = "1 night(s)";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Location = new System.Drawing.Point(120, 65);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(250, 22);
            this.dtpCheckOut.TabIndex = 3;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Location = new System.Drawing.Point(20, 68);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(91, 16);
            this.lblCheckOut.TabIndex = 2;
            this.lblCheckOut.Text = "Check-out Date:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Location = new System.Drawing.Point(120, 35);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(250, 22);
            this.dtpCheckIn.TabIndex = 1;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Location = new System.Drawing.Point(20, 38);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(83, 16);
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "Check-in Date:";
            // 
            // grpRoomSelection
            // 
            this.grpRoomSelection.Controls.Add(this.lblRoomPrice);
            this.grpRoomSelection.Controls.Add(this.lblRoomCount);
            this.grpRoomSelection.Controls.Add(this.cmbRoom);
            this.grpRoomSelection.Controls.Add(this.lblRoom);
            this.grpRoomSelection.Location = new System.Drawing.Point(12, 244);
            this.grpRoomSelection.Name = "grpRoomSelection";
            this.grpRoomSelection.Size = new System.Drawing.Size(760, 90);
            this.grpRoomSelection.TabIndex = 2;
            this.grpRoomSelection.TabStop = false;
            this.grpRoomSelection.Text = "Room Selection";
            // 
            // lblRoomPrice
            // 
            this.lblRoomPrice.AutoSize = true;
            this.lblRoomPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomPrice.ForeColor = System.Drawing.Color.Green;
            this.lblRoomPrice.Location = new System.Drawing.Point(540, 35);
            this.lblRoomPrice.Name = "lblRoomPrice";
            this.lblRoomPrice.Size = new System.Drawing.Size(127, 18);
            this.lblRoomPrice.TabIndex = 3;
            this.lblRoomPrice.Text = "Price: $0.00/night";
            // 
            // lblRoomCount
            // 
            this.lblRoomCount.AutoSize = true;
            this.lblRoomCount.ForeColor = System.Drawing.Color.Gray;
            this.lblRoomCount.Location = new System.Drawing.Point(540, 58);
            this.lblRoomCount.Name = "lblRoomCount";
            this.lblRoomCount.Size = new System.Drawing.Size(106, 16);
            this.lblRoomCount.TabIndex = 2;
            this.lblRoomCount.Text = "0 rooms available";
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(100, 40);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(420, 24);
            this.cmbRoom.TabIndex = 1;
            this.cmbRoom.SelectedIndexChanged += new System.EventHandler(this.cmbRoom_SelectedIndexChanged);
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(20, 43);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(46, 16);
            this.lblRoom.TabIndex = 0;
            this.lblRoom.Text = "Room:";
            // 
            // grpBookingDetails
            // 
            this.grpBookingDetails.Controls.Add(this.txtSpecialRequests);
            this.grpBookingDetails.Controls.Add(this.lblSpecialRequests);
            this.grpBookingDetails.Controls.Add(this.numGuests);
            this.grpBookingDetails.Controls.Add(this.lblNumberOfGuests);
            this.grpBookingDetails.Location = new System.Drawing.Point(12, 340);
            this.grpBookingDetails.Name = "grpBookingDetails";
            this.grpBookingDetails.Size = new System.Drawing.Size(760, 140);
            this.grpBookingDetails.TabIndex = 3;
            this.grpBookingDetails.TabStop = false;
            this.grpBookingDetails.Text = "Booking Details";
            // 
            // txtSpecialRequests
            // 
            this.txtSpecialRequests.Location = new System.Drawing.Point(150, 65);
            this.txtSpecialRequests.Multiline = true;
            this.txtSpecialRequests.Name = "txtSpecialRequests";
            this.txtSpecialRequests.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpecialRequests.Size = new System.Drawing.Size(590, 60);
            this.txtSpecialRequests.TabIndex = 3;
            // 
            // lblSpecialRequests
            // 
            this.lblSpecialRequests.AutoSize = true;
            this.lblSpecialRequests.Location = new System.Drawing.Point(20, 68);
            this.lblSpecialRequests.Name = "lblSpecialRequests";
            this.lblSpecialRequests.Size = new System.Drawing.Size(115, 16);
            this.lblSpecialRequests.TabIndex = 2;
            this.lblSpecialRequests.Text = "Special Requests:";
            // 
            // numGuests
            // 
            this.numGuests.Location = new System.Drawing.Point(150, 32);
            this.numGuests.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGuests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGuests.Name = "numGuests";
            this.numGuests.Size = new System.Drawing.Size(120, 22);
            this.numGuests.TabIndex = 1;
            this.numGuests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumberOfGuests
            // 
            this.lblNumberOfGuests.AutoSize = true;
            this.lblNumberOfGuests.Location = new System.Drawing.Point(20, 34);
            this.lblNumberOfGuests.Name = "lblNumberOfGuests";
            this.lblNumberOfGuests.Size = new System.Drawing.Size(118, 16);
            this.lblNumberOfGuests.TabIndex = 0;
            this.lblNumberOfGuests.Text = "Number of Guests:";
            // 
            // grpBookingSummary
            // 
            this.grpBookingSummary.Controls.Add(this.lblTotal);
            this.grpBookingSummary.Controls.Add(this.lblSubtotal);
            this.grpBookingSummary.Location = new System.Drawing.Point(12, 486);
            this.grpBookingSummary.Name = "grpBookingSummary";
            this.grpBookingSummary.Size = new System.Drawing.Size(760, 90);
            this.grpBookingSummary.TabIndex = 4;
            this.grpBookingSummary.TabStop = false;
            this.grpBookingSummary.Text = "Booking Summary";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 55);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(92, 25);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total: $0";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(20, 30);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(161, 20);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Room Charges: $0.00";
            // 
            // btnCreateBooking
            // 
            this.btnCreateBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnCreateBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBooking.ForeColor = System.Drawing.Color.White;
            this.btnCreateBooking.Location = new System.Drawing.Point(482, 590);
            this.btnCreateBooking.Name = "btnCreateBooking";
            this.btnCreateBooking.Size = new System.Drawing.Size(180, 40);
            this.btnCreateBooking.TabIndex = 5;
            this.btnCreateBooking.Text = "Create Booking";
            this.btnCreateBooking.UseVisualStyleBackColor = false;
            this.btnCreateBooking.Click += new System.EventHandler(this.btnCreateBooking_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(668, 590);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 642);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateBooking);
            this.Controls.Add(this.grpBookingSummary);
            this.Controls.Add(this.grpBookingDetails);
            this.Controls.Add(this.grpRoomSelection);
            this.Controls.Add(this.grpBookingDates);
            this.Controls.Add(this.grpGuestSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Booking";
            this.grpGuestSelection.ResumeLayout(false);
            this.grpGuestSelection.PerformLayout();
            this.grpBookingDates.ResumeLayout(false);
            this.grpBookingDates.PerformLayout();
            this.grpRoomSelection.ResumeLayout(false);
            this.grpRoomSelection.PerformLayout();
            this.grpBookingDetails.ResumeLayout(false);
            this.grpBookingDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGuests)).EndInit();
            this.grpBookingSummary.ResumeLayout(false);
            this.grpBookingSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGuestSelection;
        private System.Windows.Forms.ComboBox cmbGuest;
        private System.Windows.Forms.Label lblGuest;
        private System.Windows.Forms.Label lblGuestCount;
        private System.Windows.Forms.GroupBox grpBookingDates;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.GroupBox grpRoomSelection;
        private System.Windows.Forms.Label lblRoomCount;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblRoomPrice;
        private System.Windows.Forms.GroupBox grpBookingDetails;
        private System.Windows.Forms.NumericUpDown numGuests;
        private System.Windows.Forms.Label lblNumberOfGuests;
        private System.Windows.Forms.TextBox txtSpecialRequests;
        private System.Windows.Forms.Label lblSpecialRequests;
        private System.Windows.Forms.GroupBox grpBookingSummary;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Button btnCreateBooking;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearchGuest;
        private System.Windows.Forms.TextBox txtSearchGuest;
        private System.Windows.Forms.Label lblSearchGuest;
        private System.Windows.Forms.Button btnClearSearch;
    }
}
