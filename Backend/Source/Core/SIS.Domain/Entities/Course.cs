using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(DepartmentId), nameof(Code), IsUnique = true)]
    /// <summary>
    /// Represents a course in the system.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the course.
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// Gets or sets the type of the course (e.g., core, elective).
        /// </summary>
        public CourseType Type { get; set; }

        /// <summary>
        /// Gets or sets the description of the course.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of credits for the course.
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// Gets or sets the level of the course (e.g., undergraduate, graduate).
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the course is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the date when the course was created.
        /// </summary>
        public DateOnly CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date when the course was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the list of student IDs enrolled in this course.
        /// </summary>
        public List<int>? PrerequisiteCourseIds { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the department that offers this course.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the list of prerequisite courses for this course.
        /// </summary>
        public List<Course>? PrerequisiteCourses { get; set; }

        /// <summary>
        /// Gets or sets the department that offers this course.
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Gets or sets the list of course instance associated with this course.
        /// </summary>
        public List<CourseInstance>? CourseInstances { get; set; }
    }
}
