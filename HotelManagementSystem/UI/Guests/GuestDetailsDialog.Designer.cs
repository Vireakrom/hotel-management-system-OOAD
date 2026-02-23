namespace HotelManagementSystem.UI.Guests
{
    partial class GuestDetailsDialog
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
            this.lblStatusBadge = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxRegistration = new System.Windows.Forms.GroupBox();
            this.lblModifiedValue = new System.Windows.Forms.Label();
            this.lblModifiedLabel = new System.Windows.Forms.Label();
            this.lblRegisteredValue = new System.Windows.Forms.Label();
            this.lblRegisteredLabel = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.groupBoxAdditional = new System.Windows.Forms.GroupBox();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.lblNationalityValue = new System.Windows.Forms.Label();
            this.lblNationalityLabel = new System.Windows.Forms.Label();
            this.lblDobValue = new System.Windows.Forms.Label();
            this.lblDobLabel = new System.Windows.Forms.Label();
            this.groupBoxPersonal = new System.Windows.Forms.GroupBox();
            this.lblIdNumberValue = new System.Windows.Forms.Label();
            this.lblIdNumberLabel = new System.Windows.Forms.Label();
            this.lblPhoneValue = new System.Windows.Forms.Label();
            this.lblPhoneLabel = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblEmailLabel = new System.Windows.Forms.Label();
            this.lblNameValue = new System.Windows.Forms.Label();
            this.lblNameLabel = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupBoxRegistration.SuspendLayout();
            this.groupBoxAdditional.SuspendLayout();
            this.groupBoxPersonal.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.panelTop.Controls.Add(this.lblStatusBadge);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(520, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblStatusBadge
            // 
            this.lblStatusBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusBadge.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatusBadge.ForeColor = System.Drawing.Color.White;
            this.lblStatusBadge.Location = new System.Drawing.Point(350, 22);
            this.lblStatusBadge.Name = "lblStatusBadge";
            this.lblStatusBadge.Size = new System.Drawing.Size(155, 25);
            this.lblStatusBadge.TabIndex = 1;
            this.lblStatusBadge.Text = "ACTIVE";
            this.lblStatusBadge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblTitle.Text = "Guest Details";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.groupBoxRegistration);
            this.panelContent.Controls.Add(this.groupBoxAdditional);
            this.panelContent.Controls.Add(this.groupBoxPersonal);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(520, 390);
            this.panelContent.TabIndex = 1;
            // 
            // groupBoxPersonal
            // 
            this.groupBoxPersonal.Controls.Add(this.lblIdNumberValue);
            this.groupBoxPersonal.Controls.Add(this.lblIdNumberLabel);
            this.groupBoxPersonal.Controls.Add(this.lblPhoneValue);
            this.groupBoxPersonal.Controls.Add(this.lblPhoneLabel);
            this.groupBoxPersonal.Controls.Add(this.lblEmailValue);
            this.groupBoxPersonal.Controls.Add(this.lblEmailLabel);
            this.groupBoxPersonal.Controls.Add(this.lblNameValue);
            this.groupBoxPersonal.Controls.Add(this.lblNameLabel);
            this.groupBoxPersonal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxPersonal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.groupBoxPersonal.Location = new System.Drawing.Point(18, 18);
            this.groupBoxPersonal.Name = "groupBoxPersonal";
            this.groupBoxPersonal.Size = new System.Drawing.Size(480, 100);
            this.groupBoxPersonal.TabIndex = 0;
            this.groupBoxPersonal.TabStop = false;
            this.groupBoxPersonal.Text = "Personal Information";
            // 
            // lblNameLabel
            // 
            this.lblNameLabel.AutoSize = true;
            this.lblNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblNameLabel.Location = new System.Drawing.Point(15, 32);
            this.lblNameLabel.Name = "lblNameLabel";
            this.lblNameLabel.Size = new System.Drawing.Size(73, 17);
            this.lblNameLabel.TabIndex = 0;
            this.lblNameLabel.Text = "Full Name:";
            // 
            // lblNameValue
            // 
            this.lblNameValue.AutoSize = true;
            this.lblNameValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNameValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNameValue.Location = new System.Drawing.Point(120, 32);
            this.lblNameValue.Name = "lblNameValue";
            this.lblNameValue.Size = new System.Drawing.Size(16, 17);
            this.lblNameValue.TabIndex = 1;
            this.lblNameValue.Text = "--";
            // 
            // lblEmailLabel
            // 
            this.lblEmailLabel.AutoSize = true;
            this.lblEmailLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblEmailLabel.Location = new System.Drawing.Point(250, 32);
            this.lblEmailLabel.Name = "lblEmailLabel";
            this.lblEmailLabel.Size = new System.Drawing.Size(46, 17);
            this.lblEmailLabel.TabIndex = 2;
            this.lblEmailLabel.Text = "Email:";
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.AutoSize = true;
            this.lblEmailValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmailValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblEmailValue.Location = new System.Drawing.Point(310, 32);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(16, 17);
            this.lblEmailValue.TabIndex = 3;
            this.lblEmailValue.Text = "--";
            // 
            // lblPhoneLabel
            // 
            this.lblPhoneLabel.AutoSize = true;
            this.lblPhoneLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblPhoneLabel.Location = new System.Drawing.Point(15, 62);
            this.lblPhoneLabel.Name = "lblPhoneLabel";
            this.lblPhoneLabel.Size = new System.Drawing.Size(51, 17);
            this.lblPhoneLabel.TabIndex = 4;
            this.lblPhoneLabel.Text = "Phone:";
            // 
            // lblPhoneValue
            // 
            this.lblPhoneValue.AutoSize = true;
            this.lblPhoneValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhoneValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPhoneValue.Location = new System.Drawing.Point(120, 62);
            this.lblPhoneValue.Name = "lblPhoneValue";
            this.lblPhoneValue.Size = new System.Drawing.Size(16, 17);
            this.lblPhoneValue.TabIndex = 5;
            this.lblPhoneValue.Text = "--";
            // 
            // lblIdNumberLabel
            // 
            this.lblIdNumberLabel.AutoSize = true;
            this.lblIdNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIdNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblIdNumberLabel.Location = new System.Drawing.Point(250, 62);
            this.lblIdNumberLabel.Name = "lblIdNumberLabel";
            this.lblIdNumberLabel.Size = new System.Drawing.Size(80, 17);
            this.lblIdNumberLabel.TabIndex = 6;
            this.lblIdNumberLabel.Text = "ID Number:";
            // 
            // lblIdNumberValue
            // 
            this.lblIdNumberValue.AutoSize = true;
            this.lblIdNumberValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblIdNumberValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblIdNumberValue.Location = new System.Drawing.Point(340, 62);
            this.lblIdNumberValue.Name = "lblIdNumberValue";
            this.lblIdNumberValue.Size = new System.Drawing.Size(16, 17);
            this.lblIdNumberValue.TabIndex = 7;
            this.lblIdNumberValue.Text = "--";
            // 
            // groupBoxAdditional
            // 
            this.groupBoxAdditional.Controls.Add(this.lblAddressValue);
            this.groupBoxAdditional.Controls.Add(this.lblAddressLabel);
            this.groupBoxAdditional.Controls.Add(this.lblNationalityValue);
            this.groupBoxAdditional.Controls.Add(this.lblNationalityLabel);
            this.groupBoxAdditional.Controls.Add(this.lblDobValue);
            this.groupBoxAdditional.Controls.Add(this.lblDobLabel);
            this.groupBoxAdditional.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxAdditional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.groupBoxAdditional.Location = new System.Drawing.Point(18, 125);
            this.groupBoxAdditional.Name = "groupBoxAdditional";
            this.groupBoxAdditional.Size = new System.Drawing.Size(480, 110);
            this.groupBoxAdditional.TabIndex = 1;
            this.groupBoxAdditional.TabStop = false;
            this.groupBoxAdditional.Text = "Additional Details";
            // 
            // lblDobLabel
            // 
            this.lblDobLabel.AutoSize = true;
            this.lblDobLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDobLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblDobLabel.Location = new System.Drawing.Point(15, 32);
            this.lblDobLabel.Name = "lblDobLabel";
            this.lblDobLabel.Size = new System.Drawing.Size(97, 17);
            this.lblDobLabel.TabIndex = 0;
            this.lblDobLabel.Text = "Date of Birth:";
            // 
            // lblDobValue
            // 
            this.lblDobValue.AutoSize = true;
            this.lblDobValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDobValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDobValue.Location = new System.Drawing.Point(120, 32);
            this.lblDobValue.Name = "lblDobValue";
            this.lblDobValue.Size = new System.Drawing.Size(16, 17);
            this.lblDobValue.TabIndex = 1;
            this.lblDobValue.Text = "--";
            // 
            // lblNationalityLabel
            // 
            this.lblNationalityLabel.AutoSize = true;
            this.lblNationalityLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNationalityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblNationalityLabel.Location = new System.Drawing.Point(250, 32);
            this.lblNationalityLabel.Name = "lblNationalityLabel";
            this.lblNationalityLabel.Size = new System.Drawing.Size(84, 17);
            this.lblNationalityLabel.TabIndex = 2;
            this.lblNationalityLabel.Text = "Nationality:";
            // 
            // lblNationalityValue
            // 
            this.lblNationalityValue.AutoSize = true;
            this.lblNationalityValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNationalityValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNationalityValue.Location = new System.Drawing.Point(340, 32);
            this.lblNationalityValue.Name = "lblNationalityValue";
            this.lblNationalityValue.Size = new System.Drawing.Size(16, 17);
            this.lblNationalityValue.TabIndex = 3;
            this.lblNationalityValue.Text = "--";
            // 
            // lblAddressLabel
            // 
            this.lblAddressLabel.AutoSize = true;
            this.lblAddressLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAddressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblAddressLabel.Location = new System.Drawing.Point(15, 62);
            this.lblAddressLabel.Name = "lblAddressLabel";
            this.lblAddressLabel.Size = new System.Drawing.Size(63, 17);
            this.lblAddressLabel.TabIndex = 4;
            this.lblAddressLabel.Text = "Address:";
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAddressValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAddressValue.Location = new System.Drawing.Point(120, 62);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(345, 38);
            this.lblAddressValue.TabIndex = 5;
            this.lblAddressValue.Text = "--";
            // 
            // groupBoxRegistration
            // 
            this.groupBoxRegistration.Controls.Add(this.lblModifiedValue);
            this.groupBoxRegistration.Controls.Add(this.lblModifiedLabel);
            this.groupBoxRegistration.Controls.Add(this.lblRegisteredValue);
            this.groupBoxRegistration.Controls.Add(this.lblRegisteredLabel);
            this.groupBoxRegistration.Controls.Add(this.lblStatusValue);
            this.groupBoxRegistration.Controls.Add(this.lblStatusLabel);
            this.groupBoxRegistration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxRegistration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.groupBoxRegistration.Location = new System.Drawing.Point(18, 242);
            this.groupBoxRegistration.Name = "groupBoxRegistration";
            this.groupBoxRegistration.Size = new System.Drawing.Size(480, 100);
            this.groupBoxRegistration.TabIndex = 2;
            this.groupBoxRegistration.TabStop = false;
            this.groupBoxRegistration.Text = "Registration Info";
            // 
            // lblRegisteredLabel
            // 
            this.lblRegisteredLabel.AutoSize = true;
            this.lblRegisteredLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRegisteredLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblRegisteredLabel.Location = new System.Drawing.Point(15, 32);
            this.lblRegisteredLabel.Name = "lblRegisteredLabel";
            this.lblRegisteredLabel.Size = new System.Drawing.Size(79, 17);
            this.lblRegisteredLabel.TabIndex = 0;
            this.lblRegisteredLabel.Text = "Registered:";
            // 
            // lblRegisteredValue
            // 
            this.lblRegisteredValue.AutoSize = true;
            this.lblRegisteredValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRegisteredValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRegisteredValue.Location = new System.Drawing.Point(120, 32);
            this.lblRegisteredValue.Name = "lblRegisteredValue";
            this.lblRegisteredValue.Size = new System.Drawing.Size(16, 17);
            this.lblRegisteredValue.TabIndex = 1;
            this.lblRegisteredValue.Text = "--";
            // 
            // lblModifiedLabel
            // 
            this.lblModifiedLabel.AutoSize = true;
            this.lblModifiedLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblModifiedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblModifiedLabel.Location = new System.Drawing.Point(250, 32);
            this.lblModifiedLabel.Name = "lblModifiedLabel";
            this.lblModifiedLabel.Size = new System.Drawing.Size(98, 17);
            this.lblModifiedLabel.TabIndex = 2;
            this.lblModifiedLabel.Text = "Last Modified:";
            // 
            // lblModifiedValue
            // 
            this.lblModifiedValue.AutoSize = true;
            this.lblModifiedValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblModifiedValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblModifiedValue.Location = new System.Drawing.Point(355, 32);
            this.lblModifiedValue.Name = "lblModifiedValue";
            this.lblModifiedValue.Size = new System.Drawing.Size(16, 17);
            this.lblModifiedValue.TabIndex = 3;
            this.lblModifiedValue.Text = "--";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblStatusLabel.Location = new System.Drawing.Point(15, 62);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(52, 17);
            this.lblStatusLabel.TabIndex = 4;
            this.lblStatusLabel.Text = "Status:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblStatusValue.Location = new System.Drawing.Point(120, 62);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(16, 17);
            this.lblStatusValue.TabIndex = 5;
            this.lblStatusValue.Text = "--";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 460);
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
            // GuestDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 510);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuestDetailsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Guest Details";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.groupBoxRegistration.ResumeLayout(false);
            this.groupBoxRegistration.PerformLayout();
            this.groupBoxAdditional.ResumeLayout(false);
            this.groupBoxAdditional.PerformLayout();
            this.groupBoxPersonal.ResumeLayout(false);
            this.groupBoxPersonal.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblStatusBadge;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupBoxPersonal;
        private System.Windows.Forms.Label lblIdNumberValue;
        private System.Windows.Forms.Label lblIdNumberLabel;
        private System.Windows.Forms.Label lblPhoneValue;
        private System.Windows.Forms.Label lblPhoneLabel;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Label lblEmailLabel;
        private System.Windows.Forms.Label lblNameValue;
        private System.Windows.Forms.Label lblNameLabel;
        private System.Windows.Forms.GroupBox groupBoxAdditional;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblAddressLabel;
        private System.Windows.Forms.Label lblNationalityValue;
        private System.Windows.Forms.Label lblNationalityLabel;
        private System.Windows.Forms.Label lblDobValue;
        private System.Windows.Forms.Label lblDobLabel;
        private System.Windows.Forms.GroupBox groupBoxRegistration;
        private System.Windows.Forms.Label lblModifiedValue;
        private System.Windows.Forms.Label lblModifiedLabel;
        private System.Windows.Forms.Label lblRegisteredValue;
        private System.Windows.Forms.Label lblRegisteredLabel;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClose;
    }
}
