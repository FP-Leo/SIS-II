namespace SIS.Application.DTOs.StudentCourseEnrollmentDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new Student Course Enrollment.
    /// </summary>
    public class StudentCourseEnrollmentCreateDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the enrollment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the course instance associated with this enrollment.
        /// </summary>
        public int CourseInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the student program enrollment associated with this course's enrollment.
        /// </summary>
        public int ProgramEnrollmentId { get; set; }
    }
}
