namespace SIS.Application.DTOs.UserDTOs
{
    /// <summary>
    /// Represents the data returned after a successful user registration.
    /// </summary>
    public class UserSuccessfulRegistrationDto
    {
        /// <summary>
        /// Gets or sets the username of the registered user.
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// Gets or sets the authentication token for the registered user.
        /// </summary>
        public required string Token { get; set; }
    }
}
