using SIS.Application.DTOs.UserDTOs;

namespace SIS.Application.DTOs.AuthDTOs
{
    /// <summary>
    /// Represents the data returned after a successful login.
    /// </summary>
    public class SuccessfulLoginDto
    {
        /// <summary>
        /// Gets or sets the user data associated with the login.
        /// </summary>
        public required UserGetDto UserData { get; set; }

        /// <summary>
        /// Gets or sets the roles assigned to the user.
        /// </summary>
        public required IList<string> Role { get; set; }

        /// <summary>
        /// Gets or sets the authentication token for the user.
        /// </summary>
        public required string Token { get; set; }
    }
}
