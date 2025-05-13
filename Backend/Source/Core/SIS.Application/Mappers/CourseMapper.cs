using SIS.Application.DTOs.CourseDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Mappers
{
    /// <summary>
    /// Provides extension methods to map between <see cref="Course"/> entities and their corresponding DTOs.
    /// </summary>
    public static class CourseMapper
    {
        /// <summary>
        /// Maps a <see cref="Course"/> entity to a <see cref="CourseGetDto"/>.
        /// </summary>
        /// <param name="course">The Course entity to map.</param>
        /// <returns>A <see cref="CourseGetDto"/> containing the mapped data.</returns>
        public static CourseGetDto ToCourseGetDto(this Course course)
        {
            return new CourseGetDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Type = course.Type,
                Description = course.Description,
                Credits = course.Credits,
                Level = course.Level,
                IsActive = course.IsActive,
                Created = course.CreatedAt,
                Updated = course.UpdatedAt,
                PrerequisiteCourseIds = course.PrerequisiteCourseIds,
                DepartmentId = course.DepartmentId,
            };
        }

        /// <summary>
        /// Maps a <see cref="CourseCreateDto"/> to a <see cref="Course"/> entity.
        /// </summary>
        /// <param name="courseDto">The DTO containing the data to map.</param>
        /// <returns>A <see cref="Course"/> entity containing the mapped data.</returns>
        public static Course ToCourse(this CourseCreateDto courseDto)
        {
            return new Course
            {
                Name = courseDto.Name,
                Code = courseDto.Code,
                Type = courseDto.Type,
                Description = courseDto.Description,
                Credits = courseDto.Credits,
                Level = courseDto.Level,
                IsActive = courseDto.IsActive,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                UpdatedAt = DateTime.Now,
                PrerequisiteCourseIds = courseDto.PrerequisiteCourseIds,
                DepartmentId = courseDto.DepartmentId,
            };
        }
    }
}
