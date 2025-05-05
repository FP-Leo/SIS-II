namespace SIS.Application.DTOs.FacultyDTOs
{
    /// <summary>
    /// Represents the data required to partially update a faculty.
    /// </summary>
    public class FacultyPatchDto
    {
        /// <summary>
        /// Gets or sets the name of the faculty.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the unique code of the faculty.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the address of the faculty.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the faculty.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the faculty is active.
        /// Default value is <c>true</c>.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated university.
        /// </summary>
        public int? UniId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the dean of the faculty.
        /// </summary>
        public string? DeanId { get; set; }
    }
}
