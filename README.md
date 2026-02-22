# 🏨 Hotel Management System (HMS) - OOAD Project

## 🌟 Overview
This is a comprehensive Hotel Management System developed as a final project for Object-Oriented Analysis and Design (OOAD). It handles everything from room and guest management to complex booking workflows, automated housekeeping tasks, and multi-method payment processing.

---

## 🏗️ Technical Architecture
- **Language**: C# (.NET Framework 4.8)
- **UI Framework**: Windows Forms (MDI Architecture)
- **Database**: Microsoft SQL Server
- **Design Methodology**: 3-Layer Architecture (DAL, BLL, UI)

---

## 🧩 Design Patterns Implemented (Core Requirements)

This project demonstrates proficiency in OOAD by implementing **6 major design patterns**:

### 1. Singleton Pattern 🔒
*   **Implementation**: `DAL.DatabaseManager` and `Patterns.RoomSubject`.
*   **Purpose**: Ensures only one instance of the database connection provider and the global event subject exists, preventing resource leaks and ensuring global state consistency.

### 2. Repository Pattern 📁
*   **Implementation**: `DAL.RoomRepository`, `DAL.GuestRepository`, `DAL.BookingRepository`, etc.
*   **Purpose**: Decouples the business logic from the data access logic. It provides a clean, collection-like interface for accessing domain objects.

### 3. Factory Pattern 🏭
*   **Implementation**: `Models.RoomFactory`.
*   **Purpose**: Encapsulates the instantiation logic for different room types (`Single`, `Double`, `Suite`, `Deluxe`). The UI doesn't need to know *how* to create a Suite; it just asks the Factory.

### 4. Facade Pattern 🏛️
*   **Implementation**: `BLL.BookingFacade`.
*   **Purpose**: Provides a simplified, high-level interface to the complex booking process which involves coordinating multiple repositories (Guest, Room, Booking) and validating business rules.

### 5. Observer Pattern 👁️
*   **Implementation**: `Patterns.RoomSubject` (Subject) and `Patterns.HousekeepingObserver` (Observer).
*   **Purpose**: Implements loose coupling for automated tasks. When a guest checks out, the `RoomSubject` notifies all observers, and the `HousekeepingObserver` automatically creates a cleaning task without the Booking module knowing it exists.

### 6. Strategy Pattern 🎯
*   **Implementation**: `Patterns.IPaymentStrategy`, `CashPaymentStrategy`, `CreditCardPaymentStrategy`.
*   **Purpose**: Allows the application to switch between different payment algorithms at runtime. New payment methods (like PayPal or Crypto) can be added by simply creating a new strategy class without changing the existing `PaymentForm` logic.

---

## 🚀 Key Features

### 🏨 Room Management
- Visual Room Status Dashboard with real-time color coding.
- Dynamic pricing logic (Sea view premiums, floor-based pricing).
- Comprehensive CRUD operations for room configuration.

### 📅 Booking & Check-In/Out
- Smart availability checking (prevents double booking).
- **Strict Validation**: Enforced 1-night minimum stay policy.
- Automated Invoice generation upon Check-Out.

### 💳 Billing & Payments
- Support for Partial Payments.
- Automated tax calculations (10% GST).
- Professional Receipt generation with card number masking for security.

### 🧹 Housekeeping
- Automated task creation triggered by the **Observer Pattern**.
- Task tracking dashboard for staff.

---

## 🛠️ Setup Instructions
1.  **Database**: Run the `Context/database.sql` script in SQL Server Management Studio.
2.  **Configuration**: Update the connection string in `App.config` to point to your local SQL instance.
3.  **Credentials**: 
    - **Username**: `admin`
    - **Password**: `Admin123!`

---

## 👨‍💻 Project Details
- **Developer**: Vireak (Year 4 CS Student, RUPP)
- **Status**: Day 33 Complete - Documentation Finalized.
- **Completion Date**: March 2026
