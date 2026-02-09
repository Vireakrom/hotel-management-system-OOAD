using HotelManagementSystem.DAL;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.UI;
using HotelManagementSystem.UI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test database connection
            if (!DatabaseManager.Instance.TestConnection())
            {
                MessageBox.Show("Cannot connect to database. Please check your connection string.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show login form
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Login successful
                MessageBox.Show(
                    $"Welcome, {SessionManager.CurrentUser.FullName}!\n\n" +
                    $"Role: {SessionManager.CurrentUser.Role}\n" +
                    $"Last Login: {SessionManager.CurrentUser.LastLogin?.ToString("MMM dd, yyyy hh:mm tt") ?? "First login"}",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // TODO: Day 4 - Open MainForm (MDI container) here
                Application.Run(new MainForm());
                // Start with LoginForm


                // For now, just exit
                Application.Exit();
            }
            else
            {
                // User cancelled login
                Application.Exit();
            }
        }
    }
}
