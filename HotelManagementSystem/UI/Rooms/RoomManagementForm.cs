using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Rooms
{
    public partial class RoomManagementForm : Form
    {
        private RoomRepository roomRepository;
        private List<Room> allRooms;

        public RoomManagementForm()
        {
            InitializeComponent();
            roomRepository = new RoomRepository();
            this.Load += RoomManagementForm_Load;
        }

        private void RoomManagementForm_Load(object sender, EventArgs e)
        {
            LoadRooms();
            SetupDataGridView();
            UpdateStatusCounts();
        }

        /// <summary>
        /// Load all rooms from database
        /// </summary>
        private void LoadRooms()
        {
            try
            {
                allRooms = roomRepository.GetAll();
                
                // Apply filter if selected
                var filteredRooms = allRooms;
                
                if (cmbFilterStatus.SelectedIndex > 0) // 0 is "All Status"
                {
                    string selectedStatus = cmbFilterStatus.SelectedItem.ToString();
                    filteredRooms = allRooms.Where(r => r.Status == selectedStatus).ToList();
                }

                // Bind to DataGridView
                dgvRooms.DataSource = null;
                dgvRooms.DataSource = filteredRooms;

                // Update count label
                lblTotalRooms.Text = $"Total Rooms: {filteredRooms.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Setup DataGridView columns and formatting
        /// </summary>
        private void SetupDataGridView()
        {
            dgvRooms.AutoGenerateColumns = false;
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.ReadOnly = true;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.MultiSelect = false;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Clear existing columns
            dgvRooms.Columns.Clear();

            // Add columns
            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomId",
                HeaderText = "ID",
                DataPropertyName = "RoomId",
                Width = 50,
                Visible = false
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomNumber",
                HeaderText = "Room #",
                DataPropertyName = "RoomNumber",
                Width = 80
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomType",
                HeaderText = "Type",
                DataPropertyName = "RoomType",
                Width = 100
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FloorNumber",
                HeaderText = "Floor",
                DataPropertyName = "FloorNumber",
                Width = 60
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BasePrice",
                HeaderText = "Price/Night",
                DataPropertyName = "BasePrice",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaxOccupancy",
                HeaderText = "Max Guests",
                DataPropertyName = "MaxOccupancy",
                Width = 90
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BedType",
                HeaderText = "Bed Type",
                DataPropertyName = "BedType",
                Width = 100
            });

            // Color code rows by status
            dgvRooms.CellFormatting += DgvRooms_CellFormatting;
        }

        /// <summary>
        /// Color code rows based on room status
        /// </summary>
        private void DgvRooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRooms.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    switch (status)
                    {
                        case "Available":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            break;
                        case "Occupied":
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.DarkRed;
                            break;
                        case "Reserved":
                            e.CellStyle.BackColor = Color.LightBlue;
                            e.CellStyle.ForeColor = Color.DarkBlue;
                            break;
                        case "Cleaning":
                            e.CellStyle.BackColor = Color.LightYellow;
                            e.CellStyle.ForeColor = Color.DarkGoldenrod;
                            break;
                        case "Maintenance":
                            e.CellStyle.BackColor = Color.LightGray;
                            e.CellStyle.ForeColor = Color.DarkSlateGray;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Update status count labels
        /// </summary>
        private void UpdateStatusCounts()
        {
            if (allRooms == null) return;

            int available = allRooms.Count(r => r.Status == "Available");
            int occupied = allRooms.Count(r => r.Status == "Occupied");
            int reserved = allRooms.Count(r => r.Status == "Reserved");
            int cleaning = allRooms.Count(r => r.Status == "Cleaning");
            int maintenance = allRooms.Count(r => r.Status == "Maintenance");

            lblStatusCounts.Text = $"Available: {available} | Occupied: {occupied} | " +
                                   $"Reserved: {reserved} | Cleaning: {cleaning} | " +
                                   $"Maintenance: {maintenance}";
        }

        #region Button Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Open Add Room dialog - Day 9 Implementation!
            AddEditRoomDialog dialog = new AddEditRoomDialog();
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Refresh the room list
                LoadRooms();
                UpdateStatusCounts();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to edit.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected room
            Room selectedRoom = dgvRooms.SelectedRows[0].DataBoundItem as Room;

            // Open Edit Room dialog - Day 9 Implementation!
            AddEditRoomDialog dialog = new AddEditRoomDialog(selectedRoom);
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Refresh the room list
                LoadRooms();
                UpdateStatusCounts();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to delete.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Room selectedRoom = dgvRooms.SelectedRows[0].DataBoundItem as Room;

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete Room {selectedRoom.RoomNumber}?\n\n" +
                $"Type: {selectedRoom.RoomType}\n" +
                $"Floor: {selectedRoom.FloorNumber}\n" +
                $"Status: {selectedRoom.Status}\n\n" +
                "This will perform a soft delete (room will be marked as inactive).",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = roomRepository.Delete(selectedRoom.RoomId);
                    
                    if (success)
                    {
                        MessageBox.Show("Room deleted successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms();
                        UpdateStatusCounts();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete room.", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting room: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
            UpdateStatusCounts();
            MessageBox.Show("Room list refreshed!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadRooms(); // Show all
                return;
            }

            try
            {
                var filteredRooms = allRooms.Where(r =>
                    r.RoomNumber.ToLower().Contains(searchTerm) ||
                    r.RoomType.ToLower().Contains(searchTerm) ||
                    r.Status.ToLower().Contains(searchTerm)
                ).ToList();

                dgvRooms.DataSource = null;
                dgvRooms.DataSource = filteredRooms;

                lblTotalRooms.Text = $"Found: {filteredRooms.Count} room(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to view details.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Room selectedRoom = dgvRooms.SelectedRows[0].DataBoundItem as Room;

            // Show detailed information in styled dialog
            using (var dialog = new RoomDetailsDialog(selectedRoom))
            {
                dialog.ShowDialog(this);
            }
        }

        #endregion
    }
}
