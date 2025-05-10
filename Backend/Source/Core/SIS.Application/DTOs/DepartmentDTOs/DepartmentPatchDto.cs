namespace SIS.Application.DTOs.DepartmentDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for patching an existing department.
    /// </summary>
    public class DepartmentPatchDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the department.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the department (e.g., "CSE" for Computer Science and Engineering).
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the address of the department.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the department.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the minimum years of study for the department.
        /// </summary>
        public int? MinYears { get; set; }

        /// <summary>
        /// Gets or sets the maximum years of study for the department.
        /// </summary>
        public int? MaxYears { get; set; }

        /// <summary>
        /// Gets or sets the number of credits per semester.
        /// </summary>
        public int? SemesterCredits { get; set; }

        /// <summary>
        /// Gets or sets the total number of credits required for graduation.
        /// </summary>
        public int? TotalCredits { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the department is active.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the faculty the department belongs to.
        /// </summary>
        public int? FacultyId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the head of the department.
        /// </summary>
        public string? HeadOfDepartmentId { get; set; }
    }
}
