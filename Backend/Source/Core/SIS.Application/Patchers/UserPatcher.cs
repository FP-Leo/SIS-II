using SIS.Application.DTOs.UserDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.User;

namespace SIS.Application.Patchers
{
    public static class UserPatcher
    {
        public static void ApplyPatch(this User user, UserPatchDto dto)
        {
            if (dto.FirstName is not null) user.FirstName = dto.FirstName;
            if (dto.LastName is not null) user.LastName = dto.LastName;
            if (dto.PhoneNumber is not null) user.PhoneNumber = dto.PhoneNumber; 
            if (dto.SchoolMail is not null) user.SchoolMail = dto.SchoolMail; 
        }
    }
}
