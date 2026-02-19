# ✅ Day 32 Summary - Sample Data + Walkthrough

## 📦 Sample Data Loaded
- **Rooms:** 10 (1–4 floors)
- **Guests:** 5
- **Bookings:** 3 (Confirmed + CheckedIn)
- **Users:** 4 (Admin + staff)

Source: `Context/database.sql`

---

## 🚶 Full System Walkthrough (MVP)

### 1) Login
- Use: **admin / Admin123!**
- Role-based menus should appear.

### 2) Room Management
- Open `RoomManagementForm`.
- Verify **10 rooms** load in `DataGridView`.
- Open `RoomStatusDashboard` to confirm status colors.

### 3) Guest Management
- Open `GuestManagementForm`.
- Verify **5 guests** load and search works.

### 4) Booking Flow
- Open `NewBookingForm`.
- Create a booking with an available room.
- Confirm `BookingListForm` shows new booking.

### 5) Check-In
- In `BookingListForm`, select a **Confirmed** booking.
- Click **Check-In**.
- Room status updates to **Occupied**.

### 6) Check-Out
- In `BookingListForm`, select a **CheckedIn** booking.
- Click **Check-Out**.
- Room status updates to **Cleaning**.
- **Invoice** auto-generated.
- **Housekeeping task** auto-created.

### 7) Invoice + Payment
- Open `InvoiceListForm` or `InvoiceForm`.
- Verify invoice totals and status.
- Process cash payment in `PaymentForm`.
- Confirm payment appears in `PaymentHistoryForm` and receipt works.

---

## 🧩 Design Patterns (Where to Show)

1. **Singleton** → `DAL/DatabaseManager.cs`, `Patterns/RoomSubject.cs`
2. **Repository** → `DAL/*Repository.cs`
3. **Factory** → `Models/RoomFactory.cs`
4. **Facade** → `BLL/BookingFacade.cs`
5. **Observer** → `Patterns/RoomSubject.cs` + `HousekeepingObserver.cs`
6. **Strategy** → `Patterns/IPaymentStrategy.cs` + `PaymentContext.cs`

---

## ✅ Quick Validation Checklist
- [ ] Rooms: 10
- [ ] Guests: 5
- [ ] Bookings: 3+
- [ ] Check-in updates room → **Occupied**
- [ ] Check-out updates room → **Cleaning**
- [ ] Invoice created on checkout
- [ ] Housekeeping task created on checkout
- [ ] Payment updates invoice status
