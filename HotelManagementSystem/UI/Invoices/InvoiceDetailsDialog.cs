using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.UI.Invoices
{
    /// <summary>
    /// Dialog form for displaying detailed invoice information
    /// Shows invoice details, booking info, guest info, and payment history
    /// Day 23 - Invoice Details Enhancement
    /// </summary>
    public partial class InvoiceDetailsDialog : Form
    {
        private Invoice invoice;
        private Booking booking;
        private Guest guest;
        private List<Payment> payments;
        private RoomRepository roomRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceDetailsDialog(Invoice invoice, Booking booking, Guest guest, List<Payment> payments)
        {
            InitializeComponent();

            this.invoice = invoice;
            this.booking = booking;
            this.guest = guest;
            this.payments = payments;
            this.roomRepository = new RoomRepository();

            LoadInvoiceDetails();
            LoadPaymentHistory();
        }

        /// <summary>
        /// Load invoice and booking details
        /// </summary>
        private void LoadInvoiceDetails()
        {
            try
            {
                // Invoice information
                lblInvoiceNumber.Text = $"Invoice #: {invoice.InvoiceNumber}";
                lblIssueDate.Text = $"Issue Date: {invoice.IssueDate:MMM dd, yyyy}";
                lblDueDate.Text = $"Due Date: {invoice.DueDate:MMM dd, yyyy}";
                lblInvoiceStatus.Text = $"Status: {invoice.Status}";

                // Set status color
                switch (invoice.Status)
                {
                    case "Paid":
                        lblInvoiceStatus.ForeColor = Color.Green;
                        break;
                    case "Pending":
                        lblInvoiceStatus.ForeColor = Color.Orange;
                        break;
                    case "PartiallyPaid":
                        lblInvoiceStatus.ForeColor = Color.Blue;
                        break;
                    case "Cancelled":
                        lblInvoiceStatus.ForeColor = Color.Gray;
                        break;
                }

                // Guest information
                lblGuestName.Text = $"Guest: {guest.FirstName} {guest.LastName}";
                lblGuestEmail.Text = $"Email: {guest.Email}";
                lblGuestPhone.Text = $"Phone: {guest.Phone}";

                // Booking information
                Room room = roomRepository.GetById(booking.RoomId);
                lblBookingId.Text = $"Booking ID: {booking.BookingId}";
                lblRoomNumber.Text = $"Room: {room?.RoomNumber ?? "N/A"}";
                lblCheckIn.Text = $"Check-In: {booking.CheckInDate:MMM dd, yyyy}";
                lblCheckOut.Text = $"Check-Out: {booking.CheckOutDate:MMM dd, yyyy}";
                int nights = (booking.CheckOutDate - booking.CheckInDate).Days;
                lblNights.Text = $"Nights: {nights}";

                // Financial information
                lblSubTotal.Text = $"{invoice.SubTotal:C2}";
                lblTaxRate.Text = $"{invoice.TaxRate}%";
                lblTaxAmount.Text = $"{invoice.TaxAmount:C2}";
                lblDiscount.Text = $"{invoice.Discount:C2}";
                lblTotalAmount.Text = $"{invoice.TotalAmount:C2}";
                lblPaidAmount.Text = $"{invoice.PaidAmount:C2}";
                lblBalanceAmount.Text = $"{invoice.BalanceAmount:C2}";

                // Highlight balance if unpaid
                if (invoice.BalanceAmount > 0)
                {
                    lblBalanceAmount.ForeColor = Color.Red;
                    lblBalanceAmount.Font = new Font(lblBalanceAmount.Font, FontStyle.Bold);
                }
                else
                {
                    lblBalanceAmount.ForeColor = Color.Green;
                    lblBalanceAmount.Font = new Font(lblBalanceAmount.Font, FontStyle.Bold);
                }

                // Notes
                txtNotes.Text = invoice.Notes ?? "No notes available.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoice details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load payment history into DataGridView
        /// </summary>
        private void LoadPaymentHistory()
        {
            try
            {
                dgvPaymentHistory.AutoGenerateColumns = false;
                dgvPaymentHistory.AllowUserToAddRows = false;
                dgvPaymentHistory.AllowUserToDeleteRows = false;
                dgvPaymentHistory.ReadOnly = true;
                dgvPaymentHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Define columns
                dgvPaymentHistory.Columns.Clear();

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PaymentId",
                    HeaderText = "Payment ID",
                    DataPropertyName = "PaymentId",
                    Width = 80
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PaymentDate",
                    HeaderText = "Date",
                    DataPropertyName = "PaymentDate",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "MMM dd, yyyy HH:mm" }
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Amount",
                    HeaderText = "Amount",
                    DataPropertyName = "Amount",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PaymentMethod",
                    HeaderText = "Method",
                    DataPropertyName = "PaymentMethod",
                    Width = 100
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TransactionId",
                    HeaderText = "Transaction ID",
                    DataPropertyName = "TransactionId",
                    Width = 180
                });

                dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataPropertyName = "Status",
                    Width = 100
                });

                // Bind data
                dgvPaymentHistory.DataSource = payments;

                // Update summary
                if (payments != null && payments.Count > 0)
                {
                    lblPaymentCount.Text = $"Total Payments: {payments.Count}";
                    lblPaymentTotal.Text = $"Total Amount Paid: {payments.Sum(p => p.Amount):C2}";
                }
                else
                {
                    lblPaymentCount.Text = "Total Payments: 0";
                    lblPaymentTotal.Text = "Total Amount Paid: $0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Close dialog
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Print invoice — shows a print-preview dialog then sends to printer
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Room room   = roomRepository.GetById(booking.RoomId);
                int  nights = (booking.CheckOutDate - booking.CheckInDate).Days;

                var doc = new PrintDocument();
                doc.DocumentName = $"Invoice {invoice.InvoiceNumber}";

                doc.PrintPage += (s, pe) => DrawInvoicePage(pe, room, nights);

                using (var preview = new PrintPreviewDialog())
                {
                    preview.Document    = doc;
                    preview.Text        = $"Print Preview — Invoice {invoice.InvoiceNumber}";
                    preview.WindowState = FormWindowState.Maximized;
                    preview.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing print: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Draws the entire invoice onto the PrintPageEventArgs graphics surface
        /// </summary>
        private void DrawInvoicePage(PrintPageEventArgs pe, Room room, int nights)
        {
            Graphics g      = pe.Graphics;
            RectangleF page = pe.MarginBounds;   // usable page area (respects margins)
            float x         = page.Left;
            float y         = page.Top;
            float pageW     = page.Width;

            // ── Fonts ─────────────────────────────────────────────────────────
            var fntHotelName  = new Font("Segoe UI", 18f, FontStyle.Bold);
            var fntTagline    = new Font("Segoe UI",  9f, FontStyle.Italic);
            var fntSectionHdr = new Font("Segoe UI", 10f, FontStyle.Bold);
            var fntLabel      = new Font("Segoe UI",  9f, FontStyle.Regular);
            var fntValue      = new Font("Segoe UI",  9f, FontStyle.Bold);
            var fntSmall      = new Font("Segoe UI",  8f, FontStyle.Regular);
            var fntTotal      = new Font("Segoe UI", 11f, FontStyle.Bold);
            var fntFooter     = new Font("Segoe UI",  7.5f, FontStyle.Italic);

            // ── Colours ───────────────────────────────────────────────────────
            var blue       = Color.FromArgb(0,  102, 204);
            var darkBlue   = Color.FromArgb(0,   60, 120);
            var lightGray  = Color.FromArgb(240, 242, 245);
            var midGray    = Color.FromArgb(180, 180, 180);
            var green      = Color.FromArgb(40,  160,  70);
            var red        = Color.FromArgb(200,  40,  40);

            var brBlue      = new SolidBrush(blue);
            var brDarkBlue  = new SolidBrush(darkBlue);
            var brWhite     = new SolidBrush(Color.White);
            var brBlack     = new SolidBrush(Color.Black);
            var brGray      = new SolidBrush(Color.FromArgb(80, 80, 80));
            var penGray     = new Pen(midGray, 0.5f);
            var penBlue     = new Pen(blue, 1.5f);

            const float rowH    = 20f;   // normal row height
            const float secGap  = 10f;   // gap before a section heading
            const float labelW  = 130f;  // label column width

            // ══════════════════════════════════════════════════════════════
            // 1. HEADER BANNER
            // ══════════════════════════════════════════════════════════════
            float bannerH = 62f;
            g.FillRectangle(brBlue, x, y, pageW, bannerH);

            g.DrawString("HOTEL MANAGEMENT SYSTEM",
                fntHotelName, brWhite, x + 10, y + 8);
            g.DrawString("Official Invoice / Payment Receipt",
                fntTagline, new SolidBrush(Color.FromArgb(200, 220, 255)), x + 14, y + 40);

            // Invoice number badge (right side of banner)
            string invLabel  = invoice.InvoiceNumber;
            SizeF  invLblSz  = g.MeasureString(invLabel, fntSectionHdr);
            float  invLblX   = x + pageW - invLblSz.Width - 14;
            g.DrawString(invLabel, fntSectionHdr, brWhite, invLblX, y + 22);

            y += bannerH + 6;

            // ── Status strip ─────────────────────────────────────────────
            Color statusColor;
            switch (invoice.Status)
            {
                case "Paid":          statusColor = green; break;
                case "PartiallyPaid": statusColor = Color.FromArgb(33, 150, 243); break;
                case "Cancelled":     statusColor = Color.Gray; break;
                default:              statusColor = Color.FromArgb(255, 152, 0); break;
            }
            float stripH = 18f;
            g.FillRectangle(new SolidBrush(statusColor), x, y, pageW, stripH);
            string statusText = $"STATUS: {invoice.Status.ToUpper()}   |   Issue Date: {invoice.IssueDate:MMM dd, yyyy}   |   Due Date: {invoice.DueDate:MMM dd, yyyy}";
            g.DrawString(statusText, fntSmall, brWhite,
                x + 8, y + (stripH - fntSmall.Height) / 2);
            y += stripH + 10;

            // ══════════════════════════════════════════════════════════════
            // 2. TWO-COLUMN META SECTION  (Guest info | Booking info)
            // ══════════════════════════════════════════════════════════════
            float colW2 = pageW / 2 - 6;

            void DrawMetaRow(string label, string value, float cx, ref float cy)
            {
                g.DrawString(label + ":", fntLabel, brGray, cx, cy);
                g.DrawString(value,       fntValue,  brBlack, cx + labelW, cy);
                cy += rowH;
            }

            void DrawSectionHeader(string title, ref float cy)
            {
                cy += secGap;
                g.FillRectangle(new SolidBrush(lightGray), x, cy, pageW, 18f);
                g.DrawLine(penBlue, x, cy, x, cy + 18f);            // left accent
                g.DrawLine(penBlue, x, cy, x + 3, cy);              // corner
                g.DrawString(title, fntSectionHdr, brDarkBlue, x + 6, cy + 1);
                cy += 22f;
            }

            // Guest column
            DrawSectionHeader("Guest Information", ref y);
            float yLeft  = y;
            float yRight = y;
            float cxLeft  = x;
            float cxRight = x + colW2 + 12;

            DrawMetaRow("Guest Name",    $"{guest.FirstName} {guest.LastName}", cxLeft,  ref yLeft);
            DrawMetaRow("Email",         guest.Email  ?? "N/A",                 cxLeft,  ref yLeft);
            DrawMetaRow("Phone",         guest.Phone  ?? "N/A",                 cxLeft,  ref yLeft);

            // Booking column (share same y baseline)
            DrawMetaRow("Booking ID",   booking.BookingId.ToString(),            cxRight, ref yRight);
            DrawMetaRow("Room",         $"{room?.RoomNumber ?? "N/A"} ({room?.RoomType ?? "N/A"})", cxRight, ref yRight);
            DrawMetaRow("Check-In",     booking.CheckInDate.ToString("MMM dd, yyyy"),  cxRight, ref yRight);
            DrawMetaRow("Check-Out",    booking.CheckOutDate.ToString("MMM dd, yyyy"), cxRight, ref yRight);
            DrawMetaRow("Nights",       nights.ToString(),                        cxRight, ref yRight);

            y = Math.Max(yLeft, yRight) + 4;
            g.DrawLine(penGray, x, y, x + pageW, y);  // divider

            // ══════════════════════════════════════════════════════════════
            // 3. FINANCIAL SUMMARY
            // ══════════════════════════════════════════════════════════════
            DrawSectionHeader("Financial Summary", ref y);

            float finLabelX  = x + pageW * 0.50f;
            float finValueX  = x + pageW - 10f;
            var   sfRight    = new StringFormat { Alignment = StringAlignment.Far };

            void DrawFinRow(string label, decimal amount, Font font = null, Color? color = null)
            {
                var f = font  ?? fntLabel;
                var b = color.HasValue ? new SolidBrush(color.Value) : brBlack;
                g.DrawString(label, f, brGray,  finLabelX, y);
                g.DrawString(amount.ToString("C2"), f, b, finValueX, y, sfRight);
                y += rowH;
            }

            DrawFinRow("Sub Total",                  invoice.SubTotal);
            DrawFinRow($"Tax ({invoice.TaxRate}%)",  invoice.TaxAmount);
            DrawFinRow("Discount",                   invoice.Discount);

            // Separator line before totals
            g.DrawLine(new Pen(blue, 1f), finLabelX, y - 2, finValueX, y - 2);
            DrawFinRow("TOTAL AMOUNT",  invoice.TotalAmount,  fntTotal);
            DrawFinRow("Amount Paid",   invoice.PaidAmount,   fntValue, green);

            g.DrawLine(new Pen(midGray, 0.5f), finLabelX, y - 2, finValueX, y - 2);
            DrawFinRow("BALANCE DUE",  invoice.BalanceAmount, fntTotal,
                invoice.BalanceAmount > 0 ? red : green);

            g.DrawLine(penGray, x, y + 2, x + pageW, y + 2);
            y += 8;

            // ══════════════════════════════════════════════════════════════
            // 4. PAYMENT HISTORY TABLE
            // ══════════════════════════════════════════════════════════════
            DrawSectionHeader("Payment History", ref y);

            // ── Column layout ─────────────────────────────────────────────────
            //   #(25) | Date(105) | Method(85) | Transaction ID(215) | Amount(100) | Status(rest)
            float[] colXs    = { x, x+25, x+130, x+215, x+430, x+530 };
            float[] colWidths = { 25f, 105f, 85f, 215f, 100f, pageW - 530f };
            string[] headers  = { "#", "Date", "Method", "Transaction ID", "Amount", "Status" };
            var sfAmtFmt = new StringFormat { Alignment = StringAlignment.Far };

            // Header row
            g.FillRectangle(new SolidBrush(Color.FromArgb(220, 230, 245)), x, y, pageW, rowH);
            for (int i = 0; i < headers.Length; i++)
            {
                var rect = new RectangleF(colXs[i] + 2, y + 2, colWidths[i] - 4, rowH);
                // Right-align the Amount header to match its values
                var fmt = (i == 4) ? sfAmtFmt : StringFormat.GenericDefault;
                g.DrawString(headers[i], fntValue, brDarkBlue, rect, fmt);
            }
            y += rowH;

            if (payments != null && payments.Count > 0)
            {
                bool shade = false;
                int  idx   = 1;
                foreach (var p in payments)
                {
                    if (shade)
                        g.FillRectangle(new SolidBrush(lightGray), x, y, pageW, rowH);

                    g.DrawString(idx.ToString(),                         fntSmall, brBlack, colXs[0] + 2, y + 3);
                    g.DrawString(p.PaymentDate.ToString("MMM dd, yyyy"),  fntSmall, brBlack, colXs[1] + 2, y + 3);
                    g.DrawString(p.PaymentMethod,                         fntSmall, brBlack, colXs[2] + 2, y + 3);
                    // Clip Transaction ID within its column so it never bleeds into Amount
                    g.DrawString(p.TransactionId ?? "N/A", fntSmall, brBlack,
                        new RectangleF(colXs[3] + 2, y + 3, colWidths[3] - 4, rowH));
                    // Amount right-aligned within its column
                    g.DrawString(p.Amount.ToString("C2"), fntSmall, brBlack,
                        new RectangleF(colXs[4], y + 3, colWidths[4] - 2, rowH), sfAmtFmt);

                    Color sc = p.Status == "Completed" ? green
                             : p.Status == "Refunded"  ? Color.Orange
                             : p.Status == "Failed"    ? red
                             : Color.Gray;
                    g.DrawString(p.Status, fntSmall, new SolidBrush(sc), colXs[5] + 2, y + 3);

                    y    += rowH;
                    shade = !shade;
                    idx++;
                }

                // Summary row
                y += 4;
                g.DrawString($"Total Payments: {payments.Count}   |   Total Paid: {payments.Sum(p => p.Amount):C2}",
                    fntValue, brDarkBlue, x, y);
                y += rowH;
            }
            else
            {
                g.DrawString("  No payments recorded.", fntSmall, brGray, x, y);
                y += rowH;
            }

            // ══════════════════════════════════════════════════════════════
            // 5. NOTES  (only if present)
            // ══════════════════════════════════════════════════════════════
            if (!string.IsNullOrWhiteSpace(invoice.Notes))
            {
                DrawSectionHeader("Notes", ref y);
                g.DrawString(invoice.Notes, fntSmall, brGray,
                    new RectangleF(x, y, pageW, 60f));
                y += 32f;
            }

            // ══════════════════════════════════════════════════════════════
            // 6. FOOTER
            // ══════════════════════════════════════════════════════════════
            float footerY = page.Bottom - 28f;
            g.DrawLine(new Pen(midGray, 0.5f), x, footerY, x + pageW, footerY);
            footerY += 4;
            g.DrawString(
                $"Generated on {DateTime.Now:MMM dd, yyyy  hh:mm tt}   |   Hotel Management System   |   This is a computer-generated document.",
                fntFooter, brGray,
                new RectangleF(x, footerY, pageW, 20f),
                new StringFormat { Alignment = StringAlignment.Center });

            // ── Dispose local resources ───────────────────────────────────
            foreach (var obj in new IDisposable[]
            {
                fntHotelName, fntTagline, fntSectionHdr, fntLabel, fntValue,
                fntSmall, fntTotal, fntFooter,
                brBlue, brDarkBlue, brWhite, brBlack, brGray,
                penGray, penBlue
            })
                obj.Dispose();

            pe.HasMorePages = false;
        }

        /// <summary>
        /// Export invoice to a .txt or .csv file chosen by the user
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Title       = "Export Invoice";
                    sfd.Filter      = "Text File (*.txt)|*.txt|CSV File (*.csv)|*.csv";
                    sfd.FilterIndex = 1;
                    sfd.FileName    = $"Invoice_{invoice.InvoiceNumber}";
                    sfd.DefaultExt  = "txt";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    string filePath = sfd.FileName;
                    bool isCsv = Path.GetExtension(filePath).Equals(".csv", StringComparison.OrdinalIgnoreCase);

                    if (isCsv)
                        ExportAsCsv(filePath);
                    else
                        ExportAsText(filePath);

                    var openResult = MessageBox.Show(
                        $"Invoice exported successfully!\n\nFile: {filePath}\n\nWould you like to open the file?",
                        "Export Successful",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (openResult == DialogResult.Yes)
                        Process.Start(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting invoice: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Exports a nicely formatted plain-text invoice receipt
        /// </summary>
        private void ExportAsText(string filePath)
        {
            Room room   = roomRepository.GetById(booking.RoomId);
            int  nights = (booking.CheckOutDate - booking.CheckInDate).Days;

            var sb = new StringBuilder();
            const string sep  = "================================================================";
            const string line = "------------------------------------------------";

            sb.AppendLine(sep);
            sb.AppendLine("           HOTEL MANAGEMENT SYSTEM");
            sb.AppendLine("                   INVOICE");
            sb.AppendLine(sep);
            sb.AppendLine($"  Invoice No.  : {invoice.InvoiceNumber}");
            sb.AppendLine($"  Issue Date   : {invoice.IssueDate:MMM dd, yyyy}");
            sb.AppendLine($"  Due Date     : {invoice.DueDate:MMM dd, yyyy}");
            sb.AppendLine($"  Status       : {invoice.Status}");
            sb.AppendLine(sep);
            sb.AppendLine();

            sb.AppendLine("GUEST INFORMATION");
            sb.AppendLine(line);
            sb.AppendLine($"  Name    : {guest.FirstName} {guest.LastName}");
            sb.AppendLine($"  Email   : {guest.Email}");
            sb.AppendLine($"  Phone   : {guest.Phone}");
            sb.AppendLine();

            sb.AppendLine("BOOKING INFORMATION");
            sb.AppendLine(line);
            sb.AppendLine($"  Booking ID  : {booking.BookingId}");
            sb.AppendLine($"  Room        : {room?.RoomNumber ?? "N/A"}  ({room?.RoomType ?? "N/A"})");
            sb.AppendLine($"  Check-In    : {booking.CheckInDate:MMM dd, yyyy}");
            sb.AppendLine($"  Check-Out   : {booking.CheckOutDate:MMM dd, yyyy}");
            sb.AppendLine($"  Nights      : {nights}");
            sb.AppendLine();

            sb.AppendLine("FINANCIAL SUMMARY");
            sb.AppendLine(line);
            sb.AppendLine($"  {"Sub Total",-22} {invoice.SubTotal,10:C2}");
            sb.AppendLine($"  {"Tax (" + invoice.TaxRate + "%)",-22} {invoice.TaxAmount,10:C2}");
            sb.AppendLine($"  {"Discount",-22} {invoice.Discount,10:C2}");
            sb.AppendLine($"  {new string('-', 34)}");
            sb.AppendLine($"  {"TOTAL AMOUNT",-22} {invoice.TotalAmount,10:C2}");
            sb.AppendLine($"  {"Amount Paid",-22} {invoice.PaidAmount,10:C2}");
            sb.AppendLine($"  {new string('-', 34)}");
            sb.AppendLine($"  {"BALANCE DUE",-22} {invoice.BalanceAmount,10:C2}");
            sb.AppendLine();

            sb.AppendLine("PAYMENT HISTORY");
            sb.AppendLine(line);
            if (payments != null && payments.Count > 0)
            {
                sb.AppendLine($"  {"#",-4} {"Date",-20} {"Method",-14} {"Transaction ID",-24} {"Amount",10}  {"Status"}");
                sb.AppendLine($"  {new string('-', 80)}");
                int idx = 1;
                foreach (var p in payments)
                {
                    sb.AppendLine($"  {idx,-4} {p.PaymentDate,-20:MMM dd, yyyy HH:mm} {p.PaymentMethod,-14} {(p.TransactionId ?? "N/A"),-24} {p.Amount,10:C2}  {p.Status}");
                    idx++;
                }
                sb.AppendLine();
                sb.AppendLine($"  Total Payments : {payments.Count}");
                sb.AppendLine($"  Total Paid     : {payments.Sum(p => p.Amount):C2}");
            }
            else
            {
                sb.AppendLine("  No payments recorded.");
            }

            if (!string.IsNullOrWhiteSpace(invoice.Notes))
            {
                sb.AppendLine();
                sb.AppendLine("NOTES");
                sb.AppendLine(line);
                sb.AppendLine($"  {invoice.Notes}");
            }

            sb.AppendLine();
            sb.AppendLine(sep);
            sb.AppendLine($"  Generated on {DateTime.Now:MMM dd, yyyy  hh:mm tt}  |  Hotel Management System");
            sb.AppendLine(sep);

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Exports invoice and payment data as CSV
        /// </summary>
        private void ExportAsCsv(string filePath)
        {
            Room room   = roomRepository.GetById(booking.RoomId);
            int  nights = (booking.CheckOutDate - booking.CheckInDate).Days;

            var sb = new StringBuilder();

            // ── Invoice summary section ───────────────────────────────────────
            sb.AppendLine("INVOICE DETAILS");
            sb.AppendLine("Field,Value");
            sb.AppendLine($"Invoice Number,{CsvEscape(invoice.InvoiceNumber)}");
            sb.AppendLine($"Issue Date,{invoice.IssueDate:MMM dd yyyy}");
            sb.AppendLine($"Due Date,{invoice.DueDate:MMM dd yyyy}");
            sb.AppendLine($"Status,{CsvEscape(invoice.Status)}");
            sb.AppendLine($"Guest Name,{CsvEscape(guest.FirstName + " " + guest.LastName)}");
            sb.AppendLine($"Guest Email,{CsvEscape(guest.Email)}");
            sb.AppendLine($"Guest Phone,{CsvEscape(guest.Phone)}");
            sb.AppendLine($"Booking ID,{booking.BookingId}");
            sb.AppendLine($"Room,{CsvEscape(room?.RoomNumber ?? "N/A")}");
            sb.AppendLine($"Room Type,{CsvEscape(room?.RoomType ?? "N/A")}");
            sb.AppendLine($"Check-In,{booking.CheckInDate:MMM dd yyyy}");
            sb.AppendLine($"Check-Out,{booking.CheckOutDate:MMM dd yyyy}");
            sb.AppendLine($"Nights,{nights}");
            sb.AppendLine($"Sub Total,{invoice.SubTotal:F2}");
            sb.AppendLine($"Tax Rate,{invoice.TaxRate}");
            sb.AppendLine($"Tax Amount,{invoice.TaxAmount:F2}");
            sb.AppendLine($"Discount,{invoice.Discount:F2}");
            sb.AppendLine($"Total Amount,{invoice.TotalAmount:F2}");
            sb.AppendLine($"Paid Amount,{invoice.PaidAmount:F2}");
            sb.AppendLine($"Balance Due,{invoice.BalanceAmount:F2}");
            sb.AppendLine($"Notes,{CsvEscape(invoice.Notes ?? "")}");
            sb.AppendLine();

            // ── Payment history section ───────────────────────────────────────
            sb.AppendLine("PAYMENT HISTORY");
            sb.AppendLine("Payment ID,Date,Amount,Method,Transaction ID,Status");
            if (payments != null && payments.Count > 0)
            {
                foreach (var p in payments)
                {
                    sb.AppendLine(string.Join(",",
                        p.PaymentId,
                        CsvEscape(p.PaymentDate.ToString("MMM dd yyyy HH:mm")),
                        p.Amount.ToString("F2"),
                        CsvEscape(p.PaymentMethod),
                        CsvEscape(p.TransactionId ?? "N/A"),
                        CsvEscape(p.Status)));
                }
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Wraps a CSV field value in quotes if it contains commas, quotes, or newlines
        /// </summary>
        private static string CsvEscape(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                return $"\"{value.Replace("\"", "\"\"")}\"";
            return value;
        }
    }
}
