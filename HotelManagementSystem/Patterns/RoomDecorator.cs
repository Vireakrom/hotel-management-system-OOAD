using HotelManagementSystem.Models;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Abstract base Decorator for Room — implements Design Pattern #5 (Decorator Pattern).
    /// Wraps any Room object and delegates all calls to the inner room,
    /// allowing concrete decorators to add extra price and description without
    /// modifying or subclassing the concrete room types.
    /// </summary>
    public abstract class RoomDecorator : Room
    {
        protected readonly Room _wrappedRoom;

        protected RoomDecorator(Room room)
        {
            _wrappedRoom = room;

            // Mirror every property so this decorator is transparent to the rest of the system
            RoomId        = room.RoomId;
            RoomNumber    = room.RoomNumber;
            RoomType      = room.RoomType;
            Status        = room.Status;
            BasePrice     = room.BasePrice;
            FloorNumber   = room.FloorNumber;
            MaxOccupancy  = room.MaxOccupancy;
            BedType       = room.BedType;
            Area          = room.Area;
            ViewType      = room.ViewType;
            HasBalcony    = room.HasBalcony;
            HasSeaView    = room.HasSeaView;
            HasJacuzzi    = room.HasJacuzzi;
            HasPrivatePool = room.HasPrivatePool;
            Amenities     = room.Amenities;
            Description   = room.Description;
            CreatedDate   = room.CreatedDate;
            ModifiedDate  = room.ModifiedDate;
        }

        /// <summary>
        /// Returns the wrapped room's per-night price.
        /// Concrete decorators override this to add their surcharge.
        /// </summary>
        public override decimal GetPrice() => _wrappedRoom.GetPrice();

        /// <summary>
        /// Returns the wrapped room's description.
        /// Concrete decorators append their service label.
        /// </summary>
        public override string GetDescription() => _wrappedRoom.GetDescription();
    }
}
