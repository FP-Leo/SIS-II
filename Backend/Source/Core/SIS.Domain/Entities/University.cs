using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    /// <summary>
    /// Represents a university in the system.
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Abbreviation), IsUnique = true)]
    [Index(nameof(RectorId), IsUnique = true)]
    public class University
    {
        /// <summary>
        /// Gets or sets the unique identifier for the university.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the university.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation of the university (e.g., "METU").
        /// </summary>
        public required string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the address of the university.
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// Gets or sets the domain of the university (used for website and email).
        /// </summary>
        public required string Domain { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the rector of the university.
        /// </summary>
        public required string RectorId { get; set; }

        /// <summary>
        /// Gets or sets the collection of faculties within the university.
        /// </summary>
        public ICollection<Faculty> Faculties { get; set; } = [];

        /// <summary>
        /// Gets or sets the user who is the rector of the university.
        /// </summary>
        public User? Rector { get; set; }
    }
}