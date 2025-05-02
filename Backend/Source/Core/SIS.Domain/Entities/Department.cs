using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace SIS.Domain.Entities
{
    [Index(nameof(Name), nameof(FacultyId), IsUnique = true)] // to ensure local uniqueness. If global uniqueness is needed, it needs to be changed to [Index(nameof(DepartmentName), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(HeadOfDepartmentId), IsUnique = true)] // HeadOfDepartmentId is unique to ensure one head per department. If otherwise, it will need to change.
    public class Department
    {
        // Primary Key
        public int Id { get; set; }

        // Properties
        public required string Name { get; set; }
        public required string Code { get; set; } // for example, "CSE" for Computer Science and Engineering, "EEE" for Electrical and Electronics Engineering. Used in website and course code.
        public required string Address { get; set; } // Includes building, floor etc. If needed it can be split into multiple columns.
        public required string PhoneNumber { get; set; } // e.g., "123-456-7890"
        public int MinYears { get; set; } = 4; // Minimum years of study for the department, default is 4 years.
        public int MaxYears { get; set; } = 7; // Maximum years of study for the department, default is 7 years.
        public int SemesterCredits { get; set; } = 15; // Number of credits per semester, default is 15 credits.
        public int TotalCredits { get; set; } = 120; // Total number of credits required for graduation, default is 120 credits.
        public bool IsActive { get; set; } = true; // Department is active or not

        // Foreign Keys
        public required int FacultyId { get; set; } // query by int for performance
        public required string HeadOfDepartmentId { get; set; }

        // Navigation Properties
        public required Faculty Faculty { get; set; }
        public required User HeadOfDepartment { get; set; }
    }
}