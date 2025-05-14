using SIS.Application.DTOs.AdministratorProfileDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="AdministratorProfile"/> entities and their corresponding DTOs.
    /// </summary>
    public static class AdministratorProfileMapper
    {
        /// <summary>
        /// Maps a <see cref="AdministratorProfile"/> entity to a <see cref="AdministratorProfileGetDto"/>.
        /// </summary>
        /// <param name="profile">The AdministratorProfile entity to map.</param>
        public static AdministratorProfileGetDto ToProfileGetDto(this AdministratorProfile profile)
        {
            return new AdministratorProfileGetDto
            {
                Id = profile.Id,
                UserId = profile.UserId,
                DepartmentId = profile.DepartmentId,
            };
        }

        /// <summary>
        /// Maps a <see cref="AdministratorProfileCreateDTO"/> to a <see cref="AdministratorProfile"/> entity.
        /// </summary>
        /// <param name="profile">The DTO containing the data to map.</param>
        public static AdministratorProfile ToProfile(this AdministratorProfileCreateDto profile)
        {
            return new AdministratorProfile
            {
                UserId = profile.UserId,
                DepartmentId = profile.DepartmentId,
            };
        }
    }
}
