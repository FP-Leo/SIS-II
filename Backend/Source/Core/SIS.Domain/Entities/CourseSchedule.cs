using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(DayOfWeek), nameof(StartTime), nameof(Location), IsUnique = true)]
    /// <summary>
    /// Represents a course schedule in the system.
    /// </summary>
    public class CourseSchedule
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course schedule.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the day of the week for the course schedule (0 = Sunday, 1 = Monday, ..., 6 = Saturday).
        /// </summary>
        public int DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the start time of the course schedule.
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Gets or sets the total hours for the course schedule.
        /// </summary>
        public int TotalHours { get; set; }

        /// <summary>
        /// Gets or sets the location of the course schedule (e.g., "Room 101").
        /// </summary>
        public required string Location { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the course instance associated with this schedule.
        /// </summary>
        public int CourseInstanceId { get; set; }
        /// <summary>
        /// Gets or sets the course instance associated with this schedule.
        /// </summary>
        public CourseInstance? CourseInstance { get; set; }
    }
}
