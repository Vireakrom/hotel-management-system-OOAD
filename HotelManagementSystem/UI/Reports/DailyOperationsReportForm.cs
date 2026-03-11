using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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
            DateTime reportDate = dtpReportDate.Value.Date;
            DailyOperationsReportData reportData;

            try
            {
                reportData = reportRepository.GetDailyOperationsReportData(reportDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error preparing report export:\n{ex.Message}",
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Export Daily Operations Report";
                    sfd.Filter = "PDF File (*.pdf)|*.pdf|Excel File (*.xls)|*.xls";
                    sfd.FilterIndex = 1;
                    sfd.FileName = $"DailyOperations_{reportDate:yyyyMMdd}";
                    sfd.DefaultExt = "pdf";
                    sfd.AddExtension = true;

                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    string filePath = sfd.FileName;
                    string extension = Path.GetExtension(filePath);
                    bool exportAsPdf = string.Equals(extension, ".pdf", StringComparison.OrdinalIgnoreCase);

                    if (exportAsPdf)
                    {
                        ExportAsPdf(filePath, reportDate, reportData);
                    }
                    else
                    {
                        ExportAsExcel(filePath, reportDate, reportData);
                    }

                    lblStatus.Text = $"Report exported to {Path.GetFileName(filePath)}";

                    DialogResult openResult = MessageBox.Show(
                        $"Report exported successfully!\n\nFile: {filePath}\n\nWould you like to open the file?",
                        "Export Successful",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (openResult == DialogResult.Yes)
                    {
                        Process.Start(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error exporting report:\n{ex.Message}",
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Export Helpers

        private void ExportAsPdf(string filePath, DateTime reportDate, DailyOperationsReportData reportData)
        {
            string reportText = GenerateExportTextReport(reportDate, reportData);
            WriteSimplePdf(filePath, reportText);
        }

        private void ExportAsExcel(string filePath, DateTime reportDate, DailyOperationsReportData reportData)
        {
            string html = GenerateExcelHtmlReport(reportDate, reportData);
            File.WriteAllText(filePath, html, Encoding.UTF8);
        }

        private void WriteSimplePdf(string filePath, string reportText)
        {
            List<List<string>> pages = BuildPdfPages(reportText);
            int objectCount = 3 + (pages.Count * 2);
            byte[][] objects = new byte[objectCount][];
            List<int> pageObjectNumbers = new List<int>();

            for (int pageIndex = 0; pageIndex < pages.Count; pageIndex++)
            {
                int pageObjectNumber = 4 + (pageIndex * 2);
                int contentObjectNumber = pageObjectNumber + 1;

                pageObjectNumbers.Add(pageObjectNumber);
                objects[pageObjectNumber - 1] = Encoding.ASCII.GetBytes(
                    $"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Resources << /Font << /F1 3 0 R >> >> /Contents {contentObjectNumber} 0 R >>");
                objects[contentObjectNumber - 1] = BuildPdfContentObject(pages[pageIndex]);
            }

            string kids = string.Join(" ", pageObjectNumbers.Select(number => $"{number} 0 R"));
            objects[0] = Encoding.ASCII.GetBytes("<< /Type /Catalog /Pages 2 0 R >>");
            objects[1] = Encoding.ASCII.GetBytes($"<< /Type /Pages /Kids [{kids}] /Count {pages.Count} >>");
            objects[2] = Encoding.ASCII.GetBytes("<< /Type /Font /Subtype /Type1 /BaseFont /Courier >>");

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                byte[] header = new byte[]
                {
                    0x25, 0x50, 0x44, 0x46, 0x2D, 0x31, 0x2E, 0x34, 0x0A,
                    0x25, 0xE2, 0xE3, 0xCF, 0xD3, 0x0A
                };
                fs.Write(header, 0, header.Length);

                List<long> offsets = new List<long> { 0 };
                for (int i = 0; i < objects.Length; i++)
                {
                    offsets.Add(fs.Position);
                    byte[] objectHeader = Encoding.ASCII.GetBytes($"{i + 1} 0 obj\n");
                    byte[] objectFooter = Encoding.ASCII.GetBytes("\nendobj\n");
                    fs.Write(objectHeader, 0, objectHeader.Length);
                    fs.Write(objects[i], 0, objects[i].Length);
                    fs.Write(objectFooter, 0, objectFooter.Length);
                }

                long xrefPosition = fs.Position;
                byte[] xrefHeader = Encoding.ASCII.GetBytes($"xref\n0 {objects.Length + 1}\n");
                fs.Write(xrefHeader, 0, xrefHeader.Length);

                byte[] freeEntry = Encoding.ASCII.GetBytes("0000000000 65535 f \n");
                fs.Write(freeEntry, 0, freeEntry.Length);

                for (int i = 1; i < offsets.Count; i++)
                {
                    byte[] entry = Encoding.ASCII.GetBytes($"{offsets[i]:D10} 00000 n \n");
                    fs.Write(entry, 0, entry.Length);
                }

                byte[] trailer = Encoding.ASCII.GetBytes(
                    $"trailer\n<< /Size {objects.Length + 1} /Root 1 0 R >>\nstartxref\n{xrefPosition}\n%%EOF");
                fs.Write(trailer, 0, trailer.Length);
            }
        }

        private static List<List<string>> BuildPdfPages(string reportText)
        {
            const int maxLineLength = 95;
            const int maxLinesPerPage = 50;

            List<string> wrappedLines = new List<string>();
            string[] rawLines = reportText.Replace("\r\n", "\n").Split('\n');

            foreach (string rawLine in rawLines)
            {
                string normalizedLine = rawLine ?? string.Empty;

                if (normalizedLine.Length == 0)
                {
                    wrappedLines.Add(string.Empty);
                    continue;
                }

                string remaining = normalizedLine;
                while (remaining.Length > maxLineLength)
                {
                    int splitIndex = remaining.LastIndexOf(' ', maxLineLength);
                    if (splitIndex <= 0)
                    {
                        splitIndex = maxLineLength;
                    }

                    wrappedLines.Add(remaining.Substring(0, splitIndex).TrimEnd());
                    remaining = remaining.Substring(splitIndex).TrimStart();
                }

                wrappedLines.Add(remaining);
            }

            if (wrappedLines.Count == 0)
            {
                wrappedLines.Add(string.Empty);
            }

            List<List<string>> pages = new List<List<string>>();
            for (int i = 0; i < wrappedLines.Count; i += maxLinesPerPage)
            {
                pages.Add(wrappedLines.Skip(i).Take(maxLinesPerPage).ToList());
            }

            return pages;
        }

        private static byte[] BuildPdfContentObject(IReadOnlyList<string> pageLines)
        {
            StringBuilder streamBuilder = new StringBuilder();
            streamBuilder.AppendLine("BT");
            streamBuilder.AppendLine("/F1 10 Tf");
            streamBuilder.AppendLine("14 TL");
            streamBuilder.AppendLine("40 760 Td");

            foreach (string line in pageLines)
            {
                streamBuilder.Append('(');
                streamBuilder.Append(EscapePdfText(line));
                streamBuilder.AppendLine(") Tj");
                streamBuilder.AppendLine("T*");
            }

            streamBuilder.AppendLine("ET");

            byte[] streamBytes = Encoding.ASCII.GetBytes(streamBuilder.ToString());
            byte[] prefix = Encoding.ASCII.GetBytes($"<< /Length {streamBytes.Length} >>\nstream\n");
            byte[] suffix = Encoding.ASCII.GetBytes("endstream");

            return CombineBytes(prefix, streamBytes, suffix);
        }

        private static byte[] CombineBytes(params byte[][] segments)
        {
            int totalLength = segments.Sum(segment => segment.Length);
            byte[] combined = new byte[totalLength];
            int offset = 0;

            foreach (byte[] segment in segments)
            {
                Buffer.BlockCopy(segment, 0, combined, offset, segment.Length);
                offset += segment.Length;
            }

            return combined;
        }

        private string GenerateExportTextReport(DateTime reportDate, DailyOperationsReportData reportData)
        {
            StringBuilder sb = new StringBuilder();
            string divider = new string('=', 78);
            string sectionDivider = new string('-', 78);

            sb.AppendLine(divider);
            sb.AppendLine("HOTEL MANAGEMENT SYSTEM");
            sb.AppendLine("DAILY OPERATIONS REPORT");
            sb.AppendLine(divider);
            sb.AppendLine($"Report Date: {reportDate:dddd, MMMM dd, yyyy}");
            sb.AppendLine($"Generated:   {DateTime.Now:MMM dd, yyyy hh:mm tt}");
            sb.AppendLine();

            sb.AppendLine("SUMMARY");
            sb.AppendLine(sectionDivider);
            sb.AppendLine($"Check-Ins Today:  {reportData.CheckIns}");
            sb.AppendLine($"Check-Outs Today: {reportData.CheckOuts}");
            sb.AppendLine($"Today's Revenue:  {FormatCurrency(reportData.TodayRevenue)}");
            sb.AppendLine($"Occupancy Rate:   {reportData.OccupancyRate}%");
            sb.AppendLine($"Occupied Rooms:   {reportData.OccupiedRooms} / {reportData.TotalRooms}");
            sb.AppendLine();

            sb.AppendLine("ROOM STATUS");
            sb.AppendLine(sectionDivider);
            if (reportData.RoomStatuses.Count == 0)
            {
                sb.AppendLine("No room status data available.");
            }
            else
            {
                foreach (RoomStatusSummary roomStatus in reportData.RoomStatuses)
                {
                    sb.AppendLine(
                        $"{roomStatus.Status}: {roomStatus.Count} room(s), {roomStatus.Percentage}% occupied set, Rooms: {roomStatus.RoomNumbers}");
                }
                sb.AppendLine($"TOTAL: {reportData.TotalRooms} room(s)");
            }
            sb.AppendLine();

            sb.AppendLine("REVENUE BREAKDOWN");
            sb.AppendLine(sectionDivider);
            if (reportData.RevenueBreakdown.Count == 0)
            {
                sb.AppendLine("No payments recorded for this date.");
            }
            else
            {
                foreach (PaymentMethodSummary paymentMethod in reportData.RevenueBreakdown)
                {
                    sb.AppendLine(
                        $"{paymentMethod.PaymentMethod}: {paymentMethod.TransactionCount} transaction(s), {FormatCurrency(paymentMethod.Amount)} ({paymentMethod.Percentage}%)");
                }
                sb.AppendLine(
                    $"TOTAL: {reportData.RevenueBreakdown.Sum(item => item.TransactionCount)} transaction(s), {FormatCurrency(reportData.TodayRevenue)}");
            }
            sb.AppendLine();

            sb.AppendLine(reportData.ShowingLatestBookings ? "RECENT BOOKINGS (LATEST)" : "RECENT BOOKINGS");
            sb.AppendLine(sectionDivider);
            if (reportData.RecentBookings.Count == 0)
            {
                sb.AppendLine("No recent bookings available.");
            }
            else
            {
                foreach (RecentBookingSummary booking in reportData.RecentBookings)
                {
                    sb.AppendLine(
                        $"#{booking.BookingId} | {booking.GuestName} | Room {booking.RoomNumber} ({booking.RoomType}) | " +
                        $"{booking.CheckIn:MMM dd, yyyy} to {booking.CheckOut:MMM dd, yyyy} | {booking.Nights} night(s) | " +
                        $"{FormatCurrency(booking.TotalAmount)} | {booking.Status}");
                }
            }

            sb.AppendLine();
            sb.AppendLine("End of Report");

            return sb.ToString();
        }

        private string GenerateExcelHtmlReport(DateTime reportDate, DailyOperationsReportData reportData)
        {
            StringBuilder sb = new StringBuilder();
            string bookingsTitle = reportData.ShowingLatestBookings
                ? "Recent Bookings (Latest)"
                : $"Bookings for {reportDate:MMM dd, yyyy}";

            sb.AppendLine("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Segoe UI, Arial, sans-serif; }");
            sb.AppendLine("h1, h2 { color: #2c3e50; }");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; margin-bottom: 18px; }");
            sb.AppendLine("th, td { border: 1px solid #cfd8dc; padding: 6px 8px; text-align: left; }");
            sb.AppendLine("th { background: #ecf0f1; font-weight: bold; }");
            sb.AppendLine(".number { text-align: right; }");
            sb.AppendLine(".center { text-align: center; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<h1>Daily Operations Report</h1>");
            sb.AppendLine($"<p><strong>Report Date:</strong> {HtmlEncode(reportDate.ToString("dddd, MMMM dd, yyyy"))}<br />");
            sb.AppendLine($"<strong>Generated:</strong> {HtmlEncode(DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"))}</p>");

            sb.AppendLine("<h2>Summary</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><th>Metric</th><th>Value</th></tr>");
            sb.AppendLine($"<tr><td>Check-Ins Today</td><td class=\"number\">{reportData.CheckIns}</td></tr>");
            sb.AppendLine($"<tr><td>Check-Outs Today</td><td class=\"number\">{reportData.CheckOuts}</td></tr>");
            sb.AppendLine($"<tr><td>Today's Revenue</td><td class=\"number\">{HtmlEncode(FormatCurrency(reportData.TodayRevenue))}</td></tr>");
            sb.AppendLine($"<tr><td>Occupancy Rate</td><td class=\"number\">{HtmlEncode(reportData.OccupancyRate + "%")}</td></tr>");
            sb.AppendLine($"<tr><td>Occupied Rooms</td><td class=\"number\">{reportData.OccupiedRooms} / {reportData.TotalRooms}</td></tr>");
            sb.AppendLine("</table>");

            sb.AppendLine("<h2>Room Status</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><th>Status</th><th>Count</th><th>Percentage</th><th>Room Numbers</th></tr>");
            if (reportData.RoomStatuses.Count == 0)
            {
                sb.AppendLine("<tr><td colspan=\"4\">No room status data available.</td></tr>");
            }
            else
            {
                foreach (RoomStatusSummary roomStatus in reportData.RoomStatuses)
                {
                    sb.AppendLine(
                        $"<tr><td>{HtmlEncode(roomStatus.Status)}</td><td class=\"center\">{roomStatus.Count}</td><td class=\"center\">{HtmlEncode(roomStatus.Percentage + "%")}</td><td>{HtmlEncode(roomStatus.RoomNumbers)}</td></tr>");
                }
                sb.AppendLine($"<tr><th>TOTAL</th><th class=\"center\">{reportData.TotalRooms}</th><th class=\"center\">100%</th><th></th></tr>");
            }
            sb.AppendLine("</table>");

            sb.AppendLine("<h2>Revenue Breakdown</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><th>Payment Method</th><th>Transactions</th><th>Amount</th><th>% of Total</th></tr>");
            if (reportData.RevenueBreakdown.Count == 0)
            {
                sb.AppendLine("<tr><td colspan=\"4\">No payments recorded for this date.</td></tr>");
            }
            else
            {
                foreach (PaymentMethodSummary paymentMethod in reportData.RevenueBreakdown)
                {
                    sb.AppendLine(
                        $"<tr><td>{HtmlEncode(paymentMethod.PaymentMethod)}</td><td class=\"center\">{paymentMethod.TransactionCount}</td><td class=\"number\">{HtmlEncode(FormatCurrency(paymentMethod.Amount))}</td><td class=\"center\">{HtmlEncode(paymentMethod.Percentage + "%")}</td></tr>");
                }
                sb.AppendLine(
                    $"<tr><th>TOTAL</th><th class=\"center\">{reportData.RevenueBreakdown.Sum(item => item.TransactionCount)}</th><th class=\"number\">{HtmlEncode(FormatCurrency(reportData.TodayRevenue))}</th><th class=\"center\">100%</th></tr>");
            }
            sb.AppendLine("</table>");

            sb.AppendLine($"<h2>{HtmlEncode(bookingsTitle)}</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><th>Booking ID</th><th>Guest Name</th><th>Room</th><th>Room Type</th><th>Check-In</th><th>Check-Out</th><th>Nights</th><th>Total Amount</th><th>Status</th></tr>");
            if (reportData.RecentBookings.Count == 0)
            {
                sb.AppendLine("<tr><td colspan=\"9\">No recent bookings available.</td></tr>");
            }
            else
            {
                foreach (RecentBookingSummary booking in reportData.RecentBookings)
                {
                    sb.AppendLine(
                        $"<tr><td class=\"center\">{booking.BookingId}</td><td>{HtmlEncode(booking.GuestName)}</td><td class=\"center\">{HtmlEncode(booking.RoomNumber)}</td><td>{HtmlEncode(booking.RoomType)}</td><td>{HtmlEncode(booking.CheckIn.ToString("MMM dd, yyyy"))}</td><td>{HtmlEncode(booking.CheckOut.ToString("MMM dd, yyyy"))}</td><td class=\"center\">{booking.Nights}</td><td class=\"number\">{HtmlEncode(FormatCurrency(booking.TotalAmount))}</td><td>{HtmlEncode(booking.Status)}</td></tr>");
                }
            }
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        private static string EscapePdfText(string value)
        {
            StringBuilder sb = new StringBuilder(value.Length);

            foreach (char character in value)
            {
                char normalizedCharacter = character;
                if (normalizedCharacter < 32 || normalizedCharacter > 126)
                {
                    normalizedCharacter = normalizedCharacter == '\t' ? ' ' : '?';
                }

                if (normalizedCharacter == '\\' || normalizedCharacter == '(' || normalizedCharacter == ')')
                {
                    sb.Append('\\');
                }

                sb.Append(normalizedCharacter);
            }

            return sb.ToString();
        }

        private static string FormatCurrency(decimal amount)
        {
            return string.Format(CultureInfo.InvariantCulture, "${0:N2}", amount);
        }

        private static string HtmlEncode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;");
        }

        #endregion

        #region Text Report Generation

        /// <summary>
        /// Generate a formatted text report for printing/clipboard
        /// </summary>
        public string GenerateTextReport(DateTime reportDate)
        {
            StringBuilder sb = new StringBuilder();
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
