using HotelManagementSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Bookings
{
    public partial class BookingDetailsForm : Form
    {
        private readonly Booking _booking;
        private readonly Guest _guest;
        private readonly Room _room;

        public BookingDetailsForm(Booking booking, Guest guest, Room room)
        {
            _booking = booking;
            _guest = guest;
            _room = room;
            InitializeComponent();
            PopulateDetails();
        }

        private void PopulateDetails()
        {
            // Header
            lblBookingId.Text = $"Booking #{_booking.BookingId}";
            lblBookingDate.Text = $"Booked on {_booking.BookingDate:MMM dd, yyyy  hh:mm tt}";
            SetStatusBadge(_booking.Status);

            // Guest info
            lblGuestName.Text = _guest != null ? _guest.FullName : "Unknown";
            lblGuestEmail.Text = _guest?.Email ?? "N/A";
            lblGuestPhone.Text = _guest?.Phone ?? "N/A";
            lblGuestNationality.Text = _guest?.Nationality ?? "N/A";
            lblGuestId.Text = _guest?.IDNumber ?? "N/A";

            // Room info
            lblRoomNumber.Text = _room != null ? $"Room {_room.RoomNumber}" : "N/A";
            lblRoomType.Text = _room?.RoomType ?? "N/A";
            lblRoomFloor.Text = _room != null ? $"Floor {_room.FloorNumber}" : "N/A";
            lblRoomBed.Text = _room?.BedType ?? "N/A";
            lblRoomView.Text = _room?.ViewType ?? "Standard";
            lblRoomFeatures.Text = _room?.GetFeaturesSummary() ?? "N/A";

            // Dates
            lblCheckIn.Text = _booking.CheckInDate.ToString("dddd, MMM dd, yyyy");
            lblCheckOut.Text = _booking.CheckOutDate.ToString("dddd, MMM dd, yyyy");
            lblNights.Text = $"{_booking.NumberOfNights} night{(_booking.NumberOfNights != 1 ? "s" : "")}";
            lblGuests.Text = $"{_booking.NumberOfGuests} guest{(_booking.NumberOfGuests != 1 ? "s" : "")}";

            if (_booking.ActualCheckInDate.HasValue)
                lblActualCheckIn.Text = _booking.ActualCheckInDate.Value.ToString("MMM dd, yyyy  hh:mm tt");
            else
                lblActualCheckIn.Text = "—";

            if (_booking.ActualCheckOutDate.HasValue)
                lblActualCheckOut.Text = _booking.ActualCheckOutDate.Value.ToString("MMM dd, yyyy  hh:mm tt");
            else
                lblActualCheckOut.Text = "—";

            // Financial
            lblRoomCharges.Text = $"${_booking.RoomCharges:F2}";
            lblServiceCharges.Text = $"${_booking.ServiceCharges:F2}";
            lblTotalAmount.Text = $"${_booking.TotalAmount:F2}";

            // Notes
            if (!string.IsNullOrWhiteSpace(_booking.SpecialRequests))
            {
                lblSpecialRequests.Text = _booking.SpecialRequests;
                pnlSpecialRequests.Visible = true;
            }
            else
            {
                pnlSpecialRequests.Visible = false;
            }

            if (!string.IsNullOrWhiteSpace(_booking.Notes))
            {
                lblNotes.Text = _booking.Notes;
                pnlNotes.Visible = true;
            }
            else
            {
                pnlNotes.Visible = false;
            }

            if (_booking.Status == "Cancelled" && !string.IsNullOrWhiteSpace(_booking.CancellationReason))
            {
                lblCancellationDate.Text = _booking.CancelledDate.HasValue
                    ? _booking.CancelledDate.Value.ToString("MMM dd, yyyy  hh:mm tt")
                    : "N/A";
                lblCancellationReason.Text = _booking.CancellationReason;
                pnlCancellation.Visible = true;
            }
            else
            {
                pnlCancellation.Visible = false;
            }
        }

        private void SetStatusBadge(string status)
        {
            lblStatus.Text = status;
            switch (status)
            {
                case "Pending":
                    lblStatus.BackColor = Color.FromArgb(255, 193, 7);
                    lblStatus.ForeColor = Color.Black;
                    break;
                case "Confirmed":
                    lblStatus.BackColor = Color.FromArgb(40, 167, 69);
                    lblStatus.ForeColor = Color.White;
                    break;
                case "CheckedIn":
                    lblStatus.BackColor = Color.FromArgb(0, 123, 255);
                    lblStatus.ForeColor = Color.White;
                    break;
                case "CheckedOut":
                    lblStatus.BackColor = Color.FromArgb(108, 117, 125);
                    lblStatus.ForeColor = Color.White;
                    break;
                case "Cancelled":
                    lblStatus.BackColor = Color.FromArgb(220, 53, 69);
                    lblStatus.ForeColor = Color.White;
                    break;
                default:
                    lblStatus.BackColor = Color.Gray;
                    lblStatus.ForeColor = Color.White;
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
