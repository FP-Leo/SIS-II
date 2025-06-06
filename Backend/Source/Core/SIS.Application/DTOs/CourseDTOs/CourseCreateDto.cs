﻿using SIS.Domain.Shared;

namespace SIS.Application.DTOs.CourseDTOs
{
    /// <summary>
    /// Represent the data transfer object when creating a department.
    /// </summary>
    public class CourseCreateDto
    {
        /// <summary>
        /// Gets or sets the name for the course.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the code for the course.
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// Gets or sets the type of the course (e.g., core, elective).
        /// </summary>
        public required CourseType Type { get; set; }

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
        /// Gets or sets a value indicating whether the course is active.
        /// </summary>
        public required bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the list of student IDs enrolled in this course.
        /// </summary>
        public required List<int>? PrerequisiteCourseIds { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the department that offers this course.
        /// </summary>
        public required int DepartmentId { get; set; }
    }
}
