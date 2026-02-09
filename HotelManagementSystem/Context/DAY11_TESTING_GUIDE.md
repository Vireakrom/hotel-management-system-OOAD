# ?? Day 11 - Guest Management Form Testing Guide

**Date:** February 13, 2026  
**Feature:** GuestManagementForm - View, Search, Delete Guests

---

## ? PRE-TESTING CHECKLIST

1. ? Build successful (no errors)
2. ? Database connection working
3. ? Sample guest data exists in database
4. ? Login credentials: **admin / Admin@123**

---

## ?? TEST SCENARIOS

### Test 1: Open Guest Management Form
**Steps:**
1. Run the application
2. Login with: **admin / Admin@123**
3. Click menu: **Guests ? Guest Management**

**Expected Result:**
- Form opens successfully
- DataGridView displays all active guests
- Guest count label shows correct number
- Columns visible: Full Name, Email, Phone, ID Number, Nationality, Registered Date

**Status:** ? Pass | ? Fail

---

### Test 2: View Guest Details
**Steps:**
1. Select any guest in the grid
2. Click **"View Details"** button

**Expected Result:**
- MessageBox displays complete guest information:
  - Guest ID
  - Full Name
  - Email, Phone
  - ID Number
  - Date of Birth
  - Nationality
  - Address
  - Registered date
  - Last modified date

**Status:** ? Pass | ? Fail

---

### Test 3: Double-Click to View Details
**Steps:**
1. Double-click any row in the grid

**Expected Result:**
- Same as Test 2 - details dialog appears

**Status:** ? Pass | ? Fail

---

### Test 4: Search by Name
**Steps:**
1. Type a guest name (e.g., "John") in the search box
2. Click **"Search"** button OR press **Enter**

**Expected Result:**
- Grid displays only matching guests
- "Found: X guest(s)" label updates
- If no matches, shows "No guests found" message

**Status:** ? Pass | ? Fail

---

### Test 5: Search by Email
**Steps:**
1. Type part of an email (e.g., "gmail.com") in search box
2. Click Search

**Expected Result:**
- Grid displays guests with matching email addresses
- Count updates correctly

**Status:** ? Pass | ? Fail

---

### Test 6: Search by Phone
**Steps:**
1. Type part of a phone number in search box
2. Click Search

**Expected Result:**
- Grid displays guests with matching phone numbers
- Count updates correctly

**Status:** ? Pass | ? Fail

---

### Test 7: Empty Search / Clear Filter
**Steps:**
1. Clear the search box (make it empty)
2. Click Search OR Refresh

**Expected Result:**
- Grid displays ALL guests again
- "Total Guests: X" label displays

**Status:** ? Pass | ? Fail

---

### Test 8: Refresh Data
**Steps:**
1. Click **"Refresh"** button

**Expected Result:**
- Search box clears
- Grid reloads all active guests
- Count updates
- Any previous search filters are cleared

**Status:** ? Pass | ? Fail

---

### Test 9: Delete Guest (Soft Delete)
**Steps:**
1. Select a guest from the grid
2. Click **"Delete"** button
3. Confirmation dialog appears ? Click **"Yes"**

**Expected Result:**
- Confirmation dialog: "Are you sure you want to delete guest: [Name]?"
- After clicking Yes: "Guest deleted successfully!" message
- Grid refreshes automatically
- Deleted guest no longer appears in list
- Database: Guest record's `IsActive` field set to 0 (soft delete)

**Status:** ? Pass | ? Fail

---

### Test 10: Delete Without Selection
**Steps:**
1. Click anywhere OUTSIDE the grid (deselect)
2. Click **"Delete"** button

**Expected Result:**
- Warning message: "Please select a guest to delete."
- No deletion occurs

**Status:** ? Pass | ? Fail

---

### Test 11: View Without Selection
**Steps:**
1. Deselect all rows
2. Click **"View Details"** button

**Expected Result:**
- Warning message: "Please select a guest to view."
- No details dialog opens

**Status:** ? Pass | ? Fail

---

### Test 12: Cancel Delete
**Steps:**
1. Select a guest
2. Click Delete
3. Confirmation dialog appears ? Click **"No"**

**Expected Result:**
- Guest is NOT deleted
- Grid remains unchanged
- No success message

**Status:** ? Pass | ? Fail

---

### Test 13: UI Visual Check
**Steps:**
1. Open the form
2. Visually inspect the layout

**Expected Result:**
- ? Title bar: "Guest Management" in white on dark blue
- ? Search panel: Gray background with label, textbox, Search & Refresh buttons
- ? DataGridView: White background, alternating gray rows
- ? Right panel: White background with View Details & Delete buttons
- ? Bottom panel: Gray background with "Total Guests: X" label
- ? Buttons: Proper colors (Search=Green, Refresh=Blue, View=Blue, Delete=Red)
- ? All elements properly aligned

**Status:** ? Pass | ? Fail

---

### Test 14: Keyboard Functionality
**Steps:**
1. Click in the search textbox
2. Type a search term
3. Press **Enter** key (don't click Search button)

**Expected Result:**
- Search executes automatically on Enter key press
- Same results as clicking Search button

**Status:** ? Pass | ? Fail

---

### Test 15: Error Handling - Database Connection
**Steps:**
1. (Manually stop SQL Server if possible, or simulate connection error)
2. Try to open Guest Management form

**Expected Result:**
- Error message displays: "Error loading guests: [error details]"
- Form doesn't crash
- Error is user-friendly

**Status:** ? Pass | ? Fail | ? N/A

---

## ?? KNOWN ISSUES / LIMITATIONS

### Current Limitations (Expected):
- ?? **Cannot ADD new guests** - This is Day 12 feature
- ?? **Cannot EDIT guests** - This is Day 12 feature
- ?? No guest booking history view - Future feature

### Issues Found During Testing:
*Document any bugs or unexpected behavior here:*

```
1. 
2. 
3. 
```

---

## ?? TESTING SUMMARY

| Test # | Test Name | Status | Notes |
|--------|-----------|--------|-------|
| 1 | Open Form | ? | |
| 2 | View Details | ? | |
| 3 | Double-Click View | ? | |
| 4 | Search by Name | ? | |
| 5 | Search by Email | ? | |
| 6 | Search by Phone | ? | |
| 7 | Clear Search | ? | |
| 8 | Refresh | ? | |
| 9 | Delete Guest | ? | |
| 10 | Delete No Selection | ? | |
| 11 | View No Selection | ? | |
| 12 | Cancel Delete | ? | |
| 13 | UI Visual | ? | |
| 14 | Keyboard Enter | ? | |
| 15 | Error Handling | ? | |

**Overall Status:** ? All Pass | ? Some Failures | ? Not Tested

---

## ?? DATABASE VERIFICATION

After testing Delete functionality, verify in SQL Server:

```sql
-- Check if soft delete worked (IsActive should be 0)
SELECT GuestId, FirstName, LastName, Email, IsActive 
FROM Guests 
WHERE GuestId = [ID_OF_DELETED_GUEST];

-- Should return IsActive = 0, not actually deleted from table
```

---

## ? SIGN-OFF

**Tester Name:** ________________________  
**Date:** ________________________  
**Build Version:** Day 11  
**Overall Result:** ? PASS | ? FAIL  

**Comments:**
```


```

---

## ?? NEXT: Day 12 Testing

On Day 12, we'll add:
- **Add Guest** dialog and functionality
- **Edit Guest** dialog and functionality
- Complete CRUD validation

Stay tuned! ??
