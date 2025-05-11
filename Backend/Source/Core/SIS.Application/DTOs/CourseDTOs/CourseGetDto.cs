using SIS.Domain.Shared;

namespace SIS.Application.DTOs.CourseDTOs
{
    /// <summary>
    /// Represent the data returned when retrieving a course.
    /// </summary>
    public class CourseGetDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the course.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of credits for the course.
        /// </summary>
        public required int Credits { get; set; }

        /// <summary>
        /// Gets or sets the level of the course (e.g., undergraduate, graduate).
        /// </summary>
        public required Level Level { get; set; }

        /// <summary>
        /// Gets or sets the date when the course was created.
        /// </summary>
        public required DateOnly Created { get; set; }

        /// <summary>
        /// Gets or sets the date when the course was last updated.
        /// </summary>
        public required DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the list of student IDs enrolled in this course.
        /// </summary>
        public required List<int> PrerequisiteCourseIds { get; set; } = [];

        /// <summary>
        /// Gets or sets the unique identifier for the department that offers this course.
        /// </summary>
        public required int DepartmentId { get; set; }
    }
}
