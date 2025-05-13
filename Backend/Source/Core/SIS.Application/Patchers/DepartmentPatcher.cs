using SIS.Application.DTOs.DepartmentDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods to apply updates or patches to a <see cref="Department"/> entity.
    /// </summary>
    public static class DepartmentPatcher
    {
        /// <summary>
        /// Updates the properties of a <see cref="Department"/> entity with the values from a <see cref="DepartmentUpdateDto"/>.
        /// </summary>
        /// <param name="Department">The Department entity to update.</param>
        /// <param name="DepartmentUpdateDto">The DTO containing the updated values.</param>
        public static void ApplyUpdate(this Department Department, DepartmentUpdateDto DepartmentUpdateDto)
        {
            Department.Name = DepartmentUpdateDto.Name;
            Department.Code = DepartmentUpdateDto.Code;
            Department.Address = DepartmentUpdateDto.Address;
            Department.PhoneNumber = DepartmentUpdateDto.PhoneNumber;
            Department.IsActive = DepartmentUpdateDto.IsActive;
            Department.FacultyId = DepartmentUpdateDto.FacultyId;
            Department.HeadOfDepartmentId = DepartmentUpdateDto.HeadOfDepartmentId;
        }

        /// <summary>
        /// Partially updates the properties of a <see cref="Department"/> entity with the non-null values from a <see cref="DepartmentPatchDto"/>.
        /// </summary>
        /// <param name="Department">The Department entity to patch.</param>
        /// <param name="DepartmentPatchDto">The DTO containing the patch values.</param>
        public static void ApplyPatch(this Department Department, DepartmentPatchDto DepartmentPatchDto)
        {
            if (DepartmentPatchDto.Name != null)
                Department.Name = DepartmentPatchDto.Name;
            if (DepartmentPatchDto.Code != null)
                Department.Code = DepartmentPatchDto.Code;
            if (DepartmentPatchDto.Address != null)
                Department.Address = DepartmentPatchDto.Address;
            if (DepartmentPatchDto.PhoneNumber != null)
                Department.PhoneNumber = DepartmentPatchDto.PhoneNumber;
            if (DepartmentPatchDto.IsActive != null)
                Department.IsActive = (bool)DepartmentPatchDto.IsActive;
            if (DepartmentPatchDto.FacultyId != null)
                Department.FacultyId = (int)DepartmentPatchDto.FacultyId;
            if (DepartmentPatchDto.HeadOfDepartmentId != null)
                Department.HeadOfDepartmentId = DepartmentPatchDto.HeadOfDepartmentId;
        }
    }
}
