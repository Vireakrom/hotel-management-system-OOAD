# Hotel Management System — Project Documentation

---

## I. Objective

The **Hotel Management System** is a desktop application developed in **C# using Windows Forms** that provides a comprehensive solution for managing the daily operations of a hotel. The system streamlines guest management, room allocation, booking workflows, invoicing, payment processing, housekeeping task coordination, and staff administration — all from a single unified interface.

### Purpose

The primary purpose of this system is to replace manual hotel operations with an efficient, digital management platform that reduces human error, speeds up processes, and provides real‑time visibility into hotel operations.

### What the System Can Perform

| Module | Capabilities |
|---|---|
| **Authentication** | Secure login with hashed passwords (SHA-256 + salt), role‑based access control (Admin, Receptionist, Housekeeping), "Remember Me" functionality |
| **Guest Management** | Register new guests, update guest profiles, search guests by name/email/phone, soft‑delete records, view guest booking history |
| **Room Management** | Add/edit rooms of 4 types (Single, Double, Suite, Deluxe), track room status (Available, Occupied, Reserved, Maintenance, Cleaning), visual status dashboard |
| **Booking Management** | Create, confirm, modify, and cancel bookings; check‑in/check‑out guests; automatic room charge calculation based on room price × nights; date conflict detection |
| **Invoicing** | Auto‑generate invoices on checkout with subtotal, 10% tax, discounts; track invoice status (Pending, Paid, Partially Paid, Cancelled) |
| **Payment Processing** | Process Cash and Credit Card payments using the Strategy design pattern; change calculation for cash; Luhn card validation; styled receipt generation with print/copy support |
| **Housekeeping** | Auto‑create cleaning tasks on checkout via Observer pattern; smart staff assignment (assigns to least‑busy housekeeping staff); task status tracking (Pending → In Progress → Completed) |
| **Staff Management** | CRUD operations for staff/user accounts; role assignment; password management with secure hashing |
| **Reporting** | Daily operations report dashboard |

---

## II. Functional Description

### System Workflow

The overall workflow follows a typical hotel operation lifecycle:

```
Login → Guest Registration → Room Selection → Booking Creation
  → Check‑In → (Stay) → Check‑Out → Invoice Generated
  → Payment Processed → Receipt Displayed
  → Housekeeping Task Auto‑Created → Task Completed → Room Available
```

### Forms and Their Functions

#### Form 1 — Login Form (`LoginForm.cs`)

The entry point of the application. Provides secure user authentication.

- **Username and password** fields with toggle visibility (🔒 / 👁)
- **"Remember Me"** checkbox that persists credentials (Base64‑encoded) in application settings
- Calls `UserRepository.Authenticate()` which verifies the password hash using `PasswordHelper.VerifyPassword()`
- On success, stores the authenticated user in `SessionManager.CurrentUser` and opens the Main Form
- On failure, displays an error message and clears the password field

**Authentication flow:**
```
User enters credentials
  → UserRepository.Authenticate(username, password)
  → PasswordHelper retrieves stored salt
  → SHA-256(input + salt) compared to stored hash
  → Success: SessionManager.CurrentUser = user → Open MainForm
  → Failure: Show error
```

#### Form 2 — Main Form (`MainForm.cs`)

The MDI (Multiple Document Interface) container that serves as the main navigation hub.

- **Menu bar** with access to all modules: Booking, Guest, Room, Housekeeping, Invoices & Payments, Reports, Settings, Admin
- **Status bar** displaying the current logged‑in user, role, and live clock (updated every second)
- **Midnight blue theme** with Segoe UI typography
- **Initializes the Observer pattern** on startup:
  ```
  RoomSubject.Instance → Attach(new HousekeepingObserver())
  ```

#### Form 3 — Guest Management (`GuestManagementForm.cs`)

Complete CRUD interface for managing hotel guests.

- **DataGridView** listing all active guests with columns: Name, Email, Phone, ID Number, Nationality
- **Search** by name, email, or phone number
- **Add Guest** button → opens `AddEditGuestDialog` for inserting a new guest record
- **Edit Guest** button → opens `AddEditGuestDialog` pre‑populated with existing data
- **Delete Guest** → soft delete (sets `IsActive = 0`)
- **View Details** → opens `GuestDetailsDialog` showing full guest profile

#### Form 4 — Room Management (`RoomManagementForm.cs`)

Manages hotel rooms with a visual dashboard.

- **Room list** with filtering by type and status
- **Add Room** → opens `AddEditRoomDialog`; rooms are created via `RoomFactory.CreateRoom()` (Factory Pattern)
- **Edit Room** / **Delete Room** (soft delete to Maintenance status)
- **Room Status Dashboard** (`RoomStatusDashboard.cs`) — visual card‑based overview of all rooms color‑coded by status

**Room types and their defaults (set by RoomFactory):**

| Type | Max Occupancy | Bed | Area | Base Price | Special Features |
|---|---|---|---|---|---|
| Single | 1 | Single | 20 m² | $50 | — |
| Double | 2 | Queen | 30 m² | $80 | — |
| Suite | 4 | King | 50 m² | $150 | Balcony |
| Deluxe | 4 | King | 70 m² | $250 | Balcony, Jacuzzi |

#### Form 5 — Booking List (`BookingListForm.cs`)

Central booking management form with all booking operations.

- **DataGridView** showing all bookings with color‑coded status rows:
  - 🟡 Yellow = Pending
  - 🟢 Green = Confirmed
  - 🔵 Blue = Checked In
  - ⚪ Gray = Checked Out
  - 🔴 Red = Cancelled
- **Search & Filter** by guest name, room number, or status
- **Action buttons:**
  - **View Details** → opens `BookingDetailsForm`
  - **Check‑In** → validates status → updates booking to CheckedIn → sets room to Occupied
  - **Check‑Out** → updates booking → sets room to Cleaning → auto‑generates invoice → triggers Observer (auto‑creates housekeeping task)
  - **Process Payment** → opens `PaymentForm` for checked‑out bookings
  - **Cancel Booking** → prompts for reason → cancels booking → frees room

**Booking status lifecycle:**
```
Pending → Confirmed → CheckedIn → CheckedOut
    ↘ Cancelled (from any state except CheckedOut)
```

#### Form 6 — New Booking (`NewBookingForm.cs`)

Wizard‑style form for creating new reservations.

- Guest selection, room selection (filtered by availability), date pickers
- Automatic charge calculation: `RoomCharges = BasePrice × NumberOfNights`
- Total amount with 10% tax via `BookingFacade.CalculateTotalAmount()`
- Uses the **Facade Pattern** (`BookingFacade`) to orchestrate the multi‑step booking workflow

#### Form 7 — Payment Form (`PaymentForm.cs`)

Processes payments using the **Strategy Pattern**.

- Displays invoice details: subtotal, tax, total, paid, balance
- **Cash payment mode:**
  - Enter amount received → automatic change calculation
  - Uses `CashPaymentStrategy` for processing
- **Credit card payment mode:**
  - Card number (validated with Luhn algorithm), holder name, expiry, CVV
  - Simulated gateway authorization (95% success rate)
  - Card number masked — only last 4 digits stored
  - Uses `CreditCardPaymentStrategy` for processing
- On success → automatically displays the styled **Receipt Form**

#### Form 8 — Receipt Form (`ReceiptForm.cs`)

Styled visual receipt displayed after successful payment.

- **Gradient blue header** with checkmark icon and "Payment Successful" text
- **Section cards** for: Receipt Info, Guest Info, Booking Details, Financial Breakdown, Payment Info
- **Color‑coded status badge:** ✓ PAID IN FULL (green) / ◑ PARTIALLY PAID (orange) / ○ PENDING (red)
- **Action buttons:** Print, Export PDF, Copy to Clipboard, Close
- Uses custom GDI+ drawing with `LinearGradientBrush` for the gradient header

#### Form 9 — Invoice Management (`InvoiceListForm.cs` / `InvoiceForm.cs`)

View and manage invoices generated from bookings.

- List all invoices with status filtering
- View invoice details via `InvoiceDetailsDialog`
- Track payment history per invoice

#### Form 10 — Housekeeping Tasks (`HousekeepingTasksForm.cs`)

Manages cleaning and maintenance tasks.

- Lists all housekeeping tasks with status, priority, room, and assigned staff
- Tasks are **auto‑created** by the Observer pattern when a guest checks out
- Staff can be assigned manually or automatically (least‑busy algorithm)
- Status workflow: Pending → In Progress → Completed

#### Form 11 — Staff Management (`StaffManagementForm.cs`)

Admin interface for managing system users.

- CRUD operations for staff accounts via `AddEditStaffDialog`
- Role assignment: Admin, Receptionist, Housekeeping
- Password management with secure SHA-256 hashing

#### Form 12 — Daily Operations Report (`DailyOperationsReportForm.cs`)

Dashboard providing an overview of daily hotel operations and key metrics.

---

## III. Design Patterns Implementation

This project implements **6 design patterns**, exceeding the minimum requirement of 5.

### Pattern 1 — Singleton Pattern

**Files:** `DAL/DatabaseManager.cs`, `Patterns/RoomSubject.cs`

**Purpose:** Ensures that only one instance of a critical resource exists throughout the application's lifetime.

**Implementation — DatabaseManager (Database Connection):**

```csharp
public class DatabaseManager
{
    private static DatabaseManager _instance;
    private static readonly object _lock = new object();

    // Thread-safe singleton with double-check locking
    public static DatabaseManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DatabaseManager();
                }
            }
            return _instance;
        }
    }

    private DatabaseManager() { }  // Private constructor prevents external instantiation

    public SqlConnection GetConnection() { ... }
    public DataTable ExecuteQuery(string query, SqlParameter[] parameters) { ... }
    public int ExecuteNonQuery(string query, SqlParameter[] parameters) { ... }
    public object ExecuteScalar(string query, SqlParameter[] parameters) { ... }
}
```

**Why Singleton:** The database connection manager must be a single shared resource. Multiple instances would lead to connection pool exhaustion, inconsistent state, and resource leaks. The thread‑safe double‑check locking pattern ensures safety in multi‑threaded scenarios.

**Where it's used:** Every Repository class accesses `DatabaseManager.Instance` to execute SQL queries against the hotel database.

**Implementation — RoomSubject (Observer Subject):**

The `RoomSubject` also uses the Singleton pattern so that all parts of the system (booking forms, checkout logic) can notify the same central subject, and all observers receive the notifications.

```csharp
public class RoomSubject
{
    private static RoomSubject _instance;
    private static readonly object _lock = new object();

    public static RoomSubject Instance { get { ... } }  // Same double-check locking
}
```

---

### Pattern 2 — Factory Method Pattern

**Files:** `BLL/Factories/RoomFactory.cs`, `Models/Room.cs` (abstract base + 4 subclasses)

**Purpose:** Encapsulates the creation of different room type objects, allowing the system to create rooms without specifying their exact concrete class.

**Implementation:**

```csharp
// Abstract base class
public abstract class Room
{
    public abstract decimal GetPrice();
    public abstract string GetDescription();
    public virtual decimal CalculateTotalPrice(int numberOfNights) { ... }
    public virtual bool CanAccommodate(int numberOfGuests) { ... }
}

// Concrete room types
public class SingleRoom : Room  { /* MaxOccupancy=1, BedType="Single" */ }
public class DoubleRoom : Room  { /* MaxOccupancy=2, BedType="Queen" */ }
public class SuiteRoom  : Room  { /* MaxOccupancy=4, +15% for SeaView */ }
public class DeluxeRoom : Room  { /* MaxOccupancy=4, +20% SeaView, +25% PrivatePool */ }

// Factory class
public static class RoomFactory
{
    // Simple factory method
    public static Room CreateRoom(string roomType)
    {
        switch (roomType)
        {
            case "Single": return new SingleRoom();
            case "Double": return new DoubleRoom();
            case "Suite":  return new SuiteRoom();
            case "Deluxe": return new DeluxeRoom();
            default: throw new ArgumentException($"Invalid room type: {roomType}");
        }
    }

    // Fully configured factory method
    public static Room CreateRoom(string roomType, string roomNumber,
        int floorNumber, decimal basePrice, string status = "Available")
    {
        Room room = CreateRoom(roomType);
        room.RoomNumber = roomNumber;
        room.FloorNumber = floorNumber;
        room.BasePrice = basePrice;
        room.Status = status;
        ConfigureRoomDefaults(room);  // Sets BedType, Area, MaxOccupancy per type
        return room;
    }

    // Database reconstruction factory
    public static Room CreateRoomFromDatabase(string roomType, int roomId, ...) { ... }
}
```

**Why Factory:** Different room types have different default configurations (bed type, area, occupancy limits, amenities) and different pricing logic (Suite adds 15% for sea view, Deluxe adds 20% for sea view + 25% for private pool). The Factory centralizes this creation logic so that the UI and data access layers don't need to know which concrete class to instantiate.

**Where it's used:**
- `AddEditRoomDialog` → calls `RoomFactory.CreateRoom(type, number, floor, price)` when adding a new room
- `RoomRepository.MapReaderToRoom()` → calls `RoomFactory.CreateRoomFromDatabase()` when loading rooms from the database

---

### Pattern 3 — Strategy Pattern

**Files:** `Patterns/IPaymentStrategy.cs`, `Patterns/CashPaymentStrategy.cs`, `Patterns/CreditCardPaymentStrategy.cs`, `Patterns/PaymentContext.cs`

**Purpose:** Defines a family of interchangeable payment algorithms, letting the system switch between cash and credit card processing at runtime without changing the payment workflow.

**Implementation:**

```csharp
// Strategy Interface
public interface IPaymentStrategy
{
    Payment ProcessPayment(Invoice invoice, decimal amount, int userId);
    bool ValidatePayment(decimal amount);
    string GetPaymentMethodName();
}

// Concrete Strategy: Cash
public class CashPaymentStrategy : IPaymentStrategy
{
    public Payment ProcessPayment(Invoice invoice, decimal amount, int userId)
    {
        // 1. Create Payment record (method="Cash", TransactionId=TXN-...)
        // 2. Insert into database via PaymentRepository
        // 3. Update Invoice: PaidAmount += amount
        // 4. Set invoice status: "Paid" or "PartiallyPaid"
        // 5. Return Payment object
    }

    public static decimal CalculateChange(decimal amountDue, decimal amountReceived)
        => amountReceived - amountDue;
}

// Concrete Strategy: Credit Card
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public Payment ProcessPayment(Invoice invoice, decimal amount, int userId)
    {
        // Same flow as cash, plus:
        // - Card number validation (Luhn algorithm)
        // - CVV validation (3-4 digits)
        // - Gateway authorization simulation (95% success)
        // - Card number masking (only last 4 digits stored)
    }

    public static bool ValidateCardNumber(string cardNumber) { /* Luhn */ }
    public static bool SimulateGatewayAuthorization(...) { /* 95% pass rate */ }
}

// Context (switches strategies at runtime)
public class PaymentContext
{
    private IPaymentStrategy _strategy;

    public PaymentContext() { _strategy = new CashPaymentStrategy(); }

    public void SetPaymentStrategy(string paymentMethod)
    {
        switch (paymentMethod)
        {
            case "Cash":       _strategy = new CashPaymentStrategy(); break;
            case "CreditCard": _strategy = new CreditCardPaymentStrategy(); break;
        }
    }

    public Payment ExecutePayment(Invoice invoice, decimal amount, int userId)
        => _strategy.ProcessPayment(invoice, amount, userId);
}
```

**Why Strategy:** The hotel needs to support multiple payment methods with completely different processing logic (cash requires change calculation; credit cards require Luhn validation, CVV checks, and gateway authorization). The Strategy pattern allows adding new payment methods (e.g., Mobile Payment, Bank Transfer) by simply creating a new class that implements `IPaymentStrategy` — no changes to existing code required.

**Where it's used:** `PaymentForm.cs` creates a `PaymentContext`, sets the strategy based on the user's radio button selection (Cash/Credit Card), and calls `ProcessCashPayment()` or `ProcessCreditCardPayment()`.

---

### Pattern 4 — Observer Pattern

**Files:** `Patterns/IObserver.cs`, `Patterns/RoomSubject.cs`, `Patterns/HousekeepingObserver.cs`

**Purpose:** Establishes a one‑to‑many notification system so that when a room event occurs (e.g., guest checkout), all registered observers are automatically notified and can take action.

**Implementation:**

```csharp
// Observer Interface
public interface IObserver
{
    void Update(int roomId, string eventType, object additionalData = null);
}

// Subject (Observable) — Singleton
public class RoomSubject
{
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer) => _observers.Add(observer);
    public void Detach(IObserver observer) => _observers.Remove(observer);

    public void Notify(int roomId, string eventType, object additionalData = null)
    {
        foreach (var observer in _observers)
            observer.Update(roomId, eventType, additionalData);
    }
}

// Concrete Observer: Housekeeping
public class HousekeepingObserver : IObserver
{
    public void Update(int roomId, string eventType, object additionalData)
    {
        switch (eventType)
        {
            case "CheckOut":
                CreateCheckOutCleaningTask(roomId, additionalData);
                break;
            case "Maintenance":
                CreateMaintenanceTask(roomId);
                break;
        }
    }

    private void CreateCheckOutCleaningTask(int roomId, object additionalData)
    {
        // 1. Create HousekeepingTask (type="Cleaning", priority="High")
        // 2. Smart auto-assignment: find housekeeping staff with fewest active tasks
        // 3. Insert task into database
    }
}
```

**Why Observer:** When a guest checks out, multiple subsystems need to respond: the room status must change, a cleaning task must be created, and the right staff member must be assigned. Without the Observer pattern, the checkout code would need to directly call housekeeping logic, creating tight coupling. With Observer, the checkout simply calls `RoomSubject.Notify()`, and any number of observers can react independently.

**Where it's used:**
- **Setup:** `MainForm` constructor creates the observer and attaches it:
  ```csharp
  roomSubject = RoomSubject.Instance;
  roomSubject.Attach(new HousekeepingObserver());
  ```
- **Trigger:** `BookingListForm.btnCheckOut_Click()` calls:
  ```csharp
  roomSubject.Notify(booking.RoomId, "CheckOut", bookingId);
  ```
- **Result:** `HousekeepingObserver` auto‑creates a high‑priority cleaning task and assigns it to the least‑busy housekeeping staff member.

---

### Pattern 5 — Repository Pattern

**Files:** `DAL/IRepository.cs`, `DAL/GuestRepository.cs`, `DAL/RoomRepository.cs`, `DAL/BookingRepository.cs`, `DAL/InvoiceRepository.cs`, `DAL/PaymentRepository.cs`, `DAL/UserRepository.cs`, `DAL/HousekeepingTaskRepository.cs`

**Purpose:** Separates the data access logic from the business logic by providing a clean, generic interface for CRUD operations. Each entity has its own repository that encapsulates all SQL queries.

**Implementation:**

```csharp
// Generic Repository Interface
public interface IRepository<T> where T : class
{
    int Insert(T entity);
    T GetById(int id);
    List<T> GetAll();
    bool Update(T entity);
    bool Delete(int id);
}

// Example: GuestRepository
public class GuestRepository : IRepository<Guest>
{
    public int Insert(Guest guest) { /* INSERT SQL + parameterized query */ }
    public Guest GetById(int id)   { /* SELECT WHERE GuestId=@id AND IsActive=1 */ }
    public List<Guest> GetAll()    { /* SELECT WHERE IsActive=1 ORDER BY LastName */ }
    public bool Update(Guest guest){ /* UPDATE SQL */ }
    public bool Delete(int id)     { /* Soft delete: SET IsActive=0 */ }

    // Extended query methods
    public List<Guest> Search(string searchTerm)
    { /* LIKE search on FirstName, LastName, Email, Phone */ }
}
```

**All 7 repositories and their extended methods:**

| Repository | Standard CRUD | Extended Methods |
|---|---|---|
| `GuestRepository` | ✅ | `Search(searchTerm)` |
| `RoomRepository` | ✅ | `GetAvailableRooms()`, `UpdateRoomStatus()`, `GetByRoomNumber()` |
| `BookingRepository` | ✅ | `GetBookingsByGuest()`, `GetActiveBookings()`, `CheckIn()`, `CheckOut()`, `CancelBooking()` |
| `InvoiceRepository` | ✅ | `GetByBookingId()`, `GetInvoicesByStatus()` |
| `PaymentRepository` | ✅ | `GetPaymentsByInvoiceId()`, `GetPaymentsByMethod()`, `GetPaymentsByDateRange()` |
| `UserRepository` | ✅ | `Authenticate()`, `GetByRole()`, `UpdatePassword()` |
| `HousekeepingTaskRepository` | ✅ | `GetTasksByStatus()`, `GetTasksByRoom()`, `UpdateStatus()` |

**Why Repository:** Without this pattern, SQL queries would be scattered across UI forms and business logic classes, making the code unmaintainable. The Repository pattern provides a single place to manage all data operations per entity, enables unit testing with mock repositories, and ensures consistent data access patterns (parameterized queries, connection management via `DatabaseManager.Instance`).

---

### Pattern 6 — Facade Pattern

**Files:** `BLL/BookingFacade.cs`

**Purpose:** Provides a simplified interface to the complex booking subsystem, which involves coordinating multiple repositories (Guest, Room, Booking) and multiple validation steps.

**Implementation:**

```csharp
public class BookingFacade
{
    private GuestRepository _guestRepository;
    private RoomRepository _roomRepository;
    private BookingRepository _bookingRepository;

    public int CreateBooking(int guestId, int roomId,
        DateTime checkInDate, DateTime checkOutDate,
        int numberOfGuests, string specialRequests, string notes)
    {
        // Orchestrates 8 steps behind a single method call:
        // 1. Validate booking dates (check-in >= today, check-out > check-in)
        // 2. Validate guest exists in database
        // 3. Validate room exists in database
        // 4. Check room capacity (numberOfGuests <= room.MaxOccupancy)
        // 5. Check room availability (no date conflicts)
        // 6. Calculate charges: roomCharges = room.BasePrice × numberOfNights
        // 7. Create Booking object (status = "Pending")
        // 8. Update room status to "Reserved"
        // Returns: new bookingId
    }

    public decimal CalculateTotalAmount(decimal roomCharges, decimal serviceCharges)
    {
        decimal subtotal = roomCharges + serviceCharges;
        decimal tax = subtotal * 0.10m;  // 10% tax rate
        return Math.Round(subtotal + tax, 2);
    }

    public bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut) { ... }
    public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut) { ... }

    // Status management
    public bool ConfirmBooking(int bookingId)  { ... }
    public bool CheckIn(int bookingId)         { ... }
    public bool CheckOut(int bookingId)        { ... }
    public bool CancelBooking(int bookingId, string reason) { ... }
}
```

**Why Facade:** Creating a booking requires coordinating 3 repositories, performing 5 validations, and executing multiple database operations in the correct order. Without the Facade, the UI form would need to orchestrate all of this directly, leading to complex and duplicated code. The Facade simplifies this to a single `CreateBooking()` call.

**Where it's used:** `NewBookingForm` calls `BookingFacade.CreateBooking()` to handle the entire booking workflow, and `BookingFacade.CalculateTotalAmount()` for price display.

---

## IV. Conclusion

### Development Process

The **Hotel Management System** was developed as a comprehensive C# Windows Forms application following a modular, layered architecture:

- **Presentation Layer (UI):** 18+ Windows Forms providing intuitive interfaces for each hotel operation module
- **Business Logic Layer (BLL):** Facades and factories encapsulating complex business rules and workflows
- **Data Access Layer (DAL):** Generic Repository pattern with 7 repository implementations for clean database operations
- **Design Patterns Layer:** 6 well‑integrated design patterns (Singleton, Factory, Strategy, Observer, Repository, Facade) applied to solve real architectural challenges

### Key Technical Achievements

1. **Secure Authentication:** SHA-256 password hashing with random salt generation ensures user credentials are never stored in plain text
2. **Automated Workflows:** The Observer pattern enables event‑driven automation — checkout triggers housekeeping task creation with intelligent staff assignment
3. **Flexible Payment Processing:** The Strategy pattern makes it trivial to add new payment methods without modifying existing payment logic
4. **Maintainable Data Layer:** The Repository pattern with a generic `IRepository<T>` interface provides consistent CRUD operations across all 7 entities
5. **Simplified Complex Operations:** The Facade pattern reduces multi‑step booking creation to a single validated method call
6. **Input Validation:** A comprehensive `ValidationHelper` class provides reusable validation for emails, phone numbers, credit cards (Luhn algorithm), dates, and numeric ranges

### Overall Outcome

The system successfully delivers a fully functional hotel management platform that covers the complete hotel operation lifecycle — from guest registration through booking, stay management, checkout, payment, and housekeeping. The implementation of 6 design patterns demonstrates solid software engineering principles including separation of concerns, loose coupling, code reusability, and the Open/Closed Principle. The modular architecture ensures the system can be extended with new features (e.g., additional room types, new payment methods, more observer actions) with minimal changes to existing code.
