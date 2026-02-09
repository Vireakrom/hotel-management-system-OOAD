# ?? Room Status Dashboard - User Guide

## Quick Start Guide

### How to Access
1. Login to the system (admin / Admin@123)
2. Click on **Rooms** menu
3. Select **Room Status Dashboard**

---

## ?? Understanding the Colors

| Color | Status | Meaning |
|-------|--------|---------|
| ?? Green | Available | Room is ready for booking |
| ?? Red | Occupied | Guest currently staying |
| ?? Yellow | Reserved | Booking confirmed, guest not checked in yet |
| ?? Blue | Cleaning | Housekeeping in progress |
| ? Gray | Maintenance | Room under repair/maintenance |

---

## ?? Dashboard Sections

### 1. Top Bar (Title)
- Displays "Room Status Dashboard" heading

### 2. Control Bar
- **Filter Dropdown:** Select status to filter rooms
  - All (shows all rooms)
  - Available
  - Occupied
  - Reserved
  - Cleaning
  - Maintenance
- **Refresh Button:** Reload data from database
- **Close Button:** Exit the dashboard

### 3. Status Summary Panel
Shows counts for:
- **Total Rooms:** Overall room count
- **Available:** Rooms ready to book
- **Occupied:** Rooms with guests
- **Reserved:** Rooms with confirmed bookings
- **Cleaning:** Rooms being cleaned
- **Maintenance:** Rooms under maintenance
- **Occupancy Rate:** Percentage of rooms occupied/reserved

### 4. Room Panels Area
- Scrollable area with all room panels
- Each panel shows:
  - Room Number (e.g., "Room 101")
  - Room Type (Single, Double, Suite, Deluxe)
  - Floor Number
  - Current Status (in uppercase)
  - Price per night

### 5. Legend Bar (Bottom)
- Visual guide to status colors
- Quick reference for understanding panel colors

---

## ??? How to Use

### View All Rooms
1. Open the dashboard
2. All rooms display as colored panels
3. Scroll to see more rooms if needed

### Filter by Status
1. Click the **Filter** dropdown
2. Select a status (e.g., "Available")
3. Only rooms with that status will display
4. Status counts update automatically

### View Room Details
1. **Click** any room panel
2. A popup shows complete information:
   - Room number and type
   - Floor and status
   - Price per night
   - Max occupancy
   - Bed type
   - Area in sq.m
   - View type
   - Special features (Balcony, Sea View, Jacuzzi, Pool)
   - Description

### Refresh Data
1. Click the **Refresh** button
2. Dashboard reloads from database
3. Confirmation message appears

### Exit Dashboard
1. Click the **Close** button
2. Return to main application window

---

## ?? Tips & Tricks

### Quick Status Check
- **Glance at colors** to instantly see room availability
- **Green rooms** = Available for immediate booking
- **Red rooms** = Cannot be booked right now

### Monitor Occupancy
- Check the **Occupancy Rate** in the summary panel
- Higher percentage = more rooms generating revenue
- Track trends over time

### Filter for Specific Needs
- Looking for available rooms? **Filter: Available**
- Need to see cleaning progress? **Filter: Cleaning**
- Check maintenance status? **Filter: Maintenance**

### Use with Room Management
1. Open **Room Management** to add/edit rooms
2. Open **Room Status Dashboard** to see visual overview
3. Use both forms together for complete room control

---

## ?? Common Use Cases

### Scenario 1: Front Desk Check-In
**Goal:** Find available rooms quickly
1. Open dashboard
2. Filter by "Available"
3. Look for green panels
4. Click room to check details
5. Proceed with booking in Room Management

### Scenario 2: Housekeeping Supervisor
**Goal:** Monitor cleaning progress
1. Open dashboard
2. Filter by "Cleaning"
3. See all blue panels (rooms being cleaned)
4. Track progress throughout the day

### Scenario 3: Maintenance Manager
**Goal:** Check rooms under repair
1. Open dashboard
2. Filter by "Maintenance"
3. View all gray panels
4. Click each to see maintenance notes

### Scenario 4: Hotel Manager
**Goal:** Get occupancy overview
1. Open dashboard with "All" filter
2. Check occupancy rate percentage
3. Count available vs. occupied rooms
4. Make staffing decisions

---

## ?? Troubleshooting

### Problem: No rooms showing
**Solution:**
- Check if database has room data
- Click Refresh button
- Verify database connection

### Problem: Colors not displaying
**Solution:**
- Close and reopen the dashboard
- Check room status values in database

### Problem: Filter not working
**Solution:**
- Select "All" first
- Then select specific status
- Click Refresh if needed

### Problem: Click not showing details
**Solution:**
- Click directly on the room panel
- Avoid clicking between panels
- Try clicking the room number text

---

## ? Keyboard Shortcuts

Currently, this dashboard is mouse-driven. Keyboard navigation can be added in future updates.

---

## ?? Best Practices

1. **Refresh regularly** during busy check-in/out times
2. **Use filters** to focus on specific room statuses
3. **Check occupancy rate** at start of day
4. **Monitor cleaning status** during housekeeping hours
5. **Keep dashboard open** on front desk computers

---

## ?? For Administrators

### Setting Room Status
Room status is changed through:
- **Room Management Form** (manual updates)
- **Booking System** (automatic on check-in/out)
- **Direct database updates** (advanced users)

### Color Customization
Colors are defined in the code:
- Available: RGB(46, 125, 50) - Green
- Occupied: RGB(198, 40, 40) - Red
- Reserved: RGB(251, 192, 45) - Yellow/Orange
- Cleaning: RGB(2, 136, 209) - Blue
- Maintenance: RGB(117, 117, 117) - Gray

To change colors, modify `GetStatusColor()` method in `RoomStatusDashboard.cs`.

---

## ?? Future Enhancements (Not in Current Version)

- Right-click menu on room panels
- Drag-and-drop status changes
- Floor-based grouping
- Room type filtering
- Quick booking from dashboard
- Real-time auto-refresh
- Export to Excel
- Print layout view

---

## ? FAQ

**Q: Can I change room status from the dashboard?**
A: Not directly. Use Room Management form to edit room details.

**Q: How often should I refresh?**
A: Refresh when you need the latest data, especially after check-ins/outs.

**Q: Can I filter by floor?**
A: Not in current version. Filter by status only. Floor filtering planned for future.

**Q: What does occupancy rate mean?**
A: Percentage of rooms that are either Occupied or Reserved (generating revenue).

**Q: Can I see multiple dashboards at once?**
A: Only one dashboard per MDI window. Close and reopen for multiple views.

---

## ?? Support

For issues or questions:
1. Check this user guide first
2. Consult the system administrator
3. Refer to the main application documentation

---

**Version:** 1.0  
**Last Updated:** February 12, 2026  
**Part of:** Day 10 Implementation

---

*Enjoy your new visual room status dashboard! It's designed to give you instant insights into your hotel's room availability.* ???
