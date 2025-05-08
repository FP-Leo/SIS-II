namespace SIS.Application.DTOs.AuthDTOs
{
    /// <summary>
    /// Represents the data required for a user to log in.
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public required string Password { get; set; }
    }
}