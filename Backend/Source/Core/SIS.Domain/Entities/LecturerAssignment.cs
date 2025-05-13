using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    /// <summary>
    /// Represents the relationship between a department and its lecturers.
    /// </summary>
    [Index(nameof(LecturerProfileId), nameof(DepartmentId), nameof(StartDate), IsUnique = true)] // To allow to keep records if the lecturer quits and rejoins the department
    public class LecturerAssignment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the department-lecturer relationship.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the start date of the lecturer's position in the department.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the lecturer's position in the department, if applicable.
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the total assigned hours for the lecturer in the department.
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the department.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the profile associated with the lecturer.
        /// </summary>
        public int LecturerProfileId { get; set; }

        /// <summary>
        /// Gets or sets the department associated with the lecturer.
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Gets or sets the lecturer profile associated with the lecturer.
        /// </summary>
        public LecturerProfile? LecturerProfile { get; set; }

        /// <summary>
        /// Gets or set the course instances associated with the lecturer.
        /// </summary>
        public List<CourseInstance>? CourseInstances { get; set; }
    }
}
