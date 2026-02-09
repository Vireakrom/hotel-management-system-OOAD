using System;
using System.Text;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.BLL.Factories
{
    /// <summary>
    /// Demonstrates the Factory Pattern implementation
    /// Shows how different room types are created without exposing instantiation logic
    /// </summary>
    public class FactoryPatternDemo
    {
        /// <summary>
        /// Runs a comprehensive demonstration of the Factory Pattern
        /// </summary>
        /// <returns>HTML-formatted demonstration output</returns>
        public static string RunDemonstration()
        {
            StringBuilder output = new StringBuilder();
            
            output.AppendLine("=".PadRight(80, '='));
            output.AppendLine("FACTORY PATTERN DEMONSTRATION");
            output.AppendLine("Design Pattern #3 of 5");
            output.AppendLine("=".PadRight(80, '='));
            output.AppendLine();

            // Demo 1: Basic factory usage
            output.AppendLine("--- Demo 1: Basic Room Creation ---");
            output.AppendLine();
            
            try
            {
                Room singleRoom = RoomFactory.CreateRoom("Single");
                output.AppendLine($"? Created: {singleRoom.GetType().Name}");
                output.AppendLine($"  Type: {singleRoom.RoomType}, Max Occupancy: {singleRoom.MaxOccupancy}");
                output.AppendLine();

                Room doubleRoom = RoomFactory.CreateRoom("Double");
                output.AppendLine($"? Created: {doubleRoom.GetType().Name}");
                output.AppendLine($"  Type: {doubleRoom.RoomType}, Max Occupancy: {doubleRoom.MaxOccupancy}");
                output.AppendLine();

                Room suiteRoom = RoomFactory.CreateRoom("Suite");
                output.AppendLine($"? Created: {suiteRoom.GetType().Name}");
                output.AppendLine($"  Type: {suiteRoom.RoomType}, Max Occupancy: {suiteRoom.MaxOccupancy}");
                output.AppendLine();

                Room deluxeRoom = RoomFactory.CreateRoom("Deluxe");
                output.AppendLine($"? Created: {deluxeRoom.GetType().Name}");
                output.AppendLine($"  Type: {deluxeRoom.RoomType}, Max Occupancy: {deluxeRoom.MaxOccupancy}");
                output.AppendLine();
            }
            catch (Exception ex)
            {
                output.AppendLine($"? Error: {ex.Message}");
                output.AppendLine();
            }

            // Demo 2: Fully configured rooms
            output.AppendLine("--- Demo 2: Fully Configured Room Creation ---");
            output.AppendLine();

            try
            {
                Room room101 = RoomFactory.CreateRoom("Single", "101", 1, 50.00m);
                output.AppendLine($"? Created Room {room101.RoomNumber}:");
                output.AppendLine($"  Type: {room101.RoomType}");
                output.AppendLine($"  Floor: {room101.FloorNumber}");
                output.AppendLine($"  Price: ${room101.BasePrice}/night");
                output.AppendLine($"  Status: {room101.Status}");
                output.AppendLine($"  Description: {room101.Description}");
                output.AppendLine();

                Room room301 = RoomFactory.CreateRoom("Suite", "301", 3, 150.00m);
                output.AppendLine($"? Created Room {room301.RoomNumber}:");
                output.AppendLine($"  Type: {room301.RoomType}");
                output.AppendLine($"  Floor: {room301.FloorNumber}");
                output.AppendLine($"  Price: ${room301.BasePrice}/night");
                output.AppendLine($"  Has Balcony: {room301.HasBalcony}");
                output.AppendLine($"  Description: {room301.Description}");
                output.AppendLine();
            }
            catch (Exception ex)
            {
                output.AppendLine($"? Error: {ex.Message}");
                output.AppendLine();
            }

            // Demo 3: Error handling
            output.AppendLine("--- Demo 3: Error Handling ---");
            output.AppendLine();

            try
            {
                Room invalidRoom = RoomFactory.CreateRoom("PenthouseSuite");
                output.AppendLine($"? This should not appear!");
            }
            catch (ArgumentException ex)
            {
                output.AppendLine($"? Correctly caught invalid room type:");
                output.AppendLine($"  Message: {ex.Message}");
                output.AppendLine();
            }

            // Demo 4: Helper methods
            output.AppendLine("--- Demo 4: Factory Helper Methods ---");
            output.AppendLine();

            output.AppendLine("Valid Room Types:");
            foreach (string roomType in RoomFactory.GetValidRoomTypes())
            {
                decimal price = RoomFactory.GetDefaultPrice(roomType);
                bool isValid = RoomFactory.IsValidRoomType(roomType);
                output.AppendLine($"  • {roomType}: ${price}/night (Valid: {isValid})");
            }
            output.AppendLine();

            // Demo 5: Polymorphism
            output.AppendLine("--- Demo 5: Polymorphism in Action ---");
            output.AppendLine();
            output.AppendLine("All rooms inherit from abstract Room base class:");
            output.AppendLine();

            Room[] rooms = new Room[]
            {
                RoomFactory.CreateRoom("Single"),
                RoomFactory.CreateRoom("Double"),
                RoomFactory.CreateRoom("Suite"),
                RoomFactory.CreateRoom("Deluxe")
            };

            foreach (Room room in rooms)
            {
                output.AppendLine($"  {room.GetType().Name}:");
                output.AppendLine($"    GetPrice(): ${room.GetPrice()}");
                output.AppendLine($"    GetDescription(): {room.GetDescription()}");
                output.AppendLine();
            }

            // Summary
            output.AppendLine("=".PadRight(80, '='));
            output.AppendLine("FACTORY PATTERN BENEFITS:");
            output.AppendLine("=".PadRight(80, '='));
            output.AppendLine("? Encapsulates object creation logic");
            output.AppendLine("? Client code doesn't need to know concrete classes");
            output.AppendLine("? Easy to add new room types without changing client code");
            output.AppendLine("? Promotes loose coupling");
            output.AppendLine("? Single Responsibility Principle - creation logic in one place");
            output.AppendLine("=".PadRight(80, '='));

            return output.ToString();
        }

        /// <summary>
        /// Shows before/after comparison of Factory Pattern
        /// </summary>
        public static string ShowBeforeAfterComparison()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("=== BEFORE FACTORY PATTERN ===");
            output.AppendLine(@"
// Client code needs to know all concrete classes
Room room;
if (roomType == ""Single"")
    room = new SingleRoom();
else if (roomType == ""Double"")
    room = new DoubleRoom();
else if (roomType == ""Suite"")
    room = new SuiteRoom();
else
    room = new DeluxeRoom();

// Problem: Client is tightly coupled to concrete classes
");

            output.AppendLine("=== AFTER FACTORY PATTERN ===");
            output.AppendLine(@"
// Client code is simple and clean
Room room = RoomFactory.CreateRoom(roomType);

// Benefits:
// ? Client doesn't need to know concrete classes
// ? Creation logic centralized in factory
// ? Easy to modify without affecting clients
");

            return output.ToString();
        }
    }
}
