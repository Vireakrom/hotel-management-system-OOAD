# 🎭 Hotel Management System - Final Demo Script

## 🏁 Phase 1: The "Hook" (Login & MDI)
**Action**: Log in as `admin / Admin123!`.
- **What to say**: "Welcome to the Grand Paradise Hotel Management System. We've implemented a role-based authentication system. As an Admin, I have full access to all modules including Billing and Reports."
- **Point out**: The **Singleton Pattern** ensures our database connection remains stable throughout this entire session.

## 🏢 Phase 2: The Command Center (Room Dashboard)
**Action**: Navigate to **Rooms -> Room Status Dashboard**.
- **What to say**: "This is our real-time command center. Each room is a polymorphic object created via our **Factory Pattern**. You can see at a glance which rooms are Available (Green), Occupied (Red), or being cleaned (Yellow)."
- **Action**: Hover over a room to show the detailed info tooltip.

## 📅 Phase 3: The Booking Workflow (Facade Pattern)
**Action**: Open **Booking -> New Booking**.
- **What to say**: "Let's create a stay for our guest, Sarah Williams. I'll select a Deluxe room for 3 nights."
- **Crucial Moment**: Try to set Check-out to the same day as Check-in.
- **What to say**: "Our system enforces strict business rules—like a minimum 1-night stay—using our centralized **ValidationHelper**." (Show the error message, then fix the date).
- **Action**: Click "Book Now".
- **Point out**: "By using the **Facade Pattern**, we just coordinated three different databases (Guest, Room, and Booking) with a single, simple command."

## 🧹 Phase 4: The Automation (Observer Pattern)
**Action**: Go to **View All Bookings**, select an "Occupied" room, and click **Check-Out**.
- **What to say**: "This is where the magic happens. When I click Check-Out, the **Observer Pattern** triggers. The booking module doesn't know about housekeeping, but a 'Cleaning Task' was just created automatically because the room status changed."
- **Action**: Quickly show **Housekeeping -> View Tasks** to see the new task for that room.

## 💰 Phase 5: The Grand Finale (Strategy Pattern)
**Action**: Open the generated **Invoice** and click **Process Payment**.
- **What to say**: "Finally, we process the payment. We use the **Strategy Pattern** here. Right now, I'll use the **Cash Strategy** to calculate change, but the system can switch to **Credit Card Strategy** instantly to validate card numbers using the Luhn algorithm."
- **Action**: Process the payment and display the **Professional Receipt**.
- **Final Word**: "From creation to payment, every step is guided by clean, object-oriented design."
