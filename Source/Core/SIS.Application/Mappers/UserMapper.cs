using SIS.Application.DTOs.UserDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    public static class UserMapper
    {
        public static UserGetDto ToUserGetDto(this User user)
        {
            return new UserGetDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SchoolMail = user.SchoolMail,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        public static User ToUser(this UserCreateDto userCreateDto)
        {
            return new User
            {
                UserName = userCreateDto.UserName,
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                SchoolMail = userCreateDto.SchoolMail,
                Email = userCreateDto.Email,
                PhoneNumber = userCreateDto.PhoneNumber,
                DateOfBirth = userCreateDto.DateOfBirth,
                RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow)
            };
        }
    }
}
