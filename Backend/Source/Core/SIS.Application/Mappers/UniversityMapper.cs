using SIS.Application.DTOs.UniversityDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods for mapping university entities to and from data transfer objects.
    /// </summary>
    public static class UniversityMapper
    {
        /// <summary>
        /// Maps a <see cref="UniversityCreateDto"/> to a <see cref="University"/> entity.
        /// </summary>
        /// <param name="universityCD">The data transfer object containing the university creation data.</param>
        /// <returns>A <see cref="University"/> entity containing the mapped data.</returns>
        public static University ToUniversity(this UniversityCreateDto universityCD)
        {
            return new University
            {
                Name = universityCD.Name,
                Abbreviation = universityCD.Abbreviation,
                Address = universityCD.Address,
                RectorId = universityCD.RectorId
            };
        }

        /// <summary>
        /// Maps a <see cref="UniversityCreateDto"/> to a <see cref="UniversityGetDto"/>.
        /// </summary>
        /// <param name="universityCD">The data transfer object containing the university creation data.</param>
        /// <returns>A <see cref="UniversityGetDto"/> containing the mapped data.</returns>
        public static UniversityGetDto ToUniversityGetDto(this UniversityCreateDto universityCD)
        {
            return new UniversityGetDto
            {
                Name = universityCD.Name,
                Abbreviation = universityCD.Abbreviation,
                Address = universityCD.Address,
                RectorId = universityCD.RectorId
            };
        }

        /// <summary>
        /// Maps a <see cref="University"/> entity to a <see cref="UniversityGetDto"/>.
        /// </summary>
        /// <param name="university">The university entity to map.</param>
        /// <returns>A <see cref="UniversityGetDto"/> containing the mapped data.</returns>
        public static UniversityGetDto ToUniversityGetDto(this University university)
        {
            return new UniversityGetDto
            {
                Id = university.Id,
                Name = university.Name,
                Abbreviation = university.Abbreviation,
                Address = university.Address,
                RectorId = university.RectorId
            };
        }
    }
}