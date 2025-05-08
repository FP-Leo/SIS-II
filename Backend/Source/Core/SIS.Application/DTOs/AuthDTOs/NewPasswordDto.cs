namespace SIS.Application.DTOs.AuthDTOs
{
    /// <summary>
    /// Represents the data required to set a new password.
    /// </summary>
    public class NewPasswordDto
    {
        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        public required string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirmation of the new password.
        /// </summary>
        public required string ConfirmPassword { get; set; }
    }
}
