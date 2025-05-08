namespace SIS.Application.DTOs.AuthDTOs
{
    /// <summary>
    /// Represents the data required for a user to reset their own password.
    /// </summary>
    public class SelfResetPasswordDto
    {
        /// <summary>
        /// Gets or sets the ID of the user resetting their password.
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Gets or sets the current password of the user.
        /// </summary>
        public required string CurrentPassword { get; set; }

        /// <summary>
        /// Gets or sets the new password details.
        /// </summary>
        public required NewPasswordDto PasswordDto { get; set; }
    }
}
