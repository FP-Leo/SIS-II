using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.CourseDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing Courses within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/courses")]
    [ApiController]
    public class CourseController(ICourseRepository CourseRepository) : ControllerBase
    {
        private readonly ICourseRepository _CourseRepository = CourseRepository;

        /// <summary>
        /// Retrieves all Courses.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of Courses.</returns>
        /// <response code="200">Returns the list of Courses.</response>
        /// <response code="404">No Courses found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCourses(CancellationToken cancellationToken)
        {
            IEnumerable<Course> Courses = await _CourseRepository.GetAllCoursesAsync(cancellationToken);
            if (Courses == null || !Courses.Any())
            {
                return NotFound("No Courses found.");
            }

            return Ok(Courses.Select(u => u.ToCourseGetDto()));
        }

        /// <summary>
        /// Retrieves Courses by their Department ID.
        /// </summary>
        /// <param name="departmentId">The unique identifier of the department.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>A list of Courses</returns>
        /// <response code="200">Returns the list of Courses associated with the provided Department Id.</response>
        /// <response code="404">No Courses found for the specified Department Id.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("/department/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDepartmentCourses([FromRoute] int departmentId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(departmentId, "Department");

            IEnumerable<Course> Courses = await _CourseRepository.GetCoursesByDepartmentIdAsync(departmentId, cancellationToken);
            if (Courses == null || !Courses.Any())
            {
                return NotFound("No Courses found for the provided department.");
            }

            return Ok(Courses.Select(u => u.ToCourseGetDto()));
        }

        /// <summary>
        /// Retrieves a Course by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Course.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Course with the specified ID.</returns>
        /// <response code="200">Returns the Course.</response>
        /// <response code="404">Course not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourseById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Course");

            Course? course = await _CourseRepository.GetCourseByIdAsync(id, cancellationToken);
            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(course.ToCourseGetDto());
        }

        /// <summary>
        /// Creates a new Course.
        /// </summary>
        /// <param name="courseCreateDto">The DTO containing the Course data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created Course.</returns>
        /// <response code="201">Course created successfully.</response>
        /// <response code="400">Invalid Course data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateCourse(CourseCreateDto courseCreateDto, [FromServices] IValidator<CourseCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(courseCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            Course Course = courseCreateDto.ToCourse();

            Course result = await _CourseRepository.CreateCourseAsync(Course, cancellationToken);

            return CreatedAtAction(nameof(GetCourseById), new { id = result.Id }, result.ToCourseGetDto());
        }

        /// <summary>
        /// Updates an existing Course.
        /// </summary>
        /// <param name="id">The unique identifier of the Course.</param>
        /// <param name="courseUpdateDto">The DTO containing the updated Course data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Course.</returns>
        /// <response code="200">Course updated successfully.</response>
        /// <response code="400">Invalid Course data.</response>
        /// <response code="404">Course not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateCourse([FromRoute] int id, CourseUpdateDto courseUpdateDto, [FromServices] IValidator<CourseUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, courseUpdateDto.Id, "Course");

            ValidationResult validationResult = await validator.ValidateAsync(courseUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            Course? existingCourse = await _CourseRepository.GetCourseByIdAsync(id, cancellationToken);
            if (existingCourse == null)
                return NotFound($"Course with Id {id} not found.");

            existingCourse.ApplyUpdate(courseUpdateDto);

            await _CourseRepository.UpdateCourseAsync(existingCourse, cancellationToken);

            return Ok(existingCourse.ToCourseGetDto());
        }

        /// <summary>
        /// Partially updates an existing Course.
        /// </summary>
        /// <param name="id">The unique identifier of the Course.</param>
        /// <param name="coursePatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Course.</returns>
        /// <response code="200">Course patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">Course not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchCourse([FromRoute] int id, [FromBody] CoursePatchDto coursePatchDto, [FromServices] IValidator<CoursePatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, coursePatchDto.Id, "Course");

            ValidationResult validationResult = await validator.ValidateAsync(coursePatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            Course? existingCourse = await _CourseRepository.GetCourseByIdAsync(id, cancellationToken);
            if (existingCourse == null)
                return NotFound($"Course with Id {id} not found.");

            existingCourse.ApplyPatch(coursePatchDto);

            await _CourseRepository.UpdateCourseAsync(existingCourse, cancellationToken);

            return Ok(existingCourse.ToCourseGetDto());
        }

        /// <summary>
        /// Deletes a Course by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Course.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Course deleted successfully.</response>
        /// <response code="400">Invalid Course ID.</response>
        /// <response code="404">Course not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Course");

            Course? Course = await _CourseRepository.GetCourseByIdAsync(id, cancellationToken);
            if (Course == null)
                return NotFound($"Course with ID {id} not found.");

            await _CourseRepository.DeleteCourseAsync(Course, cancellationToken);

            return NoContent();
        }
    }
}
