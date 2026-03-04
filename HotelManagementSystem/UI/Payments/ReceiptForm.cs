using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.UI.Payments
{
    public partial class ReceiptForm : Form
    {
        private Payment _payment;
        private Invoice _invoice;
        private Booking _booking;
        private Guest _guest;
        private Room _room;

        // Design tokens
        private static readonly Color ColorPrimary    = Color.FromArgb(26,  82,  118);
        private static readonly Color ColorAccent     = Color.FromArgb(41,  128, 185);
        private static readonly Color ColorSuccess    = Color.FromArgb(39,  174,  96);
        private static readonly Color ColorWarning    = Color.FromArgb(243, 156,  18);
        private static readonly Color ColorDanger     = Color.FromArgb(192,  57,  43);
        private static readonly Color ColorSectionBg  = Color.FromArgb(241, 245, 249);
        private static readonly Color ColorTextDark   = Color.FromArgb( 44,  62,  80);
        private static readonly Color ColorTextMuted  = Color.FromArgb(127, 140, 141);
        private static readonly Color ColorDivider    = Color.FromArgb(189, 195, 199);

        private const int CardWidth   = 640;
        private const int CardPadX    = 24;
        private const int LabelColW   = 155;

        public ReceiptForm(int paymentId)
        {
            InitializeComponent();
            LoadPaymentDetails(paymentId);
            this.Load += (s, e) => BuildReceiptUI();
        }

        // ─── Data Loading ────────────────────────────────────────────────────────

        private void LoadPaymentDetails(int paymentId)
        {
            var paymentRepo = new PaymentRepository();
            _payment = paymentRepo.GetById(paymentId);

            if (_payment == null)
            {
                MessageBox.Show("Payment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            var invoiceRepo = new InvoiceRepository();
            _invoice = invoiceRepo.GetById(_payment.InvoiceId);

            if (_invoice != null)
            {
                var bookingRepo = new BookingRepository();
                _booking = bookingRepo.GetById(_invoice.BookingId);

                if (_booking != null)
                {
                    _guest = new GuestRepository().GetById(_booking.GuestId);
                    _room  = new RoomRepository().GetById(_booking.RoomId);
                }
            }
        }

        // ─── UI Construction ─────────────────────────────────────────────────────

        private void BuildReceiptUI()
        {
            pnlContent.Controls.Clear();
            pnlContent.SuspendLayout();

            int cardLeft = Math.Max(10, (pnlContent.ClientSize.Width - CardWidth) / 2);

            // White "paper" card
            var card = new Panel
            {
                BackColor   = Color.White,
                Left        = cardLeft,
                Top         = 20,
                Width       = CardWidth,
                Height      = 100,       // will be updated at end
                BorderStyle = BorderStyle.None
            };
            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(210, 215, 220), 1))
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };
            pnlContent.Controls.Add(card);

            int y = 0;

            // ── Card header (gradient) ──────────────────────────────────────────
            var cardHeader = new Panel { Left = 0, Top = 0, Width = CardWidth, Height = 96, BackColor = ColorPrimary };
            cardHeader.Paint += CardHeader_Paint;
            card.Controls.Add(cardHeader);
            y = 106;

            // ── Receipt Information ─────────────────────────────────────────────
            y = AddSectionHeader(card, "RECEIPT INFORMATION", y);
            y = AddRow(card, "Receipt #:",   _payment.PaymentId.ToString("D8"), y);
            y = AddRow(card, "Date & Time:", _payment.PaymentDate.ToString("MMMM dd, yyyy   hh:mm tt"), y);
            if (_invoice != null)
                y = AddRow(card, "Invoice #:", _invoice.InvoiceNumber ?? "—", y);
            y += 6;

            // ── Guest Information ───────────────────────────────────────────────
            if (_guest != null)
            {
                y = AddSectionHeader(card, "GUEST INFORMATION", y);
                y = AddRow(card, "Name:",  $"{_guest.FirstName} {_guest.LastName}", y);
                if (!string.IsNullOrEmpty(_guest.Email))  y = AddRow(card, "Email:", _guest.Email,  y);
                if (!string.IsNullOrEmpty(_guest.Phone))  y = AddRow(card, "Phone:", _guest.Phone,  y);
                y += 6;
            }

            // ── Booking Details ─────────────────────────────────────────────────
            if (_booking != null)
            {
                y = AddSectionHeader(card, "BOOKING DETAILS", y);
                y = AddRow(card, "Booking ID:", $"# {_booking.BookingId}", y);
                if (_room != null)
                    y = AddRow(card, "Room:", $"{_room.RoomNumber}  —  {_room.RoomType}", y);
                y = AddRow(card, "Check-In:",   _booking.CheckInDate.ToString("MMM dd, yyyy"),  y);
                y = AddRow(card, "Check-Out:",  _booking.CheckOutDate.ToString("MMM dd, yyyy"), y);
                int nights = (_booking.CheckOutDate - _booking.CheckInDate).Days;
                y = AddRow(card, "Duration:",   $"{nights} night{(nights != 1 ? "s" : "")}", y);
                y = AddRow(card, "Guests:",     _booking.NumberOfGuests.ToString(), y);
                y += 6;
            }

            // ── Financial Breakdown ─────────────────────────────────────────────
            if (_invoice != null)
            {
                y = AddSectionHeader(card, "FINANCIAL BREAKDOWN", y);

                if (_booking != null)
                {
                    y = AddAmountRow(card, "Room Charges:",     _booking.RoomCharges,    y, false);
                    if (_booking.ServiceCharges > 0)
                        y = AddAmountRow(card, "Service Charges:", _booking.ServiceCharges, y, false);
                }

                y = AddAmountRow(card, $"Tax ({_invoice.TaxRate:0}%):", _invoice.TaxAmount, y, false);

                if (_invoice.Discount > 0)
                    y = AddAmountRow(card, "Discount:", -_invoice.Discount, y, false);

                y = AddDivider(card, y);
                y = AddAmountRow(card, "TOTAL AMOUNT:", _invoice.TotalAmount, y, true);
                y += 6;
            }

            // ── Payment Information ─────────────────────────────────────────────
            y = AddSectionHeader(card, "PAYMENT INFORMATION", y);
            y = AddRow(card, "Method:", _payment.PaymentMethod, y);

            if (_payment.PaymentMethod == "CreditCard" && !string.IsNullOrEmpty(_payment.CardNumber))
            {
                y = AddRow(card, "Card:", $"**** **** **** {_payment.CardNumber}", y);
                if (!string.IsNullOrEmpty(_payment.CardHolderName))
                    y = AddRow(card, "Card Holder:", _payment.CardHolderName, y);
            }

            if (!string.IsNullOrEmpty(_payment.TransactionId))
                y = AddRow(card, "Transaction ID:", _payment.TransactionId, y);

            y = AddDivider(card, y);

            y = AddAmountRow(card, "AMOUNT PAID:", _payment.Amount, y, true, ColorSuccess);

            if (_invoice != null)
            {
                Color balColor = _invoice.BalanceAmount <= 0 ? ColorSuccess : ColorDanger;
                y = AddAmountRow(card, "REMAINING BALANCE:", _invoice.BalanceAmount, y, true, balColor);
            }
            y += 10;

            // ── Status Badge ────────────────────────────────────────────────────
            y = AddStatusBadge(card, y);
            y += 14;

            // ── Footer ──────────────────────────────────────────────────────────
            y = AddFooter(card, y);
            y += 24;

            // Finalize card height and scroll size
            card.Height = y;
            pnlContent.AutoScrollMinSize = new Size(CardWidth + 40, y + 40);
            pnlContent.ResumeLayout(true);
        }

        // ─── Paint Handlers ──────────────────────────────────────────────────────

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            var g   = e.Graphics;
            var pnl = (Panel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Gradient background
            using (var br = new LinearGradientBrush(pnl.ClientRectangle, ColorPrimary, ColorAccent, LinearGradientMode.Horizontal))
                g.FillRectangle(br, pnl.ClientRectangle);

            // Hotel name (left)
            using (var fnt = new Font("Segoe UI", 13f, FontStyle.Bold))
            using (var br  = new SolidBrush(Color.White))
                g.DrawString("🏨  Hotel Management System", fnt, br, new PointF(18, 20));

            // Subtitle
            using (var fnt = new Font("Segoe UI", 9f))
            using (var br  = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                g.DrawString("Payment Receipt", fnt, br, new PointF(22, 52));

            // Date on the right
            string dateStr = _payment != null
                ? _payment.PaymentDate.ToString("MMM dd, yyyy")
                : DateTime.Now.ToString("MMM dd, yyyy");
            using (var fnt = new Font("Segoe UI", 8.5f))
            using (var br  = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
            {
                var fmt = new StringFormat { Alignment = StringAlignment.Far };
                g.DrawString(dateStr, fnt, br, new RectangleF(0, 24, pnl.Width - 16, 20), fmt);
                if (_payment != null)
                    g.DrawString($"Receipt # {_payment.PaymentId:D8}", fnt, br,
                        new RectangleF(0, 46, pnl.Width - 16, 20), fmt);
            }
        }

        private void CardHeader_Paint(object sender, PaintEventArgs e)
        {
            var g   = e.Graphics;
            var pnl = (Panel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var br = new LinearGradientBrush(pnl.ClientRectangle, ColorPrimary, ColorAccent, LinearGradientMode.Horizontal))
                g.FillRectangle(br, pnl.ClientRectangle);

            // Checkmark circle
            var cr = new Rectangle(18, 18, 58, 58);
            g.FillEllipse(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), cr);
            g.DrawEllipse(new Pen(Color.White, 2), cr);
            using (var pen = new Pen(Color.White, 3f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                g.DrawLines(pen, new[] { new PointF(31, 48), new PointF(41, 60), new PointF(63, 37) });

            // "Payment Successful"
            using (var fnt = new Font("Segoe UI", 15f, FontStyle.Bold))
            using (var br  = new SolidBrush(Color.White))
                g.DrawString("Payment Successful", fnt, br, new PointF(90, 16));

            // Hotel name
            using (var fnt = new Font("Segoe UI", 9f))
            using (var br  = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                g.DrawString("HOTEL MANAGEMENT SYSTEM", fnt, br, new PointF(92, 52));

            // Date (right)
            if (_payment != null)
            {
                using (var fnt = new Font("Segoe UI", 8.5f))
                using (var br  = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                {
                    var fmt = new StringFormat { Alignment = StringAlignment.Far };
                    g.DrawString(_payment.PaymentDate.ToString("MMM dd, yyyy"), fnt, br,
                        new RectangleF(0, 22, pnl.Width - 16, 20), fmt);
                    g.DrawString($"# {_payment.PaymentId:D8}", fnt, br,
                        new RectangleF(0, 44, pnl.Width - 16, 20), fmt);
                }
            }
        }

        // ─── Row Builders ─────────────────────────────────────────────────────────

        private int AddSectionHeader(Panel card, string title, int y)
        {
            var pnl = new Panel { Left = 0, Top = y, Width = CardWidth, Height = 30, BackColor = ColorSectionBg };
            var lbl = new Label
            {
                Text      = title,
                Font      = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = ColorPrimary,
                Left      = CardPadX,
                Top       = 7,
                AutoSize  = true,
                BackColor = Color.Transparent
            };
            pnl.Controls.Add(lbl);
            card.Controls.Add(pnl);
            return y + 36;
        }

        private int AddRow(Panel card, string label, string value, int y)
        {
            card.Controls.Add(new Label
            {
                Text      = label,
                Font      = new Font("Segoe UI", 9f),
                ForeColor = ColorTextMuted,
                Left      = CardPadX,
                Top       = y,
                Width     = LabelColW,
                Height    = 22,
                AutoSize  = false
            });
            card.Controls.Add(new Label
            {
                Text      = value,
                Font      = new Font("Segoe UI", 9f),
                ForeColor = ColorTextDark,
                Left      = CardPadX + LabelColW,
                Top       = y,
                Width     = CardWidth - CardPadX * 2 - LabelColW,
                Height    = 22,
                AutoSize  = false
            });
            return y + 24;
        }

        private int AddAmountRow(Panel card, string label, decimal amount, int y, bool bold, Color? color = null)
        {
            var fnt   = bold ? new Font("Segoe UI", 10f, FontStyle.Bold) : new Font("Segoe UI", 9f);
            var clr   = color ?? ColorTextDark;
            int rowH  = bold ? 26 : 22;
            int valW  = 120;

            card.Controls.Add(new Label
            {
                Text      = label,
                Font      = fnt,
                ForeColor = clr,
                Left      = CardPadX,
                Top       = y,
                Width     = CardWidth - CardPadX * 2 - valW,
                Height    = rowH,
                AutoSize  = false
            });
            card.Controls.Add(new Label
            {
                Text      = amount.ToString("C"),
                Font      = fnt,
                ForeColor = clr,
                Left      = CardWidth - CardPadX - valW,
                Top       = y,
                Width     = valW,
                Height    = rowH,
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize  = false
            });
            return y + rowH + 2;
        }

        private int AddDivider(Panel card, int y)
        {
            y += 4;
            card.Controls.Add(new Panel { Left = CardPadX, Top = y, Width = CardWidth - CardPadX * 2, Height = 1, BackColor = ColorDivider });
            return y + 8;
        }

        private int AddStatusBadge(Panel card, int y)
        {
            string status = _invoice?.Status ?? "Pending";
            Color  badgeColor;
            string badgeText;

            switch (status)
            {
                case "Paid":
                    badgeColor = ColorSuccess;
                    badgeText  = "✓   PAID IN FULL";
                    break;
                case "PartiallyPaid":
                    badgeColor = ColorWarning;
                    badgeText  = "◑   PARTIALLY PAID";
                    break;
                default:
                    badgeColor = ColorDanger;
                    badgeText  = "○   PAYMENT PENDING";
                    break;
            }

            const int bw = 210;
            card.Controls.Add(new Label
            {
                Text      = badgeText,
                Font      = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = badgeColor,
                TextAlign = ContentAlignment.MiddleCenter,
                Left      = (CardWidth - bw) / 2,
                Top       = y,
                Width     = bw,
                Height    = 38
            });
            return y + 50;
        }

        private int AddFooter(Panel card, int y)
        {
            card.Controls.Add(new Panel { Left = CardPadX, Top = y, Width = CardWidth - CardPadX * 2, Height = 1, BackColor = ColorDivider });
            y += 12;
            card.Controls.Add(new Label
            {
                Text      = "Thank you for choosing Hotel Management System\r\ninfo@hotelms.com  |  +1-234-567-8900",
                Font      = new Font("Segoe UI", 8.5f),
                ForeColor = ColorTextMuted,
                TextAlign = ContentAlignment.MiddleCenter,
                Left      = 0,
                Top       = y,
                Width     = CardWidth,
                Height    = 38,
                AutoSize  = false
            });
            return y + 44;
        }

        // ─── Text Generation (for Print / Copy) ──────────────────────────────────

        private string GenerateReceiptText()
        {
            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════");
            sb.AppendLine("           HOTEL MANAGEMENT SYSTEM");
            sb.AppendLine("                 PAYMENT RECEIPT");
            sb.AppendLine("═══════════════════════════════════════════════════");
            sb.AppendLine();

            if (_payment != null)
            {
                sb.AppendLine($"Receipt #:          {_payment.PaymentId:D8}");
                sb.AppendLine($"Date:               {_payment.PaymentDate:dd/MM/yyyy HH:mm}");
                sb.AppendLine($"Method:             {_payment.PaymentMethod}");
            }
            if (_invoice != null)
                sb.AppendLine($"Invoice #:          {_invoice.InvoiceNumber}");
            sb.AppendLine();

            if (_guest != null)
            {
                sb.AppendLine("───────────────────────────────────────────────────");
                sb.AppendLine("GUEST INFORMATION");
                sb.AppendLine("───────────────────────────────────────────────────");
                sb.AppendLine($"Name:               {_guest.FirstName} {_guest.LastName}");
                sb.AppendLine($"Email:              {_guest.Email}");
                sb.AppendLine($"Phone:              {_guest.Phone}");
                sb.AppendLine();
            }

            if (_booking != null && _room != null)
            {
                sb.AppendLine("───────────────────────────────────────────────────");
                sb.AppendLine("BOOKING DETAILS");
                sb.AppendLine("───────────────────────────────────────────────────");
                sb.AppendLine($"Booking ID:         #{_booking.BookingId}");
                sb.AppendLine($"Room:               {_room.RoomNumber} ({_room.RoomType})");
                sb.AppendLine($"Check-In:           {_booking.CheckInDate:dd/MM/yyyy}");
                sb.AppendLine($"Check-Out:          {_booking.CheckOutDate:dd/MM/yyyy}");
                int nights = (_booking.CheckOutDate - _booking.CheckInDate).Days;
                sb.AppendLine($"Nights:             {nights}");
                sb.AppendLine();
            }

            if (_invoice != null)
            {
                sb.AppendLine("───────────────────────────────────────────────────");
                sb.AppendLine("FINANCIAL BREAKDOWN");
                sb.AppendLine("───────────────────────────────────────────────────");
                sb.AppendLine($"Subtotal:           {_invoice.SubTotal,15:C}");
                sb.AppendLine($"Tax ({_invoice.TaxRate:0}%):         {_invoice.TaxAmount,15:C}");
                if (_invoice.Discount > 0)
                    sb.AppendLine($"Discount:           {_invoice.Discount,15:C}");
                sb.AppendLine($"                    ────────────────");
                sb.AppendLine($"Total:              {_invoice.TotalAmount,15:C}");
                sb.AppendLine();
            }

            if (_payment != null)
            {
                sb.AppendLine($"Amount Paid:        {_payment.Amount,15:C}");
                if (_payment.PaymentMethod == "CreditCard" && !string.IsNullOrEmpty(_payment.CardNumber))
                    sb.AppendLine($"Card:               **** **** **** {_payment.CardNumber}");
                if (!string.IsNullOrEmpty(_payment.TransactionId))
                    sb.AppendLine($"Transaction ID:     {_payment.TransactionId}");
            }
            if (_invoice != null)
            {
                sb.AppendLine($"Remaining Balance:  {_invoice.BalanceAmount,15:C}");
                sb.AppendLine($"Status:             {_invoice.Status}");
            }

            sb.AppendLine();
            sb.AppendLine("═══════════════════════════════════════════════════");
            sb.AppendLine("         THANK YOU FOR YOUR PAYMENT!");
            sb.AppendLine("═══════════════════════════════════════════════════");
            return sb.ToString();
        }

        // ─── Button Handlers ─────────────────────────────────────────────────────

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var printDialog  = new PrintDialog();
                var printDoc     = new System.Drawing.Printing.PrintDocument();
                printDoc.PrintPage += (s, pe) =>
                    pe.Graphics.DrawString(GenerateReceiptText(), new Font("Courier New", 10), Brushes.Black, new PointF(50, 50));
                printDialog.Document = printDoc;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    MessageBox.Show("Receipt sent to printer successfully!", "Print",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF export will be available in a future version.\n\n" +
                "Tip: Use Print → 'Microsoft Print to PDF' to save as PDF.",
                "PDF Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(GenerateReceiptText());
                MessageBox.Show("Receipt copied to clipboard!", "Copied",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying to clipboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
