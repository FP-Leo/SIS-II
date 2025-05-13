using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(UserId), nameof(DepartmentId))]
    /// <summary>
    /// Represents the administrator profile.
    /// </summary>
    public class AdministratorProfile
    {
        /// <summary>
        /// Gets and sets the unique identifier for the administrator profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the unique identifier for the user associated with the administrator profile.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Gets and sets the unique identifier for the department associated with the administrator profile.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets and sets the user associated with the administrator profile.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets and sets the department associated with the administrator profile.
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Gets or sets the list of course instances associated with the administrator profile.
        /// </summary>
        public List<CourseInstance>? CourseInstances { get; set; }
    }
}
