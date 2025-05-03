using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Domain.Entities;

namespace SIS.Application.Patchers
{
    public static class UniversityPatcher
    {
        public static void ApplyUpdate(this University university, UniversityUpdateDto dto)
        {
            university.Name = dto.Name;
            university.Abbreviation = dto.Abbreviation;
            university.Address = dto.Address;
            university.Domain = dto.Domain;
            university.RectorId = dto.RectorId;
        }

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
