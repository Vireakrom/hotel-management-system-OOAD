# Hotel Management System Demo Script

## Demo Goal

This demo shows how the Hotel Management System supports the full hotel workflow:

`Login -> Room and guest management -> Booking -> Check-out -> Invoice -> Payment -> Housekeeping -> Reporting`

It also highlights the core design patterns used in the project:

- Singleton
- Repository
- Factory
- Facade
- Strategy
- Observer
- Decorator

---

## Demo Length

- Full demo: 8 to 10 minutes
- Short demo: 4 to 5 minutes

---

## Pre-Demo Checklist

Before starting the presentation, make sure:

1. The database has been created by running `HotelManagementSystem/Context/database.sql`.
2. The application can connect to SQL Server.
3. You can log in with:
   - Username: `admin`
   - Password: `Admin123!`
4. Sample rooms, guests, and bookings are visible.
5. If you want to demonstrate different role views, create working `Manager`, `Receptionist`, and `Housekeeping` users first from Staff Management.

> Note: in the seed SQL, only the `admin` login is clearly usable by default. The sample `manager1`, `receptionist1`, and `housekeeping1` rows use placeholder hashes.

---

## Demo Scenario

Use this story during the presentation:

"Today I will demonstrate a hotel staff workflow using our Hotel Management System. I will log in as an administrator, show role-based access, manage hotel data, create or review a booking, complete check-out, process payment, and show how housekeeping is triggered automatically after checkout."

---

## Full Demo Script

## 1. Introduction

### What to say

"This project is a desktop Hotel Management System built with C# Windows Forms and SQL Server using a 3-layer architecture: UI, Business Logic Layer, and Data Access Layer."

"The system helps hotel staff manage rooms, guests, bookings, billing, payments, housekeeping, staff accounts, and daily reports in one application."

"A key objective of this project is not only functionality, but also applying object-oriented design patterns to solve real business problems."

### What to show

- Start the application.
- Pause at the login screen.

---

## 2. Login and Authentication

### What to say

"This is the login form. It supports secure authentication using hashed passwords with salt, and the authenticated user is stored in the session manager after login."

"The system currently supports four roles: Admin, Manager, Receptionist, and Housekeeping."

### What to show

- Enter:
  - Username: `admin`
  - Password: `Admin123!`
- Optionally point to the `Remember Me` checkbox.
- Click login.

### Design pattern / technical point

"The authentication data is handled through the `UserRepository`, while the current signed-in user is stored in `SessionManager.CurrentUser`."

---

## 3. Main Dashboard and Role-Based Access

### What to say

"After login, the system opens the main MDI form, which acts as the central navigation hub."

"Different roles see different features. For example, Admin has full access, Manager can see reports but not housekeeping tasks, Receptionist focuses on guests and bookings, and Housekeeping mainly sees task-related functionality."

### What to show

- Point to the menu bar.
- Point to the status bar showing current user and role.
- Mention that role-based visibility changes depending on login role.

### Design pattern / technical point

"This is where role-based access control is applied based on the logged-in user's role."

---

## 4. Room Management

### What to say

"Next, I will show room management. The hotel supports four room types: Single, Double, Suite, and Deluxe."

"These room types are created using the Factory pattern, which centralizes room creation and default configuration."

### What to show

- Open Room Management.
- Open the Room Status Dashboard if useful.
- Show a few sample rooms like `101`, `201`, `301`, and `401`.
- Mention statuses such as Available, Occupied, Reserved, Cleaning, and Maintenance.

### Design pattern / technical point

"The Factory pattern is useful here because each room type has different defaults like bed type, area, occupancy, and price."

---

## 5. Guest Management

### What to say

"The guest management module allows staff to register, edit, search, and review guest records."

"This improves data organization and reduces the errors common in manual record keeping."

### What to show

- Open Guest Management.
- Search for an existing sample guest.
- Optionally open the add guest form and explain the input fields.

### Design pattern / technical point

"Guest data is accessed through the Repository pattern, which keeps database logic separate from the UI."

---

## 6. Booking Workflow

### What to say

"Now I will demonstrate the booking workflow, which is one of the core parts of the system."

"Creating a booking involves validation, room availability checking, pricing, and status updates. To simplify all of that, the system uses a Facade pattern through `BookingFacade`."

### What to show

Choose one of these two options:

1. Open `New Booking` and create a new reservation.
2. Open `Booking List` and explain an existing sample booking.

If creating a new booking:

- Select a guest.
- Select an available room.
- Choose check-in and check-out dates.
- Mention that the system prevents invalid date ranges and room conflicts.

### Decorator point

"This form also supports optional services such as Breakfast, Extra Bed, and Airport Transfer. These are implemented with the Decorator pattern, so services can be added dynamically without changing the base room classes."

### What to show

- If available, toggle add-on services.
- Point out that total price updates automatically.

---

## 7. Check-In and Check-Out

### What to say

"After a booking is confirmed and the guest checks in, the booking status changes through the booking lifecycle."

"When the guest checks out, the system automatically updates the room, generates an invoice, and notifies housekeeping."

### What to show

- Open Booking List.
- Select a booking that is `CheckedIn`, or explain one already in that state.
- Perform check-out if safe for your demo database.

### Design pattern / technical point

"This is where the Observer pattern appears. After check-out, `RoomSubject` notifies `HousekeepingObserver`, and the system automatically creates a housekeeping task."

---

## 8. Invoice and Payment

### What to say

"Once checkout is complete, the system generates an invoice and allows payment processing."

"For payments, the system uses the Strategy pattern. Cash and credit card payments use different processing logic, but the UI can switch between them without changing the overall workflow."

### What to show

- Open Invoice Management.
- Open an invoice.
- Click Process Payment.
- Show both payment modes:
  - Cash
  - Credit Card

If processing live:

- Use cash for the safest demo.
- Show payment amount, amount received, and automatic change calculation.

### Design pattern / technical point

"Cash and credit card payments are different strategies selected at runtime. This makes the system easy to extend with new payment methods later."

---

## 9. Receipt Generation

### What to say

"After a successful payment, the system displays a professional receipt."

"This provides a better user experience for hotel staff and customers and gives a clear record of the transaction."

### What to show

- Show the receipt form.
- Point out:
  - Guest information
  - Booking information
  - Financial breakdown
  - Payment details

---

## 10. Housekeeping Automation

### What to say

"One of the most useful automated features in this system is housekeeping task generation."

"When checkout happens, a cleaning task is created automatically and assigned using the least-busy staff logic."

### What to show

- Open Housekeeping Tasks.
- Show the newly created or existing task.
- Point out task fields such as room, priority, status, and assigned staff.

### Design pattern / technical point

"This demonstrates loose coupling. The booking module does not need to directly manage housekeeping logic because the Observer pattern handles the communication."

---

## 11. Staff Management and Roles

### What to say

"The system also supports staff account management. Admin users can create and maintain user accounts and assign roles."

"The four supported roles are Admin, Manager, Receptionist, and Housekeeping."

### What to show

- Open Staff Management.
- Show the role column or role selection.
- If you prepared accounts in advance, mention that logging in with a different role changes available modules.

---

## 12. Reporting

### What to say

"Finally, the reporting module provides a daily operations overview, including room and revenue-related information."

"This helps management monitor hotel performance and daily activity."

### What to show

- Open Daily Operations Report.
- Briefly explain what the report summarizes.

---

## 13. Design Pattern Summary

### What to say

"This project demonstrates seven design patterns in a practical way."

"Singleton is used for shared system-wide resources, Repository for clean data access, Factory for room creation, Facade for booking workflow, Strategy for payment processing, Observer for housekeeping automation, and Decorator for optional room services."

"These patterns improve maintainability, flexibility, scalability, and separation of concerns."

---

## 14. Closing

### What to say

"In conclusion, this Hotel Management System digitalizes the full hotel workflow from login to booking, billing, payment, housekeeping, and reporting."

"The project not only solves a real business problem, but also demonstrates strong object-oriented analysis and design through layered architecture and multiple design patterns."

"Thank you. I am ready for questions."

---

## Short Demo Version

If you only have 4 to 5 minutes, use this order:

1. Login as `admin`
2. Show role-based main screen
3. Open Room Dashboard
4. Open Booking List
5. Explain check-out -> invoice -> housekeeping automation
6. Open Payment Form and mention Strategy pattern
7. Open Housekeeping Tasks
8. End with design pattern summary

---

## Backup Talking Points

Use these if a live action fails during the demo:

- "Even if I do not execute the full transaction right now, the workflow is already implemented in the system and follows this sequence: booking, checkout, invoice generation, payment, then housekeeping notification."
- "The role-based behavior is implemented in the main form by hiding or showing modules depending on the logged-in role."
- "The project database already includes sample rooms, guests, and bookings for demonstration."
- "For a fresh database, the default guaranteed login is `admin / Admin123!`."

