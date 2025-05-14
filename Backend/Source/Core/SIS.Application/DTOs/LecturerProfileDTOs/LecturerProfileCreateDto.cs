using SIS.Domain.Shared;

namespace SIS.Application.DTOs.LecturerProfileDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a lecturer profile.
    /// </summary>
    public class LecturerProfileCreateDto
    {
        /// <summary>
        /// Gets or sets the title of the lecturer (e.g., "Professor", "Associate Professor").
        /// </summary>
        public LecturerType Title { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the lecturer.
        /// </summary>
        public required string UserId;
    }
}
