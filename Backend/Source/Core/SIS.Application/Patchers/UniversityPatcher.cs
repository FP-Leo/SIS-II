using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Domain.Entities;

namespace SIS.Application.Patchers
{
    public static class UniversityPatcher
    {
        public static async Task ApplyPatchAsync(this University university, UniversityPatchDto dto, IUserService userService)
        {
            if (dto.Name is not null) university.Name = dto.Name;
            if (dto.Abbreviation is not null) university.Abbreviation = dto.Abbreviation;
            if (dto.Address is not null) university.Address = dto.Address;
            if (dto.Domain is not null) university.Domain = dto.Domain;
            if (dto.RectorId is not null)
            {
                university.RectorId = dto.RectorId;
                var rector = await userService.GetUserByIdAsync(dto.RectorId);
                if (rector != null) university.Rector = rector;
            }
        }
    }
}
