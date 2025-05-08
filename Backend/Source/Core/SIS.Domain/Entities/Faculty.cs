using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace SIS.Domain.Entities
{
    [Index(nameof(UniversityId), nameof(Name), IsUnique = true)]
    [Index(nameof(UniversityId), nameof(Code), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Index(nameof(DeanId), IsUnique = true)] // DeanID is unique to ensure one dean per faculty. If otherwise, it will need to change.
    /// <summary>
    /// Represents a faculty within a university in the system.
    /// </summary>
    public class Faculty
    {
        /// <summary>
        /// Gets or sets the unique identifier for the faculty.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the faculty.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the faculty (e.g., "ENG" for Engineering).
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// Gets or sets the address of the faculty.
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the faculty.
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the faculty is active.
        /// </summary>
        public required bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the unique identifier of the university the faculty belongs to.
        /// </summary>
        public required int UniversityId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the dean of the faculty.
        /// </summary>
        public required string DeanId { get; set; }

        /// <summary>
        /// Gets or sets the university the faculty belongs to.
        /// </summary>
        public University? University { get; set; }

        /// <summary>
        /// Gets or sets the user who is the dean of the faculty.
        /// </summary>
        public User? Dean { get; set; }

        /// <summary>
        /// Gets or sets the collection of departments within the faculty.
        /// </summary>
        public ICollection<Department> Departments { get; set; } = [];
    }
}