using System.Collections.Generic;

namespace HotelManagementSystem.Patterns
{
    /// <summary>
    /// Observer Pattern - Subject (Observable)
    /// RoomSubject maintains a list of observers and notifies them of room events
    /// </summary>
    public class RoomSubject
    {
        // Singleton instance
        private static RoomSubject _instance;
        private static readonly object _lock = new object();

        // List of observers
        private List<IObserver> _observers;

        /// <summary>
        /// Private constructor for Singleton pattern
        /// </summary>
        private RoomSubject()
        {
            _observers = new List<IObserver>();
        }

        /// <summary>
        /// Get the singleton instance of RoomSubject
        /// </summary>
        public static RoomSubject Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RoomSubject();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Attach an observer to receive notifications
        /// </summary>
        /// <param name="observer">Observer to attach</param>
        public void Attach(IObserver observer)
        {
            if (observer != null && !_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        /// <summary>
        /// Detach an observer from receiving notifications
        /// </summary>
        /// <param name="observer">Observer to detach</param>
        public void Detach(IObserver observer)
        {
            if (observer != null && _observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        /// <summary>
        /// Notify all observers of a room event
        /// </summary>
        /// <param name="roomId">ID of the room</param>
        /// <param name="eventType">Type of event (e.g., "CheckOut", "CheckIn", "StatusChange")</param>
        /// <param name="additionalData">Additional data to pass to observers</param>
        public void Notify(int roomId, string eventType, object additionalData = null)
        {
            foreach (var observer in _observers)
            {
                observer.Update(roomId, eventType, additionalData);
            }
        }

        /// <summary>
        /// Get count of registered observers
        /// </summary>
        public int ObserverCount
        {
            get { return _observers.Count; }
        }

        /// <summary>
        /// Clear all observers (useful for testing)
        /// </summary>
        public void ClearObservers()
        {
            _observers.Clear();
        }
    }
}
