using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(AcademicYearId), IsUnique = true)]
    /// <summary>
    /// Represents an academic calendar in the system.
    /// </summary>
    public class AcademicCalendar
    {
        /// <summary>
        /// Gets or sets the unique identifier for the academic calendar.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the academic calendar.
        /// </summary>
        public required string Name { get; set; }  // e.g., "2025-2026 Engineering Calendar"

        /// <summary>
        /// Gets or sets the unique identifier for the academic year associated with this calendar.
        /// </summary>
        public required int AcademicYearId { get; set; }

        /// <summary>
        /// Gets or sets the Academic Year associated with this calendar.
        /// </summary>
        public AcademicYear? AcademicYear { get; set; }

        /// <summary>
        /// Gets or sets the events associated with this academic calendar.
        /// </summary>
        public List<AcademicSemester>? Semesters { get; set; }

        /// <summary>
        /// Gets or sets the list of holidays associated with this academic calendar.
        /// </summary>
        public List<Holidays>? Holidays { get; set; }
    }
}
