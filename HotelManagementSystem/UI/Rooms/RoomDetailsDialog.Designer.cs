namespace HotelManagementSystem.UI.Rooms
{
    partial class RoomDetailsDialog
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxFeatures = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFeatures = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.lblAreaValue = new System.Windows.Forms.Label();
            this.lblAreaLabel = new System.Windows.Forms.Label();
            this.lblViewValue = new System.Windows.Forms.Label();
            this.lblViewLabel = new System.Windows.Forms.Label();
            this.lblOccupancyValue = new System.Windows.Forms.Label();
            this.lblOccupancyLabel = new System.Windows.Forms.Label();
            this.lblBedValue = new System.Windows.Forms.Label();
            this.lblBedLabel = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.lblPriceLabel = new System.Windows.Forms.Label();
            this.lblFloorValue = new System.Windows.Forms.Label();
            this.lblFloorLabel = new System.Windows.Forms.Label();
            this.lblTypeValue = new System.Windows.Forms.Label();
            this.lblTypeLabel = new System.Windows.Forms.Label();
            this.lblRoomNumValue = new System.Windows.Forms.Label();
            this.lblRoomNumLabel = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupBoxFeatures.SuspendLayout();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.panelTop.Controls.Add(this.lblStatus);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(520, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(350, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(155, 25);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "AVAILABLE";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Room Details";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.groupBoxFeatures);
            this.panelContent.Controls.Add(this.groupBoxDescription);
            this.panelContent.Controls.Add(this.groupBoxDetails);
            this.panelContent.Controls.Add(this.groupBoxInfo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(520, 420);
            this.panelContent.TabIndex = 1;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.lblPriceValue);
            this.groupBoxInfo.Controls.Add(this.lblPriceLabel);
            this.groupBoxInfo.Controls.Add(this.lblFloorValue);
            this.groupBoxInfo.Controls.Add(this.lblFloorLabel);
            this.groupBoxInfo.Controls.Add(this.lblTypeValue);
            this.groupBoxInfo.Controls.Add(this.lblTypeLabel);
            this.groupBoxInfo.Controls.Add(this.lblRoomNumValue);
            this.groupBoxInfo.Controls.Add(this.lblRoomNumLabel);
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.groupBoxInfo.Location = new System.Drawing.Point(18, 18);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(480, 100);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Room Information";
            // 
            // lblRoomNumLabel
            // 
            this.lblRoomNumLabel.AutoSize = true;
            this.lblRoomNumLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRoomNumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblRoomNumLabel.Location = new System.Drawing.Point(15, 32);
            this.lblRoomNumLabel.Name = "lblRoomNumLabel";
            this.lblRoomNumLabel.Size = new System.Drawing.Size(98, 17);
            this.lblRoomNumLabel.TabIndex = 0;
            this.lblRoomNumLabel.Text = "Room Number:";
            // 
            // lblRoomNumValue
            // 
            this.lblRoomNumValue.AutoSize = true;
            this.lblRoomNumValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRoomNumValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoomNumValue.Location = new System.Drawing.Point(120, 32);
            this.lblRoomNumValue.Name = "lblRoomNumValue";
            this.lblRoomNumValue.Size = new System.Drawing.Size(16, 17);
            this.lblRoomNumValue.TabIndex = 1;
            this.lblRoomNumValue.Text = "--";
            // 
            // lblTypeLabel
            // 
            this.lblTypeLabel.AutoSize = true;
            this.lblTypeLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTypeLabel.Location = new System.Drawing.Point(250, 32);
            this.lblTypeLabel.Name = "lblTypeLabel";
            this.lblTypeLabel.Size = new System.Drawing.Size(83, 17);
            this.lblTypeLabel.TabIndex = 2;
            this.lblTypeLabel.Text = "Room Type:";
            // 
            // lblTypeValue
            // 
            this.lblTypeValue.AutoSize = true;
            this.lblTypeValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTypeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTypeValue.Location = new System.Drawing.Point(340, 32);
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(16, 17);
            this.lblTypeValue.TabIndex = 3;
            this.lblTypeValue.Text = "--";
            // 
            // lblFloorLabel
            // 
            this.lblFloorLabel.AutoSize = true;
            this.lblFloorLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFloorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblFloorLabel.Location = new System.Drawing.Point(15, 62);
            this.lblFloorLabel.Name = "lblFloorLabel";
            this.lblFloorLabel.Size = new System.Drawing.Size(44, 17);
            this.lblFloorLabel.TabIndex = 4;
            this.lblFloorLabel.Text = "Floor:";
            // 
            // lblFloorValue
            // 
            this.lblFloorValue.AutoSize = true;
            this.lblFloorValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFloorValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFloorValue.Location = new System.Drawing.Point(120, 62);
            this.lblFloorValue.Name = "lblFloorValue";
            this.lblFloorValue.Size = new System.Drawing.Size(16, 17);
            this.lblFloorValue.TabIndex = 5;
            this.lblFloorValue.Text = "--";
            // 
            // lblPriceLabel
            // 
            this.lblPriceLabel.AutoSize = true;
            this.lblPriceLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPriceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblPriceLabel.Location = new System.Drawing.Point(250, 62);
            this.lblPriceLabel.Name = "lblPriceLabel";
            this.lblPriceLabel.Size = new System.Drawing.Size(80, 17);
            this.lblPriceLabel.TabIndex = 6;
            this.lblPriceLabel.Text = "Base Price:";
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPriceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblPriceValue.Location = new System.Drawing.Point(340, 61);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(16, 19);
            this.lblPriceValue.TabIndex = 7;
            this.lblPriceValue.Text = "--";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.lblAreaValue);
            this.groupBoxDetails.Controls.Add(this.lblAreaLabel);
            this.groupBoxDetails.Controls.Add(this.lblViewValue);
            this.groupBoxDetails.Controls.Add(this.lblViewLabel);
            this.groupBoxDetails.Controls.Add(this.lblOccupancyValue);
            this.groupBoxDetails.Controls.Add(this.lblOccupancyLabel);
            this.groupBoxDetails.Controls.Add(this.lblBedValue);
            this.groupBoxDetails.Controls.Add(this.lblBedLabel);
            this.groupBoxDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.groupBoxDetails.Location = new System.Drawing.Point(18, 125);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(480, 100);
            this.groupBoxDetails.TabIndex = 1;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Room Details";
            // 
            // lblBedLabel
            // 
            this.lblBedLabel.AutoSize = true;
            this.lblBedLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblBedLabel.Location = new System.Drawing.Point(15, 32);
            this.lblBedLabel.Name = "lblBedLabel";
            this.lblBedLabel.Size = new System.Drawing.Size(69, 17);
            this.lblBedLabel.TabIndex = 0;
            this.lblBedLabel.Text = "Bed Type:";
            // 
            // lblBedValue
            // 
            this.lblBedValue.AutoSize = true;
            this.lblBedValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBedValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBedValue.Location = new System.Drawing.Point(120, 32);
            this.lblBedValue.Name = "lblBedValue";
            this.lblBedValue.Size = new System.Drawing.Size(16, 17);
            this.lblBedValue.TabIndex = 1;
            this.lblBedValue.Text = "--";
            // 
            // lblOccupancyLabel
            // 
            this.lblOccupancyLabel.AutoSize = true;
            this.lblOccupancyLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOccupancyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblOccupancyLabel.Location = new System.Drawing.Point(250, 32);
            this.lblOccupancyLabel.Name = "lblOccupancyLabel";
            this.lblOccupancyLabel.Size = new System.Drawing.Size(109, 17);
            this.lblOccupancyLabel.TabIndex = 2;
            this.lblOccupancyLabel.Text = "Max Occupancy:";
            // 
            // lblOccupancyValue
            // 
            this.lblOccupancyValue.AutoSize = true;
            this.lblOccupancyValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblOccupancyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOccupancyValue.Location = new System.Drawing.Point(365, 32);
            this.lblOccupancyValue.Name = "lblOccupancyValue";
            this.lblOccupancyValue.Size = new System.Drawing.Size(16, 17);
            this.lblOccupancyValue.TabIndex = 3;
            this.lblOccupancyValue.Text = "--";
            // 
            // lblViewLabel
            // 
            this.lblViewLabel.AutoSize = true;
            this.lblViewLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblViewLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblViewLabel.Location = new System.Drawing.Point(15, 62);
            this.lblViewLabel.Name = "lblViewLabel";
            this.lblViewLabel.Size = new System.Drawing.Size(77, 17);
            this.lblViewLabel.TabIndex = 4;
            this.lblViewLabel.Text = "View Type:";
            // 
            // lblViewValue
            // 
            this.lblViewValue.AutoSize = true;
            this.lblViewValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblViewValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblViewValue.Location = new System.Drawing.Point(120, 62);
            this.lblViewValue.Name = "lblViewValue";
            this.lblViewValue.Size = new System.Drawing.Size(16, 17);
            this.lblViewValue.TabIndex = 5;
            this.lblViewValue.Text = "--";
            // 
            // lblAreaLabel
            // 
            this.lblAreaLabel.AutoSize = true;
            this.lblAreaLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAreaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblAreaLabel.Location = new System.Drawing.Point(250, 62);
            this.lblAreaLabel.Name = "lblAreaLabel";
            this.lblAreaLabel.Size = new System.Drawing.Size(41, 17);
            this.lblAreaLabel.TabIndex = 6;
            this.lblAreaLabel.Text = "Area:";
            // 
            // lblAreaValue
            // 
            this.lblAreaValue.AutoSize = true;
            this.lblAreaValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAreaValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAreaValue.Location = new System.Drawing.Point(365, 62);
            this.lblAreaValue.Name = "lblAreaValue";
            this.lblAreaValue.Size = new System.Drawing.Size(16, 17);
            this.lblAreaValue.TabIndex = 7;
            this.lblAreaValue.Text = "--";
            // 
            // groupBoxFeatures
            // 
            this.groupBoxFeatures.Controls.Add(this.flowLayoutPanelFeatures);
            this.groupBoxFeatures.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxFeatures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.groupBoxFeatures.Location = new System.Drawing.Point(18, 232);
            this.groupBoxFeatures.Name = "groupBoxFeatures";
            this.groupBoxFeatures.Size = new System.Drawing.Size(480, 80);
            this.groupBoxFeatures.TabIndex = 2;
            this.groupBoxFeatures.TabStop = false;
            this.groupBoxFeatures.Text = "Special Features";
            // 
            // flowLayoutPanelFeatures
            // 
            this.flowLayoutPanelFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFeatures.Location = new System.Drawing.Point(3, 22);
            this.flowLayoutPanelFeatures.Name = "flowLayoutPanelFeatures";
            this.flowLayoutPanelFeatures.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.flowLayoutPanelFeatures.Size = new System.Drawing.Size(474, 55);
            this.flowLayoutPanelFeatures.TabIndex = 0;
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.lblDescription);
            this.groupBoxDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.groupBoxDescription.Location = new System.Drawing.Point(18, 319);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(480, 70);
            this.groupBoxDescription.TabIndex = 3;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Description";
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDescription.Location = new System.Drawing.Point(3, 22);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lblDescription.Size = new System.Drawing.Size(474, 45);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "No description available.";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 490);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(520, 50);
            this.panelButtons.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(395, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RoomDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 540);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomDetailsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room Details";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.groupBoxFeatures.ResumeLayout(false);
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblPriceLabel;
        private System.Windows.Forms.Label lblFloorValue;
        private System.Windows.Forms.Label lblFloorLabel;
        private System.Windows.Forms.Label lblTypeValue;
        private System.Windows.Forms.Label lblTypeLabel;
        private System.Windows.Forms.Label lblRoomNumValue;
        private System.Windows.Forms.Label lblRoomNumLabel;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label lblAreaValue;
        private System.Windows.Forms.Label lblAreaLabel;
        private System.Windows.Forms.Label lblViewValue;
        private System.Windows.Forms.Label lblViewLabel;
        private System.Windows.Forms.Label lblOccupancyValue;
        private System.Windows.Forms.Label lblOccupancyLabel;
        private System.Windows.Forms.Label lblBedValue;
        private System.Windows.Forms.Label lblBedLabel;
        private System.Windows.Forms.GroupBox groupBoxFeatures;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFeatures;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClose;
    }
}
