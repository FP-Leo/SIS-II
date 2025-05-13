using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(ProgramSemesterId), nameof(CourseId), IsUnique = true)]
    /// <summary>
    /// Represents a course offering in the system.
    /// </summary>
    public class CourseInstance
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course offering.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the enrollment limit for the course offering.
        /// </summary>
        public int? EnrollmentLimit { get; set; }

        /// <summary>
        /// Gets or sets the delivery method for the course offering (e.g., online, in-person).
        /// </summary>
        public required DeliveryMethod DeliveryMethod { get; set; }

        /// <summary>
        /// Gets or sets the required attendance percentage for the course offering.
        /// </summary>
        public required int AttendancePercentage { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the course associated with this offering.
        /// </summary>
        public required int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the lecturer assignment associated with this offering.
        /// </summary>

        public required int LecturerAssignmentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the program and semester associated with this offering.
        /// </summary>
        public required int ProgramSemesterId { get; set; }

        /// <summary>
        /// Gets or sets the course associated with this offering.
        /// </summary>
        public Course? Course { get; set; }

        /// <summary>
        /// Gets or sets the profile of the lecturer associated with this offering.
        /// </summary>
        public LecturerAssignment? LecturerAssignment { get; set; }

        /// <summary>
        /// Gets or sets the program and semester associated with this offering.
        /// </summary>
        public ProgramSemester? ProgramSemester { get; set; }

        /// <summary>
        /// Gets or sets the list of assessments associated with this course offering.
        /// </summary>
        public List<Assessment>? Assessments { get; set; }

        /// <summary>
        /// Gets or sets the course schedules associated with this course offering.
        /// </summary>
        public List<CourseSchedule>? CourseSchedules { get; set; }

        /// <summary>
        /// Gets or sets the list of student enrollments associated with this course offering.
        /// </summary>
        public List<StudentCourseEnrollment>? StudentEnrollments { get; set; }
    }
}
