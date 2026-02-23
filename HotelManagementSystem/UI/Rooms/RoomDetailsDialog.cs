using HotelManagementSystem.Models;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Rooms
{
    /// <summary>
    /// Custom dialog for displaying detailed room information with a styled UI
    /// </summary>
    public partial class RoomDetailsDialog : Form
    {
        private Room room;

        public RoomDetailsDialog(Room room)
        {
            InitializeComponent();
            this.room = room;
            LoadRoomDetails();
        }

        /// <summary>
        /// Populate all fields with room data
        /// </summary>
        private void LoadRoomDetails()
        {
            // Header
            lblTitle.Text = $"Room {room.RoomNumber}";
            this.Text = $"Room {room.RoomNumber} - Details";

            // Status badge with color
            lblStatus.Text = room.Status.ToUpper();
            panelTop.BackColor = GetStatusColor(room.Status);

            // Room Information group
            lblRoomNumValue.Text = room.RoomNumber;
            lblTypeValue.Text = room.RoomType;
            lblFloorValue.Text = room.FloorNumber.ToString();
            lblPriceValue.Text = $"${room.BasePrice:F2}/night";

            // Room Details group
            lblBedValue.Text = room.BedType ?? "N/A";
            lblOccupancyValue.Text = $"{room.MaxOccupancy} guest(s)";
            lblViewValue.Text = room.ViewType ?? "Standard";
            lblAreaValue.Text = $"{room.Area} sq.m";

            // Special Features - add styled tags
            AddFeatureTag("Balcony", room.HasBalcony);
            AddFeatureTag("Sea View", room.HasSeaView);
            AddFeatureTag("Jacuzzi", room.HasJacuzzi);
            AddFeatureTag("Private Pool", room.HasPrivatePool);

            // Description
            if (!string.IsNullOrWhiteSpace(room.Description))
            {
                lblDescription.Text = room.Description;
            }
            else
            {
                lblDescription.Text = "No description available.";
            }
        }

        /// <summary>
        /// Add a styled feature tag to the features panel
        /// </summary>
        private void AddFeatureTag(string featureName, bool hasFeature)
        {
            Label tag = new Label
            {
                Text = (hasFeature ? "✓ " : "✗ ") + featureName,
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = hasFeature ? Color.White : Color.FromArgb(120, 120, 120),
                BackColor = hasFeature ? Color.FromArgb(46, 125, 50) : Color.FromArgb(224, 224, 224),
                Padding = new Padding(6, 3, 6, 3),
                Margin = new Padding(3),
            };

            flowLayoutPanelFeatures.Controls.Add(tag);
        }

        /// <summary>
        /// Get color based on room status
        /// </summary>
        private Color GetStatusColor(string status)
        {
            switch (status?.ToLower())
            {
                case "available":
                    return Color.FromArgb(46, 125, 50);
                case "occupied":
                    return Color.FromArgb(198, 40, 40);
                case "reserved":
                    return Color.FromArgb(251, 192, 45);
                case "cleaning":
                    return Color.FromArgb(2, 136, 209);
                case "maintenance":
                    return Color.FromArgb(117, 117, 117);
                default:
                    return Color.FromArgb(102, 126, 234);
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
