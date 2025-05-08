namespace SIS.Application.DTOs.UniversityDTOs
{
    /// <summary>
    /// Represents the data required to create a new university.
    /// </summary>
    public class UniversityCreateDto
    {
        /// <summary>
        /// Gets or sets the name of the university.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation of the university.
        /// </summary>
        public required string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the address of the university.
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// Gets or sets the domain of the university.
        /// </summary>
        public required string Domain { get; set; }

        /// <summary>
        /// Gets or sets the ID of the rector of the university.
        /// </summary>
        public required string RectorId { get; set; }
    }
}
