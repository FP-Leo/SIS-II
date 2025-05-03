using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Application.DTOs.UserDTOs
{
    public class UserCreateDto
    {
        public required string Role { get; set; }
        public required string UserName { get; set; }
        public required NewPasswordDto PasswordDto { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string SchoolMail { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
