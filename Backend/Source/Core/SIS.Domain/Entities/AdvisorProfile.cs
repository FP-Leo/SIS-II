using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(UserId), nameof(DepartmentId))]
    /// <summary>
    /// Represents an advisor profile in the system.
    /// </summary>
    public class AdvisorProfile
    {
        /// <summary>
        /// Gets or sets the unique identifier for the advisor profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with this advisor profile.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the department associated with this advisor profile.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the program semester associated with this advisor profile.
        /// </summary>
        public User? Advisor { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the program semester associated with this advisor profile.
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Gets or sets the list of student program enrollments associated with this advisor profile.
        /// </summary>
        public List<StudentProgramEnrollment>? Students { get; set; }
    }
}
