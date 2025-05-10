using SIS.Application.DTOs.DepartmentDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="Department"/> entities and their corresponding DTOs.
    /// </summary>
    public static class DepartmentMapper
    {
        /// <summary>
        /// Maps a <see cref="Department"/> entity to a <see cref="DepartmentGetDto"/>.
        /// </summary>
        /// <param name="department">The Department entity to map.</param>
        /// <returns>A <see cref="DepartmentGetDto"/> containing the mapped data.</returns>
        public static DepartmentGetDto ToDepartmentGetDto(this Department department)
        {
            return new DepartmentGetDto
            {
                Name = department.Name,
                Code = department.Code,
                Address = department.Address,
                PhoneNumber = department.PhoneNumber,
                IsActive = department.IsActive,
                FacultyId = department.FacultyId,
                HeadOfDepartmentId = department.HeadOfDepartmentId
            };
        }

        /// <summary>
        /// Maps a <see cref="DepartmentCreateDto"/> to a <see cref="Department"/> entity.
        /// </summary>
        /// <param name="departmentCreateDto">The DTO containing the data to map.</param>
        /// <returns>A <see cref="Department"/> entity containing the mapped data.</returns>
        public static Department ToDepartment(this DepartmentCreateDto departmentCreateDto)
        {
            return new Department
            {
                Name = departmentCreateDto.Name,
                Code = departmentCreateDto.Code,
                Address = departmentCreateDto.Address,
                PhoneNumber = departmentCreateDto.PhoneNumber,
                IsActive = departmentCreateDto.IsActive,
                FacultyId = departmentCreateDto.FacultyId,
                HeadOfDepartmentId = departmentCreateDto.HeadOfDepartmentId
            };
        }

        /// <summary>
        /// Maps a <see cref="DepartmentUpdateDto"/> to a <see cref="Department"/> entity.
        /// </summary>
        /// <param name="departmentUpdateDto">The DTO containing the data to map.</param>
        /// <returns>A <see cref="Department"/> entity containing the mapped data.</returns>
        public static Department ToDepartment(this DepartmentUpdateDto departmentUpdateDto)
        {
            return new Department
            {
                Name = departmentUpdateDto.Name,
                Code = departmentUpdateDto.Code,
                Address = departmentUpdateDto.Address,
                PhoneNumber = departmentUpdateDto.PhoneNumber,
                IsActive = departmentUpdateDto.IsActive,
                FacultyId = departmentUpdateDto.FacultyId,
                HeadOfDepartmentId = departmentUpdateDto.HeadOfDepartmentId
            };
        }
    }
}
