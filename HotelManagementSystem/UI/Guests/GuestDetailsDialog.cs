using HotelManagementSystem.Models;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Guests
{
    /// <summary>
    /// Custom dialog for displaying detailed guest information with a styled UI
    /// </summary>
    public partial class GuestDetailsDialog : Form
    {
        private Guest guest;

        public GuestDetailsDialog(Guest guest)
        {
            InitializeComponent();
            this.guest = guest;
            LoadGuestDetails();
        }

        /// <summary>
        /// Populate all fields with guest data
        /// </summary>
        private void LoadGuestDetails()
        {
            // Header
            lblTitle.Text = guest.FullName;
            this.Text = $"{guest.FullName} - Guest Details";

            // Status badge
            if (guest.IsActive)
            {
                lblStatusBadge.Text = "ACTIVE";
                panelTop.BackColor = Color.FromArgb(46, 125, 50);
            }
            else
            {
                lblStatusBadge.Text = "INACTIVE";
                panelTop.BackColor = Color.FromArgb(198, 40, 40);
            }

            // Personal Information
            lblNameValue.Text = guest.FullName;
            lblEmailValue.Text = guest.Email ?? "N/A";
            lblPhoneValue.Text = guest.Phone ?? "N/A";
            lblIdNumberValue.Text = guest.IDNumber ?? "N/A";

            // Additional Details
            lblDobValue.Text = guest.DateOfBirth.HasValue
                ? guest.DateOfBirth.Value.ToString("MM/dd/yyyy")
                : "N/A";
            lblNationalityValue.Text = guest.Nationality ?? "N/A";
            lblAddressValue.Text = guest.Address ?? "N/A";

            // Registration Info
            lblRegisteredValue.Text = guest.CreatedDate.ToString("MM/dd/yyyy");
            lblModifiedValue.Text = guest.ModifiedDate.HasValue
                ? guest.ModifiedDate.Value.ToString("MM/dd/yyyy")
                : "Never";

            if (guest.IsActive)
            {
                lblStatusValue.Text = "Active";
                lblStatusValue.ForeColor = Color.FromArgb(46, 125, 50);
            }
            else
            {
                lblStatusValue.Text = "Inactive";
                lblStatusValue.ForeColor = Color.FromArgb(198, 40, 40);
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
