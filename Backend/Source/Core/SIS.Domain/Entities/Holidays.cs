using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(Name), nameof(AcademicCalendarId), IsUnique = true)]
    /// <summary>
    /// Represents a holiday in the system.
    /// </summary>
    public class Holidays
    {
        /// <summary>
        /// Gets or sets the unique identifier for the holiday.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the holiday.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the holiday.
        /// </summary>
        public required HolidayType Type { get; set; }

        /// <summary>
        /// Gets or sets the description of the holiday.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the date when the holiday starts.
        /// </summary>
        public required DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the holiday ends.
        /// </summary>
        public required DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the academic calendar associated with this holiday.
        /// </summary>
        public required int AcademicCalendarId { get; set; }

        /// <summary>
        /// Gets or sets the academic calendar associated with this holiday.
        /// </summary>
        public AcademicCalendar? AcademicCalendar { get; set; }
    }
}
