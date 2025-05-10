using SIS.Application.DTOs.FacultyDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="Faculty"/> entities and their corresponding DTOs.
    /// </summary>
    public static class FacultyMapper
    {
        /// <summary>
        /// Maps a <see cref="Faculty"/> entity to a <see cref="FacultyGetDto"/>.
        /// </summary>
        /// <param name="faculty">The faculty entity to map.</param>
        /// <returns>A <see cref="FacultyGetDto"/> containing the mapped data.</returns>
        public static FacultyGetDto ToFacultyGetDto(this Faculty faculty)
        {
            return new FacultyGetDto
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Code = faculty.Code,
                Address = faculty.Address,
                PhoneNumber = faculty.PhoneNumber,
                IsActive = faculty.IsActive,
                UniId = faculty.UniversityId,
                DeanId = faculty.DeanId
            };
        }

        /// <summary>
        /// Maps a <see cref="FacultyCreateDto"/> to a <see cref="Faculty"/> entity.
        /// </summary>
        /// <param name="facultyCreateDto">The DTO containing the data to map.</param>
        /// <returns>A <see cref="Faculty"/> entity containing the mapped data.</returns>
        public static Faculty ToFaculty(this FacultyCreateDto facultyCreateDto)
        {
            return new Faculty
            {
                Name = facultyCreateDto.Name,
                Code = facultyCreateDto.Code,
                Address = facultyCreateDto.Address,
                PhoneNumber = facultyCreateDto.PhoneNumber,
                IsActive = facultyCreateDto.IsActive,
                UniversityId = facultyCreateDto.UniId,
                DeanId = facultyCreateDto.DeanId
            };
        }
    }
}
