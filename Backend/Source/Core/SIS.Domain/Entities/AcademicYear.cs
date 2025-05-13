using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    /// <summary>
    /// Represents an academic year in the system.
    /// </summary>
    [Index(nameof(Name), nameof(UniversityId), IsUnique=true)]
    public class AcademicYear
    {
        /// <summary>
        /// Gets or sets the unique identifier for the academic year.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the academic year.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the start date of the academic year.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the academic year.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the academic year was created.
        /// </summary>
        public int UniversityId { get; set; }

        /// <summary>
        /// Gets or sets the university associated with this academic year.
        /// </summary>

        public University? University { get; set; }

        /// <summary>
        /// Gets or sets the list of academic calendars associated with this academic year.
        /// </summary>

        public List<AcademicCalendar>? Calendars { get; set; }
    }
}
