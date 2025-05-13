using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(ProgramId), nameof(SemesterId), IsUnique = true)]
    /// <summary>
    /// Represents the association between an academic program and a semester in the system.
    /// </summary>
    public class ProgramSemester
    {
        /// <summary>
        /// Gets or sets the unique identifier for the program semester.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the number of core courses in this semester.
        /// </summary>
        public int NumberOfCoreCourses { get; set; }

        /// <summary>
        /// Gets or sets the number of elective courses in this semester.
        /// </summary>
        public int NumberOfElectiveCourses { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the program associated with this semester.
        /// </summary>
        public int ProgramId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the semester associated with this program.
        /// </summary>
        public int SemesterId { get; set; }

        /// <summary>
        /// Gets or sets the program associated with this semester.
        /// </summary>
        public AcademicProgram? Program { get; set; }

        /// <summary>
        /// Gets or sets the semester associated with this program.
        /// </summary>
        public AcademicSemester? Semester { get; set; }

        /// <summary>
        /// Gets or sets the list of course instances associated with this academic semester.
        /// </summary>
        public List<CourseInstance>? CourseInstances { get; set; }
    }
}
