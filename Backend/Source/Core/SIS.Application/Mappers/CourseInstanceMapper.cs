using SIS.Application.DTOs.CourseInstance;
using SIS.Application.DTOs.CourseInstanceDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="CourseInstance"/> entities and their corresponding DTOs.
    /// </summary>
    public static class CourseInstanceMapper
    {
        public static CourseInstanceGetDto ToCourseInstanceGetDto(this CourseInstance courseInstance)
        {
            return new CourseInstanceGetDto
            {
                Id = courseInstance.Id,
                EnrollmentLimit = courseInstance.EnrollmentLimit,
                DeliveryMethod = courseInstance.DeliveryMethod,
                AttendancePercentage = courseInstance.AttendancePercentage,
                CourseId = courseInstance.CourseId,
                LecturerAssignmentId = courseInstance.LecturerAssignmentId,
                AdminProfileId = courseInstance.AdminProfileId,
                ProgramSemesterId = courseInstance.ProgramSemesterId
            };
        }

        public static CourseInstance ToCourseInstance(this CourseInstanceCreateDto courseInstance)
        {
            return new CourseInstance
            {
                EnrollmentLimit = courseInstance.EnrollmentLimit,
                DeliveryMethod = courseInstance.DeliveryMethod,
                AttendancePercentage = courseInstance.AttendancePercentage,
                CourseId = courseInstance.CourseId,
                LecturerAssignmentId = courseInstance.LecturerAssignmentId,
                AdminProfileId = courseInstance.AdminProfileId,
                ProgramSemesterId = courseInstance.ProgramSemesterId
            };
        }
    }
}
