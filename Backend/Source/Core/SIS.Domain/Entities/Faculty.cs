using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace SIS.Domain.Entities
{
    [Index(nameof(UniId), nameof(Name), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Index(nameof(DeanId), IsUnique = true)] // DeanID is unique to ensure one dean per faculty. If otherwise, it will need to change.
    public class Faculty
    {
        // Primary Key
        public int Id { get; set; }

        // Properties
        public required string Name { get; set; }
        public required string Code { get; set; } // e.g., "ENG" for Engineering, "SCI" for Science
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required bool IsActive { get; set; } = true; // Faculty is active or not

        // Foreign Keys
        public required int UniId { get; set; } // query by int for performance
        public required string DeanId { get; set; } // GUID from User table. If tracking start/end date is needed, it needs to be a separate table.

        // Navigation Properties
        public required University University { get; set; }   //One-to-Many relationship, connection on the Many side
        public required User Dean { get; set; } // One-to-One relationship, less faculties than users
        public ICollection<Department> Departments { get; set; } = []; // One-to-Many relationship, connection on the Many side (Department)
    }
}