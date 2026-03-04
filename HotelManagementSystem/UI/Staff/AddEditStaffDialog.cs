using HotelManagementSystem.DAL;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Staff
{
    public partial class AddEditStaffDialog : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private User _currentUser;
        private bool _isEditMode;

        private static readonly string[] Roles = { "Admin", "Manager", "FrontDesk", "Housekeeping" };

        public AddEditStaffDialog()
        {
            InitializeComponent();
            _isEditMode = false;
            this.Load += AddEditStaffDialog_Load;
        }

        public AddEditStaffDialog(User user) : this()
        {
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            _isEditMode = true;
        }

        private void AddEditStaffDialog_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(Roles);

            if (_isEditMode)
            {
                this.Text = "Edit Staff Member";
                lblTitle.Text = "Edit Staff Member";
                btnSave.Text = "Update";
                lblPassword.Text = "New Password";
                lblConfirmPassword.Text = "Confirm New Password";
                // Username cannot be changed to avoid login issues
                txtUsername.Enabled = false;
                LoadUserData();
            }
            else
            {
                this.Text = "Add Staff Member";
                lblTitle.Text = "Add Staff Member";
                btnSave.Text = "Add Staff";
                lblPasswordHint.Visible = false;
            }
        }

        private void LoadUserData()
        {
            txtFirstName.Text = _currentUser.FirstName;
            txtLastName.Text = _currentUser.LastName;
            txtUsername.Text = _currentUser.Username;
            txtEmail.Text = _currentUser.Email ?? "";
            txtPhone.Text = _currentUser.Phone ?? "";

            int roleIndex = Array.IndexOf(Roles, _currentUser.Role);
            cmbRole.SelectedIndex = roleIndex >= 0 ? roleIndex : 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string error))
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_isEditMode)
                    SaveEdit();
                else
                    SaveNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving staff: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveNew()
        {
            var user = new User
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName  = txtLastName.Text.Trim(),
                Username  = txtUsername.Text.Trim(),
                Email     = txtEmail.Text.Trim(),
                Phone     = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                Role      = cmbRole.SelectedItem.ToString(),
                // PasswordHash is used as the plain-text input; UserRepository.Insert hashes it
                PasswordHash = txtPassword.Text,
                IsActive  = true
            };

            int newId = _userRepo.Insert(user);
            if (newId > 0)
            {
                MessageBox.Show($"Staff member added successfully!\nID: {newId}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add staff member.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveEdit()
        {
            _currentUser.FirstName = txtFirstName.Text.Trim();
            _currentUser.LastName  = txtLastName.Text.Trim();
            _currentUser.Email     = txtEmail.Text.Trim();
            _currentUser.Phone     = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim();
            _currentUser.Role      = cmbRole.SelectedItem.ToString();

            bool success = _userRepo.Update(_currentUser);

            // If a new password was entered, update it separately
            if (success && !string.IsNullOrWhiteSpace(txtPassword.Text))
                _userRepo.UpdatePassword(_currentUser.UserId, txtPassword.Text);

            if (success)
            {
                MessageBox.Show("Staff member updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update staff member.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput(out string error)
        {
            error = string.Empty;

            if (!ValidationHelper.ValidateRequired(txtFirstName, "First name", out error)) return false;
            if (!ValidationHelper.ValidateMinLength(txtFirstName, "First name", 2, out error)) return false;

            if (!ValidationHelper.ValidateRequired(txtLastName, "Last name", out error)) return false;
            if (!ValidationHelper.ValidateMinLength(txtLastName, "Last name", 2, out error)) return false;

            if (!_isEditMode)
            {
                if (!ValidationHelper.ValidateRequired(txtUsername, "Username", out error)) return false;
                if (!ValidationHelper.ValidateMinLength(txtUsername, "Username", 3, out error)) return false;
            }

            if (!ValidationHelper.ValidateRequired(cmbRole, "Role", out error)) return false;

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                if (!ValidationHelper.ValidateEmail(txtEmail, out error)) return false;

            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
                if (!ValidationHelper.ValidatePhone(txtPhone, out error)) return false;

            // Password required for new users; optional for edit
            bool hasPassword = !string.IsNullOrWhiteSpace(txtPassword.Text);

            if (!_isEditMode && !hasPassword)
            {
                error = "Password is required for new staff members.";
                txtPassword.Focus();
                return false;
            }

            if (hasPassword)
            {
                if (txtPassword.Text.Length < 6)
                {
                    error = "Password must be at least 6 characters.";
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    error = "Passwords do not match.";
                    txtConfirmPassword.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
