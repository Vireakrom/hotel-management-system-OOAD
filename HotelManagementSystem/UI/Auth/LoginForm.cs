using HotelManagementSystem.DAL;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Models;
using HotelManagementSystem.Testing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Auth
{
    public partial class LoginForm : Form
    {
        private UserRepository userRepo;
        public LoginForm()
        {
            InitializeComponent();
            userRepo = new UserRepository();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            // Hide previous error
            lblError.Visible = false;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Please enter username");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Please enter password");
                txtPassword.Focus();
                return;
            }

            try
            {
                // Attempt authentication
                User user = userRepo.Authenticate(txtUsername.Text.Trim(), txtPassword.Text);

                if (user != null)
                {
                    // Set current user in session
                    SessionManager.CurrentUser = user;

                    // Close login form with success
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError("Invalid username or password");
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Login error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
