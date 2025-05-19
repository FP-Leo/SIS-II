using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.CourseInstanceDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing Course Instances within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/courses/instances")]
    [ApiController]
    public class CourseInstanceController(ICourseInstanceRepository courseInstanceRepository) : ControllerBase
    {
        private readonly ICourseInstanceRepository _courseInstanceRepository = courseInstanceRepository;

        /// <summary>
        /// Retrieves all Course Instances.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of CourseInstances.</returns>
        /// <response code="200">Returns the list of Course Instances.</response>
        /// <response code="404">No Course Instances found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("course/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCourseInstances([FromRoute] int id, CancellationToken cancellationToken)
        {
            IEnumerable<CourseInstance> CourseInstances = await _courseInstanceRepository.GetAllInstancesOfCourseAsync(id, cancellationToken);
            if (CourseInstances == null || !CourseInstances.Any())
            {
                return NotFound("No Course Instances of the provided course found.");
            }

            return Ok(CourseInstances.Select(u => u.ToCourseInstanceGetDto()));
        }

        /// <summary>
        /// Retrieves Course Instances by their Semester ID.
        /// </summary>
        /// <param name="id">The unique identifier of the semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>A list of Course Instances</returns>
        /// <response code="200">Returns the list of CourseInstances associated with the provided Semester Id.</response>
        /// <response code="404">No Course Instances found for the specified Semester Id.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("program/semester/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSemesterCourseInstances([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Semester");

            IEnumerable<CourseInstance> CourseInstances = await _courseInstanceRepository.GetAllCourseInstancesOfSemesterAsync(id, cancellationToken);
            if (CourseInstances == null || !CourseInstances.Any())
            {
                return NotFound("No Course Instances found for the provided semester.");
            }

            return Ok(CourseInstances.Select(u => u.ToCourseInstanceGetDto()));
        }

        /// <summary>
        /// Retrieves Course Instances by the Lecturer ID.
        /// </summary>
        /// <param name="lecturer">The unique identifier of the lecturer.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of Course Instances belonging to the specified lecturer.</returns>
        [HttpGet("lecturer/all/{lecturer:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLecturerCourseInstances([FromRoute] int lecturer, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(lecturer, "Lecturer");
            IEnumerable<CourseInstance> CourseInstances = await _courseInstanceRepository.GetLecturersAllCourseInstancesAsync(lecturer, cancellationToken);
            if (CourseInstances == null || !CourseInstances.Any())
            {
                return NotFound("No Course Instances found for the provided lecturer.");
            }
            return Ok(CourseInstances.Select(u => u.ToCourseInstanceGetDto()));
        }

        /// <summary>
        /// Retrieves Course Instances by the Program Semester ID and a Lecturer ID.
        /// </summary>
        /// <param name="lecId">The unique identifier of the lecturer.</param>
        /// <param name="progSemId">The unique identifier of the program semester.</param>
        /// <param name="cancellationToken">Token to cancel operations.</param>
        /// <returns>List of Course Instances belonging to Lecturer in the spiecified Program Semester</returns>
        [HttpGet("lecturer/program/semester/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLecturerCourseInstancesBySemester([FromQuery] int lecId, [FromQuery] int progSemId, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(lecId, "LecturerProfile");
            CommonUtils.EnsureIdIsValid(progSemId, "ProgramSemester");

            IEnumerable<CourseInstance> CourseInstances = await _courseInstanceRepository.GetLecturersAllCourseInstancesAsync(lecId, progSemId, cancellationToken);
            if (CourseInstances == null || !CourseInstances.Any())
            {
                return NotFound("No Course Instances found for the provided lecturer in the specified program semester.");
            }
            return Ok(CourseInstances.Select(u => u.ToCourseInstanceGetDto()));
        }

        /// <summary>
        /// Retrieves a Course Instance by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Course Instance.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Course Instance with the specified ID.</returns>
        /// <response code="200">Returns the Course Instance.</response>
        /// <response code="404">CourseInstance not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourseInstanceById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "CourseInstance");

            CourseInstance? CourseInstance = await _courseInstanceRepository.GetCourseInstanceByIdAsync(id, cancellationToken);
            if (CourseInstance == null)
                return NotFound($"Course Instance not found.");

            return Ok(CourseInstance.ToCourseInstanceGetDto());
        }

        /// <summary>
        /// Creates a new Course Instance.
        /// </summary>
        /// <param name="CourseInstanceCreateDto">The DTO containing the Course Instance data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created Course Instance.</returns>
        /// <response code="201">Course Instance created successfully.</response>
        /// <response code="400">Invalid Course Instance data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateCourseInstance(CourseInstanceCreateDto CourseInstanceCreateDto, [FromServices] IValidator<CourseInstanceCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(CourseInstanceCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            CourseInstance CourseInstance = CourseInstanceCreateDto.ToCourseInstance();

            CourseInstance result = await _courseInstanceRepository.CreateCourseInstanceAsync(CourseInstance, cancellationToken);

            return CreatedAtAction(nameof(GetCourseInstanceById), new { id = result.Id }, result.ToCourseInstanceGetDto());
        }

        /// <summary>
        /// Updates an existing Course Instance.
        /// </summary>
        /// <param name="id">The unique identifier of the Course Instance.</param>
        /// <param name="CourseInstanceUpdateDto">The DTO containing the updated Course Instance data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Course Instance.</returns>
        /// <response code="200">Course Instance updated successfully.</response>
        /// <response code="400">Invalid Course Instance data.</response>
        /// <response code="404">Course Instance not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateCourseInstance([FromRoute] int id, CourseInstanceUpdateDto CourseInstanceUpdateDto, [FromServices] IValidator<CourseInstanceUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, CourseInstanceUpdateDto.Id, "CourseInstance");

            ValidationResult validationResult = await validator.ValidateAsync(CourseInstanceUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            CourseInstance? existingCourseInstance = await _courseInstanceRepository.GetCourseInstanceByIdAsync(id, cancellationToken);
            if (existingCourseInstance == null)
                return NotFound($"CourseInstance not found.");

            existingCourseInstance.ApplyUpdate(CourseInstanceUpdateDto);

            await _courseInstanceRepository.UpdateCourseInstanceAsync(existingCourseInstance, cancellationToken);

            return Ok(existingCourseInstance.ToCourseInstanceGetDto());
        }

        /// <summary>
        /// Partially updates an existing Course Instance.
        /// </summary>
        /// <param name="id">The unique identifier of the Course Instance.</param>
        /// <param name="CourseInstancePatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Course Instance.</returns>
        /// <response code="200">Course Instance patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">CourseInstance not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchCourseInstance([FromRoute] int id, [FromBody] CourseInstancePatchDto CourseInstancePatchDto, [FromServices] IValidator<CourseInstancePatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, CourseInstancePatchDto.Id, "CourseInstance");

            ValidationResult validationResult = await validator.ValidateAsync(CourseInstancePatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            CourseInstance? existingCourseInstance = await _courseInstanceRepository.GetCourseInstanceByIdAsync(id, cancellationToken);
            if (existingCourseInstance == null)
                return NotFound($"CourseInstance not found.");

            existingCourseInstance.ApplyPatch(CourseInstancePatchDto);

            await _courseInstanceRepository.UpdateCourseInstanceAsync(existingCourseInstance, cancellationToken);

            return Ok(existingCourseInstance.ToCourseInstanceGetDto());
        }

        /// <summary>
        /// Deletes a Course Instance by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Course Instance.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Course Instance deleted successfully.</response>
        /// <response code="400">Invalid Course Instance ID.</response>
        /// <response code="404">Course Instance not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteCourseInstance([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "CourseInstance");

            CourseInstance? CourseInstance = await _courseInstanceRepository.GetCourseInstanceByIdAsync(id, cancellationToken);
            if (CourseInstance == null)
                return NotFound($"CourseInstance not found.");

            await _courseInstanceRepository.DeleteCourseInstanceAsync(CourseInstance, cancellationToken);

            return NoContent();
        }
    }
}
