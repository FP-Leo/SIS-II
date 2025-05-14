namespace SIS.Application.DTOs.AdministratorProfileDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for retrieving administrator profile information.
    /// </summary>
    public class AdministratorProfileGetDto
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
    }
}
