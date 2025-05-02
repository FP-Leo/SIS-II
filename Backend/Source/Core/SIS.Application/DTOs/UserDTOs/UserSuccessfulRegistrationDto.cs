namespace SIS.Application.DTOs.UserDTOs
{
    public class UserSuccessfulRegistrationDto
    {
        public required string UserName { get; set; }
        public required string Token { get; set; }
    }
}
