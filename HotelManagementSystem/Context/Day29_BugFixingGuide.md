# Day 29: Bug Fixing Session - Comprehensive Testing Guide

## Overview
**Date:** Monday, March 3, 2025  
**Duration:** 2 hours  
**Goal:** Test all CRUD operations and fix any crashes or errors

---

## What You Built So Far (Weeks 1-4)
✓ Database connected  
✓ Login system (authentication)  
✓ Room Management (CRUD operations)  
✓ Guest Management (CRUD operations)  
✓ Booking System (Create, Check-In, Check-Out)  
✓ Invoice Management  
✓ Payment Processing (Strategy pattern)  
✓ Housekeeping Tasks (Observer pattern)  
✓ 5 Design Patterns implemented  

---

## Today's Tasks (2 Hours)

### Task 1: Run Comprehensive CRUD Tests (30 minutes)
**What to do:**
1. Open `Day29BugFixingTests.cs` 
2. Uncomment the `Main` method in `TestRunner.cs`
3. Build and run the test suite
4. Note any FAILED or ERROR test results
5. Screenshot the test results

**Expected Output:**
- 16 tests across 7 sections
- 3 design patterns verified (Factory, Repository, Strategy)
- All CRUD operations tested

**Critical Tests:**
- Guest Create/Read/Update/Delete
- Room Create/Read/Update
- Booking Create/Read/Update
- Invoice Create/Read/Update
- Payment Create/Read
- Housekeeping Task Create/Update

---

### Task 2: Test All Forms Manually (45 minutes)
Follow this sequence to test the entire workflow:

#### Test Sequence A: Guest & Room Management
1. **Open Login Form**
   - Login with Admin credentials
   - ✓ Verify authentication works
   - ✓ Check main menu appears correctly

2. **Open Guest Management Form**
   - ✓ View all guests in DataGridView
   - ✓ Add new guest
   - ✓ Edit existing guest
   - ✓ Delete guest (if implemented)
   - ✓ Search/filter guests

3. **Open Room Management Form**
   - ✓ View all rooms in DataGridView
   - ✓ Add new room (use Factory pattern)
   - ✓ Edit room details
   - ✓ Check room status updates correctly
   - ✓ Filter by status

#### Test Sequence B: Booking Workflow
1. **Open New Booking Form**
   - ✓ Select guest from list
   - ✓ Select room (available rooms only)
   - ✓ Set check-in and check-out dates
   - ✓ Calculate total price correctly
   - ✓ Create booking successfully
   - ✓ Verify room status changes to "Reserved"

2. **Open Booking List Form**
   - ✓ View all bookings
   - ✓ Check booking details display correctly
   - ✓ Filter by status

3. **Check-In Process**
   - ✓ Select booking from list
   - ✓ Click Check-In button
   - ✓ Verify status changes to "CheckedIn"
   - ✓ Verify room status changes to "Occupied"

4. **Check-Out Process**
   - ✓ Select CheckedIn booking
   - ✓ Click Check-Out button
   - ✓ Verify status changes to "CheckedOut"
   - ✓ Verify room status changes to "Cleaning"
   - ✓ Verify housekeeping task created (Observer pattern)

#### Test Sequence C: Billing & Payment
1. **Open Invoice Form**
   - ✓ Generate invoice from booking
   - ✓ Display correct amounts (subtotal, tax, total)
   - ✓ Invoice details show correctly

2. **Open Payment Form**
   - ✓ Select payment method (Cash)
   - ✓ Enter amount received
   - ✓ Calculate change correctly
   - ✓ Process payment successfully

3. **Verify Invoice Status**
   - ✓ Invoice marked as "Paid"
   - ✓ Payment history updated

#### Test Sequence D: Housekeeping Tasks
1. **Open Housekeeping Tasks Form**
   - ✓ View all tasks in DataGridView
   - ✓ See auto-created tasks from check-outs
   - ✓ Update task status (Pending → Completed)
   - ✓ Filter by status

---

### Task 3: Bug Logging & Fixing (45 minutes)

**For each bug found:**

1. **Document it:**
   ```
   Bug #1: [Name]
   Severity: [Critical/High/Medium/Low]
   Steps to Reproduce: [Exact steps]
   Expected: [What should happen]
   Actual: [What happens]
   Error Message: [Full error message if applicable]
   ```

2. **Categorize:**
   - **Crash:** Application freezes or closes
   - **Data Issue:** Wrong calculation or missing data
   - **UI Issue:** Controls not visible/responsive
   - **Logic Issue:** Feature doesn't work as designed

3. **Fix Priority:**
   - **CRITICAL:** Crashes - Fix immediately
   - **HIGH:** Data loss or incorrect calculations - Fix before end of day
   - **MEDIUM:** UI/UX issues - Fix if time permits
   - **LOW:** Minor UI polish - Document for Week 5 Day 30

---

## Common Bugs to Look For

### Data Issues
- [ ] Invoice amounts calculated incorrectly
- [ ] Room prices not displaying
- [ ] Booking total price calculation wrong
- [ ] Tax calculation incorrect

### Null Reference Errors
- [ ] Selecting room without guest selected
- [ ] Checking out booking with no invoice
- [ ] Payment without invoice

### UI/Logic Issues
- [ ] Check-out date before check-in date
- [ ] Booking overlapping with existing booking
- [ ] Room status not updating after check-in/out
- [ ] Invoice not generating after check-out

### Display Issues
- [ ] DataGridView not refreshing after CRUD operations
- [ ] Forms not closing after successful save
- [ ] Drop-down lists empty (no guests/rooms)
- [ ] Date pickers not showing correct format

---

## How to Run the Test Suite

```csharp
// In TestRunner.cs, uncomment this:
static void Main(string[] args)
{
    RunDay29BugFixingTests();
}

// Then run: Ctrl+F5 (or Debug > Start Without Debugging)
```

**Test Output Shows:**
- ✓ PASSED - Test succeeded
- ✗ FAILED - Test failed, review error
- ⚠ PARTIAL - Test completed but with warnings

---

## What Each Test Section Validates

### Section 1: Guest Management CRUD
Tests create, read, update, delete, and list all guests

### Section 2: Room Management CRUD
Tests create, read, update, and list available rooms

### Section 3: Booking Management CRUD
Tests create, read, update booking status, and list bookings

### Section 4: Invoice Management CRUD
Tests create, read, update invoice with correct calculations

### Section 5: Payment Management CRUD
Tests create and retrieve payment records

### Section 6: Housekeeping Task CRUD
Tests create and update housekeeping tasks

### Section 7: Edge Cases & Error Handling
Tests null inputs, empty queries, and database connectivity

---

## Design Patterns Verification Checklist

During testing, verify these 5 required patterns are working:

1. **🏭 Factory Pattern (Room Creation)**
   - [ ] RoomFactory creates different room types
   - [ ] Single, Double, Suite, Deluxe rooms work
   - [ ] Room prices set correctly

2. **📦 Repository Pattern (Data Access)**
   - [ ] GuestRepository CRUD works
   - [ ] RoomRepository CRUD works
   - [ ] BookingRepository CRUD works
   - [ ] GetAll() returns correct objects

3. **🎭 Facade Pattern (Booking System)**
   - [ ] BookingFacade coordinates Guest, Room, Booking repos
   - [ ] Simplifies complex booking logic

4. **👁️ Observer Pattern (Housekeeping)**
   - [ ] Housekeeping task auto-created on check-out
   - [ ] Observer notified when room status changes
   - [ ] RoomSubject works correctly

5. **🔄 Strategy Pattern (Payment Methods)**
   - [ ] CashPaymentStrategy processes correctly
   - [ ] PaymentContext uses correct strategy
   - [ ] Payment updates invoice status

---

## Time Breakdown (2 Hours)

| Time | Task | Notes |
|------|------|-------|
| 00:00-00:30 | Run test suite | Document all failures |
| 00:30-01:15 | Manual CRUD testing | Test each form workflow |
| 01:15-02:00 | Bug fixing | Fix crashes/critical issues |

---

## What NOT to Do Today
❌ Don't add new features  
❌ Don't refactor working code  
❌ Don't change database schema  
❌ Don't over-polish UI (save for Day 30)  

---

## Success Criteria for Day 29

✓ All test suite tests pass OR errors are documented  
✓ Can complete full workflow: Create Booking → Check-In → Check-Out → Payment  
✓ No crashes when running forms  
✓ All CRUD operations work (Create, Read, Update, Delete/List)  
✓ All 5 design patterns verified and working  

---

## Notes for Next Session
- Document any bugs found but not fixed
- List which tests failed and why
- Note any improvements needed for Week 5
- Screenshot important test results

---

## Quick Reference: Test Expected Results

```
Total Tests: 16
Section 1 (Guest): 5 tests
Section 2 (Room): 4 tests
Section 3 (Booking): 4 tests
Section 4 (Invoice): 3 tests
Section 5 (Payment): 2 tests
Section 6 (Housekeeping): 2 tests
Section 7 (Edge Cases): 3 tests
```

**Target Success Rate: 85-100%**

If you get less than 85%, focus on critical CRUD operations first, then edge cases.

---

Good luck with Day 29! You're almost there! 🚀
