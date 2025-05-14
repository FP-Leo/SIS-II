using SIS.Application.DTOs.LecturerProfileDTOs;
using SIS.Domain.Entities;
using SIS.Domain.Shared;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods to apply updates or patches to a <see cref="LecturerProfile"/> entity.
    /// </summary>
    public static class LecturerProfilePatcher
    {
        /// <summary>
        /// Updates the properties of a <see cref="LecturerProfile"/> entity with the values from a <see cref="LecturerProfileUpdateDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileDTO"></param>
        public static void ApplyUpdate(this LecturerProfile profile, LecturerProfileUpdateDto profileDTO)
        {
            profile.Title = profileDTO.Title;
        }

        /// <summary>
        /// Updates the properties of a <see cref="LecturerProfile"/> entity with the non-null values from a <see cref="LecturerProfilePatchDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileDTO"></param>
        public static void ApplyPatch(this LecturerProfile profile, LecturerProfilePatchDto profileDTO)
        {
            if (profileDTO.Title != null)
                profile.Title = (LecturerType)profileDTO.Title;
        }
    }
}
