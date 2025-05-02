using SIS.Application.DTOs.UniversityDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{

    public static class UniversityMapper
    {
        public static University ToUniversity(this UniversityCreateDto universityCD, User Rector)
        {
            return new University
            {
                Name = universityCD.Name,
                Abbreviation = universityCD.Abbreviation,
                Address = universityCD.Address,
                Domain = universityCD.Domain,
                RectorId = Rector.Id,
                Rector = Rector
            };
        }
        public static UniversityGetDto ToUniversityGetDto(this UniversityCreateDto universityCD, User Rector)
        {
            return new UniversityGetDto
            {
                Name = universityCD.Name,
                Abbreviation = universityCD.Abbreviation,
                Address = universityCD.Address,
                Domain = universityCD.Domain,
                RectorId = Rector.Id
            };
        }
        public static UniversityGetDto ToUniversityGetDto(this University university)
        {
            return new UniversityGetDto
            {
                Id = university.Id,
                Name = university.Name,
                Abbreviation = university.Abbreviation,
                Address = university.Address,
                Domain = university.Domain,
                RectorId = university.RectorId
            };
        }
    }
}