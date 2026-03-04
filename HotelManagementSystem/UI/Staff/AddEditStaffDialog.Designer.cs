namespace HotelManagementSystem.UI.Staff
{
    partial class AddEditStaffDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordHint = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(480, 55);
            this.panelTop.TabIndex = 0;
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Staff Member";
            // panelContent
            this.panelContent.Controls.Add(this.lblPasswordHint);
            this.panelContent.Controls.Add(this.txtConfirmPassword);
            this.panelContent.Controls.Add(this.lblConfirmPassword);
            this.panelContent.Controls.Add(this.txtPassword);
            this.panelContent.Controls.Add(this.lblPassword);
            this.panelContent.Controls.Add(this.cmbRole);
            this.panelContent.Controls.Add(this.lblRole);
            this.panelContent.Controls.Add(this.txtPhone);
            this.panelContent.Controls.Add(this.lblPhone);
            this.panelContent.Controls.Add(this.txtEmail);
            this.panelContent.Controls.Add(this.lblEmail);
            this.panelContent.Controls.Add(this.txtUsername);
            this.panelContent.Controls.Add(this.lblUsername);
            this.panelContent.Controls.Add(this.txtLastName);
            this.panelContent.Controls.Add(this.lblLastName);
            this.panelContent.Controls.Add(this.txtFirstName);
            this.panelContent.Controls.Add(this.lblFirstName);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 55);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.panelContent.Size = new System.Drawing.Size(480, 390);
            this.panelContent.TabIndex = 1;
            // -- Row 1: First Name --
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.Location = new System.Drawing.Point(20, 20);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name *";
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFirstName.Location = new System.Drawing.Point(20, 40);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 26);
            this.txtFirstName.TabIndex = 1;
            // -- Row 1: Last Name --
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLastName.Location = new System.Drawing.Point(240, 20);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name *";
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtLastName.Location = new System.Drawing.Point(240, 40);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 26);
            this.txtLastName.TabIndex = 3;
            // -- Row 2: Username --
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(20, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username *";
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtUsername.Location = new System.Drawing.Point(20, 100);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 26);
            this.txtUsername.TabIndex = 5;
            // -- Row 2: Role --
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(240, 80);
            this.lblRole.Name = "lblRole";
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "Role *";
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbRole.Location = new System.Drawing.Point(240, 100);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(200, 27);
            this.cmbRole.TabIndex = 7;
            // -- Row 3: Email --
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(20, 142);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtEmail.Location = new System.Drawing.Point(20, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(420, 26);
            this.txtEmail.TabIndex = 9;
            // -- Row 4: Phone --
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Location = new System.Drawing.Point(20, 202);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Phone";
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtPhone.Location = new System.Drawing.Point(20, 222);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 26);
            this.txtPhone.TabIndex = 11;
            // -- Row 5: Password --
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(20, 262);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password *";
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtPassword.Location = new System.Drawing.Point(20, 282);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 26);
            this.txtPassword.TabIndex = 13;
            // -- Row 5: Confirm Password --
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPassword.Location = new System.Drawing.Point(240, 262);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.TabIndex = 14;
            this.lblConfirmPassword.Text = "Confirm Password *";
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(240, 282);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 26);
            this.txtConfirmPassword.TabIndex = 15;
            // lblPasswordHint
            this.lblPasswordHint.AutoSize = true;
            this.lblPasswordHint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblPasswordHint.ForeColor = System.Drawing.Color.Gray;
            this.lblPasswordHint.Location = new System.Drawing.Point(20, 316);
            this.lblPasswordHint.Name = "lblPasswordHint";
            this.lblPasswordHint.TabIndex = 16;
            this.lblPasswordHint.Text = "Leave password blank to keep existing password (edit mode).";
            // panelButtons
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 390);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(480, 60);
            this.panelButtons.TabIndex = 2;
            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(280, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(380, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // AddEditStaffDialog
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditStaffDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Staff Member";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblPasswordHint;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
