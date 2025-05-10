namespace SIS.Application.DTOs.FacultyDTOs
{
    /// <summary>
    /// Represents the data required to update a new faculty.
    /// </summary>
    public class FacultyUpdateDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the faculty.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the faculty.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique code of the faculty.
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
        /// Default value is <c>true</c>.
        /// </summary>
        public required bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the unique identifier of the associated university.
        /// </summary>
        public required int UniId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the dean of the faculty.
        /// </summary>
        public required string DeanId { get; set; }
    }
}
