# UML Diagrams — Design Patterns

This document contains **class diagrams** for all 6 design patterns implemented in the Hotel Management System.  
Individual PlantUML (`.puml`) source files are located in the [`UML_Diagrams/`](./UML_Diagrams/) folder.

---

## Pattern 1 — Singleton

> Ensures a single shared instance of `DatabaseManager` (database access) and `RoomSubject` (event hub) throughout the application.

```mermaid
classDiagram
    class DatabaseManager {
        -DatabaseManager _instance$
        -object _lock$
        -DatabaseManager()
        +DatabaseManager Instance$
        +GetConnection() SqlConnection
        +ExecuteQuery(query, parameters) DataTable
        +ExecuteNonQuery(query, parameters) int
        +ExecuteScalar(query, parameters) object
    }
    class RoomSubject {
        -RoomSubject _instance$
        -object _lock$
        -List~IObserver~ _observers
        -RoomSubject()
        +RoomSubject Instance$
        +Attach(observer) void
        +Detach(observer) void
        +Notify(roomId, eventType, additionalData) void
    }
    DatabaseManager ..> DatabaseManager : instantiates self
    RoomSubject ..> RoomSubject : instantiates self
```

**Files:** `DAL/DatabaseManager.cs`, `Patterns/RoomSubject.cs`

---

## Pattern 2 — Factory Method

> Centralizes the creation of typed `Room` objects (Single, Double, Suite, Deluxe) with their default configurations and pricing logic.

```mermaid
classDiagram
    class Room {
        <<abstract>>
        +string RoomNumber
        +int FloorNumber
        +decimal BasePrice
        +string Status
        +int MaxOccupancy
        +string BedType
        +decimal Area
        +GetPrice() decimal*
        +GetDescription() string*
        +CalculateTotalPrice(numberOfNights) decimal
        +CanAccommodate(numberOfGuests) bool
    }
    class SingleRoom {
        +GetPrice() decimal
        +GetDescription() string
    }
    class DoubleRoom {
        +GetPrice() decimal
        +GetDescription() string
    }
    class SuiteRoom {
        +GetPrice() decimal
        +GetDescription() string
    }
    class DeluxeRoom {
        +GetPrice() decimal
        +GetDescription() string
    }
    class RoomFactory {
        <<static>>
        +CreateRoom(roomType) Room$
        +CreateRoom(roomType, roomNumber, floorNumber, basePrice, status) Room$
        +CreateRoomFromDatabase(roomType, roomId, ...) Room$
        -ConfigureRoomDefaults(room) void$
    }

    Room <|-- SingleRoom
    Room <|-- DoubleRoom
    Room <|-- SuiteRoom
    Room <|-- DeluxeRoom
    RoomFactory ..> SingleRoom  : creates
    RoomFactory ..> DoubleRoom  : creates
    RoomFactory ..> SuiteRoom   : creates
    RoomFactory ..> DeluxeRoom  : creates
```

**Files:** `BLL/Factories/RoomFactory.cs`, `Models/Room.cs` (+ 4 subclasses)

---

## Pattern 3 — Strategy

> Allows switching between `CashPaymentStrategy` and `CreditCardPaymentStrategy` at runtime without changing the payment workflow.

```mermaid
classDiagram
    class IPaymentStrategy {
        <<interface>>
        +ProcessPayment(invoice, amount, userId) Payment
        +ValidatePayment(amount) bool
        +GetPaymentMethodName() string
    }
    class CashPaymentStrategy {
        +ProcessPayment(invoice, amount, userId) Payment
        +ValidatePayment(amount) bool
        +GetPaymentMethodName() string
        +CalculateChange(amountDue, amountReceived) decimal$
    }
    class CreditCardPaymentStrategy {
        +ProcessPayment(invoice, amount, userId) Payment
        +ValidatePayment(amount) bool
        +GetPaymentMethodName() string
        +ValidateCardNumber(cardNumber) bool$
        +SimulateGatewayAuthorization(...) bool$
    }
    class PaymentContext {
        -IPaymentStrategy _strategy
        +PaymentContext()
        +SetPaymentStrategy(paymentMethod) void
        +ExecutePayment(invoice, amount, userId) Payment
    }
    class PaymentForm {
        -PaymentContext _paymentContext
        +ProcessCashPayment() void
        +ProcessCreditCardPayment() void
    }

    IPaymentStrategy <|.. CashPaymentStrategy
    IPaymentStrategy <|.. CreditCardPaymentStrategy
    PaymentContext o--> IPaymentStrategy : _strategy
    PaymentContext ..> CashPaymentStrategy       : creates
    PaymentContext ..> CreditCardPaymentStrategy : creates
    PaymentForm --> PaymentContext : uses
```

**Files:** `Patterns/IPaymentStrategy.cs`, `Patterns/CashPaymentStrategy.cs`, `Patterns/CreditCardPaymentStrategy.cs`, `Patterns/PaymentContext.cs`

---

## Pattern 4 — Observer

> Decouples checkout logic from housekeeping: when a guest checks out, `RoomSubject` notifies `HousekeepingObserver`, which auto-creates a cleaning task.

```mermaid
classDiagram
    class IObserver {
        <<interface>>
        +Update(roomId, eventType, additionalData) void
    }
    class RoomSubject {
        <<Singleton>>
        -RoomSubject _instance$
        -object _lock$
        -List~IObserver~ _observers
        -RoomSubject()
        +RoomSubject Instance$
        +Attach(observer) void
        +Detach(observer) void
        +Notify(roomId, eventType, additionalData) void
    }
    class HousekeepingObserver {
        +Update(roomId, eventType, additionalData) void
        -CreateCheckOutCleaningTask(roomId, additionalData) void
        -CreateMaintenanceTask(roomId) void
    }
    class MainForm {
        -RoomSubject roomSubject
        +MainForm()
    }
    class BookingListForm {
        +btnCheckOut_Click() void
    }

    IObserver <|.. HousekeepingObserver
    RoomSubject "1" o--> "*" IObserver : _observers
    MainForm --> RoomSubject    : Attach(new HousekeepingObserver())
    BookingListForm --> RoomSubject : Notify(roomId, CheckOut, bookingId)
```

**Files:** `Patterns/IObserver.cs`, `Patterns/RoomSubject.cs`, `Patterns/HousekeepingObserver.cs`

---

## Pattern 5 — Repository

> Separates all SQL data access behind a generic `IRepository<T>` interface; each of the 7 entities has its own repository with both standard CRUD and extended query methods.

```mermaid
classDiagram
    class IRepository~T~ {
        <<interface>>
        +Insert(entity) int
        +GetById(id) T
        +GetAll() List~T~
        +Update(entity) bool
        +Delete(id) bool
    }
    class GuestRepository {
        +Search(searchTerm) List~Guest~
    }
    class RoomRepository {
        +GetAvailableRooms() List~Room~
        +UpdateRoomStatus(id, status) bool
        +GetByRoomNumber(number) Room
    }
    class BookingRepository {
        +GetBookingsByGuest(guestId) List~Booking~
        +GetActiveBookings() List~Booking~
        +CheckIn(bookingId) bool
        +CheckOut(bookingId) bool
        +CancelBooking(bookingId, reason) bool
    }
    class InvoiceRepository {
        +GetByBookingId(bookingId) Invoice
        +GetInvoicesByStatus(status) List~Invoice~
    }
    class PaymentRepository {
        +GetPaymentsByInvoiceId(invoiceId) List~Payment~
        +GetPaymentsByMethod(method) List~Payment~
        +GetPaymentsByDateRange(from, to) List~Payment~
    }
    class UserRepository {
        +Authenticate(username, password) User
        +GetByRole(role) List~User~
        +UpdatePassword(userId, hash, salt) bool
    }
    class HousekeepingTaskRepository {
        +GetTasksByStatus(status) List~HousekeepingTask~
        +GetTasksByRoom(roomId) List~HousekeepingTask~
        +UpdateStatus(taskId, status) bool
    }
    class DatabaseManager {
        <<Singleton>>
        +DatabaseManager Instance$
        +ExecuteQuery(...) DataTable
        +ExecuteNonQuery(...) int
        +ExecuteScalar(...) object
    }

    IRepository~T~ <|.. GuestRepository
    IRepository~T~ <|.. RoomRepository
    IRepository~T~ <|.. BookingRepository
    IRepository~T~ <|.. InvoiceRepository
    IRepository~T~ <|.. PaymentRepository
    IRepository~T~ <|.. UserRepository
    IRepository~T~ <|.. HousekeepingTaskRepository

    GuestRepository            --> DatabaseManager : uses
    RoomRepository             --> DatabaseManager : uses
    BookingRepository          --> DatabaseManager : uses
    InvoiceRepository          --> DatabaseManager : uses
    PaymentRepository          --> DatabaseManager : uses
    UserRepository             --> DatabaseManager : uses
    HousekeepingTaskRepository --> DatabaseManager : uses
```

**Files:** `DAL/IRepository.cs`, `DAL/GuestRepository.cs`, `DAL/RoomRepository.cs`, `DAL/BookingRepository.cs`, `DAL/InvoiceRepository.cs`, `DAL/PaymentRepository.cs`, `DAL/UserRepository.cs`, `DAL/HousekeepingTaskRepository.cs`

---

## Pattern 6 — Facade

> Hides the complexity of coordinating 3 repositories and 8 validation/creation steps behind a single `BookingFacade.CreateBooking()` call.

```mermaid
classDiagram
    class NewBookingForm {
        -BookingFacade _bookingFacade
        +btnCreate_Click() void
    }
    class BookingFacade {
        -GuestRepository _guestRepository
        -RoomRepository _roomRepository
        -BookingRepository _bookingRepository
        +CreateBooking(guestId, roomId, checkIn, checkOut, guests, requests, notes) int
        +CalculateTotalAmount(roomCharges, serviceCharges) decimal
        +IsRoomAvailable(roomId, checkIn, checkOut) bool
        +GetAvailableRooms(checkIn, checkOut) List~Room~
        +ConfirmBooking(bookingId) bool
        +CheckIn(bookingId) bool
        +CheckOut(bookingId) bool
        +CancelBooking(bookingId, reason) bool
    }
    class GuestRepository {
        +GetById(id) Guest
        +GetAll() List~Guest~
    }
    class RoomRepository {
        +GetById(id) Room
        +GetAvailableRooms() List~Room~
        +UpdateRoomStatus(id, status) bool
    }
    class BookingRepository {
        +Insert(booking) int
        +GetById(id) Booking
        +CheckIn(bookingId) bool
        +CheckOut(bookingId) bool
        +CancelBooking(bookingId, reason) bool
    }

    NewBookingForm --> BookingFacade      : CreateBooking()\nCalculateTotalAmount()
    BookingFacade  --> GuestRepository   : validates guest
    BookingFacade  --> RoomRepository    : validates room\nchecks availability\nupdates status
    BookingFacade  --> BookingRepository : creates & manages bookings
```

**Files:** `BLL/BookingFacade.cs`

---

## Summary

| # | Pattern | Intent | Key Files |
|---|---------|--------|-----------|
| 1 | **Singleton** | One shared instance of DB manager & event subject | `DatabaseManager.cs`, `RoomSubject.cs` |
| 2 | **Factory Method** | Centralized, type-safe room object creation | `RoomFactory.cs`, `Room.cs` + subclasses |
| 3 | **Strategy** | Pluggable payment algorithms (Cash / Credit Card) | `IPaymentStrategy.cs`, `PaymentContext.cs` |
| 4 | **Observer** | Event-driven housekeeping on checkout | `IObserver.cs`, `HousekeepingObserver.cs` |
| 5 | **Repository** | Unified data access layer for all 7 entities | `IRepository.cs` + 7 repositories |
| 6 | **Facade** | Simplified booking workflow (8 steps → 1 call) | `BookingFacade.cs` |
