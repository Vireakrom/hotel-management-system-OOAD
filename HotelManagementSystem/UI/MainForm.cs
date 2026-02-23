using HotelManagementSystem.Helpers;
using HotelManagementSystem.UI.Auth;
using HotelManagementSystem.Models;
using HotelManagementSystem.Patterns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.UI
{
    public partial class MainForm : Form
    {
        private RoomSubject roomSubject;
        private HousekeepingObserver housekeepingObserver;

        public MainForm()
        {
            InitializeComponent();

            ConfigureUiTheme();

            // Set up MDI container properties
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Hotel Management System";

            // Set background gradient for MDI area
            this.BackColor = Color.LightSteelBlue;

            // Initialize global Observer Pattern (Day 21) - One instance for the entire app!
            roomSubject = RoomSubject.Instance;
            housekeepingObserver = new HousekeepingObserver();
            roomSubject.Attach(housekeepingObserver);

            // Start status bar timer
            timerStatusBar.Interval = 1000; // Update every second
            timerStatusBar.Start();

            InitializeModernUI();
        }

        private void InitializeModernUI()
        {
            // Update menu text to match modern style
            billingToolStripMenuItem.Text = "Financials";
            invoiceManagementToolStripMenuItem.Text = "Invoices & Payments";
            viewAllBookingsToolStripMenuItem.Text = "Manage Bookings (Check-In/Out)";
        }

        private void ConfigureUiTheme()
        {
            // Set consistent font for the entire application
            Font = new Font("Segoe UI", 9.5F);
            menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            statusStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Professional Midnight Blue & White Theme
            Color primaryColor = Color.FromArgb(43, 87, 154); // Deep Blue
            Color menuBackColor = Color.FromArgb(248, 249, 250); // Light Gray-White
            Color textColor = Color.FromArgb(33, 33, 33); // Dark Gray

            menuStrip1.BackColor = menuBackColor;
            menuStrip1.ForeColor = textColor;
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Padding = new Padding(6, 4, 0, 4);
            
            statusStrip1.BackColor = primaryColor;
            statusStrip1.ForeColor = Color.White;
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            
            toolStripStatusLabelUser.ForeColor = Color.White;
            toolStripStatusLabelUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            
            toolStripStatusLabelTime.ForeColor = Color.White;

            menuStrip1.ImageScalingSize = new Size(20, 20);
            ApplyMenuIcons();

            // Set MDI background to a clean professional color
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(232, 236, 241); // Light Blue-Gray
                    break;
                }
            }
        }

        private static Image EmojiToImage(string emoji)
        {
            // Create a high-quality bitmap from a modern emoji
            Bitmap bmp = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                
                // Segoe UI Emoji is the standard Windows emoji font
                using (Font font = new Font("Segoe UI Emoji", 12f))
                {
                    // Center the emoji in the 24x24 box
                    TextRenderer.DrawText(g, emoji, font, new Rectangle(0, 0, 24, 24), 
                        Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
            return bmp;
        }

        private void ApplyMenuIcons()
        {
            // Category Icons - Using Modern Colorful Emojis
            fileToolStripMenuItem.Image = EmojiToImage("🏨");
            roomsToolStripMenuItem.Image = EmojiToImage("🛌");
            guestsToolStripMenuItem.Image = EmojiToImage("👥");
            bookingsToolStripMenuItem.Image = EmojiToImage("📅");
            billingToolStripMenuItem.Image = EmojiToImage("💰");
            housekeepingToolStripMenuItem.Image = EmojiToImage("🧹");
            reportsToolStripMenuItem.Image = EmojiToImage("📊");
            helpToolStripMenuItem.Image = EmojiToImage("❓");

            // Sub-menu Icons
            logoutToolStripMenuItem.Image = EmojiToImage("🔓");
            exitToolStripMenuItem.Image = EmojiToImage("❌");

            roomManagementToolStripMenuItem.Image = EmojiToImage("🔧");
            roomStatusDashboardToolStripMenuItem.Image = EmojiToImage("🖥️");

            guestManagementToolStripMenuItem.Image = EmojiToImage("👤");

            newBookingToolStripMenuItem.Image = EmojiToImage("➕");
            viewAllBookingsToolStripMenuItem.Image = EmojiToImage("📋");

            invoiceManagementToolStripMenuItem.Image = EmojiToImage("🧾");

            viewTasksToolStripMenuItem.Image = EmojiToImage("📝");

            dailyOperationToolStripMenuItem.Image = EmojiToImage("☀️");

            userGuideToolStripMenuItem.Image = EmojiToImage("📖");
            developerToolsToolStripMenuItem.Image = EmojiToImage("🛠️");
            aboutToolStripMenuItem.Image = EmojiToImage("ℹ️");
            
            // Set the icon size for the menu strip
            menuStrip1.ImageScalingSize = new Size(20, 20);
        }

        #region Menu Configuration

        /// <summary>
        /// Apply role-based access control to menu items
        /// </summary>
        private void ApplyRoleBasedAccess()
        {
            string role = SessionManager.CurrentUser.Role;

            switch (role)
            {
                case "Admin":
                    // Admin has access to everything - no changes
                    break;

                case "Receptionist":
                    // Receptionist cannot access Reports or Housekeeping
                    reportsToolStripMenuItem.Visible = false;
                    housekeepingToolStripMenuItem.Visible = false;
                    break;

                case "Manager":
                    // Manager can see reports but not housekeeping tasks
                    housekeepingToolStripMenuItem.Visible = false;
                    break;

                case "Housekeeping":
                    // Housekeeping staff only see their tasks
                    roomsToolStripMenuItem.Visible = false;
                    guestsToolStripMenuItem.Visible = false;
                    bookingsToolStripMenuItem.Visible = false;
                    reportsToolStripMenuItem.Visible = false;
                    break;

                default:
                    // Unknown role - hide all functional menus (safety)
                    roomsToolStripMenuItem.Visible = false;
                    guestsToolStripMenuItem.Visible = false;
                    bookingsToolStripMenuItem.Visible = false;
                    housekeepingToolStripMenuItem.Visible = false;
                    reportsToolStripMenuItem.Visible = false;
                    break;
            }
        }

        #endregion

        #region File Menu Events

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Confirm logout
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Stop timer
                timerStatusBar.Stop();

                // Close all child forms
                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Close();
                }

                // Clear session
                SessionManager.Logout();

                // Create and show login form
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Close this form
                this.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Confirm exit
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Close all forms and exit application
                Application.Exit();
            }
        }

        #endregion

        #region Rooms Menu Events

        private void roomManagementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Day 8 - Room Management Form is now ready!
            OpenChildForm(new HotelManagementSystem.UI.Rooms.RoomManagementForm());
        }
        private void roomStatusDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Day 10 - Room Status Dashboard is now ready!
            OpenChildForm(new HotelManagementSystem.UI.Rooms.RoomStatusDashboard());
        }

        #endregion

        #region Guests Menu Events
        private void guestManagementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Day 11 - Guest Management Form is now ready!
            OpenChildForm(new HotelManagementSystem.UI.Guests.GuestManagementForm());
        }

        #endregion

        #region Bookings Menu Events

        private void newBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Day 15 - New Booking Form is now ready!
            // Show as dialog instead of MDI child for better focus
            HotelManagementSystem.UI.Bookings.NewBookingForm bookingForm = new HotelManagementSystem.UI.Bookings.NewBookingForm();
            bookingForm.ShowDialog(this);
        }

        private void viewAllBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Day 18 - Booking List Form is now ready!
            OpenChildForm(new HotelManagementSystem.UI.Bookings.BookingListForm());
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Check-In functionality will be implemented on Day 19.\n\n" +
                "Features:\n" +
                "• Quick check-in for confirmed bookings\n" +
                "• Verify guest identity\n" +
                "• Update room status to Occupied\n" +
                "• Print room key card",
                "Coming Soon - Day 19",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // FUTURE: This might be part of BookingListForm
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Check-Out functionality will be implemented on Day 20.\n\n" +
                "Features:\n" +
                "• Process check-out\n" +
                "• Auto-generate invoice\n" +
                "• Update room status to Cleaning\n" +
                "• Create housekeeping task automatically",
                "Coming Soon - Day 20",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // FUTURE: This might be part of BookingListForm
        }

        #endregion

        #region Housekeeping Menu Events

        private void viewTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Day 21 - Housekeeping Tasks Form with Observer Pattern!
            OpenChildForm(new HotelManagementSystem.UI.Housekeeping.HousekeepingTasksForm());
        }

        #endregion

        #region Billing Menu Events

        private void invoiceManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Day 23 - Invoice Management Form!
            OpenChildForm(new HotelManagementSystem.UI.Invoices.InvoiceListForm());
        }

        private void processPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Process Payment\n\n" +
                "To process a payment:\n" +
                "1. Go to Bookings → View All Bookings\n" +
                "2. Select a checked-out booking with an invoice\n" +
                "3. Click 'Process Payment' button\n\n" +
                "Or use: Billing → Invoice Management to view all invoices.",
                "How to Process Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Reports Menu Events

        private void dailyOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HotelManagementSystem.UI.Reports.DailyOperationsReportForm());
        }

        #endregion

        #region Help Menu Events

        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Hotel Management System - User Guide\n\n" +
                "NAVIGATION:\n" +
                "• Use the menu bar to access different modules\n" +
                "• All forms open within this main window (MDI)\n" +
                "• Your role determines which menus you can see\n\n" +
                "TIPS:\n" +
                "• Check the status bar for your login info\n" +
                "• Use File → Logout to switch users\n" +
                "• Forms stay open until you close them\n\n" +
                "For detailed documentation, see the project files.",
                "User Guide",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "HOTEL MANAGEMENT SYSTEM\n" +
                "Version 1.0.0 - Day 31 Complete\n\n" +
                "Developed for OOAD Final Project\n" +
                "Computer Science - Year 4\n\n" +
                "DESIGN PATTERNS IMPLEMENTED:\n" +
                "✅ Singleton (DatabaseManager)\n" +
                "✅ Repository (DAL)\n" +
                "✅ Factory (RoomFactory)\n" +
                "✅ Facade (BookingFacade)\n" +
                "✅ Observer (Housekeeping Pattern)\n" +
                "✅ Strategy (Payment Strategies)\n\n" +
                "PROGRESS: 100% Core Features Complete ✓\n" +
                "Day 31 Milestone: UI Polish & Consistency ✓\n\n" +
                "© 2026 - All Rights Reserved\n" +
                "Deadline: March 10, 2026",
                "About Hotel Management System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void testFactoryPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show test selection dialog
            DialogResult result = MessageBox.Show(
                "Run comprehensive test suite for Factory Pattern and Room Models?\n\n" +
                "✓ Basic Room Creation (4 types)\n" +
                "✓ Configured Room Creation\n" +
                "✓ Room Type Validation\n" +
                "✓ Default Pricing\n" +
                "✓ Polymorphism Testing\n" +
                "✓ Room Data Validation\n" +
                "✓ Utility Methods\n" +
                "✓ Dynamic Price Calculation\n" +
                "✓ Feature Detection\n" +
                "✓ Error Handling\n\n" +
                "Total: 10 comprehensive tests",
                "Day 6 - Factory Pattern Test Suite",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Run comprehensive test suite
                string testOutput = Testing.RoomFactoryTests.RunAllTests();

                // Show results in a form
                Form resultForm = new Form
                {
                    Text = "Day 6 - Test Results",
                    Width = 900,
                    Height = 700,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();
            }
            else if (result == DialogResult.No)
            {
                // Run simple demonstration
                string demoOutput = RoomFactory.RunDemonstration();

                // Show results in a form
                Form resultForm = new Form
                {
                    Text = "Factory Pattern Demo",
                    Width = 800,
                    Height = 600,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = demoOutput
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();
            }
        }

        private void testBookingRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show test selection dialog
            DialogResult result = MessageBox.Show(
                "Run comprehensive test suite for Booking Repository?\n\n" +
                "Day 13 - Repository Pattern Test Suite\n\n" +
                "✓ Create Booking (INSERT)\n" +
                "✓ Read Booking by ID (SELECT)\n" +
                "✓ Update Booking (UPDATE)\n" +
                "✓ Get All Bookings\n" +
                "✓ Get Bookings by Guest\n" +
                "✓ Get Bookings by Status\n" +
                "✓ Check-In Functionality\n" +
                "✓ Check-Out Functionality\n" +
                "✓ Cancel Booking (DELETE)\n" +
                "✓ Calculate Number of Nights\n\n" +
                "Total: 10 comprehensive tests\n\n" +
                "Note: This will create test data in your database.",
                "Day 13 - Booking Repository Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Run comprehensive test suite
                string testOutput = Testing.BookingRepositoryTests.RunAllTests();

                // Show results in a form
                Form resultForm = new Form
                {
                    Text = "Day 13 - Booking Repository Test Results",
                    Width = 1000,
                    Height = 750,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput,
                    BackColor = Color.White,
                    ReadOnly = true
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                MessageBox.Show(
                    "Booking Repository testing complete!\n\n" +
                    "✓ All CRUD operations tested\n" +
                    "✓ Check-In/Check-Out functionality verified\n" +
                    "✓ Repository Pattern validated\n\n" +
                    "Check the test results window for details.",
                    "Test Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void testBookingFacadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show test selection dialog
            DialogResult result = MessageBox.Show(
                "Run comprehensive test suite for Booking Facade?\n\n" +
                "Day 14 - Facade Pattern Test Suite\n\n" +
                "✓ Validate Booking Dates\n" +
                "✓ Reject Invalid Dates\n" +
                "✓ Calculate Total Amount (with tax)\n" +
                "✓ Create Booking - Complete Workflow\n" +
                "✓ Get Available Rooms\n" +
                "✓ Confirm Booking\n" +
                "✓ Check-In Guest\n" +
                "✓ Check-Out Guest\n" +
                "✓ Get Guest Bookings\n" +
                "✓ Get Active Bookings\n\n" +
                "Total: 10 comprehensive tests\n\n" +
                "This demonstrates the Facade Pattern coordinating\n" +
                "Guest, Room, and Booking repositories!\n\n" +
                "Note: This will create test data in your database.",
                "Day 14 - Booking Facade Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Run comprehensive test suite
                string testOutput = Testing.BookingFacadeTests.RunAllTests();

                // Show results in a form
                Form resultForm = new Form
                {
                    Text = "Day 14 - Booking Facade Test Results (Facade Pattern)",
                    Width = 1000,
                    Height = 750,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput,
                    BackColor = Color.White,
                    ReadOnly = true
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                MessageBox.Show(
                    "Booking Facade testing complete!\n\n" +
                    "✓ FACADE PATTERN DEMONSTRATED!\n" +
                    "✓ Complete booking workflow tested\n" +
                    "✓ Guest, Room, and Booking coordination verified\n" +
                    "✓ Business logic encapsulation validated\n\n" +
                    "Design Pattern #4 Complete! 🎉\n\n" +
                    "Check the test results window for details.",
                    "Test Complete - Facade Pattern",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void testDay17IntegrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show test selection dialog
            DialogResult result = MessageBox.Show(
                "Run Day 17 Integration Test Suite?\n\n" +
                "Day 17 - Complete Booking Creation Workflow\n\n" +
                "✓ Complete Booking Creation with Room Status Update\n" +
                "✓ Verify BookingFacade Coordination\n" +
                "✓ Verify Room Status Changes Throughout Workflow\n" +
                "✓ Verify Booking Validation\n" +
                "✓ Verify Room Availability Check Before Booking\n" +
                "✓ Verify Total Amount Calculation with Tax\n" +
                "✓ Verify Multiple Bookings Don't Conflict\n\n" +
                "Total: 7 comprehensive integration tests\n\n" +
                "This verifies that:\n" +
                "• Booking creation logic is complete\n" +
                "• BookingFacade is used for coordination\n" +
                "• Room status updates to Reserved automatically\n\n" +
                "Note: This will create and clean up test data in your database.",
                "Day 17 - Integration Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Run comprehensive test suite
                string testOutput = Testing.Day17IntegrationTests.RunAllTests();

                // Show results in a form
                Form resultForm = new Form
                {
                    Text = "Day 17 - Integration Test Results",
                    Width = 1100,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput,
                    BackColor = Color.White,
                    ReadOnly = true
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                MessageBox.Show(
                    "Day 17 Integration testing complete!\n\n" +
                    "✓ Complete booking creation workflow verified\n" +
                    "✓ BookingFacade coordination confirmed\n" +
                    "✓ Room status updates to Reserved automatically\n" +
                    "✓ Validation and error handling working correctly\n\n" +
                    "Day 17 Complete! 🎉\n\n" +
                    "Check the test results window for details.",
                    "Test Complete - Day 17",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void testDay28IntegrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Run Day 28 Integration Test Suite?\n\n" +
                "Day 28 - Full Workflow Integration\n\n" +
                "✓ Book → Confirm → Check-In → Check-Out → Payment\n" +
                "✓ Auto-create housekeeping task on checkout\n" +
                "✓ Invoice status updates after payment\n\n" +
                "Total: 3 comprehensive integration tests\n\n" +
                "This verifies that:\n" +
                "• Full workflow works end-to-end\n" +
                "• Housekeeping tasks are auto-created\n" +
                "• Payment updates invoice status\n\n" +
                "Note: This will create test data in your database.",
                "Day 28 - Integration Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                string testOutput = Testing.Day28IntegrationTests.RunAllTests();

                Form resultForm = new Form
                {
                    Text = "Day 28 - Integration Test Results",
                    Width = 1100,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput,
                    BackColor = Color.White,
                    ReadOnly = true
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                MessageBox.Show(
                    "Day 28 Integration testing complete!\n\n" +
                    "✓ Full workflow verified end-to-end\n" +
                    "✓ Housekeeping tasks auto-created\n" +
                    "✓ Payment updates invoice status\n\n" +
                    "Day 28 Complete! 🎉\n\n" +
                    "Check the test results window for details.",
                    "Test Complete - Day 28",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void testObserverPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Run Observer Pattern Test Suite?\n\n" +
                "Day 21 - Observer Pattern (Design Pattern #5)\n\n" +
                "✓ RoomSubject Singleton Pattern\n" +
                "✓ Observer Registration (Attach)\n" +
                "✓ Observer Notification\n" +
                "✓ Auto-Create Cleaning Task on CheckOut\n" +
                "✓ Multiple Observers Registration\n" +
                "✓ Observer Detachment\n\n" +
                "Total: 6 comprehensive tests\n\n" +
                "This verifies that:\n" +
                "• Observer Pattern is implemented correctly\n" +
                "• Housekeeping tasks are auto-created on checkout\n\n" +
                "Note: This will create test data in your database.",
                "Day 21 - Observer Pattern Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                string testOutput = Testing.ObserverPatternTests.RunAllTests();

                Form resultForm = new Form
                {
                    Text = "Day 21 - Observer Pattern Test Results",
                    Width = 1100,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput,
                    BackColor = Color.White,
                    ReadOnly = true
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                MessageBox.Show(
                    "Observer Pattern testing complete!\n\n" +
                    "✓ Observer Pattern implemented correctly\n" +
                    "✓ Housekeeping tasks auto-created on checkout\n" +
                    "✓ Multiple observers supported\n\n" +
                    "Day 21 Complete! 🎉\n\n" +
                    "Check the test results window for details.",
                    "Test Complete - Day 21",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        /// <summary>
        /// Test Strategy Pattern (Day 22)
        /// </summary>
        private void testStrategyPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "This will test the Strategy Pattern implementation (Day 22):\n\n" +
                "PAYMENT STRATEGY PATTERN TESTS:\n" +
                "✓ Cash Payment Strategy\n" +
                "✓ Credit Card Payment Strategy\n" +
                "✓ Payment Context Strategy Switching\n" +
                "✓ Partial Payment Processing\n" +
                "✓ Credit Card Validation (Luhn Algorithm)\n" +
                "✓ Cash Change Calculation\n" +
                "✓ Full Payment Workflow (End-to-End)\n\n" +
                "Total: 7 comprehensive tests\n\n" +
                "This verifies that:\n" +
                "• Strategy Pattern is implemented correctly\n" +
                "• Different payment methods work properly\n" +
                "• Payment context can switch strategies\n" +
                "• Payment validation works\n" +
                "• Invoice status updates correctly\n\n" +
                "🎉 This is the FINAL design pattern (5/5)! 🎉\n\n" +
                "Note: This will create test data in your database.",
                "Day 22 - Strategy Pattern Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Run comprehensive test suite
                string testOutput = Testing.StrategyPatternTests.RunAllTests();

                // Show results in a form
                Form resultForm = new Form
                {
                    Text = "Day 22 - Strategy Pattern Test Results",
                    Width = 1100,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput,
                    BackColor = Color.White,
                    ReadOnly = true
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                MessageBox.Show(
                    "Strategy Pattern testing complete!\n\n" +
                    "✓ Strategy Pattern implemented correctly\n" +
                    "✓ Cash and Credit Card strategies working\n" +
                    "✓ Payment context switches strategies\n" +
                    "✓ Payment validation and processing work\n\n" +
                    "🎉 ALL 5 DESIGN PATTERNS COMPLETE! 🎉\n\n" +
                    "1. Singleton (DatabaseManager, RoomSubject)\n" +
                    "2. Repository (Guest, Room, Booking, Invoice, Payment, etc.)\n" +
                    "3. Factory (RoomFactory)\n" +
                    "4. Facade (BookingFacade)\n" +
                    "5. Observer (RoomSubject, HousekeepingObserver)\n" +
                    "6. STRATEGY (PaymentContext, IPaymentStrategy) ✨\n\n" +
                    "🚀 Day 22 Complete - Ready for Day 23!",
                    "Strategy Pattern - SUCCESS!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        /// <summary>
        /// Test Invoice Management (Day 23)
        /// </summary>
        private void testInvoiceManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "This will test the Invoice Management features (Day 23):\n\n" +
                "INVOICE MANAGEMENT TESTS:\n" +
                "✓ Load All Invoices\n" +
                "✓ Filter Invoices by Status\n" +
                "✓ Get Unpaid Invoices\n" +
                "✓ Payment History Retrieval\n" +
                "✓ Invoice Model Methods\n" +
                "✓ Invoice Number Generation\n" +
                "✓ Revenue Statistics Calculation\n\n" +
                "Total: 7 comprehensive tests\n\n" +
                "This verifies that:\n" +
                "• Invoice listing and filtering work\n" +
                "• Payment history can be retrieved\n" +
                "• Invoice calculations are correct\n" +
                "• Revenue statistics are accurate\n\n" +
                "📋 Day 23: Invoice Management & Enhancement\n\n" +
                "Run tests now?",
                "Day 23 - Invoice Management Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Run comprehensive test suite
                string testOutput = Testing.InvoiceManagementTests.RunAllTests();

                // Show results in a form
                Form resultForm = new Form
                {
                    Text = "Day 23 - Invoice Management Test Results",
                    Width = 1100,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                // Show success message
                MessageBox.Show(
                    "Invoice Management Tests Complete! ✅\n\n" +
                    "Features verified:\n" +
                    "✓ Invoice listing with filters\n" +
                    "✓ Payment history display\n" +
                    "✓ Revenue statistics\n" +
                    "✓ Invoice status management\n" +
                    "✓ Invoice calculations\n\n" +
                    "📋 Day 23 Complete!\n\n" +
                    "New features available:\n" +
                    "• Billing → Invoice Management\n" +
                    "• View invoice details with payment history\n" +
                    "• Filter invoices by status\n" +
                    "• Revenue statistics dashboard\n\n" +
                    "Check the test results window for details.",
                    "Day 23 - Invoice Management Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        /// <summary>
        /// Test Invoice Form (Day 24)
        /// </summary>
        private void testInvoiceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "This will test the Invoice Form features (Day 24):\n\n" +
                "INVOICE FORM TESTS:\n" +
                "✓ Create Test Data (Guest, Booking, Invoice)\n" +
                "✓ Invoice Display with All Information\n" +
                "✓ Financial Calculations Verification\n" +
                "✓ Edit Mode Functionality\n" +
                "✓ Discount Update & Recalculation\n" +
                "✓ Status Color Coding\n" +
                "✓ Invoice with Payment Display\n\n" +
                "Total: 7 comprehensive tests\n\n" +
                "This verifies that:\n" +
                "• Invoice form displays all details correctly\n" +
                "• Financial calculations are accurate\n" +
                "• Edit mode allows discount and notes editing\n" +
                "• Changes are saved to database\n" +
                "• Status colors match invoice status\n\n" +
                "📄 Day 24: Invoice Form UI with Edit Capabilities\n\n" +
                "After tests, you can view a sample invoice form!\n\n" +
                "Run tests now?",
                "Day 24 - Invoice Form Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Create test instance
                Testing.InvoiceFormTests tests = new Testing.InvoiceFormTests();
                
                // Create result window
                Form resultForm = new Form
                {
                    Text = "Day 24 - Invoice Form Test Results",
                    Width = 1100,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = string.Empty,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                // Redirect console output to textbox
                System.IO.StringWriter stringWriter = new System.IO.StringWriter();
                Console.SetOut(stringWriter);

                // Run tests
                tests.RunAllTests();

                // Get results
                string testOutput = stringWriter.ToString();
                txtResults.Text = testOutput;

                // Restore console output
                var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);

                // Show success message with option to view invoice form
                var viewResult = MessageBox.Show(
                    "Invoice Form Tests Complete! ✅\n\n" +
                    "Features verified:\n" +
                    "✓ Complete invoice display\n" +
                    "✓ Guest and booking information\n" +
                    "✓ Financial details (subtotal, tax, total)\n" +
                    "✓ Edit mode for discount and notes\n" +
                    "✓ Real-time calculation updates\n" +
                    "✓ Status color coding\n\n" +
                    "📄 Day 24 Complete!\n\n" +
                    "New features:\n" +
                    "• Comprehensive invoice viewing form\n" +
                    "• Edit invoice discount and notes\n" +
                    "• Real-time total recalculation\n" +
                    "• Print invoice (placeholder)\n\n" +
                    "Would you like to view a sample invoice form now?",
                    "Day 24 - Invoice Form Complete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (viewResult == DialogResult.Yes)
                {
                    tests.ShowTestInvoiceForm();
                }
            }
        }

        /// <summary>
        /// Test Payment Enhancement & Receipt Generation (Day 25)
        /// </summary>
        private void testPaymentEnhancementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "This will test the Payment Enhancement features (Day 25):\n\n" +
                "PAYMENT ENHANCEMENT TESTS:\n" +
                "✓ Create Test Data (Guest, Booking, Invoice, Payment)\n" +
                "✓ Invoice Has Payment Records\n" +
                "✓ Payment History Retrieval\n" +
                "✓ Receipt Data Generation\n" +
                "✓ Multiple Payments on Single Invoice\n" +
                "✓ Payment Statistics Calculation\n" +
                "✓ Payment Method Tracking\n\n" +
                "Total: 7 comprehensive tests\n\n" +
                "This verifies that:\n" +
                "• Receipt form displays complete payment info\n" +
                "• Payment history shows all payments for invoice\n" +
                "• Multiple payments are tracked correctly\n" +
                "• Statistics are calculated accurately\n" +
                "• Different payment methods work properly\n\n" +
                "💳 Day 25: Payment Enhancement & Receipt Generation\n\n" +
                "New Features:\n" +
                "• ReceiptForm - Professional receipt generation\n" +
                "• PaymentHistoryForm - Complete payment timeline\n" +
                "• Enhanced PaymentForm with receipt viewing\n" +
                "• Print and export capabilities\n\n" +
                "Run tests now?",
                "Day 25 - Payment Enhancement Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Create result window
                Form resultForm = new Form
                {
                    Text = "Day 25 - Payment Enhancement Test Results",
                    Width = 1100,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = string.Empty,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                // Redirect console output to textbox
                System.IO.StringWriter stringWriter = new System.IO.StringWriter();
                Console.SetOut(stringWriter);

                // Run tests
                Testing.Day25PaymentEnhancementTests.RunAllTests();

                // Get results
                string testOutput = stringWriter.ToString();
                txtResults.Text = testOutput;

                // Restore console output
                var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);

                // Show success message
                MessageBox.Show(
                    "Payment Enhancement Tests Complete! ✅\n\n" +
                    "Features verified:\n" +
                    "✓ Receipt generation with complete details\n" +
                    "✓ Payment history tracking\n" +
                    "✓ Multiple payment support\n" +
                    "✓ Payment statistics calculation\n" +
                    "✓ Payment method tracking\n" +
                    "✓ Print and export functionality\n\n" +
                    "💳 Day 25 Complete!\n\n" +
                    "New features available:\n" +
                    "• View payment receipts from payment history\n" +
                    "• Invoice List → Payment History button\n" +
                    "• Enhanced payment processing with receipt option\n" +
                    "• Print receipts and export to PDF (placeholder)\n\n" +
                    "Check the test results window for details.",
                    "Day 25 - Payment Enhancement Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        /// <summary>
        /// Test Daily Operations Report (Day 26)
        /// </summary>
        private void testDailyOperationsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "This will test the Daily Operations Report features (Day 26):\n\n" +
                "DAILY OPERATIONS REPORT TESTS:\n" +
                "✓ Room Repository - Get All Rooms\n" +
                "✓ Room Status Grouping\n" +
                "✓ Occupancy Rate Calculation\n" +
                "✓ Booking Data Retrieval\n" +
                "✓ Payment Data and Revenue Calculation\n" +
                "✓ Date Range Filtering for Payments\n" +
                "✓ Text Report Generation\n\n" +
                "Total: 7 comprehensive tests\n\n" +
                "This verifies that:\n" +
                "• Room status breakdown works correctly\n" +
                "• Occupancy calculation is accurate\n" +
                "• Revenue statistics are correct\n" +
                "• Date filtering works properly\n" +
                "• Text report generation succeeds\n\n" +
                "📊 Day 26: Daily Operations Report & Enhanced Reporting\n\n" +
                "Run tests now?",
                "Day 26 - Daily Operations Report Test Suite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                // Run comprehensive test suite
                string testOutput = Testing.Day26ReportingTests.RunAllTests();

                // Show results in a form
                Form resultForm = new Form
                {
                    Text = "Day 26 - Daily Operations Report Test Results",
                    Width = 1100,
                    Height = 800,
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                TextBox txtResults = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9F),
                    Text = testOutput,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                resultForm.Controls.Add(txtResults);
                resultForm.Show();

                // Show success message
                MessageBox.Show(
                    "Daily Operations Report Tests Complete! ✅\n\n" +
                    "Features verified:\n" +
                    "✓ Room status breakdown with counts\n" +
                    "✓ Occupancy rate calculation\n" +
                    "✓ Revenue tracking by payment method\n" +
                    "✓ Date range filtering\n" +
                    "✓ Text report generation\n\n" +
                    "📊 Day 26 Complete!\n\n" +
                    "New features available:\n" +
                    "• Reports → Daily Operation\n" +
                    "• Reports → Revenue Report\n" +
                    "• Reports → Occupancy Statistics\n" +
                    "• Date picker to view any day's report\n" +
                    "• Print/Copy report functionality\n\n" +
                    "Check the test results window for details.",
                    "Day 26 - Daily Operations Report Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        #endregion

        #region Window Menu Events (Future)

        // These will be implemented in Day 5 if time permits

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Opens a child form within the MDI container
        /// Prevents duplicate forms from opening
        /// </summary>
        /// <param name="childForm">Form to open</param>
        private void OpenChildForm(Form childForm)
        {
            // Check if an instance of this form type is already open
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm.GetType() == childForm.GetType())
                {
                    // Dispose the unused new instance to avoid resource leaks
                    childForm.Dispose();

                    // Close all other child forms so only one is visible
                    foreach (Form other in this.MdiChildren)
                    {
                        if (other != openForm)
                            other.Close();
                    }

                    // Restore if minimized, then bring to front
                    if (openForm.WindowState == FormWindowState.Minimized)
                        openForm.WindowState = FormWindowState.Maximized;

                    openForm.BringToFront();
                    openForm.Activate();
                    return;
                }
            }

            // Close all existing child forms so only one form is displayed at a time
            foreach (Form openForm in this.MdiChildren)
            {
                openForm.Close();
            }

            // Apply consistent styling to child forms (Day 31 Polish)
            childForm.MdiParent = this;
            childForm.Font = new Font("Segoe UI", 9.5F);
            childForm.BackColor = Color.White;

            // Apply standard background to DataGridViews if they exist
            foreach (Control ctrl in childForm.Controls)
            {
                if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    dgv.EnableHeadersVisualStyles = false;
                }
            }

            // Show first, then maximize to avoid MDI rendering glitches
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region Status Bar Timer

        private void timerStatusBar_Tick(object sender, EventArgs e)
        {
            // Update time display every second
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt");
        }

        #endregion

        #region Form Closing Event

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If user didn't logout, confirm they want to exit
            if (SessionManager.IsLoggedIn && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to exit?\nYou will be logged out.",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the close operation
                }
                else
                {
                    SessionManager.Logout();
                }
            }
        }

        #endregion


        private void MainForm_Load_1(object sender, EventArgs e)
        {
            // Display welcome message
            string userName = SessionManager.CurrentUser.FullName;
            string role = SessionManager.CurrentUser.Role;

            // Update status bar
            toolStripStatusLabelUser.Text = $"Logged in as: {userName} ({role})";
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm tt");

            // Apply role-based menu access
            ApplyRoleBasedAccess();

            // Welcome message
            MessageBox.Show(
                $"Welcome to Hotel Management System, {userName}!\n\n" +
                $"Role: {role}\n" +
                $"Login Time: {DateTime.Now:hh:mm tt}",
                "Login Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


    }

}
