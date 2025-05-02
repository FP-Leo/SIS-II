using SIS.Application.DTOs.UserDTOs;

namespace SIS.Application.DTOs.AuthDTOs
{
    public class SuccessfulLoginDto
    {
        public required UserGetDto UserData { get; set; }
        public required IList<string> Role { get; set; }
        public required string Token { get; set; }
    }
}
