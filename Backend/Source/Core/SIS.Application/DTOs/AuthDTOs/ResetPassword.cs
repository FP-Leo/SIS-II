namespace SIS.Application.DTOs.AuthDTOs
{
    /// <summary>
    /// Represents the data required to reset a user's password.
    /// </summary>
    public class ResetPassword
    {
        /// <summary>
        /// Gets or sets the ID of the user whose password is being reset.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Gets or sets the new password details.
        /// </summary>
        public required NewPasswordDto PasswordDto { get; set; }
    }
}
