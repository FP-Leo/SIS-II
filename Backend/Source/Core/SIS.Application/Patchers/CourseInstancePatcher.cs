using SIS.Application.DTOs.CourseInstanceDTOs;
using SIS.Domain.Entities;
using SIS.Domain.Shared;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides extension methods to apply updates or patches to a <see cref="CourseInstance"/> entity.
    /// </summary>
    public static class CourseInstancePatcher
    {
        /// <summary>
        /// Updates the properties of a <see cref="CourseInstance"/> entity with the values from a <see cref="CourseInstanceUpdateDto"/>.
        /// </summary>
        /// <param name="courseInstance">The CourseInstance entity to update.</param>
        /// <param name="courseInstanceDTO">The DTO containing the updated values.</param>
        public static void ApplyUpdate(this CourseInstance courseInstance, CourseInstanceUpdateDto courseInstanceDTO)
        {
            courseInstance.EnrollmentLimit = courseInstanceDTO.EnrollmentLimit;
            courseInstance.DeliveryMethod = (DeliveryMethod)courseInstanceDTO.DeliveryMethod;
            courseInstance.AttendancePercentage = courseInstanceDTO.AttendancePercentage;
            courseInstance.LecturerAssignmentId = courseInstanceDTO.LecturerAssignmentId;
        }

        /// <summary>
        /// Updates the properties of a <see cref="CourseInstance"/> entity with the non-null values from a <see cref="CourseInstancePatchDto"/>.
        /// </summary>
        /// <param name="courseInstance">The CourseInstance entity to patch.</param>
        /// <param name="courseInstanceDTO">The DTO containing the patch values.</param>
        public static void ApplyPatch(this CourseInstance courseInstance, CourseInstancePatchDto courseInstanceDTO)
        {
            if (courseInstanceDTO.EnrollmentLimit != null)
                courseInstance.EnrollmentLimit = (int)courseInstanceDTO.EnrollmentLimit;
            if (courseInstanceDTO.DeliveryMethod != null)
                courseInstance.DeliveryMethod = (DeliveryMethod)courseInstanceDTO.DeliveryMethod;
            if (courseInstanceDTO.AttendancePercentage != null)
                courseInstance.AttendancePercentage = (int)courseInstanceDTO.AttendancePercentage;
            if (courseInstanceDTO.LecturerAssignmentId != null)
                courseInstance.LecturerAssignmentId = (int)courseInstanceDTO.LecturerAssignmentId;
        }
    }
}
