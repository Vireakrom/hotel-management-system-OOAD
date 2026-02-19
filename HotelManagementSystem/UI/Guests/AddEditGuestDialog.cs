using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;
using HotelManagementSystem.Helpers;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Guests
{
    /// <summary>
    /// Dialog for adding or editing guest information
    /// Day 12 Implementation - Complete Guest CRUD
    /// Day 30 Enhancement - Comprehensive Validation
    /// </summary>
    public partial class AddEditGuestDialog : Form
    {
        private GuestRepository guestRepository;
        private Guest currentGuest;
        private bool isEditMode;

        public AddEditGuestDialog()
        {
            InitializeComponent();
            guestRepository = new GuestRepository();
            isEditMode = false;
            this.Load += AddEditGuestDialog_Load;
        }

        /// <summary>
        /// Constructor for Edit mode
        /// </summary>
        public AddEditGuestDialog(Guest guest) : this()
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest));

            currentGuest = guest;
            isEditMode = true;
        }

        private void AddEditGuestDialog_Load(object sender, EventArgs e)
        {
            InitializeControls();

            if (isEditMode)
            {
                LoadGuestData();
                this.Text = "Edit Guest";
                btnSave.Text = "Update";
            }
            else
            {
                this.Text = "Add New Guest";
                btnSave.Text = "Add Guest";
            }
        }

        /// <summary>
        /// Initialize form controls
        /// </summary>
        private void InitializeControls()
        {
            // Set date picker limits
            dtpDateOfBirth.MaxDate = DateTime.Today;
            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-120);
            dtpDateOfBirth.Value = DateTime.Today.AddYears(-30); // Default to 30 years ago
            chkHasDOB.Checked = false;
            dtpDateOfBirth.Enabled = false;

            // Populate common nationalities
            cmbNationality.Items.Clear();
            cmbNationality.Items.AddRange(new string[]
            {
                "Afghan", "Albanian", "Algerian", "American", "Andorran", "Angolan", "Argentine", "Armenian",
                "Australian", "Austrian", "Azerbaijani", "Bahamian", "Bahraini", "Bangladeshi", "Barbadian",
                "Belarusian", "Belgian", "Belizean", "Beninese", "Bhutanese", "Bolivian", "Bosnian",
                "Brazilian", "British", "Bruneian", "Bulgarian", "Burkinabe", "Burmese", "Burundian",
                "Cambodian", "Cameroonian", "Canadian", "Cape Verdean", "Central African", "Chadian",
                "Chilean", "Chinese", "Colombian", "Comoran", "Congolese", "Costa Rican", "Croatian",
                "Cuban", "Cypriot", "Czech", "Danish", "Djiboutian", "Dominican", "Dutch", "East Timorese",
                "Ecuadorean", "Egyptian", "Emirati", "English", "Eritrean", "Estonian", "Ethiopian",
                "Fijian", "Filipino", "Finnish", "French", "Gabonese", "Gambian", "Georgian", "German",
                "Ghanaian", "Greek", "Grenadian", "Guatemalan", "Guinean", "Guyanese", "Haitian",
                "Honduran", "Hungarian", "Icelandic", "Indian", "Indonesian", "Iranian", "Iraqi", "Irish",
                "Israeli", "Italian", "Ivorian", "Jamaican", "Japanese", "Jordanian", "Kazakhstani",
                "Kenyan", "Korean", "Kuwaiti", "Kyrgyz", "Lao", "Latvian", "Lebanese", "Liberian",
                "Libyan", "Lithuanian", "Luxembourgish", "Macedonian", "Malagasy", "Malawian", "Malaysian",
                "Maldivian", "Malian", "Maltese", "Mexican", "Moldovan", "Monacan", "Mongolian",
                "Montenegrin", "Moroccan", "Mozambican", "Namibian", "Nepalese", "New Zealand", "Nicaraguan",
                "Nigerian", "Norwegian", "Omani", "Pakistani", "Panamanian", "Paraguayan", "Peruvian",
                "Polish", "Portuguese", "Qatari", "Romanian", "Russian", "Rwandan", "Saudi", "Scottish",
                "Senegalese", "Serbian", "Singaporean", "Slovak", "Slovenian", "Somali", "South African",
                "Spanish", "Sri Lankan", "Sudanese", "Surinamese", "Swedish", "Swiss", "Syrian", "Taiwanese",
                "Tajik", "Tanzanian", "Thai", "Togolese", "Trinidadian", "Tunisian", "Turkish", "Turkmen",
                "Ugandan", "Ukrainian", "Uruguayan", "Uzbek", "Venezuelan", "Vietnamese", "Welsh", "Yemeni",
                "Zambian", "Zimbabwean"
            });
        }

        /// <summary>
        /// Load guest data into form controls (Edit mode)
        /// </summary>
        private void LoadGuestData()
        {
            if (currentGuest == null) return;

            txtFirstName.Text = currentGuest.FirstName;
            txtLastName.Text = currentGuest.LastName;
            txtEmail.Text = currentGuest.Email;
            txtPhone.Text = currentGuest.Phone;
            txtIDNumber.Text = currentGuest.IDNumber;
            txtAddress.Text = currentGuest.Address;

            if (currentGuest.DateOfBirth.HasValue)
            {
                chkHasDOB.Checked = true;
                dtpDateOfBirth.Enabled = true;
                dtpDateOfBirth.Value = currentGuest.DateOfBirth.Value;
            }
            else
            {
                chkHasDOB.Checked = false;
                dtpDateOfBirth.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(currentGuest.Nationality))
            {
                int index = cmbNationality.FindStringExact(currentGuest.Nationality);
                if (index >= 0)
                    cmbNationality.SelectedIndex = index;
                else
                    cmbNationality.Text = currentGuest.Nationality;
            }
        }

        /// <summary>
        /// Validate all input fields - Enhanced for Day 30
        /// </summary>
        private bool ValidateInput(out string errorMessage)
        {
            errorMessage = string.Empty;

            // First Name validation - using ValidationHelper
            if (!ValidationHelper.ValidateRequired(txtFirstName, "First name", out errorMessage))
                return false;

            if (!ValidationHelper.ValidateMinLength(txtFirstName, "First name", 2, out errorMessage))
                return false;

            if (!ValidationHelper.ValidateMaxLength(txtFirstName, "First name", 50, out errorMessage))
                return false;

            // Last Name validation - using ValidationHelper
            if (!ValidationHelper.ValidateRequired(txtLastName, "Last name", out errorMessage))
                return false;

            if (!ValidationHelper.ValidateMinLength(txtLastName, "Last name", 2, out errorMessage))
                return false;

            if (!ValidationHelper.ValidateMaxLength(txtLastName, "Last name", 50, out errorMessage))
                return false;

            // Email validation (optional but must be valid if provided)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!ValidationHelper.ValidateEmail(txtEmail, out errorMessage))
                    return false;
            }

            // Phone validation (optional but must be valid if provided)
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                if (!ValidationHelper.ValidatePhone(txtPhone, out errorMessage))
                    return false;
            }

            // ID Number validation (optional but must be valid if provided)
            if (!string.IsNullOrWhiteSpace(txtIDNumber.Text))
            {
                if (!ValidationHelper.ValidateMinLength(txtIDNumber, "ID number", 5, out errorMessage))
                    return false;

                if (!ValidationHelper.ValidateMaxLength(txtIDNumber, "ID number", 50, out errorMessage))
                    return false;
            }

            // Address validation (optional)
            if (!string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                if (!ValidationHelper.ValidateMaxLength(txtAddress, "Address", 200, out errorMessage))
                    return false;
            }

            // Date of Birth validation (if checked)
            if (chkHasDOB.Checked)
            {
                // Must be in the past
                if (!ValidationHelper.ValidatePastDate(dtpDateOfBirth.Value, "Date of birth", out errorMessage))
                {
                    dtpDateOfBirth.Focus();
                    return false;
                }

                // Check if age is reasonable (at least 18 years old)
                int age = DateTime.Today.Year - dtpDateOfBirth.Value.Year;
                if (dtpDateOfBirth.Value.Date > DateTime.Today.AddYears(-age))
                    age--;

                if (age < 18)
                {
                    errorMessage = "Guest must be at least 18 years old to make a booking.";
                    dtpDateOfBirth.Focus();
                    return false;
                }

                if (age > 120)
                {
                    errorMessage = "Please enter a valid date of birth (maximum age: 120 years).";
                    dtpDateOfBirth.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Save button click handler
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (!ValidateInput(out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create or update guest
                Guest guest;
                if (isEditMode)
                {
                    // Update existing guest
                    guest = currentGuest;
                    guest.FirstName = txtFirstName.Text.Trim();
                    guest.LastName = txtLastName.Text.Trim();
                    guest.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                    guest.Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim();
                    guest.IDNumber = string.IsNullOrWhiteSpace(txtIDNumber.Text) ? null : txtIDNumber.Text.Trim();
                    guest.Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();
                    guest.DateOfBirth = chkHasDOB.Checked ? (DateTime?)dtpDateOfBirth.Value : null;
                    guest.Nationality = string.IsNullOrWhiteSpace(cmbNationality.Text) ? null : cmbNationality.Text.Trim();
                    guest.ModifiedDate = DateTime.Now;

                    bool success = guestRepository.Update(guest);
                    if (success)
                    {
                        MessageBox.Show("Guest updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update guest. Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create new guest
                    guest = new Guest
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                        Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                        IDNumber = string.IsNullOrWhiteSpace(txtIDNumber.Text) ? null : txtIDNumber.Text.Trim(),
                        Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                        DateOfBirth = chkHasDOB.Checked ? (DateTime?)dtpDateOfBirth.Value : null,
                        Nationality = string.IsNullOrWhiteSpace(cmbNationality.Text) ? null : cmbNationality.Text.Trim(),
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };

                    int newId = guestRepository.Insert(guest);
                    if (newId > 0)
                    {
                        MessageBox.Show($"Guest added successfully!\nGuest ID: {newId}", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add guest. Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving guest: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancel button click handler
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Date of birth checkbox changed
        /// </summary>
        private void chkHasDOB_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateOfBirth.Enabled = chkHasDOB.Checked;
        }
    }
}
