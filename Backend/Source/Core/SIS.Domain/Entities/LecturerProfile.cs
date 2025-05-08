namespace SIS.Domain.Entities
{
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
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the lecturer.
        /// </summary>
        public required string LecturerId;

        /// <summary>
        /// Gets or sets the user associated with the lecturer profile.
        /// </summary>
        public required User User { get; set; }
    }
}
