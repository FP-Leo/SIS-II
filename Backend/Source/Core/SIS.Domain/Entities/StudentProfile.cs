using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(UserId), IsUnique = true)]
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
        /// Gets or sets the unique identifier of the user associated with the student profile.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the student profile.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the department associated with the student profile.
        /// </summary>
        public List<StudentProgramEnrollment>? ProgramEnrollments { get; set; }
    }
}
