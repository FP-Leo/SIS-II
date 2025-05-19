using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.CourseInstance
{
    /// <summary>
    /// Provides validation logic for course instance-related operations.
    /// Implements the <see cref="ICourseInstanceValidator"/> interface.
    /// </summary>
    /// <param name="courseInstanceRepository">The repository for course instance-related data operations.</param>
    /// <param name="courseRepository">The repository for course-related data operations.</param>
    /// <param name="programSemesterRepository">The repository for program semester-related data operations.</param>
    /// <param name="lecturerAssignmentRepository">The repository for lecturer assignment-related data operations.</param>
    /// <param name="userService">The service for user-related operations.</param>
    public class CourseInstanceValidator(ICourseInstanceRepository courseInstanceRepository, 
        ICourseRepository courseRepository,
        IProgramSemesterRepository programSemesterRepository,
        ILecturerAssignmentRepository lecturerAssignmentRepository,
        IAdministratorProfileRepository administratorProfileRepository
        ) : ICourseInstanceValidator
    {
        private readonly ICourseInstanceRepository _courseInstanceRepository = courseInstanceRepository;
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IProgramSemesterRepository _programSemesterRepository = programSemesterRepository;
        private readonly ILecturerAssignmentRepository _lecturerAssignmentRepository = lecturerAssignmentRepository;
        private readonly IAdministratorProfileRepository _administratorProfileRepository = administratorProfileRepository;


        /// <inheritdoc />
        public async Task<bool> IsUniqueCourseInstance(int courseId, int programSemesterId, CancellationToken cancellationToken)
        {
            bool exists = await _courseInstanceRepository.CourseInstanceExistsAsync(courseId, programSemesterId, cancellationToken);
            if (exists) throw new InvalidInputException($"The course instance already exists in the specified program semester.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> IsUniqueCourseInstance(int courseId, int programSemesterId, int courseInstanceId, CancellationToken cancellationToken)
        {
            bool exists = await _courseInstanceRepository.CourseInstanceExistsAsync(courseId, programSemesterId, courseInstanceId, cancellationToken);
            if (exists) throw new InvalidInputException($"The course instance already exists in the specified program semester.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> IsValidAdminByCourse(int id, int courseId, CancellationToken cancellationToken)
        {
            int? depId = await _courseRepository.GetDepartmentIdByCourseIdAsync(courseId, cancellationToken) ?? throw new InvalidInputException($"The specified course does not exist.");
            
            bool profileExists = await _administratorProfileRepository.ProfileExistsAsync(id, (int)depId, cancellationToken);
            if (!profileExists) throw new InvalidInputException($"The specified administrator profile does not exist in the course's department.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> IsValidCourse(int id, CancellationToken cancellationToken)
        {
            bool exists = await _courseRepository.CourseExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException($"Course not found.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeValidCourseInstance(int id, CancellationToken cancellationToken)
        {
            bool exists = await _courseInstanceRepository.CourseInstanceExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException($"Course instance not found.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> IsValidLecturerByCourse(int id, int courseId, CancellationToken cancellationToken)
        {
            int? depID = await _courseRepository.GetDepartmentIdByCourseIdAsync(courseId, cancellationToken) ?? throw new InvalidInputException($"The specified course does not exist.");

            bool exists = await _lecturerAssignmentRepository.ActiveLecturerAssignmentExistsAsync(id, (int)depID, cancellationToken);
            if(!exists) throw new InvalidInputException($"The specified lecturer assignment does not exist (or it's inactive) in the course's department.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> IsValidLecturerByCourseInstance(int id, int instanceId, CancellationToken cancellationToken)
        {
            int? depID = await _courseInstanceRepository.GetDepIdOfCourseInstance(instanceId, cancellationToken) ?? throw new InvalidInputException($"The specified course does not exist.");

            bool exists = await _lecturerAssignmentRepository.ActiveLecturerAssignmentExistsAsync(id, (int)depID, cancellationToken);
            if (!exists) throw new InvalidInputException($"The specified lecturer assignment does not exist (or it's inactive) in the course's department.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeValidProgramSemesterByCourse(int id, int courseId, CancellationToken cancellationToken)
        {
            int? depId = await _courseRepository.GetDepartmentIdByCourseIdAsync(courseId, cancellationToken) ?? throw new InvalidInputException($"The specified course does not exist.");

            bool exists = await _programSemesterRepository.ProgramSemesterExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException($"Program semester not found.");

            int? depIdOfProgramSemester = await _programSemesterRepository.GetDepIdOfProgramSemester(id, cancellationToken);
            if (depId != depIdOfProgramSemester) throw new InvalidInputException($"The specified program semester does not belong to the same department as the course.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeValidProgramSemesterByInstance(int id, int instanceId, CancellationToken cancellationToken)
        {
            int? depId = await _courseInstanceRepository.GetDepIdOfCourseInstance(instanceId, cancellationToken) ?? throw new InvalidInputException($"The specified course instance does not exist.");

            bool exists = await _programSemesterRepository.ProgramSemesterExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException($"Program semester not found.");

            int? depIdOfProgramSemester = await _programSemesterRepository.GetDepIdOfProgramSemester(id, cancellationToken);
            if (depId != depIdOfProgramSemester) throw new InvalidInputException($"The specified program semester does not belong to the same department as the course instance.");

            return true;
        }
    }
}
