//using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    // Is it necessary to have a unique index on Name, City, and Country?
    //[Index(nameof(Name), nameof(City), nameof(Country), IsUnique = true)]
    /// <summary>
    /// Represents a campus building in the system.
    /// </summary>
    public class CampusBuilding
    {
        /// <summary>
        /// Gets or sets the unique identifier for the campus building.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the campus building.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the address line 1 of the campus building.
        /// </summary>
        public required string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2 of the campus building, if applicable.
        /// </summary>
        public string? AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city of the campus building.
        /// </summary>
        public required string City { get; set; }

        /// <summary>
        /// Gets or sets the country of the campus building.
        /// </summary>
        public required string Country { get; set; }

        /// <summary>
        /// Gets or sets the zip code of the campus building.
        /// </summary>
        public required string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the notes for the campus building.
        /// </summary>
        public string? Notes { get; set; }            
    }
}
