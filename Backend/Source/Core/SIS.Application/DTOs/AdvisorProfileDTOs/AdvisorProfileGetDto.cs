namespace SIS.Application.DTOs.AdvisorProfileDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for retrieving Advisor profile information.
    /// </summary>
    public class AdvisorProfileGetDto
    {
        /// <summary>
        /// Gets and sets the unique identifier for the Advisor profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the unique identifier for the user associated with the Advisor profile.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Gets and sets the unique identifier for the department associated with the Advisor profile.
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
