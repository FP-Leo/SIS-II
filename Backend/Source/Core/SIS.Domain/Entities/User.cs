using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    /// <summary>
    /// Represents a user in the system, extending the functionality of the ASP.NET Core IdentityUser.
    /// </summary>
    [Index("SchoolMail", IsUnique = true)]
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the user.
        /// </summary>
        public DateOnly DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the registration date of the user in the system.
        /// </summary>
        public DateOnly RegisterDate { get; set; }

        /// <summary>
        /// Gets or sets the school email of the user, which must be unique.
        /// </summary>
        public required string SchoolMail { get; set; }
    }
}
