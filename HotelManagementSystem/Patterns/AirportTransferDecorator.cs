using HotelManagementSystem.Models;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Decorator that adds a daily airport-transfer shuttle service to any Room.
    /// Adds $25 per night on top of the wrapped room's price.
    /// </summary>
    public class AirportTransferDecorator : RoomDecorator
    {
        public const decimal PRICE_PER_NIGHT = 25m;

        public AirportTransferDecorator(Room room) : base(room) { }

        public override decimal GetPrice()
            => _wrappedRoom.GetPrice() + PRICE_PER_NIGHT;

        public override string GetDescription()
            => _wrappedRoom.GetDescription() + " + Airport Transfer ($25/night)";
    }
}
