namespace SIS.Application.DTOs.UserDTOs
{
    /// <summary>
    /// Represents the data returned for a user.
    /// </summary>
    public class UserGetDto
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the school mail of the user.
        /// </summary>
        public required string SchoolMail { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string? Email { get; set; } = null;

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string? PhoneNumber { get; set; } = null;
    }
}
