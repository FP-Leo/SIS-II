using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(Name), nameof(AcademicCalendarId), IsUnique = true)]
    /// <summary>
    /// Represents an academic event in the system.
    /// </summary>
    public class AcademicSemester
    {
        /// <summary>
        /// Gets or sets the unique identifier for the academic event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the academic event.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the academic event.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the date when the academic event starts.
        /// </summary>
        public required DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the academic event ends.
        /// </summary>
        public required DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the academic event.
        /// </summary>
        public required AcademicEventStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the academic calendar associated with this event.
        /// </summary>
        public required int AcademicCalendarId { get; set; }

        /// <summary>
        /// Gets or sets the academic calendar associated with this event.
        /// </summary>
        public AcademicCalendar? AcademicCalendar { get; set; }

        /// <summary>
        /// Gets or sets the list of registration periods associated with this academic semester.
        /// </summary>
        public List<RegistrationPeriod>? RegistrationPeriods { get; set; }
    }
}
