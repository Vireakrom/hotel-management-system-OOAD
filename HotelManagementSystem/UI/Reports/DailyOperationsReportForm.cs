using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.UI.Reports
{
    /// <summary>
    /// Daily Operations Report - comprehensive dashboard showing
    /// today's check-ins, check-outs, occupancy rate, revenue,
    /// room status breakdown, and recent bookings.
    /// Day 26 - Enhanced Reporting
    /// </summary>
    public partial class DailyOperationsReportForm : Form
    {
        private readonly ReportRepository reportRepository;

        public DailyOperationsReportForm()
        {
            InitializeComponent();

            reportRepository = new ReportRepository();

            // Set up grids
            SetupRoomStatusGrid();
            SetupRevenueBreakdownGrid();
            SetupRecentBookingsGrid();

            // Set default date to today
            dtpReportDate.Value = DateTime.Today;

            // Load report
            LoadReport();

            // Clear grid selection once the window handle is created (constructor runs before it exists)
            this.Load += (s, e) =>
            {
                dgvRoomStatus.ClearSelection();
                dgvRevenueBreakdown.ClearSelection();
                dgvRecentBookings.ClearSelection();
            };
        }

        #region Grid Setup

        private void SetupRoomStatusGrid()
        {
            dgvRoomStatus.AutoGenerateColumns = false;
            dgvRoomStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoomStatus.MultiSelect = false;
            dgvRoomStatus.RowHeadersVisible = false;

            dgvRoomStatus.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Room Status",
                Width = 150
            });

            dgvRoomStatus.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Count",
                HeaderText = "Count",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvRoomStatus.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Percentage",
                HeaderText = "Percentage",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvRoomStatus.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Rooms",
                HeaderText = "Room Numbers",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void SetupRevenueBreakdownGrid()
        {
            dgvRevenueBreakdown.AutoGenerateColumns = false;
            dgvRevenueBreakdown.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenueBreakdown.MultiSelect = false;
            dgvRevenueBreakdown.RowHeadersVisible = false;

            dgvRevenueBreakdown.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PaymentMethod",
                HeaderText = "Payment Method",
                Width = 150
            });

            dgvRevenueBreakdown.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TransactionCount",
                HeaderText = "Transactions",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvRevenueBreakdown.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Amount",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvRevenueBreakdown.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Percentage",
                HeaderText = "% of Total",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private void SetupRecentBookingsGrid()
        {
            dgvRecentBookings.AutoGenerateColumns = false;
            dgvRecentBookings.MultiSelect = false;
            dgvRecentBookings.RowHeadersVisible = false;

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BookingId",
                HeaderText = "ID",
                Width = 50
            });

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GuestName",
                HeaderText = "Guest Name",
                Width = 180
            });

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomNumber",
                HeaderText = "Room",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomType",
                HeaderText = "Type",
                Width = 100
            });

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CheckIn",
                HeaderText = "Check-In",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "MMM dd, yyyy" }
            });

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CheckOut",
                HeaderText = "Check-Out",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "MMM dd, yyyy" }
            });

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nights",
                HeaderText = "Nights",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Total",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvRecentBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        #endregion

        #region Load Report Data

        private void LoadReport()
        {
            try
            {
                DateTime reportDate = dtpReportDate.Value.Date;
                DailyOperationsReportData reportData = reportRepository.GetDailyOperationsReportData(reportDate);
                lblReportDate.Text = reportDate.ToString("dddd, MMMM dd, yyyy");
                lblStatus.Text = "Loading report...";

                LoadStatistics(reportData);
                LoadRoomStatusBreakdown(reportData);
                LoadRevenueBreakdown(reportData);
                LoadRecentBookings(reportDate, reportData);

                // Defer clear until after the DataGridView finishes rendering
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        dgvRoomStatus.ClearSelection();
                        dgvRevenueBreakdown.ClearSelection();
                        dgvRecentBookings.ClearSelection();
                    }));
                }

                lblStatus.Text = $"Report loaded for {reportDate:MMM dd, yyyy} at {DateTime.Now:hh:mm:ss tt}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading report";
                MessageBox.Show(
                    $"Error loading report:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Load the 4 main statistics cards: check-ins, check-outs, revenue, occupancy
        /// </summary>
        private void LoadStatistics(DailyOperationsReportData reportData)
        {
            lblCheckInsValue.Text = reportData.CheckIns.ToString();
            lblCheckOutsValue.Text = reportData.CheckOuts.ToString();
            lblRevenueValue.Text = reportData.TodayRevenue.ToString("C2");
            lblOccupancyValue.Text = $"{reportData.OccupancyRate}%";
        }

        /// <summary>
        /// Load room status breakdown into the grid
        /// </summary>
        private void LoadRoomStatusBreakdown(DailyOperationsReportData reportData)
        {
            dgvRoomStatus.Rows.Clear();

            if (reportData.TotalRooms == 0) return;

            foreach (RoomStatusSummary roomStatus in reportData.RoomStatuses)
            {
                int rowIndex = dgvRoomStatus.Rows.Add(
                    roomStatus.Status,
                    roomStatus.Count,
                    $"{roomStatus.Percentage}%",
                    roomStatus.RoomNumbers);

                // Color-code status rows
                DataGridViewRow row = dgvRoomStatus.Rows[rowIndex];
                switch (roomStatus.Status)
                {
                    case "Available":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                        break;
                    case "Occupied":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224);
                        break;
                    case "Reserved":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253);
                        break;
                    case "Cleaning":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(243, 229, 245);
                        break;
                    case "Maintenance":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
                        break;
                }
            }

            // Add total row
            int totalRowIndex = dgvRoomStatus.Rows.Add("TOTAL", reportData.TotalRooms, "100%", "");
            dgvRoomStatus.Rows[totalRowIndex].DefaultCellStyle.Font = new Font(dgvRoomStatus.Font, FontStyle.Bold);
            dgvRoomStatus.Rows[totalRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);
        }

        /// <summary>
        /// Load revenue breakdown by payment method for the selected date
        /// </summary>
        private void LoadRevenueBreakdown(DailyOperationsReportData reportData)
        {
            dgvRevenueBreakdown.Rows.Clear();

            if (reportData.RevenueBreakdown.Count == 0)
            {
                dgvRevenueBreakdown.Rows.Add("No payments", "0", "$0.00", "-");
                return;
            }

            foreach (PaymentMethodSummary paymentMethod in reportData.RevenueBreakdown)
            {
                int rowIndex = dgvRevenueBreakdown.Rows.Add(
                    paymentMethod.PaymentMethod,
                    paymentMethod.TransactionCount,
                    paymentMethod.Amount,
                    $"{paymentMethod.Percentage}%");

                // Color-code payment methods
                DataGridViewRow row = dgvRevenueBreakdown.Rows[rowIndex];
                switch (paymentMethod.PaymentMethod)
                {
                    case "Cash":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                        break;
                    case "CreditCard":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253);
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(243, 229, 245);
                        break;
                }
            }

            // Add total row
            int transactionCount = reportData.RevenueBreakdown.Sum(item => item.TransactionCount);
            int totalRowIndex = dgvRevenueBreakdown.Rows.Add("TOTAL", transactionCount, reportData.TodayRevenue, "100%");
            dgvRevenueBreakdown.Rows[totalRowIndex].DefaultCellStyle.Font = new Font(dgvRevenueBreakdown.Font, FontStyle.Bold);
            dgvRevenueBreakdown.Rows[totalRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);
        }

        /// <summary>
        /// Load recent bookings for the selected date and surrounding days
        /// </summary>
        private void LoadRecentBookings(DateTime reportDate, DailyOperationsReportData reportData)
        {
            dgvRecentBookings.Rows.Clear();

            lblRecentBookingsTitle.Text = reportData.ShowingLatestBookings
                ? "Recent Bookings (Latest)"
                : $"Bookings for {reportDate:MMM dd, yyyy}";

            foreach (RecentBookingSummary booking in reportData.RecentBookings)
            {
                int rowIndex = dgvRecentBookings.Rows.Add(
                    booking.BookingId,
                    booking.GuestName,
                    booking.RoomNumber,
                    booking.RoomType,
                    booking.CheckIn,
                    booking.CheckOut,
                    booking.Nights,
                    booking.TotalAmount,
                    booking.Status
                );

                // Color-code status
                DataGridViewRow row = dgvRecentBookings.Rows[rowIndex];
                switch (booking.Status)
                {
                    case "CheckedIn":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253);
                        break;
                    case "CheckedOut":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                        break;
                    case "Confirmed":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224);
                        break;
                    case "Pending":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(243, 229, 245);
                        break;
                    case "Cancelled":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
                        break;
                }
            }
        }

        #endregion

        #region Event Handlers

        private void dtpReportDate_ValueChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Generate text-based report for printing
            DateTime reportDate = dtpReportDate.Value.Date;
            string report = GenerateTextReport(reportDate);

            Form printForm = new Form
            {
                Text = $"Daily Operations Report - {reportDate:MMM dd, yyyy}",
                Width = 800,
                Height = 600,
                StartPosition = FormStartPosition.CenterScreen
            };

            TextBox txtReport = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 9F),
                Text = report,
                ReadOnly = true,
                BackColor = Color.White
            };

            Button btnCopy = new Button
            {
                Text = "Copy to Clipboard",
                Dock = DockStyle.Bottom,
                Height = 35,
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F)
            };
            btnCopy.Click += (s, ev) =>
            {
                Clipboard.SetText(report);
                MessageBox.Show("Report copied to clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            printForm.Controls.Add(txtReport);
            printForm.Controls.Add(btnCopy);
            printForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Text Report Generation

        /// <summary>
        /// Generate a formatted text report for printing/clipboard
        /// </summary>
        public string GenerateTextReport(DateTime reportDate)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            DailyOperationsReportData reportData = reportRepository.GetDailyOperationsReportData(reportDate);

            sb.AppendLine("╔══════════════════════════════════════════════════════════╗");
            sb.AppendLine("║            HOTEL MANAGEMENT SYSTEM                      ║");
            sb.AppendLine("║            Daily Operations Report                      ║");
            sb.AppendLine("╚══════════════════════════════════════════════════════════╝");
            sb.AppendLine();
            sb.AppendLine($"  Report Date: {reportDate:dddd, MMMM dd, yyyy}");
            sb.AppendLine($"  Generated:   {DateTime.Now:MMM dd, yyyy hh:mm tt}");
            sb.AppendLine();

            // Summary section
            sb.AppendLine("  ─────────── SUMMARY ───────────");
            sb.AppendLine($"  Check-Ins Today:    {reportData.CheckIns}");
            sb.AppendLine($"  Check-Outs Today:   {reportData.CheckOuts}");
            sb.AppendLine($"  Today's Revenue:    {reportData.TodayRevenue:C2}");
            sb.AppendLine($"  Occupancy Rate:     {reportData.OccupancyRate}%");
            sb.AppendLine($"  Occupied Rooms:     {reportData.OccupiedRooms} / {reportData.TotalRooms}");
            sb.AppendLine();

            // Room status
            sb.AppendLine("  ─────────── ROOM STATUS ───────────");
            foreach (RoomStatusSummary roomStatus in reportData.RoomStatuses)
            {
                sb.AppendLine($"  {roomStatus.Status,-15} {roomStatus.Count,3} ({roomStatus.Percentage,5}%)  [{roomStatus.RoomNumbers}]");
            }
            sb.AppendLine($"  {"TOTAL",-15} {reportData.TotalRooms,3} (100.0%)");
            sb.AppendLine();

            // Revenue breakdown
            sb.AppendLine("  ─────────── REVENUE BREAKDOWN ───────────");
            if (reportData.RevenueBreakdown.Count > 0)
            {
                foreach (PaymentMethodSummary paymentMethod in reportData.RevenueBreakdown)
                {
                    sb.AppendLine($"  {paymentMethod.PaymentMethod,-15} {paymentMethod.TransactionCount,3} txn(s)  {paymentMethod.Amount,12:C2}  ({paymentMethod.Percentage}%)");
                }
                sb.AppendLine($"  {"TOTAL",-15} {reportData.RevenueBreakdown.Sum(item => item.TransactionCount),3} txn(s)  {reportData.TodayRevenue,12:C2}");
            }
            else
            {
                sb.AppendLine("  No payments recorded for this date.");
            }
            sb.AppendLine();

            sb.AppendLine("══════════════════════════════════════════════════════════");
            sb.AppendLine("  End of Report");

            return sb.ToString();
        }

        #endregion
    }
}
