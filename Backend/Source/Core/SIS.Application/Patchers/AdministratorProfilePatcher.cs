using SIS.Application.DTOs.AdministratorProfileDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods to apply updates or patches to a <see cref="AdministratorProfile"/> entity.
    /// </summary>
    public static class AdministratorProfilePatcher
    {
        /// <summary>
        /// Updates the properties of a <see cref="AdministratorProfile"/> entity with the values from a <see cref="AdministratorProfileUpdateDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileDTO"></param>
        public static void ApplyUpdate(this AdministratorProfile profile, AdministratorProfileUpdateDto profileDTO)
        {
            profile.DepartmentId = profileDTO.DepartmentId;
        }

        /// <summary>
        /// Updates the properties of a <see cref="AdministratorProfile"/> entity with the non-null values from a <see cref="AdministratorProfilePatchDto"/>.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileDTO"></param>
        public static void ApplyPatch(this AdministratorProfile profile, AdministratorProfilePatchDto profileDTO)
        {
            if (profileDTO.DepartmentId != null)
                profile.DepartmentId = (int)profileDTO.DepartmentId;
        }
    }
}
