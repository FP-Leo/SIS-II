using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index("SchoolMail", IsUnique=true)]
    public class User : IdentityUser
    {
        // Properties
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required DateOnly RegisterDate { get; set; }
        public required string SchoolMail { get; set; }
    }
}

