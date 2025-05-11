namespace SIS.Application.DTOs.UserDTOs
{
    /// <summary>
    /// Represents the data required to partially update a user.
    /// </summary>
    public class UserPatchDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        
        public required string Id { get; set; }
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the school mail of the user.
        /// </summary>
        public string? SchoolMail { get; set; }

        /// <summary>
        /// Gets or sets the mail of the user.
        /// </summary>
        public string? Mail { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}
