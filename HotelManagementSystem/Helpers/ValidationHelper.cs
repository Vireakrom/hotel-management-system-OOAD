using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HotelManagementSystem.Helpers
{
    /// <summary>
    /// Day 30 Implementation - Comprehensive Input Validation Helper
    /// Provides reusable validation methods for forms throughout the application
    /// </summary>
    public static class ValidationHelper
    {
        #region Required Field Validation

        /// <summary>
        /// Validates that a text field is not empty
        /// </summary>
        public static bool ValidateRequired(TextBox textBox, string fieldName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorMessage = $"{fieldName} is required.";
                textBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a combo box has a selection
        /// </summary>
        public static bool ValidateRequired(ComboBox comboBox, string fieldName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (comboBox.SelectedIndex <= 0 || comboBox.SelectedItem == null || 
                comboBox.SelectedItem.ToString().StartsWith("--"))
            {
                errorMessage = $"Please select a {fieldName}.";
                comboBox.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region String Validation

        /// <summary>
        /// Validates minimum string length
        /// </summary>
        public static bool ValidateMinLength(TextBox textBox, string fieldName, int minLength, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (textBox.Text.Trim().Length < minLength)
            {
                errorMessage = $"{fieldName} must be at least {minLength} characters.";
                textBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates maximum string length
        /// </summary>
        public static bool ValidateMaxLength(TextBox textBox, string fieldName, int maxLength, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (textBox.Text.Trim().Length > maxLength)
            {
                errorMessage = $"{fieldName} must not exceed {maxLength} characters.";
                textBox.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Email Validation

        /// <summary>
        /// Validates email format using regex
        /// </summary>
        public static bool ValidateEmail(string email, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(email))
            {
                return true; // Allow empty if not required
            }

            // Email regex pattern
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            
            if (!Regex.IsMatch(email.Trim(), pattern))
            {
                errorMessage = "Please enter a valid email address.\nExample: name@example.com";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates email in a TextBox
        /// </summary>
        public static bool ValidateEmail(TextBox textBox, out string errorMessage)
        {
            bool isValid = ValidateEmail(textBox.Text, out errorMessage);
            if (!isValid)
            {
                textBox.Focus();
            }
            return isValid;
        }

        #endregion

        #region Phone Validation

        /// <summary>
        /// Validates phone number (basic validation)
        /// </summary>
        public static bool ValidatePhone(string phone, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(phone))
            {
                return true; // Allow empty if not required
            }

            // Remove common formatting characters
            string cleaned = Regex.Replace(phone, @"[\s\-\(\)\+]", "");

            // Must contain only digits and be between 7 and 15 characters
            if (!Regex.IsMatch(cleaned, @"^\d{7,15}$"))
            {
                errorMessage = "Please enter a valid phone number (7-15 digits).\nExample: +1-555-123-4567";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates phone in a TextBox
        /// </summary>
        public static bool ValidatePhone(TextBox textBox, out string errorMessage)
        {
            bool isValid = ValidatePhone(textBox.Text, out errorMessage);
            if (!isValid)
            {
                textBox.Focus();
            }
            return isValid;
        }

        #endregion

        #region Date Validation

        /// <summary>
        /// Validates that end date is after start date
        /// </summary>
        public static bool ValidateDateRange(DateTime startDate, DateTime endDate, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (endDate <= startDate)
            {
                errorMessage = "End date must be after start date.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that end date is after start date with custom field names
        /// </summary>
        public static bool ValidateDateRange(DateTime startDate, DateTime endDate, 
            string startFieldName, string endFieldName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (endDate <= startDate)
            {
                errorMessage = $"{endFieldName} must be after {startFieldName}.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a date is not in the past
        /// </summary>
        public static bool ValidateFutureDate(DateTime date, string fieldName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (date.Date < DateTime.Today)
            {
                errorMessage = $"{fieldName} cannot be in the past.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a date is not in the future
        /// </summary>
        public static bool ValidatePastDate(DateTime date, string fieldName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (date.Date > DateTime.Today)
            {
                errorMessage = $"{fieldName} cannot be in the future.";
                return false;
            }

            return true;
        }

        #endregion

        #region Numeric Validation

        /// <summary>
        /// Validates that a numeric value is within range
        /// </summary>
        public static bool ValidateNumericRange(decimal value, decimal min, decimal max, 
            string fieldName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (value < min || value > max)
            {
                errorMessage = $"{fieldName} must be between {min} and {max}.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a value is positive
        /// </summary>
        public static bool ValidatePositive(decimal value, string fieldName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (value <= 0)
            {
                errorMessage = $"{fieldName} must be greater than zero.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates decimal input in TextBox
        /// </summary>
        public static bool ValidateDecimal(TextBox textBox, string fieldName, out decimal value, out string errorMessage)
        {
            errorMessage = string.Empty;
            value = 0;

            if (!decimal.TryParse(textBox.Text, out value))
            {
                errorMessage = $"Please enter a valid number for {fieldName}.";
                textBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates integer input in TextBox
        /// </summary>
        public static bool ValidateInteger(TextBox textBox, string fieldName, out int value, out string errorMessage)
        {
            errorMessage = string.Empty;
            value = 0;

            if (!int.TryParse(textBox.Text, out value))
            {
                errorMessage = $"Please enter a valid whole number for {fieldName}.";
                textBox.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Credit Card Validation

        /// <summary>
        /// Validates credit card number using Luhn algorithm
        /// </summary>
        public static bool ValidateCreditCardNumber(string cardNumber, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                errorMessage = "Card number is required.";
                return false;
            }

            // Remove spaces and dashes
            string cleaned = cardNumber.Replace(" ", "").Replace("-", "");

            // Must be 13-19 digits
            if (!Regex.IsMatch(cleaned, @"^\d{13,19}$"))
            {
                errorMessage = "Card number must be 13-19 digits.";
                return false;
            }

            // Luhn algorithm check
            int sum = 0;
            bool alternate = false;

            for (int i = cleaned.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cleaned[i].ToString());

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                alternate = !alternate;
            }

            if (sum % 10 != 0)
            {
                errorMessage = "Invalid card number.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates CVV format
        /// </summary>
        public static bool ValidateCVV(string cvv, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(cvv))
            {
                errorMessage = "CVV is required.";
                return false;
            }

            if (!Regex.IsMatch(cvv, @"^\d{3,4}$"))
            {
                errorMessage = "CVV must be 3 or 4 digits.";
                return false;
            }

            return true;
        }

        #endregion

        #region UI Helper Methods

        /// <summary>
        /// Shows validation error message box
        /// </summary>
        public static void ShowValidationError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows validation error with custom title
        /// </summary>
        public static void ShowValidationError(string errorMessage, string title)
        {
            MessageBox.Show(errorMessage, title, 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Highlights a control to indicate validation error
        /// </summary>
        public static void HighlightError(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.BackColor = System.Drawing.Color.LightPink;
            }
        }

        /// <summary>
        /// Clears error highlighting from a control
        /// </summary>
        public static void ClearErrorHighlight(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        #endregion

        #region Composite Validation

        /// <summary>
        /// Validates multiple conditions and returns all error messages
        /// </summary>
        public static bool ValidateAll(params (bool isValid, string errorMessage)[] validations)
        {
            var errors = new System.Collections.Generic.List<string>();

            foreach (var validation in validations)
            {
                if (!validation.isValid)
                {
                    errors.Add(validation.errorMessage);
                }
            }

            if (errors.Count > 0)
            {
                ShowValidationError(string.Join("\n\n", errors), "Validation Errors");
                return false;
            }

            return true;
        }

        #endregion
    }
}
