using SIS.Domain.Shared;

namespace SIS.Application.DTOs.CourseDTOs
{
    /// <summary>
    /// Represents the data transfer object when patching a course.
    /// </summary>
    public class CoursePatchDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the course.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the number of credits for the course.
        /// </summary>
        public int? Credits { get; set; }

        /// <summary>
        /// Gets or sets the level of the course (e.g., undergraduate, graduate).
        /// </summary>
        public Level? Level { get; set; }

        /// <summary>
        /// Gets or sets the list of student IDs enrolled in this course.
        /// </summary>
        public List<int>? PrerequisiteCourseIds { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the department that offers this course.
        /// </summary>
        public int? DepartmentId { get; set; }
    }
}
