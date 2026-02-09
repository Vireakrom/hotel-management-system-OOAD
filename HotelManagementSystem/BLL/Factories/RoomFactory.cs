using System;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.BLL.Factories
{
    /// <summary>
    /// Factory Pattern: Creates different types of Room objects without exposing instantiation logic
    /// This demonstrates the Factory design pattern for OOAD requirements
    /// </summary>
    public class RoomFactory
    {
        /// <summary>
        /// Creates a Room instance based on the specified room type
        /// </summary>
        /// <param name="roomType">Type of room (Single, Double, Suite, Deluxe)</param>
        /// <returns>Concrete Room implementation</returns>
        /// <exception cref="ArgumentException">Thrown when roomType is invalid</exception>
        public static Room CreateRoom(string roomType)
        {
            if (string.IsNullOrWhiteSpace(roomType))
            {
                throw new ArgumentException("Room type cannot be null or empty", nameof(roomType));
            }

            // Normalize input (trim and convert to proper case)
            roomType = roomType.Trim();

            switch (roomType)
            {
                case "Single":
                    return new SingleRoom
                    {
                        RoomType = "Single",
                        MaxOccupancy = 1
                    };

                case "Double":
                    return new DoubleRoom
                    {
                        RoomType = "Double",
                        MaxOccupancy = 2
                    };

                case "Suite":
                    return new SuiteRoom
                    {
                        RoomType = "Suite",
                        MaxOccupancy = 4
                    };

                case "Deluxe":
                    return new DeluxeRoom
                    {
                        RoomType = "Deluxe",
                        MaxOccupancy = 4
                    };

                default:
                    throw new ArgumentException(
                        $"Invalid room type: '{roomType}'. Valid types are: Single, Double, Suite, Deluxe",
                        nameof(roomType));
            }
        }

        /// <summary>
        /// Creates a fully configured Room instance with all properties
        /// </summary>
        /// <param name="roomType">Type of room</param>
        /// <param name="roomNumber">Room number</param>
        /// <param name="floorNumber">Floor number</param>
        /// <param name="basePrice">Base price per night</param>
        /// <param name="status">Room status (default: Available)</param>
        /// <returns>Fully configured Room object</returns>
        public static Room CreateRoom(
            string roomType,
            string roomNumber,
            int floorNumber,
            decimal basePrice,
            string status = "Available")
        {
            // Use the basic factory method to create the correct type
            Room room = CreateRoom(roomType);

            // Configure common properties
            room.RoomNumber = roomNumber;
            room.FloorNumber = floorNumber;
            room.BasePrice = basePrice;
            room.Status = status;
            room.CreatedDate = DateTime.Now;
            room.ModifiedDate = DateTime.Now;

            // Set type-specific defaults
            ConfigureRoomDefaults(room);

            return room;
        }

        /// <summary>
        /// Creates a Room instance from database values (used by RoomRepository)
        /// </summary>
        public static Room CreateRoomFromDatabase(
            string roomType,
            int roomId,
            string roomNumber,
            int floorNumber,
            decimal basePrice,
            string status,
            int maxOccupancy,
            string bedType = null,
            decimal? area = null,
            string viewType = null,
            string description = null,
            string amenities = null,
            bool hasBalcony = false,
            bool hasSeaView = false,
            bool hasJacuzzi = false,
            bool hasPrivatePool = false,
            DateTime? createdDate = null,
            DateTime? modifiedDate = null)
        {
            // Create base room using factory
            Room room = CreateRoom(roomType);

            // Set all properties from database
            room.RoomId = roomId;
            room.RoomNumber = roomNumber;
            room.FloorNumber = floorNumber;
            room.BasePrice = basePrice;
            room.Status = status;
            room.MaxOccupancy = maxOccupancy;
            room.BedType = bedType;
            room.Area = area;
            room.ViewType = viewType;
            room.Description = description;
            room.Amenities = amenities;
            room.HasBalcony = hasBalcony;
            room.HasSeaView = hasSeaView;
            room.HasJacuzzi = hasJacuzzi;
            room.HasPrivatePool = hasPrivatePool;
            room.CreatedDate = createdDate ?? DateTime.Now;
            room.ModifiedDate = modifiedDate ?? DateTime.Now;

            return room;
        }

        /// <summary>
        /// Configures default values based on room type
        /// </summary>
        private static void ConfigureRoomDefaults(Room room)
        {
            switch (room.RoomType)
            {
                case "Single":
                    room.BedType = room.BedType ?? "Single";
                    room.Area = room.Area ?? 20.0m;
                    room.MaxOccupancy = 1;
                    room.Description = room.Description ?? "Cozy single room perfect for solo travelers";
                    break;

                case "Double":
                    room.BedType = room.BedType ?? "Queen";
                    room.Area = room.Area ?? 30.0m;
                    room.MaxOccupancy = 2;
                    room.Description = room.Description ?? "Comfortable double room for couples or friends";
                    break;

                case "Suite":
                    room.BedType = room.BedType ?? "King";
                    room.Area = room.Area ?? 50.0m;
                    room.MaxOccupancy = 4;
                    room.HasBalcony = true;
                    room.Description = room.Description ?? "Luxurious suite with separate living area";
                    break;

                case "Deluxe":
                    room.BedType = room.BedType ?? "King";
                    room.Area = room.Area ?? 70.0m;
                    room.MaxOccupancy = 4;
                    room.HasBalcony = true;
                    room.HasJacuzzi = true;
                    room.Description = room.Description ?? "Premium deluxe room with exclusive amenities";
                    break;
            }
        }

        /// <summary>
        /// Gets default base price for a room type
        /// </summary>
        public static decimal GetDefaultPrice(string roomType)
        {
            switch (roomType)
            {
                case "Single":
                    return 50.00m;
                case "Double":
                    return 80.00m;
                case "Suite":
                    return 150.00m;
                case "Deluxe":
                    return 250.00m;
                default:
                    throw new ArgumentException($"Invalid room type: {roomType}");
            }
        }

        /// <summary>
        /// Gets all valid room types
        /// </summary>
        public static string[] GetValidRoomTypes()
        {
            return new string[] { "Single", "Double", "Suite", "Deluxe" };
        }

        /// <summary>
        /// Validates if a room type is valid
        /// </summary>
        public static bool IsValidRoomType(string roomType)
        {
            if (string.IsNullOrWhiteSpace(roomType))
                return false;

            roomType = roomType.Trim();
            return roomType == "Single" || roomType == "Double" || 
                   roomType == "Suite" || roomType == "Deluxe";
        }
    }
}
