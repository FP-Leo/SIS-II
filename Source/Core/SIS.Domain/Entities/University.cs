using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Abbreviation), IsUnique = true)]
    [Index(nameof(RectorId), IsUnique = true)]
    public class University
    {
        // Primary Key
        public int Id { get; set; }

        // Properties
        public required string Name { get; set; }
        public required string Abbreviation { get; set; } // e.g., "METU" for Middle East Technical University
        public required string Address { get; set; }
        public required string Domain { get; set; } // used for website and email

        // Foreign Keys
        public required string RectorId { get; set; } // GUID from User table. If tracking start/end date is needed, it needs to be a separate table.

        // Navigation Properties  
        public ICollection<Faculty> Faculties { get; set; } = []; // One-to-Many relationship
        public required User Rector { get; set; } // One-to-One
    }
}