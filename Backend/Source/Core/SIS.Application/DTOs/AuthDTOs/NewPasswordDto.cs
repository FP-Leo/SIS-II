namespace SIS.Application.DTOs.AuthDTOs
{
    public class NewPasswordDto
    {
        public required string NewPassword { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
