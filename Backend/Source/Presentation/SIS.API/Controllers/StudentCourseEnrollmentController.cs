using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.StudentCourseEnrollmentDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing student CourseEnrollments within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/enrollment/courses")]
    [ApiController]
    public class StudentCourseEnrollmentController(IStudentCourseEnrollmentRepository studentCourseEnrollmentRepository) : ControllerBase
    {
        private readonly IStudentCourseEnrollmentRepository _studentCourseEnrollmentRepository = studentCourseEnrollmentRepository;

        /// <summary>
        /// Retrieves all Course Enrollments of a specific Student's Program.
        /// </summary>
        /// <param name="id"> The unique identifier of the Student Program.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of Student CourseEnrollments.</returns>
        /// <response code="200">Returns the list of Student Course Enrollments.</response>
        /// <response code="404">No Student Course Enrollments found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("program/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProgramCourseEnrollments([FromRoute] int id,CancellationToken cancellationToken)
        {
            IEnumerable<StudentCourseEnrollment> studentCourseEnrollments = await _studentCourseEnrollmentRepository.GetStudentsAllCourseEnrollments(id, cancellationToken);
            if (studentCourseEnrollments == null || !studentCourseEnrollments.Any())
            {
                return NotFound("No Student Course Enrollments found.");
            }

            return Ok(studentCourseEnrollments.Select(u => u.ToStudentCourseEnrollmentGetDto()));
        }

        /// <summary>
        /// Retrieves all Course Enrollments of Students of a specific course instance.
        /// </summary>
        /// <param name="id"> The unique identifier of the Course Instance.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of Student CourseEnrollments.</returns>
        /// <response code="200">Returns the list of Student Course Enrollments.</response>
        /// <response code="404">No Student Course Enrollments found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("course/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCoursesAllEnrollments([FromRoute] int id, CancellationToken cancellationToken)
        {
            IEnumerable<StudentCourseEnrollment> studentCourseEnrollments = await _studentCourseEnrollmentRepository.GetCoursesAllStudentEnrollments(id, cancellationToken);
            if (studentCourseEnrollments == null || !studentCourseEnrollments.Any())
            {
                return NotFound("No Student Course Enrollments found.");
            }

            return Ok(studentCourseEnrollments.Select(u => u.ToStudentCourseEnrollmentGetDto()));
        }

        /// <summary>
        /// Retrieves an Student Course Enrollment by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Course Enrollment.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Student CourseEnrollment with the specified ID.</returns>
        /// <response code="200">Returns the Student Course Enrollment.</response>
        /// <response code="404">Student Course Enrollment not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentCourseEnrollmentById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "StudentCourseEnrollment");

            StudentCourseEnrollment? studentCourseEnrollment = await _studentCourseEnrollmentRepository.GetStudentCourseEnrollmentByIdAsync(id, cancellationToken);
            if (studentCourseEnrollment == null)
                return NotFound($"Student CourseEnrollment not found.");

            return Ok(studentCourseEnrollment.ToStudentCourseEnrollmentGetDto());
        }

        /// <summary>
        /// Creates a new Student Course Enrollment.
        /// </summary>
        /// <param name="studentCourseEnrollmentCreateDto">The DTO containing the Student Course Enrollment data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created student Course Enrollment.</returns>
        /// <response code="201">Student Course Enrollment created successfully.</response>
        /// <response code="400">Invalid Student Course Enrollment data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateStudentCourseEnrollment(StudentCourseEnrollmentCreateDto studentCourseEnrollmentCreateDto, [FromServices] IValidator<StudentCourseEnrollmentCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(studentCourseEnrollmentCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            StudentCourseEnrollment studentCourseEnrollment = studentCourseEnrollmentCreateDto.ToStudentCourseEnrollment();

            StudentCourseEnrollment result = await _studentCourseEnrollmentRepository.CreateStudentCourseEnrollmentAsync(studentCourseEnrollment, cancellationToken);

            return CreatedAtAction(nameof(GetStudentCourseEnrollmentById), new { id = result.Id }, result.ToStudentCourseEnrollmentGetDto());
        }

        /// <summary>
        /// Updates an existing Student Course Enrollment.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Course Enrollment.</param>
        /// <param name="studentCourseEnrollmentUpdateDto">The DTO containing the updated Student Course Enrollment data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Student Course Enrollment.</returns>
        /// <response code="200">Student Course Enrollment updated successfully.</response>
        /// <response code="400">Invalid student Course Enrollment data.</response>
        /// <response code="404">Student Course Enrollment not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateStudentCourseEnrollment([FromRoute] int id, StudentCourseEnrollmentUpdateDto studentCourseEnrollmentUpdateDto, [FromServices] IValidator<StudentCourseEnrollmentUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, studentCourseEnrollmentUpdateDto.Id, "StudentCourseEnrollment");

            ValidationResult validationResult = await validator.ValidateAsync(studentCourseEnrollmentUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            StudentCourseEnrollment? existingstudentCourseEnrollment = await _studentCourseEnrollmentRepository.GetStudentCourseEnrollmentByIdAsync(id, cancellationToken);
            if (existingstudentCourseEnrollment == null)
                return NotFound($"Student Course Enrollment not found.");

            existingstudentCourseEnrollment.ApplyUpdate(studentCourseEnrollmentUpdateDto);

            await _studentCourseEnrollmentRepository.UpdateStudentCourseEnrollmentAsync(existingstudentCourseEnrollment, cancellationToken);

            return Ok(existingstudentCourseEnrollment.ToStudentCourseEnrollmentGetDto());
        }

        /// <summary>
        /// Partially updates an existing Student Course Enrollment.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Course Enrollment.</param>
        /// <param name="studentCourseEnrollmentPatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Student Course Enrollment.</returns>
        /// <response code="200">Student Course Enrollment patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">Student Course Enrollment not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchstudentCourseEnrollment([FromRoute] int id, [FromBody] StudentCourseEnrollmentPatchDto studentCourseEnrollmentPatchDto, [FromServices] IValidator<StudentCourseEnrollmentPatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, studentCourseEnrollmentPatchDto.Id, "StudentCourseEnrollment");

            ValidationResult validationResult = await validator.ValidateAsync(studentCourseEnrollmentPatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            StudentCourseEnrollment? existingstudentCourseEnrollment = await _studentCourseEnrollmentRepository.GetStudentCourseEnrollmentByIdAsync(id, cancellationToken);
            if (existingstudentCourseEnrollment == null)
                return NotFound($"Student CourseEnrollment not found.");

            existingstudentCourseEnrollment.ApplyPatch(studentCourseEnrollmentPatchDto);

            await _studentCourseEnrollmentRepository.UpdateStudentCourseEnrollmentAsync(existingstudentCourseEnrollment, cancellationToken);

            return Ok(existingstudentCourseEnrollment.ToStudentCourseEnrollmentGetDto());
        }

        /// <summary>
        /// Deletes an Student Course Enrollment by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Course Enrollment.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Student Course Enrollment deleted successfully.</response>
        /// <response code="400">Invalid Student Course Enrollment ID.</response>
        /// <response code="404">Student Course Enrollment not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteStudentCourseEnrollment([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "StudentCourseEnrollment");

            StudentCourseEnrollment? studentCourseEnrollment = await _studentCourseEnrollmentRepository.GetStudentCourseEnrollmentByIdAsync(id, cancellationToken);
            if (studentCourseEnrollment == null)
                return NotFound($"Student CourseEnrollment not found.");

            await _studentCourseEnrollmentRepository.DeleteStudentCourseEnrollmentAsync(studentCourseEnrollment, cancellationToken);

            return NoContent();
        }
    }
}
