using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(ProgramEnrollmentId), nameof(CourseInstanceId), IsUnique = true)]
    /// <summary>
    /// Represents a student's enrollment in a course offering.
    /// </summary>
    public class StudentCourseEnrollment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the enrollment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the status of the enrollment (e.g., "Enrolled", "Waitlisted", "Dropped").
        /// </summary>
        public required EnrollmentStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the date the student enrolled in the course offering.
        /// </summary>
        public DateTime? EnrollmentDate { get; set; }

        /// <summary>
        /// Gets or sets the date the student completed the course offering, if applicable.
        /// </summary>
        public DateTime? CompletmentDate { get; set; }

        /// <summary>
        /// Gets or sets the attendance percentage of the student in the course offering
        /// </summary>
        public required int AttendancePercentage { get; set; }

        /// <summary>
        /// Gets or sets the elegibility for makeup exams (e.g., "Eligible", "Not Eligible").
        /// </summary>
        public required bool EledgibleForMakeup { get; set; }

        /// <summary>
        /// Gets or sets the list of assessment IDs associated with the student's enrollment.
        /// </summary>
        public List<int>? AssessmentIds { get; set; }

        /// <summary>
        /// Gets or sets the grade received by the student in the course offering, if applicable.
        /// </summary>
        public float? Grade { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the course instance associated with this enrollment.
        /// </summary>
        public required int CourseInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the student program enrollment associated with this course's enrollment.
        /// </summary>
        public required int ProgramEnrollmentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the course instance associated with this enrollment.
        /// </summary>
        public CourseInstance? CourseInstance { get; set; }

        /// <summary>
        /// Gets or sets the student program enrollment associated with the course's enrollment.
        /// </summary>
        public StudentProgramEnrollment? ProgramEnrollment { get; set; }

        /// <summary>
        /// Gets or sets the list of assessments associated with the student's enrollment.
        /// </summary>
        public List<Assessment>? Assessments { get; set; }
    }
}
