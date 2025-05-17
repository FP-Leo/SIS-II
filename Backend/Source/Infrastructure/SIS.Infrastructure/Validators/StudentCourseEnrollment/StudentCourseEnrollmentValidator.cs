using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.StudentCourseEnrollment
{
    /// <summary>
    /// Provides validation logic for Student Course Enrollment-related operations.
    /// Implements the <see cref="IStudentCourseEnrollmentValidator"/> interface.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="StudentCourseEnrollmentValidator"/> class.
    /// </remarks>
    /// <param name="courseEnrRepository">The repository for Student Course Enrollment-related data operations.</param>
    /// <param name="programEnrRepository">The repository for Student Program Enrollment-related data operations.</param>
    /// <param name="courseInsRepository">The repository for Course Instance-related data operations.</param>
    public class StudentCourseEnrollmentValidator(IStudentCourseEnrollmentRepository courseEnrRepository, IStudentProgramEnrollmentRepository programEnrRepository, ICourseInstanceRepository courseInsRepository) : IStudentCourseEnrollmentValidator
    {
        private readonly IStudentCourseEnrollmentRepository _courseEnrRepository = courseEnrRepository;
        private readonly IStudentProgramEnrollmentRepository _programEnrRepository = programEnrRepository;
        private readonly ICourseInstanceRepository _courseInsRepository = courseInsRepository;

        /// <inheritdoc/>
        public async Task<bool> BeValidCourseInstance(int courseInstanceId, CancellationToken cancellationToken)
        {
            bool exists = await _courseInsRepository.CourseInstanceExistsByIdAsync(courseInstanceId, cancellationToken);
            if(!exists) throw new InvalidInputException("The specified Course Instance does not exist.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidCourseEnrollment(int id, CancellationToken cancellationToken)
        {
            bool exists = await _courseEnrRepository.StudentCourseEnrollmentExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException("The specified Course Enrollment does not exist.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidProgramEnrollment(int programEnrollmentId, CancellationToken cancellationToken)
        {
            bool exists = await _programEnrRepository.ProgramEnrollmentExistsByIdAsync(programEnrollmentId, cancellationToken);
            if (!exists) throw new InvalidInputException("The specified Program Enrollment does not exist.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueEnrollment(int programEnrollmentId, int courseInstanceId, CancellationToken cancellationToken)
        {
            bool exists = await _courseEnrRepository.StudentCourseEnrollmentExistsAsync(programEnrollmentId, courseInstanceId, cancellationToken);
            if (exists) throw new InvalidInputException("The specified Course Enrollment already exists.");

            return true;
        }
    }
}
