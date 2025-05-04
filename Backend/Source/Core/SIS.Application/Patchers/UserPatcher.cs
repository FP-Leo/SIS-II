using SIS.Application.DTOs.UserDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods for patching user entities.
    /// </summary>
    public static class UserPatcher
    {
        /// <summary>
        /// Applies the changes from a <see cref="UserPatchDto"/> to a <see cref="User"/> entity.
        /// </summary>
        /// <param name="user">The user entity to patch.</param>
        /// <param name="dto">The data transfer object containing the changes.</param>
        public static void ApplyPatch(this User user, UserPatchDto dto)
        {
            if (dto.FirstName is not null) user.FirstName = dto.FirstName;
            if (dto.LastName is not null) user.LastName = dto.LastName;
            if (dto.PhoneNumber is not null) user.PhoneNumber = dto.PhoneNumber; 
            if (dto.SchoolMail is not null) user.SchoolMail = dto.SchoolMail; 
        }
    }
}
