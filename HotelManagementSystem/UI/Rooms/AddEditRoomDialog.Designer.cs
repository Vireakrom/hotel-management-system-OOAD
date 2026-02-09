namespace HotelManagementSystem.UI.Rooms
{
    partial class AddEditRoomDialog
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
            this.grpBasicInfo = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.numBasePrice = new System.Windows.Forms.NumericUpDown();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.numFloorNumber = new System.Windows.Forms.NumericUpDown();
            this.lblFloorNumber = new System.Windows.Forms.Label();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.grpRoomDetails = new System.Windows.Forms.GroupBox();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.lblArea = new System.Windows.Forms.Label();
            this.cmbViewType = new System.Windows.Forms.ComboBox();
            this.lblViewType = new System.Windows.Forms.Label();
            this.cmbBedType = new System.Windows.Forms.ComboBox();
            this.lblBedType = new System.Windows.Forms.Label();
            this.numMaxOccupancy = new System.Windows.Forms.NumericUpDown();
            this.lblMaxOccupancy = new System.Windows.Forms.Label();
            this.grpFeatures = new System.Windows.Forms.GroupBox();
            this.chkHasPrivatePool = new System.Windows.Forms.CheckBox();
            this.chkHasJacuzzi = new System.Windows.Forms.CheckBox();
            this.chkHasSeaView = new System.Windows.Forms.CheckBox();
            this.chkHasBalcony = new System.Windows.Forms.CheckBox();
            this.grpDescription = new System.Windows.Forms.GroupBox();
            this.txtAmenities = new System.Windows.Forms.TextBox();
            this.lblAmenities = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBasicInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorNumber)).BeginInit();
            this.grpRoomDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxOccupancy)).BeginInit();
            this.grpFeatures.SuspendLayout();
            this.grpDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBasicInfo
            // 
            this.grpBasicInfo.Controls.Add(this.cmbStatus);
            this.grpBasicInfo.Controls.Add(this.lblStatus);
            this.grpBasicInfo.Controls.Add(this.numBasePrice);
            this.grpBasicInfo.Controls.Add(this.lblBasePrice);
            this.grpBasicInfo.Controls.Add(this.numFloorNumber);
            this.grpBasicInfo.Controls.Add(this.lblFloorNumber);
            this.grpBasicInfo.Controls.Add(this.cmbRoomType);
            this.grpBasicInfo.Controls.Add(this.lblRoomType);
            this.grpBasicInfo.Controls.Add(this.txtRoomNumber);
            this.grpBasicInfo.Controls.Add(this.lblRoomNumber);
            this.grpBasicInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpBasicInfo.Location = new System.Drawing.Point(12, 12);
            this.grpBasicInfo.Name = "grpBasicInfo";
            this.grpBasicInfo.Size = new System.Drawing.Size(360, 200);
            this.grpBasicInfo.TabIndex = 0;
            this.grpBasicInfo.TabStop = false;
            this.grpBasicInfo.Text = "Basic Information";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(120, 160);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(220, 23);
            this.cmbStatus.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(15, 163);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // numBasePrice
            // 
            this.numBasePrice.DecimalPlaces = 2;
            this.numBasePrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numBasePrice.Location = new System.Drawing.Point(120, 125);
            this.numBasePrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBasePrice.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBasePrice.Name = "numBasePrice";
            this.numBasePrice.Size = new System.Drawing.Size(220, 23);
            this.numBasePrice.TabIndex = 7;
            this.numBasePrice.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBasePrice.Location = new System.Drawing.Point(15, 127);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(89, 15);
            this.lblBasePrice.TabIndex = 6;
            this.lblBasePrice.Text = "Price per Night:";
            // 
            // numFloorNumber
            // 
            this.numFloorNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numFloorNumber.Location = new System.Drawing.Point(120, 90);
            this.numFloorNumber.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numFloorNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFloorNumber.Name = "numFloorNumber";
            this.numFloorNumber.Size = new System.Drawing.Size(220, 23);
            this.numFloorNumber.TabIndex = 5;
            this.numFloorNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFloorNumber
            // 
            this.lblFloorNumber.AutoSize = true;
            this.lblFloorNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFloorNumber.Location = new System.Drawing.Point(15, 92);
            this.lblFloorNumber.Name = "lblFloorNumber";
            this.lblFloorNumber.Size = new System.Drawing.Size(86, 15);
            this.lblFloorNumber.TabIndex = 4;
            this.lblFloorNumber.Text = "Floor Number:";
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(120, 55);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(220, 23);
            this.cmbRoomType.TabIndex = 3;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoomType.Location = new System.Drawing.Point(15, 58);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(70, 15);
            this.lblRoomType.TabIndex = 2;
            this.lblRoomType.Text = "Room Type:";
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRoomNumber.Location = new System.Drawing.Point(120, 20);
            this.txtRoomNumber.MaxLength = 10;
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(220, 23);
            this.txtRoomNumber.TabIndex = 1;
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoomNumber.Location = new System.Drawing.Point(15, 23);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(90, 15);
            this.lblRoomNumber.TabIndex = 0;
            this.lblRoomNumber.Text = "Room Number:";
            // 
            // grpRoomDetails
            // 
            this.grpRoomDetails.Controls.Add(this.numArea);
            this.grpRoomDetails.Controls.Add(this.lblArea);
            this.grpRoomDetails.Controls.Add(this.cmbViewType);
            this.grpRoomDetails.Controls.Add(this.lblViewType);
            this.grpRoomDetails.Controls.Add(this.cmbBedType);
            this.grpRoomDetails.Controls.Add(this.lblBedType);
            this.grpRoomDetails.Controls.Add(this.numMaxOccupancy);
            this.grpRoomDetails.Controls.Add(this.lblMaxOccupancy);
            this.grpRoomDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpRoomDetails.Location = new System.Drawing.Point(378, 12);
            this.grpRoomDetails.Name = "grpRoomDetails";
            this.grpRoomDetails.Size = new System.Drawing.Size(360, 200);
            this.grpRoomDetails.TabIndex = 1;
            this.grpRoomDetails.TabStop = false;
            this.grpRoomDetails.Text = "Room Details";
            // 
            // numArea
            // 
            this.numArea.DecimalPlaces = 1;
            this.numArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numArea.Location = new System.Drawing.Point(130, 125);
            this.numArea.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numArea.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(210, 23);
            this.numArea.TabIndex = 7;
            this.numArea.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblArea.Location = new System.Drawing.Point(15, 127);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(74, 15);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Area (sq.m):";
            // 
            // cmbViewType
            // 
            this.cmbViewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbViewType.FormattingEnabled = true;
            this.cmbViewType.Location = new System.Drawing.Point(130, 90);
            this.cmbViewType.Name = "cmbViewType";
            this.cmbViewType.Size = new System.Drawing.Size(210, 23);
            this.cmbViewType.TabIndex = 5;
            // 
            // lblViewType
            // 
            this.lblViewType.AutoSize = true;
            this.lblViewType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViewType.Location = new System.Drawing.Point(15, 93);
            this.lblViewType.Name = "lblViewType";
            this.lblViewType.Size = new System.Drawing.Size(63, 15);
            this.lblViewType.TabIndex = 4;
            this.lblViewType.Text = "View Type:";
            // 
            // cmbBedType
            // 
            this.cmbBedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBedType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBedType.FormattingEnabled = true;
            this.cmbBedType.Location = new System.Drawing.Point(130, 55);
            this.cmbBedType.Name = "cmbBedType";
            this.cmbBedType.Size = new System.Drawing.Size(210, 23);
            this.cmbBedType.TabIndex = 3;
            // 
            // lblBedType
            // 
            this.lblBedType.AutoSize = true;
            this.lblBedType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBedType.Location = new System.Drawing.Point(15, 58);
            this.lblBedType.Name = "lblBedType";
            this.lblBedType.Size = new System.Drawing.Size(57, 15);
            this.lblBedType.TabIndex = 2;
            this.lblBedType.Text = "Bed Type:";
            // 
            // numMaxOccupancy
            // 
            this.numMaxOccupancy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numMaxOccupancy.Location = new System.Drawing.Point(130, 20);
            this.numMaxOccupancy.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxOccupancy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxOccupancy.Name = "numMaxOccupancy";
            this.numMaxOccupancy.Size = new System.Drawing.Size(210, 23);
            this.numMaxOccupancy.TabIndex = 1;
            this.numMaxOccupancy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaxOccupancy
            // 
            this.lblMaxOccupancy.AutoSize = true;
            this.lblMaxOccupancy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaxOccupancy.Location = new System.Drawing.Point(15, 22);
            this.lblMaxOccupancy.Name = "lblMaxOccupancy";
            this.lblMaxOccupancy.Size = new System.Drawing.Size(96, 15);
            this.lblMaxOccupancy.TabIndex = 0;
            this.lblMaxOccupancy.Text = "Max Occupancy:";
            // 
            // grpFeatures
            // 
            this.grpFeatures.Controls.Add(this.chkHasPrivatePool);
            this.grpFeatures.Controls.Add(this.chkHasJacuzzi);
            this.grpFeatures.Controls.Add(this.chkHasSeaView);
            this.grpFeatures.Controls.Add(this.chkHasBalcony);
            this.grpFeatures.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpFeatures.Location = new System.Drawing.Point(12, 218);
            this.grpFeatures.Name = "grpFeatures";
            this.grpFeatures.Size = new System.Drawing.Size(360, 100);
            this.grpFeatures.TabIndex = 2;
            this.grpFeatures.TabStop = false;
            this.grpFeatures.Text = "Special Features";
            // 
            // chkHasPrivatePool
            // 
            this.chkHasPrivatePool.AutoSize = true;
            this.chkHasPrivatePool.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkHasPrivatePool.Location = new System.Drawing.Point(180, 60);
            this.chkHasPrivatePool.Name = "chkHasPrivatePool";
            this.chkHasPrivatePool.Size = new System.Drawing.Size(90, 19);
            this.chkHasPrivatePool.TabIndex = 3;
            this.chkHasPrivatePool.Text = "Private Pool";
            this.chkHasPrivatePool.UseVisualStyleBackColor = true;
            // 
            // chkHasJacuzzi
            // 
            this.chkHasJacuzzi.AutoSize = true;
            this.chkHasJacuzzi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkHasJacuzzi.Location = new System.Drawing.Point(180, 30);
            this.chkHasJacuzzi.Name = "chkHasJacuzzi";
            this.chkHasJacuzzi.Size = new System.Drawing.Size(63, 19);
            this.chkHasJacuzzi.TabIndex = 2;
            this.chkHasJacuzzi.Text = "Jacuzzi";
            this.chkHasJacuzzi.UseVisualStyleBackColor = true;
            // 
            // chkHasSeaView
            // 
            this.chkHasSeaView.AutoSize = true;
            this.chkHasSeaView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkHasSeaView.Location = new System.Drawing.Point(20, 60);
            this.chkHasSeaView.Name = "chkHasSeaView";
            this.chkHasSeaView.Size = new System.Drawing.Size(73, 19);
            this.chkHasSeaView.TabIndex = 1;
            this.chkHasSeaView.Text = "Sea View";
            this.chkHasSeaView.UseVisualStyleBackColor = true;
            // 
            // chkHasBalcony
            // 
            this.chkHasBalcony.AutoSize = true;
            this.chkHasBalcony.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkHasBalcony.Location = new System.Drawing.Point(20, 30);
            this.chkHasBalcony.Name = "chkHasBalcony";
            this.chkHasBalcony.Size = new System.Drawing.Size(69, 19);
            this.chkHasBalcony.TabIndex = 0;
            this.chkHasBalcony.Text = "Balcony";
            this.chkHasBalcony.UseVisualStyleBackColor = true;
            // 
            // grpDescription
            // 
            this.grpDescription.Controls.Add(this.txtAmenities);
            this.grpDescription.Controls.Add(this.lblAmenities);
            this.grpDescription.Controls.Add(this.txtDescription);
            this.grpDescription.Controls.Add(this.lblDescription);
            this.grpDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDescription.Location = new System.Drawing.Point(378, 218);
            this.grpDescription.Name = "grpDescription";
            this.grpDescription.Size = new System.Drawing.Size(360, 180);
            this.grpDescription.TabIndex = 3;
            this.grpDescription.TabStop = false;
            this.grpDescription.Text = "Additional Information";
            // 
            // txtAmenities
            // 
            this.txtAmenities.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAmenities.Location = new System.Drawing.Point(15, 125);
            this.txtAmenities.MaxLength = 500;
            this.txtAmenities.Multiline = true;
            this.txtAmenities.Name = "txtAmenities";
            this.txtAmenities.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAmenities.Size = new System.Drawing.Size(325, 45);
            this.txtAmenities.TabIndex = 3;
            // 
            // lblAmenities
            // 
            this.lblAmenities.AutoSize = true;
            this.lblAmenities.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAmenities.Location = new System.Drawing.Point(15, 107);
            this.lblAmenities.Name = "lblAmenities";
            this.lblAmenities.Size = new System.Drawing.Size(63, 15);
            this.lblAmenities.TabIndex = 2;
            this.lblAmenities.Text = "Amenities:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(15, 40);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(325, 60);
            this.txtDescription.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(15, 22);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(550, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Add Room";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(648, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEditRoomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 457);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpDescription);
            this.Controls.Add(this.grpFeatures);
            this.Controls.Add(this.grpRoomDetails);
            this.Controls.Add(this.grpBasicInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditRoomDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Room";
            this.grpBasicInfo.ResumeLayout(false);
            this.grpBasicInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorNumber)).EndInit();
            this.grpRoomDetails.ResumeLayout(false);
            this.grpRoomDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxOccupancy)).EndInit();
            this.grpFeatures.ResumeLayout(false);
            this.grpFeatures.PerformLayout();
            this.grpDescription.ResumeLayout(false);
            this.grpDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBasicInfo;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.NumericUpDown numFloorNumber;
        private System.Windows.Forms.Label lblFloorNumber;
        private System.Windows.Forms.NumericUpDown numBasePrice;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpRoomDetails;
        private System.Windows.Forms.NumericUpDown numMaxOccupancy;
        private System.Windows.Forms.Label lblMaxOccupancy;
        private System.Windows.Forms.ComboBox cmbBedType;
        private System.Windows.Forms.Label lblBedType;
        private System.Windows.Forms.ComboBox cmbViewType;
        private System.Windows.Forms.Label lblViewType;
        private System.Windows.Forms.NumericUpDown numArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.GroupBox grpFeatures;
        private System.Windows.Forms.CheckBox chkHasBalcony;
        private System.Windows.Forms.CheckBox chkHasSeaView;
        private System.Windows.Forms.CheckBox chkHasJacuzzi;
        private System.Windows.Forms.CheckBox chkHasPrivatePool;
        private System.Windows.Forms.GroupBox grpDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtAmenities;
        private System.Windows.Forms.Label lblAmenities;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
