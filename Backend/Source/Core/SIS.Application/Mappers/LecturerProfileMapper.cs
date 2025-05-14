using SIS.Application.DTOs.LecturerProfileDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="LecturerProfile"/> entities and their corresponding DTOs.
    /// </summary>
    public static class LecturerProfileMapper
    {
        /// <summary>
        /// Maps a <see cref="LecturerProfile"/> entity to a <see cref="LecturerProfileGetDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static LecturerProfileGetDto ToProfileGetDto(this LecturerProfile profile)
        {
            return new LecturerProfileGetDto
            {
                Id = profile.Id,
                UserId = profile.UserId,
                Title = profile.Title,
            };
        }

        /// <summary>
        /// Maps a <see cref="LecturerProfileCreateDTO"/> to a <see cref="LecturerProfile"/> entity.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static LecturerProfile ToProfile(this LecturerProfileCreateDto profile)
        {
            return new LecturerProfile
            {
                UserId = profile.UserId,
                Title = profile.Title,
            };
        }
    }
}
