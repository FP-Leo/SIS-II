namespace SIS.Application.DTOs.AuthDTOs
{
    public class ResetPasswordDto
    {
        // Maybe needs to be mapped with username instead of userId, to be decided.
        public required string UserId { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
