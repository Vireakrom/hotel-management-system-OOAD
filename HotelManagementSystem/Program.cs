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
        internal static bool ShouldRestartWithLogin = false;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test database connection
            if (!DatabaseManager.Instance.TestConnection(out string dbError))
            {
                MessageBox.Show(
                    $"Unable to connect to the database.\n\n{dbError}",
                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (true)
            {
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() != DialogResult.OK)
                    break;

                ShouldRestartWithLogin = false;
                Application.Run(new MainForm());

                if (!ShouldRestartWithLogin)
                    break;
            }
        }
    }
}
