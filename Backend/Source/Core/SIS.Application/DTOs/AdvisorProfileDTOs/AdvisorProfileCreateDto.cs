namespace SIS.Application.DTOs.AdvisorProfileDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new advisor profile.
    /// </summary>
    public class AdvisorProfileCreateDto
    {
        /// <summary>
        /// Gets and sets the unique identifier for the user associated with the advisor profile.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Gets and sets the unique identifier for the department associated with the advisor profile.
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
