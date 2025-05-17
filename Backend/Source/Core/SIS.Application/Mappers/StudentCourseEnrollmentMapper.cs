using SIS.Application.DTOs.StudentCourseEnrollmentDTOs;
using SIS.Domain.Entities;
using SIS.Domain.Shared;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="StudentCourseEnrollment"/> entities and their corresponding DTOs.
    /// </summary>
    public static class StudentCourseEnrollmentMapper
    {
        /// <summary>
        /// Maps a <see cref="StudentCourseEnrollment"/> entity to a <see cref="StudentCourseEnrollmentGetDto"/>.
        /// </summary>
        /// <param name="enrollment">The <see cref="StudentCourseEnrollment"/> entity to map.</param>
        public static StudentCourseEnrollmentGetDto ToStudentCourseEnrollmentGetDto(this StudentCourseEnrollment enrollment)
        {
            return new StudentCourseEnrollmentGetDto
            {
                Id = enrollment.Id,
                Status = enrollment.Status,
                EnrollmentDate = enrollment.EnrollmentDate,
                CompletionDate = enrollment.CompletionDate,
                AttendancePercentage = enrollment.AttendancePercentage,
                EledgibleForMakeup = enrollment.EledgibleForMakeup,
                Grade = enrollment.Grade,
                CourseInstanceId = enrollment.CourseInstanceId,
                ProgramEnrollmentId = enrollment.ProgramEnrollmentId
            };
        }

        /// <summary>
        /// Maps a <see cref="StudentCourseEnrollmentCreateDTO"/> to a <see cref="StudentCourseEnrollment"/> entity.
        /// </summary>
        /// <param name="enrollment">The <see cref="StudentCourseEnrollmentCreateDTO"/> to map.</param>
        public static StudentCourseEnrollment ToStudentCourseEnrollment(this StudentCourseEnrollmentCreateDto enrollment)
        {
            return new StudentCourseEnrollment
            {
                Status = EnrollmentStatus.Enrolled,
                EnrollmentDate = DateTime.UtcNow,
                CompletionDate = null,
                AttendancePercentage = null,
                EledgibleForMakeup = null,
                Grade = null,
                CourseInstanceId = enrollment.CourseInstanceId,
                ProgramEnrollmentId = enrollment.ProgramEnrollmentId
            };
        }
    }
}
