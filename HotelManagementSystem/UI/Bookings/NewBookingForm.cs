using HotelManagementSystem.BLL;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Helpers;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Bookings
{
    public partial class NewBookingForm : Form
    {
        private GuestRepository guestRepository;
        private RoomRepository roomRepository;
        private BookingFacade bookingFacade;
        private List<Guest> allGuests;
        private List<Room> availableRooms;

        public NewBookingForm()
        {
            InitializeComponent();
            guestRepository = new GuestRepository();
            roomRepository = new RoomRepository();
            bookingFacade = new BookingFacade();
            this.Load += NewBookingForm_Load;
        }

        private void NewBookingForm_Load(object sender, EventArgs e)
        {
            LoadGuests();
            SetupDatePickers();
            SetupNumericUpDowns();
            UpdateAvailableRooms();
        }

        /// <summary>
        /// Load all active guests into the combo box
        /// </summary>
        private void LoadGuests()
        {
            try
            {
                allGuests = guestRepository.GetAll();

                // Clear existing items
                cmbGuest.Items.Clear();

                // Add "Select Guest..." as first item
                cmbGuest.Items.Add("-- Select Guest --");

                // Add all guests
                foreach (Guest guest in allGuests)
                {
                    // Display format: "John Smith (john@example.com)"
                    cmbGuest.Items.Add($"{guest.FirstName} {guest.LastName} ({guest.Email})");
                }

                // Select first item
                cmbGuest.SelectedIndex = 0;

                lblGuestCount.Text = $"{allGuests.Count} guests available";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guests: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Setup date pickers with default values
        /// </summary>
        private void SetupDatePickers()
        {
            // Check-in: Tomorrow (default)
            dtpCheckIn.Value = DateTime.Today.AddDays(1);
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.ValueChanged += DatesChanged;

            // Check-out: Day after check-in (default)
            dtpCheckOut.Value = DateTime.Today.AddDays(2);
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.ValueChanged += DatesChanged;
        }

        /// <summary>
        /// Setup numeric up/down controls
        /// </summary>
        private void SetupNumericUpDowns()
        {
            // Number of guests
            numGuests.Minimum = 1;
            numGuests.Maximum = 10;
            numGuests.Value = 1;
        }

        /// <summary>
        /// Event handler when dates change - update available rooms
        /// </summary>
        private void DatesChanged(object sender, EventArgs e)
        {
            // Ensure check-out is after check-in
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }

            // Update check-out min date
            dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);

            // Update number of nights
            UpdateNightsAndTotal();

            // Refresh available rooms
            UpdateAvailableRooms();
        }

        /// <summary>
        /// Update available rooms based on selected dates
        /// </summary>
        private void UpdateAvailableRooms()
        {
            try
            {
                DateTime checkIn = dtpCheckIn.Value.Date;
                DateTime checkOut = dtpCheckOut.Value.Date;

                // Get available rooms from facade
                availableRooms = bookingFacade.GetAvailableRooms(checkIn, checkOut);

                // Update combo box
                cmbRoom.Items.Clear();
                cmbRoom.Items.Add("-- Select Room --");

                foreach (Room room in availableRooms)
                {
                    // Display format: "101 - Single Room - $50.00/night (Max: 1)"
                    cmbRoom.Items.Add($"{room.RoomNumber} - {room.RoomType} - ${room.BasePrice:F2}/night (Max: {room.MaxOccupancy})");
                }

                cmbRoom.SelectedIndex = 0;

                // Update label
                lblRoomCount.Text = $"{availableRooms.Count} rooms available";

                // Clear selection
                lblRoomPrice.Text = "Price: $0.00/night";
                UpdateNightsAndTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading available rooms: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update nights and total calculation
        /// </summary>
        private void UpdateNightsAndTotal()
        {
            int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
            lblNights.Text = $"{nights} night(s)";

            // Update total if room is selected
            if (cmbRoom.SelectedIndex > 0)
            {
                Room selectedRoom = availableRooms[cmbRoom.SelectedIndex - 1];
                decimal roomCharges = selectedRoom.BasePrice * nights;
                decimal total = bookingFacade.CalculateTotalAmount(roomCharges, 0m);

                lblSubtotal.Text = $"Room Charges: ${roomCharges:F2}";
                lblTotal.Text = $"Total (incl. 10% tax): ${total:F2}";
            }
            else
            {
                lblSubtotal.Text = "Room Charges: $0.00";
                lblTotal.Text = "Total: $0.00";
            }
        }

        /// <summary>
        /// Room selection changed
        /// </summary>
        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedIndex > 0)
            {
                Room selectedRoom = availableRooms[cmbRoom.SelectedIndex - 1];
                lblRoomPrice.Text = $"Price: ${selectedRoom.BasePrice:F2}/night";

                // Update max guests based on room capacity
                numGuests.Maximum = selectedRoom.MaxOccupancy;

                // If current value exceeds max, reset to max
                if (numGuests.Value > selectedRoom.MaxOccupancy)
                {
                    numGuests.Value = selectedRoom.MaxOccupancy;
                }

                UpdateNightsAndTotal();
            }
            else
            {
                lblRoomPrice.Text = "Price: $0.00/night";
                numGuests.Maximum = 10;
                UpdateNightsAndTotal();
            }
        }

        /// <summary>
        /// Search button - filter guests by name or email
        /// </summary>
        private void btnSearchGuest_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchGuest.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadGuests(); // Reload all guests
                return;
            }

            try
            {
                // Filter guests by search term
                List<Guest> filteredGuests = allGuests.Where(g =>
                    g.FirstName.ToLower().Contains(searchTerm) ||
                    g.LastName.ToLower().Contains(searchTerm) ||
                    g.Email.ToLower().Contains(searchTerm)
                ).ToList();

                // Update combo box
                cmbGuest.Items.Clear();
                cmbGuest.Items.Add("-- Select Guest --");

                foreach (Guest guest in filteredGuests)
                {
                    cmbGuest.Items.Add($"{guest.FirstName} {guest.LastName} ({guest.Email})");
                }

                cmbGuest.SelectedIndex = 0;

                lblGuestCount.Text = $"{filteredGuests.Count} guests found";

                if (filteredGuests.Count == 0)
                {
                    MessageBox.Show("No guests found matching your search.", "Search Results",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching guests: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clear search and reload all guests
        /// </summary>
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchGuest.Clear();
            LoadGuests();
        }

        /// <summary>
        /// Create booking button
        /// </summary>
        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbGuest.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a guest.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGuest.Focus();
                return;
            }

            if (cmbRoom.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a room.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRoom.Focus();
                return;
            }

            try
            {
                // Get selected guest and room
                Guest selectedGuest = allGuests[cmbGuest.SelectedIndex - 1];
                Room selectedRoom = availableRooms[cmbRoom.SelectedIndex - 1];

                // Get booking details
                DateTime checkIn = dtpCheckIn.Value.Date;
                DateTime checkOut = dtpCheckOut.Value.Date;
                int numberOfGuests = (int)numGuests.Value;
                string specialRequests = txtSpecialRequests.Text.Trim();

                // Create booking using facade
                int bookingId = bookingFacade.CreateBooking(
                    guestId: selectedGuest.GuestId,
                    roomId: selectedRoom.RoomId,
                    checkInDate: checkIn,
                    checkOutDate: checkOut,
                    numberOfGuests: numberOfGuests,
                    specialRequests: string.IsNullOrEmpty(specialRequests) ? null : specialRequests,
                    notes: $"Booking created by {SessionManager.CurrentUser.FullName}"
                );

                // Success message
                int nights = (checkOut - checkIn).Days;
                decimal total = bookingFacade.CalculateTotalAmount(selectedRoom.BasePrice * nights, 0m);

                MessageBox.Show(
                    $"Booking created successfully!\n\n" +
                    $"Booking ID: {bookingId}\n" +
                    $"Guest: {selectedGuest.FirstName} {selectedGuest.LastName}\n" +
                    $"Room: {selectedRoom.RoomNumber} ({selectedRoom.RoomType})\n" +
                    $"Check-in: {checkIn:d}\n" +
                    $"Check-out: {checkOut:d}\n" +
                    $"Total: ${total:F2}",
                    "Booking Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Close form or reset for new booking
                DialogResult continueBooking = MessageBox.Show(
                    "Do you want to create another booking?",
                    "Continue",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (continueBooking == DialogResult.Yes)
                {
                    ResetForm();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reset form for new booking
        /// </summary>
        private void ResetForm()
        {
            cmbGuest.SelectedIndex = 0;
            cmbRoom.SelectedIndex = 0;
            dtpCheckIn.Value = DateTime.Today.AddDays(1);
            dtpCheckOut.Value = DateTime.Today.AddDays(2);
            numGuests.Value = 1;
            txtSpecialRequests.Clear();
            txtSearchGuest.Clear();
            LoadGuests();
            UpdateAvailableRooms();
        }

        /// <summary>
        /// Cancel button
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Handle Enter key in search textbox
        /// </summary>
        private void txtSearchGuest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchGuest_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
