namespace SIS.Application.DTOs.AdministratorProfileDTOs
{
    /// <summary>
    /// Data Transfer Object for updating an administrator profile.
    /// </summary>
    public class AdministratorProfileUpdateDto
    {
        /// <summary>
        /// Gets and sets the unique identifier for the administrator profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the unique identifier for the department associated with the administrator profile.
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
