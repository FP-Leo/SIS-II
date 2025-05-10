namespace SIS.Application.DTOs.UniversityDTOs
{
    /// <summary>
    /// Represents the data required to partially update a university.
    /// </summary>
    public class UniversityPatchDto
    {
        /// <summary>
        /// Gets or sets the ID of the university.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the university.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation of the university.
        /// </summary>
        public string? Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the address of the university.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the ID of the rector of the university.
        /// </summary>
        public string? RectorId { get; set; }
    }
}
