using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(LecturerId), IsUnique = true)]
    /// <summary>
    /// Represents the profile of a lecturer in the system.
    /// </summary>
    public class LecturerProfile
    {
        /// <summary>
        /// Gets or sets the unique identifier for the lecturer profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the lecturer (e.g., "Professor", "Associate Professor").
        /// </summary>
        public LecturerType Title { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the lecturer.
        /// </summary>
        public required string LecturerId;

        /// <summary>
        /// Gets or sets the user associated with the lecturer profile.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the list of department assignments for the lecturer.
        /// </summary>
        public List<LecturerAssignment>? LecturerAssignments { get; set; }
    }
}
