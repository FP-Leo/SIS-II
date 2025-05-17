using SIS.Domain.Shared;

namespace SIS.Application.DTOs.StudentCourseEnrollmentDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for retrieving Student Course Enrollment information.
    /// </summary>
    public class StudentCourseEnrollmentGetDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the enrollment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the status of the enrollment (e.g., "Enrolled", "Dropped").
        /// </summary>
        public EnrollmentStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the date the student enrolled in the course offering.
        /// </summary>
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Gets or sets the date the student completed the course offering, if applicable.
        /// </summary>
        public DateTime? CompletionDate { get; set; }

        /// <summary>
        /// Gets or sets the attendance percentage of the student in the course offering
        /// </summary>
        public int? AttendancePercentage { get; set; }

        /// <summary>
        /// Gets or sets the elegibility for makeup exams (e.g., "Eligible", "Not Eligible").
        /// </summary>
        public bool? EledgibleForMakeup { get; set; }

        /// <summary>
        /// Gets or sets the grade received by the student in the course offering, if applicable.
        /// </summary>
        public float? Grade { get; set; }

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
