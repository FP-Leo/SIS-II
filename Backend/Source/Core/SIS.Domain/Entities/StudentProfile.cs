using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index("StudentId", IsUnique = true)]
    [Index("Type", "UserId", IsUnique = true)]
    /// <summary>
    /// Represents the profile of a student in the system.
    /// </summary>
    public class StudentProfile
    {
        /// <summary>
        /// Gets or sets the unique identifier for the student profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the student ID specific to the department.
        /// </summary>
        public required int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the type of the student (e.g., "Undergraduate", "Graduate").
        /// </summary>
        public required String Type { get; set; }

        /// <summary>
        /// Gets or sets the status of the student (e.g., "Active", "Graduated").
        /// </summary>
        public required String Status { get; set; }

        /// <summary>
        /// Gets or sets the year of the student.
        /// </summary>
        public required int Year { get; set; }

        /// <summary>
        /// Gets or sets the GPA of the student.
        /// </summary>
        public required double GPA { get; set; }

        /// <summary>
        /// Gets or sets the total credits earned by the student.
        /// </summary>
        public required int Credits { get; set; }

        /// <summary>
        /// Gets or sets the date the student registered in the department.
        /// </summary>
        public required DateOnly DepartmentRegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the graduation date of the student, if applicable.
        /// </summary>
        public DateOnly? GraduationDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user associated with the student profile.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the department associated with the student profile.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the student profile.
        /// </summary>
        public required User User { get; set; }

        /// <summary>
        /// Gets or sets the department associated with the student profile.
        /// </summary>
        public required Department Department { get; set; }

        /// <summary>
        /// Gets or sets the collection of courses the student is enrolled in.
        /// </summary>
        public IEnumerable<Course> Courses { get; set; } = [];
    }
}
