using HotelManagementSystem.Models;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Decorator that adds a daily breakfast service to any Room.
    /// Adds $15 per night on top of the wrapped room's price.
    /// </summary>
    public class BreakfastDecorator : RoomDecorator
    {
        public const decimal PRICE_PER_NIGHT = 15m;

        public BreakfastDecorator(Room room) : base(room) { }

        public override decimal GetPrice()
            => _wrappedRoom.GetPrice() + PRICE_PER_NIGHT;

        public override string GetDescription()
            => _wrappedRoom.GetDescription() + " + Breakfast Included ($15/night)";
    }
}
