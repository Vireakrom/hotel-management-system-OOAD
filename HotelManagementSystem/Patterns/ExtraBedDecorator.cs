using HotelManagementSystem.Models;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Decorator that adds an extra bed service to any Room.
    /// Adds $30 per night on top of the wrapped room's price.
    /// </summary>
    public class ExtraBedDecorator : RoomDecorator
    {
        public const decimal PRICE_PER_NIGHT = 30m;

        public ExtraBedDecorator(Room room) : base(room) { }

        public override decimal GetPrice()
            => _wrappedRoom.GetPrice() + PRICE_PER_NIGHT;

        public override string GetDescription()
            => _wrappedRoom.GetDescription() + " + Extra Bed ($30/night)";
    }
}
