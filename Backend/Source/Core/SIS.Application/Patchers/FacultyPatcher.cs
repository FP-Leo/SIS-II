using SIS.Application.DTOs.FacultyDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods to apply updates or patches to a <see cref="Faculty"/> entity.
    /// </summary>
    public static class FacultyPatcher
    {
        /// <summary>
        /// Updates the properties of a <see cref="Faculty"/> entity with the values from a <see cref="FacultyUpdateDto"/>.
        /// </summary>
        /// <param name="faculty">The faculty entity to update.</param>
        /// <param name="facultyUpdateDto">The DTO containing the updated values.</param>
        public static void ApplyUpdate(this Faculty faculty, FacultyUpdateDto facultyUpdateDto)
        {
            faculty.Name = facultyUpdateDto.Name;
            faculty.Code = facultyUpdateDto.Code;
            faculty.Address = facultyUpdateDto.Address;
            faculty.PhoneNumber = facultyUpdateDto.PhoneNumber;
            faculty.IsActive = facultyUpdateDto.IsActive;
            faculty.UniversityId = facultyUpdateDto.UniId;
            faculty.DeanId = facultyUpdateDto.DeanId;
        }

        /// <summary>
        /// Partially updates the properties of a <see cref="Faculty"/> entity with the non-null values from a <see cref="FacultyPatchDto"/>.
        /// </summary>
        /// <param name="faculty">The faculty entity to patch.</param>
        /// <param name="facultyPatchDto">The DTO containing the patch values.</param>
        public static void ApplyPatch(this Faculty faculty, FacultyPatchDto facultyPatchDto)
        {
            if (facultyPatchDto.Name != null)
                faculty.Name = facultyPatchDto.Name;
            if (facultyPatchDto.Code != null)
                faculty.Code = facultyPatchDto.Code;
            if (facultyPatchDto.Address != null)
                faculty.Address = facultyPatchDto.Address;
            if (facultyPatchDto.PhoneNumber != null)
                faculty.PhoneNumber = facultyPatchDto.PhoneNumber;
            if (facultyPatchDto.IsActive != null)
                faculty.IsActive = (bool)facultyPatchDto.IsActive;
            if (facultyPatchDto.UniId != null)
                faculty.UniversityId = (int)facultyPatchDto.UniId;
            if (facultyPatchDto.DeanId != null)
                faculty.DeanId = facultyPatchDto.DeanId;
        }
    }
}
