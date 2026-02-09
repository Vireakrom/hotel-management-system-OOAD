namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Observer Pattern Interface
    /// Defines the contract for observers that need to be notified of changes
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Update method called when the subject's state changes
        /// </summary>
        /// <param name="roomId">ID of the room that triggered the notification</param>
        /// <param name="eventType">Type of event (e.g., "CheckOut")</param>
        /// <param name="additionalData">Any additional data related to the event</param>
        void Update(int roomId, string eventType, object additionalData = null);
    }
}
