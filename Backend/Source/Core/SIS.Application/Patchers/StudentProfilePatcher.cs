using SIS.Application.DTOs.StudentProfileDTOs;
using SIS.Domain.Entities;
using SIS.Domain.Shared;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods to apply updates or patches to a <see cref="StudentProfile"/> entity.
    /// </summary>
    public static class StudentProfilePatcher
    {
        /// <summary>
        /// Updates the properties of a <see cref="StudentProfile"/> entity with the values from a <see cref="StudentProfileUpdateDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileDTO"></param>
        public static void ApplyUpdate(this StudentProfile profile, StudentProfileUpdateDto profileDTO)
        {
            if (profileDTO.DefaultProgramId != null)
                profile.DefaultProgramId = profileDTO.DefaultProgramId;
        }

        /// <summary>
        /// Updates the properties of a <see cref="StudentProfile"/> entity with the non-null values from a <see cref="StudentProfilePatchDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileDTO"></param>
        public static void ApplyPatch(this StudentProfile profile, StudentProfilePatchDto profileDTO)
        {
            if (profileDTO.DefaultProgramId != null)
                profile.DefaultProgramId = profileDTO.DefaultProgramId;
        }
    }
}
