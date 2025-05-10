namespace SIS.Application.DTOs.DepartmentDTOs
{
    /// <summary>
    /// Represent the data returned when retrieving a department.
    /// </summary>
    public class DepartmentGetDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the department.
        /// </summary>
        public int Id { get; set; }

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
        /// Gets or sets the minimum years of study for the department.
        /// </summary>
        public int MinYears { get; set; } = 4;

        /// <summary>
        /// Gets or sets the maximum years of study for the department.
        /// </summary>
        public int MaxYears { get; set; } = 7;

        /// <summary>
        /// Gets or sets the number of credits per semester.
        /// </summary>
        public int SemesterCredits { get; set; } = 15;

        /// <summary>
        /// Gets or sets the total number of credits required for graduation.
        /// </summary>
        public int TotalCredits { get; set; } = 120;

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
