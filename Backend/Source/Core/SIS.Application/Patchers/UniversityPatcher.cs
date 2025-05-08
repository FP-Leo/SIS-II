using SIS.Application.DTOs.UniversityDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods for patching and updating university entities.
    /// </summary>
    public static class UniversityPatcher
    {
        /// <summary>
        /// Applies the changes from a <see cref="UniversityUpdateDto"/> to a <see cref="University"/> entity.
        /// </summary>
        /// <param name="university">The university entity to update.</param>
        /// <param name="dto">The data transfer object containing the changes.</param>
        public static void ApplyUpdate(this University university, UniversityUpdateDto dto)
        {
            university.Name = dto.Name;
            university.Abbreviation = dto.Abbreviation;
            university.Address = dto.Address;
            university.Domain = dto.Domain;
            university.RectorId = dto.RectorId;
        }

        /// <summary>
        /// Applies the changes from a <see cref="UniversityPatchDto"/> to a <see cref="University"/> entity.
        /// </summary>
        /// <param name="university">The university entity to patch.</param>
        /// <param name="dto">The data transfer object containing the changes.</param>
        public static void ApplyPatch(this University university, UniversityPatchDto dto)
        {
            if (dto.Name is not null) university.Name = dto.Name;
            if (dto.Abbreviation is not null) university.Abbreviation = dto.Abbreviation;
            if (dto.Address is not null) university.Address = dto.Address;
            if (dto.Domain is not null) university.Domain = dto.Domain;
            if (dto.RectorId is not null) university.RectorId = dto.RectorId;
        }
    }
}
