# ValidationHelper Usage Guide

## 🎯 Quick Start - How to Use ValidationHelper

This guide shows you how to use the `ValidationHelper` class in your forms.

---

## 📋 Basic Usage

### 1. Required Field Validation

#### TextBox Required
```csharp
private void btnSave_Click(object sender, EventArgs e)
{
    string errorMessage;
    
    // Validate required field
    if (!ValidationHelper.ValidateRequired(txtFirstName, "First name", out errorMessage))
    {
        ValidationHelper.ShowValidationError(errorMessage);
        return;
    }
    
    // Field is valid, continue...
}
```

#### ComboBox Required
```csharp
// Validate combo box selection
if (!ValidationHelper.ValidateRequired(cmbRoomType, "room type", out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    return;
}
```

---

### 2. String Length Validation

```csharp
// Minimum length
if (!ValidationHelper.ValidateMinLength(txtFirstName, "First name", 2, out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    return;
}

// Maximum length
if (!ValidationHelper.ValidateMaxLength(txtDescription, "Description", 500, out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    return;
}
```

---

### 3. Email Validation

```csharp
// Optional email (only validates if not empty)
if (!string.IsNullOrWhiteSpace(txtEmail.Text))
{
    if (!ValidationHelper.ValidateEmail(txtEmail, out errorMessage))
    {
        ValidationHelper.ShowValidationError(errorMessage);
        return;
    }
}
```

---

### 4. Phone Validation

```csharp
// Optional phone (only validates if not empty)
if (!string.IsNullOrWhiteSpace(txtPhone.Text))
{
    if (!ValidationHelper.ValidatePhone(txtPhone, out errorMessage))
    {
        ValidationHelper.ShowValidationError(errorMessage);
        return;
    }
}
```

---

### 5. Date Range Validation

#### Check-out > Check-in (Critical!)
```csharp
DateTime checkIn = dtpCheckIn.Value.Date;
DateTime checkOut = dtpCheckOut.Value.Date;

if (!ValidationHelper.ValidateDateRange(checkIn, checkOut, 
    "Check-in", "Check-out", out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    dtpCheckOut.Focus();
    return;
}
```

#### Future Date Validation
```csharp
// For booking dates - cannot be in past
if (!ValidationHelper.ValidateFutureDate(dtpCheckIn.Value, "Check-in date", out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    dtpCheckIn.Focus();
    return;
}
```

#### Past Date Validation
```csharp
// For date of birth - cannot be in future
if (!ValidationHelper.ValidatePastDate(dtpDateOfBirth.Value, "Date of birth", out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    dtpDateOfBirth.Focus();
    return;
}
```

---

### 6. Numeric Validation

#### Decimal Input
```csharp
decimal amount;

if (!ValidationHelper.ValidateDecimal(txtAmount, "Payment amount", out amount, out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    return;
}

// Now use the parsed 'amount' value
```

#### Integer Input
```csharp
int quantity;

if (!ValidationHelper.ValidateInteger(txtQuantity, "Quantity", out quantity, out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    return;
}
```

#### Positive Value
```csharp
if (!ValidationHelper.ValidatePositive(amount, "Payment amount", out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    return;
}
```

#### Numeric Range
```csharp
// Validate floor number is between 1 and 20
if (!ValidationHelper.ValidateNumericRange(
    (decimal)numFloorNumber.Value, 
    1, 20, 
    "Floor number", 
    out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    numFloorNumber.Focus();
    return;
}
```

---

### 7. Credit Card Validation

```csharp
// Validate card number (Luhn algorithm)
if (!ValidationHelper.ValidateCreditCardNumber(txtCardNumber.Text, out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    txtCardNumber.Focus();
    return;
}

// Validate CVV
if (!ValidationHelper.ValidateCVV(txtCVV.Text, out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    txtCVV.Focus();
    return;
}
```

---

## 🎨 Complete Form Validation Example

Here's a complete example showing how to validate an entire form:

```csharp
using HotelManagementSystem.Helpers;
using System;
using System.Windows.Forms;

namespace HotelManagementSystem.UI
{
    public partial class AddGuestForm : Form
    {
        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage;

            // 1. Validate required fields
            if (!ValidationHelper.ValidateRequired(txtFirstName, "First name", out errorMessage))
            {
                ValidationHelper.ShowValidationError(errorMessage);
                return;
            }

            // 2. Validate string length
            if (!ValidationHelper.ValidateMinLength(txtFirstName, "First name", 2, out errorMessage) ||
                !ValidationHelper.ValidateMaxLength(txtFirstName, "First name", 50, out errorMessage))
            {
                ValidationHelper.ShowValidationError(errorMessage);
                return;
            }

            // 3. Validate email (optional field)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!ValidationHelper.ValidateEmail(txtEmail, out errorMessage))
                {
                    ValidationHelper.ShowValidationError(errorMessage);
                    return;
                }
            }

            // 4. Validate phone (optional field)
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                if (!ValidationHelper.ValidatePhone(txtPhone, out errorMessage))
                {
                    ValidationHelper.ShowValidationError(errorMessage);
                    return;
                }
            }

            // 5. Validate date of birth
            if (chkHasDOB.Checked)
            {
                if (!ValidationHelper.ValidatePastDate(dtpDOB.Value, "Date of birth", out errorMessage))
                {
                    ValidationHelper.ShowValidationError(errorMessage);
                    return;
                }

                // Check age is at least 18
                int age = DateTime.Today.Year - dtpDOB.Value.Year;
                if (age < 18)
                {
                    ValidationHelper.ShowValidationError("Guest must be at least 18 years old.");
                    return;
                }
            }

            // All validation passed - save the data
            SaveGuest();
        }

        private void SaveGuest()
        {
            // Your save logic here
            MessageBox.Show("Guest saved successfully!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
```

---

## 🔄 Validation with Multiple Errors

If you want to collect all errors and show them at once:

```csharp
private void btnSave_Click(object sender, EventArgs e)
{
    var errors = new List<string>();

    // Validate all fields and collect errors
    if (!ValidationHelper.ValidateRequired(txtFirstName, "First name", out string error1))
        errors.Add(error1);

    if (!ValidationHelper.ValidateRequired(txtLastName, "Last name", out string error2))
        errors.Add(error2);

    if (!string.IsNullOrWhiteSpace(txtEmail.Text))
    {
        if (!ValidationHelper.ValidateEmail(txtEmail, out string error3))
            errors.Add(error3);
    }

    // Show all errors at once
    if (errors.Count > 0)
    {
        string allErrors = string.Join("\n\n", errors);
        ValidationHelper.ShowValidationError(allErrors, "Validation Errors");
        return;
    }

    // All valid - proceed
    SaveData();
}
```

---

## 🎯 Best Practices

### 1. Validate in This Order
```
1. Required fields first
2. Format validation (email, phone)
3. Range validation (min/max, dates)
4. Business rules (age >= 18, etc.)
5. Database checks (unique values)
```

### 2. Focus Management
```csharp
// ValidationHelper automatically focuses invalid field
if (!ValidationHelper.ValidateRequired(txtFirstName, "First name", out errorMessage))
{
    ValidationHelper.ShowValidationError(errorMessage);
    return; // txtFirstName is now focused
}
```

### 3. Optional vs Required
```csharp
// Required field
if (!ValidationHelper.ValidateRequired(txtFirstName, "First name", out error))
    return ValidationHelper.ShowValidationError(error);

// Optional field (validate only if not empty)
if (!string.IsNullOrWhiteSpace(txtEmail.Text))
{
    if (!ValidationHelper.ValidateEmail(txtEmail, out error))
        return ValidationHelper.ShowValidationError(error);
}
```

### 4. Clear Error Messages
```csharp
// Good - specific
"First name is required."
"Email must be a valid format (example: user@domain.com)"
"Check-out date must be after check-in date."

// Bad - vague
"Invalid input"
"Error"
"Please fix"
```

---

## 💡 Common Patterns

### Pattern 1: Simple Required Field
```csharp
if (!ValidationHelper.ValidateRequired(txtField, "Field name", out string error))
    return ValidationHelper.ShowValidationError(error);
```

### Pattern 2: Required + Length
```csharp
if (!ValidationHelper.ValidateRequired(txtField, "Field", out string error) ||
    !ValidationHelper.ValidateMinLength(txtField, "Field", 2, out error) ||
    !ValidationHelper.ValidateMaxLength(txtField, "Field", 50, out error))
{
    return ValidationHelper.ShowValidationError(error);
}
```

### Pattern 3: Optional with Validation
```csharp
if (!string.IsNullOrWhiteSpace(txtOptional.Text))
{
    if (!ValidationHelper.ValidateEmail(txtOptional, out string error))
        return ValidationHelper.ShowValidationError(error);
}
```

### Pattern 4: Date Range
```csharp
if (!ValidationHelper.ValidateDateRange(
    startDate, endDate, "Start", "End", out string error))
{
    ValidationHelper.ShowValidationError(error);
    dtpEnd.Focus();
    return;
}
```

---

## 🧪 Testing Your Validation

Always test these scenarios:

```
✓ Empty required fields
✓ Minimum length boundary (e.g., 1 character when min is 2)
✓ Maximum length boundary (e.g., 51 characters when max is 50)
✓ Invalid email formats
✓ Invalid phone formats
✓ Past dates for future fields
✓ Future dates for past fields
✓ Same date for date ranges
✓ Reversed date ranges (end before start)
✓ Zero or negative values for positive fields
✓ Values below minimum range
✓ Values above maximum range
```

---

## 📚 Available Validation Methods

| Method | Purpose | Example |
|--------|---------|---------|
| `ValidateRequired(TextBox)` | Check not empty | First name required |
| `ValidateRequired(ComboBox)` | Check selection | Room type selected |
| `ValidateMinLength` | Minimum characters | First name >= 2 chars |
| `ValidateMaxLength` | Maximum characters | Description <= 500 chars |
| `ValidateEmail` | Email format | user@example.com |
| `ValidatePhone` | Phone format | +1-555-123-4567 |
| `ValidateDateRange` | End after start | Check-out > Check-in |
| `ValidateFutureDate` | Not in past | Booking date |
| `ValidatePastDate` | Not in future | Date of birth |
| `ValidateNumericRange` | Value in range | Floor 1-20 |
| `ValidatePositive` | Value > 0 | Price > 0 |
| `ValidateDecimal` | Parse decimal | Payment amount |
| `ValidateInteger` | Parse integer | Quantity |
| `ValidateCreditCardNumber` | Luhn check | Card validation |
| `ValidateCVV` | 3-4 digits | CVV format |

---

## 🚀 Quick Reference

```csharp
// Add using statement
using HotelManagementSystem.Helpers;

// Basic pattern
if (!ValidationHelper.ValidateXXX(control, "Field name", out string error))
{
    ValidationHelper.ShowValidationError(error);
    return;
}

// Optional field pattern
if (!string.IsNullOrWhiteSpace(txtField.Text))
{
    if (!ValidationHelper.ValidateXXX(txtField, out string error))
    {
        ValidationHelper.ShowValidationError(error);
        return;
    }
}

// Date range pattern
if (!ValidationHelper.ValidateDateRange(start, end, "Start", "End", out string error))
{
    ValidationHelper.ShowValidationError(error);
    controlToFocus.Focus();
    return;
}
```

---

## ✅ Checklist for New Forms

When creating a new form, validate:

- [ ] All required fields (TextBox & ComboBox)
- [ ] String lengths (min/max)
- [ ] Email format (if applicable)
- [ ] Phone format (if applicable)
- [ ] Date ranges (if applicable)
- [ ] Numeric ranges (if applicable)
- [ ] Positive values (prices, quantities)
- [ ] Business rules (age >= 18, etc.)
- [ ] Test all validation scenarios
- [ ] User-friendly error messages

---

**Need Help?** Check the complete examples in:
- `AddEditGuestDialog.cs`
- `AddEditRoomDialog.cs`
- `NewBookingForm.cs`
- `PaymentForm.cs`

---

*ValidationHelper Usage Guide - Day 30*  
*Hotel Management System OOAD Project*
