using SIS.Application.DTOs.AdvisorProfileDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods to apply updates or patches to a <see cref="AdvisorProfile"/> entity.
    /// </summary>
    public static class AdvisorProfilePatcher
    {
        /// <summary>
        /// Updates the properties of a <see cref="AdvisorProfile"/> entity with the values from a <see cref="AdvisorProfileUpdateDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileDTO"></param>
        public static void ApplyUpdate(this AdvisorProfile profile, AdvisorProfileUpdateDto profileDTO)
        {
            profile.DepartmentId = profileDTO.DepartmentId;
        }

        /// <summary>
        /// Updates the properties of a <see cref="AdvisorProfile"/> entity with the non-null values from a <see cref="AdvisorProfilePatchDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileDTO"></param>
        public static void ApplyPatch(this AdvisorProfile profile, AdvisorProfilePatchDto profileDTO)
        {
            if (profileDTO.DepartmentId != null)
                profile.DepartmentId = (int)profileDTO.DepartmentId;
        }
    }
}
