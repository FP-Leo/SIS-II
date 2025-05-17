using SIS.Domain.Shared;

namespace SIS.Application.DTOs.StudentCourseEnrollmentDTOs
{
    /// <summary>
    /// Represents a data transfer object for patching a student's enrollment in a course offering.
    /// </summary>
    public class StudentCourseEnrollmentPatchDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the enrollment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the status of the enrollment (e.g., "Enrolled", "Dropped").
        /// </summary>
        public EnrollmentStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the date the student completed the course offering, if applicable.
        /// </summary>
        public DateTime? CompletionDate { get; set; }

        /// <summary>
        /// Gets or sets the attendance percentage of the student in the course offering
        /// </summary>
        public int? AttendancePercentage { get; set; }
    }
}
