using SIS.Application.DTOs.AdvisorProfileDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="AdvisorProfile"/> entities and their corresponding DTOs.
    /// </summary>
    public static class AdvisorProfileMapper
    {
        /// <summary>
        /// Maps a <see cref="AdvisorProfile"/> entity to a <see cref="AdvisorProfileGetDto"/>.
        /// </summary>
        /// <param name="profile">The AdvisorProfile entity to map.</param>
        public static AdvisorProfileGetDto ToProfileGetDto(this AdvisorProfile profile)
        {
            return new AdvisorProfileGetDto
            {
                Id = profile.Id,
                UserId = profile.UserId,
                DepartmentId = profile.DepartmentId,
            };
        }

        /// <summary>
        /// Maps a <see cref="AdvisorProfileCreateDTO"/> to a <see cref="AdvisorProfile"/> entity.
        /// </summary>
        /// <param name="profile">The DTO containing the data to map.</param>
        public static AdvisorProfile ToProfile(this AdvisorProfileCreateDto profile)
        {
            return new AdvisorProfile
            {
                UserId = profile.UserId,
                DepartmentId = profile.DepartmentId,
            };
        }
    }
}
