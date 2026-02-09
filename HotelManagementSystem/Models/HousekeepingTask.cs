using System;

namespace HotelManagementSystem.Models
{
    /// <summary>
    /// Housekeeping Task Model
    /// Represents a cleaning or maintenance task for a room
    /// </summary>
    public class HousekeepingTask
    {
        public int TaskId { get; set; }
        public int RoomId { get; set; }
        public string TaskType { get; set; } // Cleaning, Maintenance, DeepCleaning
        public string Status { get; set; } // Pending, InProgress, Completed, Cancelled
        public string Description { get; set; }
        public int? AssignedToUserId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Navigation properties (optional - for display purposes)
        public string RoomNumber { get; set; } // Not in DB, populated from join
        public string AssignedToName { get; set; } // Not in DB, populated from join

        /// <summary>
        /// Constructor with default values
        /// </summary>
        public HousekeepingTask()
        {
            Status = "Pending";
            Priority = "Medium";
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Check if task is pending
        /// </summary>
        public bool IsPending()
        {
            return Status == "Pending";
        }

        /// <summary>
        /// Check if task is completed
        /// </summary>
        public bool IsCompleted()
        {
            return Status == "Completed";
        }

        /// <summary>
        /// Check if task is in progress
        /// </summary>
        public bool IsInProgress()
        {
            return Status == "InProgress";
        }

        /// <summary>
        /// Mark task as completed
        /// </summary>
        public void MarkAsCompleted()
        {
            Status = "Completed";
            CompletedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Assign task to a user
        /// </summary>
        public void AssignTo(int userId)
        {
            AssignedToUserId = userId;
            AssignedDate = DateTime.Now;
            Status = "InProgress";
            ModifiedDate = DateTime.Now;
        }
    }
}
