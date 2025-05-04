using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace SIS.Domain.Entities
{
    /// <summary>
    /// Represents a department within a faculty in the system.
    /// </summary>
    [Index(nameof(Name), nameof(FacultyId), IsUnique = true)] // to ensure local uniqueness. If global uniqueness is needed, it needs to be changed to [Index(nameof(DepartmentName), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(HeadOfDepartmentId), IsUnique = true)] // HeadOfDepartmentId is unique to ensure one head per department. If otherwise, it will need to change.
    public class Department
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

        /// <summary>
        /// Gets or sets the faculty the department belongs to.
        /// </summary>
        public required Faculty Faculty { get; set; }

        /// <summary>
        /// Gets or sets the user who is the head of the department.
        /// </summary>
        public required User HeadOfDepartment { get; set; }
    }
}