using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    /// <summary>
    /// Represents the relationship between a department and its lecturers.
    /// </summary>
    [Index("DepartmentId, LecturerId, StartDate", IsUnique = true)] // To allow to keep records if the lecturer quits and rejoins the department
    public class DepartmentLecturers
    {
        /// <summary>
        /// Gets or sets the unique identifier for the department-lecturer relationship.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the position of the lecturer in the department.
        /// </summary>
        public required string Position { get; set; }

        /// <summary>
        /// Gets or sets the start date of the lecturer's position in the department.
        /// </summary>
        public required DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the lecturer's position in the department, if applicable.
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the total assigned hours for the lecturer in the department.
        /// </summary>
        public required int Hours { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the department.
        /// </summary>
        public required int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the lecturer.
        /// </summary>
        public required string LecturerId { get; set; }

        /// <summary>
        /// Gets or sets the department associated with the lecturer.
        /// </summary>
        public required Department Department { get; set; }

        /// <summary>
        /// Gets or sets the user who is the lecturer.
        /// </summary>
        public required User Lecturer { get; set; }
    }
}
