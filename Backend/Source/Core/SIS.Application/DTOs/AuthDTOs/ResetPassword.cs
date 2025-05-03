namespace SIS.Application.DTOs.AuthDTOs
{
    public class ResetPassword
    {
        public required string UserId { get; set; }
        public required NewPasswordDto PasswordDto { get; set; }
    }
}
