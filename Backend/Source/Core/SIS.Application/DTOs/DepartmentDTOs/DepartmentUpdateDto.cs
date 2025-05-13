namespace SIS.Application.DTOs.DepartmentDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for updating an existing department.
    /// </summary>
    public class DepartmentUpdateDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the department.
        /// </summary>
        public required int Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the department (e.g., "CSE" for Computer Science and Engineering).
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// Gets or sets the address of the department.
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the department.
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the department is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the unique identifier of the faculty the department belongs to.
        /// </summary>
        public required int FacultyId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the head of the department.
        /// </summary>
        public required string HeadOfDepartmentId { get; set; }
    }
}
