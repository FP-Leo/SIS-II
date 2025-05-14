namespace SIS.Application.DTOs.AdvisorProfileDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for patching an Advisor profile.
    /// </summary>
    public class AdvisorProfilePatchDto
    {
        /// <summary>
        /// Gets and sets the unique identifier for the Advisor profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the unique identifier for the department associated with the Advisor profile.
        /// </summary>
        public int? DepartmentId { get; set; }
    }
}
