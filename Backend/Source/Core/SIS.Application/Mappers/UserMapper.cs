using SIS.Application.DTOs.UserDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods for mapping user entities to and from data transfer objects.
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Maps a <see cref="User"/> entity to a <see cref="UserGetDto"/>.
        /// </summary>
        /// <param name="user">The user entity to map.</param>
        /// <returns>A <see cref="UserGetDto"/> containing the mapped data.</returns>
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

        /// <summary>
        /// Maps a <see cref="UserCreateDto"/> to a <see cref="User"/> entity.
        /// </summary>
        /// <param name="userCreateDto">The data transfer object containing the user creation data.</param>
        /// <returns>A <see cref="User"/> entity containing the mapped data.</returns>
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
