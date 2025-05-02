namespace SIS.Application.DTOs.UserDTOs
{
    public class UserGetDto
    {
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set;}
        public required string SchoolMail { get; set; }
        public string? Email { get; set; } = null;
        public string? PhoneNumber { get; set; } = null ;
    }
}
