using SIS.Application.DTOs.StudentCourseEnrollmentDTOs;
using SIS.Domain.Entities;
using SIS.Domain.Shared;

namespace SIS.Application.Patchers
{
    /// <summary>
    /// Provides methods to apply updates or patches to a <see cref="StudentCourseEnrollment"/> entity.
    /// </summary>
    public static class StudentCourseEnrollmentPatcher
    {
        /// <summary>
        /// Updates the properties of a <see cref="StudentCourseEnrollment"/> entity with the values from a <see cref="StudentCourseEnrollmentUpdateDto"/>.
        /// </summary>
        /// <param name="enrollment">The <see cref="StudentCourseEnrollment"/> entity to update.</param>
        /// <param name="enrollmentDTO">The <see cref="StudentCourseEnrollmentUpdateDto"/> containing the new values.</param>
        public static void ApplyUpdate(this StudentCourseEnrollment enrollment, StudentCourseEnrollmentUpdateDto enrollmentDTO)
        {
            enrollment.Status = enrollmentDTO.Status;
            if (enrollmentDTO.CompletionDate != null)
                enrollment.CompletionDate = enrollmentDTO.CompletionDate;
            if (enrollmentDTO.AttendancePercentage != null)
                enrollment.AttendancePercentage = enrollmentDTO.AttendancePercentage;
        }

        /// <summary>
        /// Updates the properties of a <see cref="StudentCourseEnrollment"/> entity with the non-null values from a <see cref="StudentCourseEnrollmentPatchDto"/>.
        /// </summary>
        /// <param name="enrollment">The <see cref="StudentCourseEnrollment"/> entity to update.</param>
        /// <param name="enrollmentDTO">The <see cref="StudentCourseEnrollmentPatchDto"/> containing the new values.</param>
        public static void ApplyPatch(this StudentCourseEnrollment enrollment, StudentCourseEnrollmentPatchDto enrollmentDTO)
        {
            if (enrollmentDTO.Status != null)
                enrollment.Status = (EnrollmentStatus)enrollmentDTO.Status;
            if (enrollmentDTO.CompletionDate != null)
                enrollment.CompletionDate = enrollmentDTO.CompletionDate;
            if (enrollmentDTO.AttendancePercentage != null)
                enrollment.AttendancePercentage = enrollmentDTO.AttendancePercentage;
        }
    }
}
