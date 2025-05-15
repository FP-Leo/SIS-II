using SIS.Application.DTOs.StudentProfileDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="StudentProfile"/> entities and their corresponding DTOs.
    /// </summary>
    public static class StudentProfileMapper
    {
        /// <summary>
        /// Maps a <see cref="StudentProfile"/> entity to a <see cref="StudentProfileGetDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static StudentProfileGetDto ToProfileGetDto(this StudentProfile profile)
        {
            return new StudentProfileGetDto
            {
                Id = profile.Id,
                UserId = profile.UserId,
                DefaultProgramId = profile.DefaultProgramId,
            };
        }

        /// <summary>
        /// Maps a <see cref="StudentProfileCreateDTO"/> to a <see cref="StudentProfile"/> entity.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static StudentProfile ToProfile(this StudentProfileCreateDto profile)
        {
            return new StudentProfile
            {
                UserId = profile.UserId
            };
        }
    }
}
