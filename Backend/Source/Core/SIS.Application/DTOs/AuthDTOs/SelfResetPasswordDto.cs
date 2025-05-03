namespace SIS.Application.DTOs.AuthDTOs
{
    public class SelfResetPasswordDto
    {
        public required string UserId { get; set; }
        public required string CurrentPassword {get; set;}
        public required NewPasswordDto PasswordDto { get; set; }
    }
}
