namespace HotelManagementSystem.UI.Bookings
{
    partial class BookingDetailsForm
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
            // ── Controls ──────────────────────────────────────────────────────
            this.pnlHeader          = new System.Windows.Forms.Panel();
            this.lblBookingId       = new System.Windows.Forms.Label();
            this.lblBookingDate     = new System.Windows.Forms.Label();
            this.lblStatus          = new System.Windows.Forms.Label();
            this.pnlBody            = new System.Windows.Forms.Panel();
            this.pnlGuest           = new System.Windows.Forms.Panel();
            this.pnlGuestHeader     = new System.Windows.Forms.Panel();
            this.lblGuestTitle      = new System.Windows.Forms.Label();
            this.tblGuest           = new System.Windows.Forms.TableLayoutPanel();
            this.pnlRoom            = new System.Windows.Forms.Panel();
            this.pnlRoomHeader      = new System.Windows.Forms.Panel();
            this.lblRoomTitle       = new System.Windows.Forms.Label();
            this.tblRoom            = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDates           = new System.Windows.Forms.Panel();
            this.pnlDatesHeader     = new System.Windows.Forms.Panel();
            this.lblDatesTitle      = new System.Windows.Forms.Label();
            this.tblDates           = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFinancial       = new System.Windows.Forms.Panel();
            this.pnlFinancialHeader = new System.Windows.Forms.Panel();
            this.lblFinancialTitle  = new System.Windows.Forms.Label();
            this.tblFinancial       = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSpecialRequests = new System.Windows.Forms.Panel();
            this.pnlSRHeader        = new System.Windows.Forms.Panel();
            this.lblSRTitle         = new System.Windows.Forms.Label();
            this.lblSpecialRequests = new System.Windows.Forms.Label();
            this.pnlNotes           = new System.Windows.Forms.Panel();
            this.pnlNotesHeader     = new System.Windows.Forms.Panel();
            this.lblNotesTitle      = new System.Windows.Forms.Label();
            this.lblNotes           = new System.Windows.Forms.Label();
            this.pnlCancellation    = new System.Windows.Forms.Panel();
            this.pnlCancelHeader    = new System.Windows.Forms.Panel();
            this.lblCancelTitle     = new System.Windows.Forms.Label();
            this.tblCancel          = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFooter          = new System.Windows.Forms.Panel();
            this.btnClose           = new System.Windows.Forms.Button();

            // Guest row labels
            this.lblGuestNameLbl        = new System.Windows.Forms.Label();
            this.lblGuestName           = new System.Windows.Forms.Label();
            this.lblGuestEmailLbl       = new System.Windows.Forms.Label();
            this.lblGuestEmail          = new System.Windows.Forms.Label();
            this.lblGuestPhoneLbl       = new System.Windows.Forms.Label();
            this.lblGuestPhone          = new System.Windows.Forms.Label();
            this.lblGuestNationalityLbl = new System.Windows.Forms.Label();
            this.lblGuestNationality    = new System.Windows.Forms.Label();
            this.lblGuestIdLbl          = new System.Windows.Forms.Label();
            this.lblGuestId             = new System.Windows.Forms.Label();

            // Room row labels
            this.lblRoomNumberLbl   = new System.Windows.Forms.Label();
            this.lblRoomNumber      = new System.Windows.Forms.Label();
            this.lblRoomTypeLbl     = new System.Windows.Forms.Label();
            this.lblRoomType        = new System.Windows.Forms.Label();
            this.lblRoomFloorLbl    = new System.Windows.Forms.Label();
            this.lblRoomFloor       = new System.Windows.Forms.Label();
            this.lblRoomBedLbl      = new System.Windows.Forms.Label();
            this.lblRoomBed         = new System.Windows.Forms.Label();
            this.lblRoomViewLbl     = new System.Windows.Forms.Label();
            this.lblRoomView        = new System.Windows.Forms.Label();
            this.lblRoomFeaturesLbl = new System.Windows.Forms.Label();
            this.lblRoomFeatures    = new System.Windows.Forms.Label();

            // Dates row labels
            this.lblCheckInLbl       = new System.Windows.Forms.Label();
            this.lblCheckIn          = new System.Windows.Forms.Label();
            this.lblCheckOutLbl      = new System.Windows.Forms.Label();
            this.lblCheckOut         = new System.Windows.Forms.Label();
            this.lblNightsLbl        = new System.Windows.Forms.Label();
            this.lblNights           = new System.Windows.Forms.Label();
            this.lblGuestsLbl        = new System.Windows.Forms.Label();
            this.lblGuests           = new System.Windows.Forms.Label();
            this.lblActualCILbl      = new System.Windows.Forms.Label();
            this.lblActualCheckIn    = new System.Windows.Forms.Label();
            this.lblActualCOLbl      = new System.Windows.Forms.Label();
            this.lblActualCheckOut   = new System.Windows.Forms.Label();

            // Financial row labels
            this.lblRoomChargesLbl   = new System.Windows.Forms.Label();
            this.lblRoomCharges      = new System.Windows.Forms.Label();
            this.lblServiceChargesLbl= new System.Windows.Forms.Label();
            this.lblServiceCharges   = new System.Windows.Forms.Label();
            this.lblTotalAmountLbl   = new System.Windows.Forms.Label();
            this.lblTotalAmount      = new System.Windows.Forms.Label();

            // Cancellation row labels
            this.lblCancellationDateLbl   = new System.Windows.Forms.Label();
            this.lblCancellationDate      = new System.Windows.Forms.Label();
            this.lblCancellationReasonLbl = new System.Windows.Forms.Label();
            this.lblCancellationReason    = new System.Windows.Forms.Label();

            // ── Colours & fonts ───────────────────────────────────────────────
            var blue   = System.Drawing.Color.FromArgb(0, 102, 204);
            var teal   = System.Drawing.Color.FromArgb(0, 150, 136);
            var orange = System.Drawing.Color.FromArgb(255, 152, 0);
            var green  = System.Drawing.Color.FromArgb(56, 142, 60);
            var red    = System.Drawing.Color.FromArgb(198, 40, 40);
            var white  = System.Drawing.Color.White;
            var bodyBg = System.Drawing.Color.FromArgb(245, 247, 250);
            var cardBg = System.Drawing.Color.White;
            var captionFont = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Regular);
            var valueFont   = new System.Drawing.Font("Segoe UI", 9f,   System.Drawing.FontStyle.Bold);
            var titleFont   = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);

            // ── SCROLL PANEL (body) ───────────────────────────────────────────
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor  = bodyBg;
            this.pnlBody.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding    = new System.Windows.Forms.Padding(0);

            // ── Helper: create a section card ─────────────────────────────────
            // (done inline below)

            // ════════════════════════════════════════════════
            // HEADER
            // ════════════════════════════════════════════════
            this.pnlHeader.BackColor = blue;
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 72;
            this.pnlHeader.Padding   = new System.Windows.Forms.Padding(16, 0, 16, 0);

            this.lblBookingId.AutoSize  = true;
            this.lblBookingId.Font      = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
            this.lblBookingId.ForeColor = white;
            this.lblBookingId.Location  = new System.Drawing.Point(16, 10);
            this.lblBookingId.Text      = "Booking #0";

            this.lblBookingDate.AutoSize  = true;
            this.lblBookingDate.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblBookingDate.ForeColor = System.Drawing.Color.FromArgb(200, 220, 255);
            this.lblBookingDate.Location  = new System.Drawing.Point(18, 44);
            this.lblBookingDate.Text      = "";

            this.lblStatus.AutoSize    = false;
            this.lblStatus.Font        = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor   = white;
            this.lblStatus.BackColor   = System.Drawing.Color.Gray;
            this.lblStatus.Size        = new System.Drawing.Size(100, 26);
            this.lblStatus.Location    = new System.Drawing.Point(530, 23);
            this.lblStatus.Text        = "Status";
            this.lblStatus.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlHeader.Controls.Add(this.lblBookingId);
            this.pnlHeader.Controls.Add(this.lblBookingDate);
            this.pnlHeader.Controls.Add(this.lblStatus);

            // ════════════════════════════════════════════════
            // LOCAL helper lambdas
            // ════════════════════════════════════════════════
            System.Action<System.Windows.Forms.TableLayoutPanel, string, System.Windows.Forms.Label, System.Windows.Forms.Label, int>
            AddRow = (tbl, caption, capLbl, valLbl, row) =>
            {
                capLbl.Text      = caption;
                capLbl.Font      = captionFont;
                capLbl.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                capLbl.Dock      = System.Windows.Forms.DockStyle.Fill;
                capLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                capLbl.Padding   = new System.Windows.Forms.Padding(4, 0, 0, 0);

                valLbl.Text      = "—";
                valLbl.Font      = valueFont;
                valLbl.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
                valLbl.Dock      = System.Windows.Forms.DockStyle.Fill;
                valLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                valLbl.Padding   = new System.Windows.Forms.Padding(4, 0, 0, 0);

                tbl.Controls.Add(capLbl, 0, row);
                tbl.Controls.Add(valLbl, 1, row);
            };

            System.Func<System.Drawing.Color, string, System.Windows.Forms.Panel, System.Windows.Forms.Label,
                        System.Windows.Forms.TableLayoutPanel, int, System.Windows.Forms.Panel>
            BuildCard = (headerColor, title, headerPnl, titleLbl, tbl, rows) =>
            {
                var card = new System.Windows.Forms.Panel();
                card.BackColor   = cardBg;
                card.BorderStyle = System.Windows.Forms.BorderStyle.None;
                card.Margin      = new System.Windows.Forms.Padding(0, 0, 0, 10);
                card.AutoSize = false;

                headerPnl.BackColor = headerColor;
                headerPnl.Dock      = System.Windows.Forms.DockStyle.Top;
                headerPnl.Height    = 32;
                headerPnl.Padding   = new System.Windows.Forms.Padding(10, 0, 0, 0);

                titleLbl.Text      = title;
                titleLbl.Font      = titleFont;
                titleLbl.ForeColor = white;
                titleLbl.Dock      = System.Windows.Forms.DockStyle.Fill;
                titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                headerPnl.Controls.Add(titleLbl);

                tbl.Dock        = System.Windows.Forms.DockStyle.Fill;
                tbl.AutoSize    = false;
                tbl.ColumnCount = 2;
                tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160));
                tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
                tbl.RowCount    = rows;
                for (int i = 0; i < rows; i++)
                    tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32));
                tbl.Padding     = new System.Windows.Forms.Padding(6, 4, 6, 4);
                tbl.BackColor   = cardBg;

                card.Height = 32 + rows * 30 + 12;
                card.Controls.Add(tbl);
                card.Controls.Add(headerPnl);
                return card;
            };

            // ════════════════════════════════════════════════
            // GUEST CARD
            // ════════════════════════════════════════════════
            var cardGuest = BuildCard(blue, "👤  Guest Information",
                this.pnlGuestHeader, this.lblGuestTitle, this.tblGuest, 5);
            AddRow(tblGuest, "Full Name",    lblGuestNameLbl,        lblGuestName,        0);
            AddRow(tblGuest, "Email",        lblGuestEmailLbl,       lblGuestEmail,       1);
            AddRow(tblGuest, "Phone",        lblGuestPhoneLbl,       lblGuestPhone,       2);
            AddRow(tblGuest, "Nationality",  lblGuestNationalityLbl, lblGuestNationality, 3);
            AddRow(tblGuest, "ID / Passport",lblGuestIdLbl,          lblGuestId,          4);

            // ════════════════════════════════════════════════
            // ROOM CARD
            // ════════════════════════════════════════════════
            var cardRoom = BuildCard(teal, "🛏  Room Information",
                this.pnlRoomHeader, this.lblRoomTitle, this.tblRoom, 6);
            AddRow(tblRoom, "Room Number", lblRoomNumberLbl,   lblRoomNumber,   0);
            AddRow(tblRoom, "Room Type",   lblRoomTypeLbl,     lblRoomType,     1);
            AddRow(tblRoom, "Floor",       lblRoomFloorLbl,    lblRoomFloor,    2);
            AddRow(tblRoom, "Bed Type",    lblRoomBedLbl,      lblRoomBed,      3);
            AddRow(tblRoom, "View",        lblRoomViewLbl,     lblRoomView,     4);
            AddRow(tblRoom, "Amenities",   lblRoomFeaturesLbl, lblRoomFeatures, 5);
            // Amenities may wrap
            lblRoomFeatures.AutoSize = true;

            // ════════════════════════════════════════════════
            // DATES CARD
            // ════════════════════════════════════════════════
            var cardDates = BuildCard(orange, "📅  Booking Dates",
                this.pnlDatesHeader, this.lblDatesTitle, this.tblDates, 6);
            AddRow(tblDates, "Check-In",          lblCheckInLbl,    lblCheckIn,       0);
            AddRow(tblDates, "Check-Out",         lblCheckOutLbl,   lblCheckOut,      1);
            AddRow(tblDates, "Duration",          lblNightsLbl,     lblNights,        2);
            AddRow(tblDates, "Number of Guests",  lblGuestsLbl,     lblGuests,        3);
            AddRow(tblDates, "Actual Check-In",   lblActualCILbl,   lblActualCheckIn, 4);
            AddRow(tblDates, "Actual Check-Out",  lblActualCOLbl,   lblActualCheckOut,5);

            // ════════════════════════════════════════════════
            // FINANCIAL CARD
            // ════════════════════════════════════════════════
            var cardFin = BuildCard(green, "💰  Financial Summary",
                this.pnlFinancialHeader, this.lblFinancialTitle, this.tblFinancial, 3);
            AddRow(tblFinancial, "Room Charges",    lblRoomChargesLbl,    lblRoomCharges,    0);
            AddRow(tblFinancial, "Service Charges", lblServiceChargesLbl, lblServiceCharges, 1);
            AddRow(tblFinancial, "Total Amount",    lblTotalAmountLbl,    lblTotalAmount,    2);
            lblTotalAmount.Font      = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            lblTotalAmount.ForeColor = green;

            // ════════════════════════════════════════════════
            // SPECIAL REQUESTS CARD
            // ════════════════════════════════════════════════
            this.pnlSRHeader.BackColor = System.Drawing.Color.FromArgb(103, 58, 183);
            this.pnlSRHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlSRHeader.Height    = 32;
            this.pnlSRHeader.Padding   = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSRTitle.Text       = "📝  Special Requests";
            this.lblSRTitle.Font       = titleFont;
            this.lblSRTitle.ForeColor  = white;
            this.lblSRTitle.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.lblSRTitle.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlSRHeader.Controls.Add(this.lblSRTitle);

            this.lblSpecialRequests.Text      = "";
            this.lblSpecialRequests.Font      = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSpecialRequests.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblSpecialRequests.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblSpecialRequests.AutoSize  = false;
            this.lblSpecialRequests.Padding   = new System.Windows.Forms.Padding(12, 6, 12, 6);

            this.pnlSpecialRequests.BackColor = cardBg;
            this.pnlSpecialRequests.Height    = 80;
            this.pnlSpecialRequests.Controls.Add(this.lblSpecialRequests);
            this.pnlSpecialRequests.Controls.Add(this.pnlSRHeader);

            // ════════════════════════════════════════════════
            // NOTES CARD
            // ════════════════════════════════════════════════
            this.pnlNotesHeader.BackColor = System.Drawing.Color.FromArgb(69, 90, 100);
            this.pnlNotesHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlNotesHeader.Height    = 32;
            this.pnlNotesHeader.Padding   = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblNotesTitle.Text       = "🗒  Notes";
            this.lblNotesTitle.Font       = titleFont;
            this.lblNotesTitle.ForeColor  = white;
            this.lblNotesTitle.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.lblNotesTitle.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlNotesHeader.Controls.Add(this.lblNotesTitle);

            this.lblNotes.Text      = "";
            this.lblNotes.Font      = new System.Drawing.Font("Segoe UI", 9f);
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblNotes.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblNotes.AutoSize  = false;
            this.lblNotes.Padding   = new System.Windows.Forms.Padding(12, 6, 12, 6);

            this.pnlNotes.BackColor = cardBg;
            this.pnlNotes.Height    = 80;
            this.pnlNotes.Controls.Add(this.lblNotes);
            this.pnlNotes.Controls.Add(this.pnlNotesHeader);

            // ════════════════════════════════════════════════
            // CANCELLATION CARD
            // ════════════════════════════════════════════════
            var cardCancel = BuildCard(red, "🚫  Cancellation Details",
                this.pnlCancelHeader, this.lblCancelTitle, this.tblCancel, 2);
            AddRow(tblCancel, "Cancelled On", lblCancellationDateLbl,   lblCancellationDate,   0);
            AddRow(tblCancel, "Reason",       lblCancellationReasonLbl, lblCancellationReason, 1);

            // ════════════════════════════════════════════════
            // LAYOUT: two columns placed directly in pnlBody
            // ════════════════════════════════════════════════
            const int colW   = 366;
            const int startX = 8;
            const int col2X  = startX + colW + 8; // 382

            var leftCol  = new System.Windows.Forms.FlowLayoutPanel();
            leftCol.FlowDirection  = System.Windows.Forms.FlowDirection.TopDown;
            leftCol.WrapContents   = false;
            leftCol.AutoSize       = true;
            leftCol.AutoSizeMode   = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            leftCol.Location       = new System.Drawing.Point(startX, 8);
            leftCol.Width          = colW;

            var rightCol = new System.Windows.Forms.FlowLayoutPanel();
            rightCol.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            rightCol.WrapContents  = false;
            rightCol.AutoSize      = true;
            rightCol.AutoSizeMode  = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            rightCol.Location      = new System.Drawing.Point(col2X, 8);
            rightCol.Width         = colW;

            cardGuest.Width               = colW; leftCol.Controls.Add(cardGuest);
            cardFin.Width                 = colW; leftCol.Controls.Add(cardFin);
            this.pnlSpecialRequests.Width = colW; leftCol.Controls.Add(this.pnlSpecialRequests);
            this.pnlNotes.Width           = colW; leftCol.Controls.Add(this.pnlNotes);
            cardCancel.Width              = colW; leftCol.Controls.Add(cardCancel);

            cardRoom.Width  = colW; rightCol.Controls.Add(cardRoom);
            cardDates.Width = colW; rightCol.Controls.Add(cardDates);

            this.pnlBody.Controls.Add(leftCol);
            this.pnlBody.Controls.Add(rightCol);

            // ════════════════════════════════════════════════
            // FOOTER
            // ════════════════════════════════════════════════
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(235, 237, 240);
            this.pnlFooter.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height    = 52;
            this.pnlFooter.Padding   = new System.Windows.Forms.Padding(0, 8, 14, 8);

            this.btnClose.Text          = "Close";
            this.btnClose.Font          = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnClose.BackColor     = blue;
            this.btnClose.ForeColor     = white;
            this.btnClose.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Size          = new System.Drawing.Size(110, 34);
            this.btnClose.Anchor        = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Location      = new System.Drawing.Point(this.pnlFooter.Width - 124, 8);
            this.btnClose.Click        += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Cursor        = System.Windows.Forms.Cursors.Hand;
            this.pnlFooter.Controls.Add(this.btnClose);

            // ════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = bodyBg;
            this.ClientSize          = new System.Drawing.Size(780, 600);
            this.MinimumSize         = new System.Drawing.Size(780, 500);
            this.Font                = new System.Drawing.Font("Segoe UI", 9f);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.Name                = "BookingDetailsForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Booking Details";

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
        }

        #endregion

        // ── Header ───────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBookingId;
        private System.Windows.Forms.Label lblBookingDate;
        private System.Windows.Forms.Label lblStatus;

        // ── Body ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlBody;

        // Guest card
        private System.Windows.Forms.Panel           pnlGuest;
        private System.Windows.Forms.Panel           pnlGuestHeader;
        private System.Windows.Forms.Label           lblGuestTitle;
        private System.Windows.Forms.TableLayoutPanel tblGuest;
        private System.Windows.Forms.Label lblGuestNameLbl, lblGuestName;
        private System.Windows.Forms.Label lblGuestEmailLbl, lblGuestEmail;
        private System.Windows.Forms.Label lblGuestPhoneLbl, lblGuestPhone;
        private System.Windows.Forms.Label lblGuestNationalityLbl, lblGuestNationality;
        private System.Windows.Forms.Label lblGuestIdLbl, lblGuestId;

        // Room card
        private System.Windows.Forms.Panel           pnlRoom;
        private System.Windows.Forms.Panel           pnlRoomHeader;
        private System.Windows.Forms.Label           lblRoomTitle;
        private System.Windows.Forms.TableLayoutPanel tblRoom;
        private System.Windows.Forms.Label lblRoomNumberLbl, lblRoomNumber;
        private System.Windows.Forms.Label lblRoomTypeLbl,   lblRoomType;
        private System.Windows.Forms.Label lblRoomFloorLbl,  lblRoomFloor;
        private System.Windows.Forms.Label lblRoomBedLbl,    lblRoomBed;
        private System.Windows.Forms.Label lblRoomViewLbl,   lblRoomView;
        private System.Windows.Forms.Label lblRoomFeaturesLbl, lblRoomFeatures;

        // Dates card
        private System.Windows.Forms.Panel           pnlDates;
        private System.Windows.Forms.Panel           pnlDatesHeader;
        private System.Windows.Forms.Label           lblDatesTitle;
        private System.Windows.Forms.TableLayoutPanel tblDates;
        private System.Windows.Forms.Label lblCheckInLbl,    lblCheckIn;
        private System.Windows.Forms.Label lblCheckOutLbl,   lblCheckOut;
        private System.Windows.Forms.Label lblNightsLbl,     lblNights;
        private System.Windows.Forms.Label lblGuestsLbl,     lblGuests;
        private System.Windows.Forms.Label lblActualCILbl,   lblActualCheckIn;
        private System.Windows.Forms.Label lblActualCOLbl,   lblActualCheckOut;

        // Financial card
        private System.Windows.Forms.Panel           pnlFinancial;
        private System.Windows.Forms.Panel           pnlFinancialHeader;
        private System.Windows.Forms.Label           lblFinancialTitle;
        private System.Windows.Forms.TableLayoutPanel tblFinancial;
        private System.Windows.Forms.Label lblRoomChargesLbl,    lblRoomCharges;
        private System.Windows.Forms.Label lblServiceChargesLbl, lblServiceCharges;
        private System.Windows.Forms.Label lblTotalAmountLbl,    lblTotalAmount;

        // Special requests card
        private System.Windows.Forms.Panel pnlSpecialRequests;
        private System.Windows.Forms.Panel pnlSRHeader;
        private System.Windows.Forms.Label lblSRTitle;
        private System.Windows.Forms.Label lblSpecialRequests;

        // Notes card
        private System.Windows.Forms.Panel pnlNotes;
        private System.Windows.Forms.Panel pnlNotesHeader;
        private System.Windows.Forms.Label lblNotesTitle;
        private System.Windows.Forms.Label lblNotes;

        // Cancellation card
        private System.Windows.Forms.Panel           pnlCancellation;
        private System.Windows.Forms.Panel           pnlCancelHeader;
        private System.Windows.Forms.Label           lblCancelTitle;
        private System.Windows.Forms.TableLayoutPanel tblCancel;
        private System.Windows.Forms.Label lblCancellationDateLbl,   lblCancellationDate;
        private System.Windows.Forms.Label lblCancellationReasonLbl, lblCancellationReason;

        // ── Footer ────────────────────────────────────────────────
        private System.Windows.Forms.Panel  pnlFooter;
        private System.Windows.Forms.Button btnClose;
    }
}
