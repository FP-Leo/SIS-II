using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Application.DTOs.UserDTOs
{
    /// <summary>
    /// Represents the data required to create a new user.
    /// </summary>
    public class UserCreateDto
    {
        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public required string Role { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password details for the user.
        /// </summary>
        public required NewPasswordDto PasswordDto { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the user.
        /// </summary>
        public required DateOnly DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the school mail of the user.
        /// </summary>
        public required string SchoolMail { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string? Email { get; set; }
    }
}
