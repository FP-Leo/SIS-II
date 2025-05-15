using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Common.Constants;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.StudentProfile
{
    /// <summary>
    /// Provides validation logic for Student profile-related operations.
    /// Implements the <see cref="IStudentProfileValidator"/> interface.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="StudentProfileValidator"/> class.
    /// </remarks>
    /// <param name="studentProfileRepo">The repository for Student profile-related data operations.</param>
    /// <param name="userService">The service for user-related operations.</param>
    public class StudentProfileValidator(IStudentProfileRepository studentProfileRepo, IAcademicProgramRepository academicProgramRepo, IStudentProgramEnrollmentRepository programEnrollmentRepo, IUserService userService) : IStudentProfileValidator
    {
        private readonly IStudentProfileRepository _studentProfileRepo = studentProfileRepo;
        private readonly IAcademicProgramRepository _academicProgramRepo = academicProgramRepo;
        private readonly IStudentProgramEnrollmentRepository _programEnrollmentRepo = programEnrollmentRepo;
        private readonly IUserService _userService = userService;

        /// <inheritdoc/>
        public async Task<bool> IsValidStudent(string userId, CancellationToken cancellationToken)
        {
            User Student = await _userService.GetUserByIdAsync(userId) ?? throw new InvalidInputException("The specified user does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(Student);
            if (roles == null || !roles.Any()) throw new InvalidInputException("The provided user doesn't have any roles associated with it.");

            if (!roles.Contains(RoleConstants.Student)) throw new InvalidInputException("The provided user is not a Student.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidProfile(int id, CancellationToken cancellationToken)
        {
            bool exists = await _studentProfileRepo.ProfileExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException("The specified profile does not exist.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueProfile(string userId, CancellationToken cancellationToken)
        {
            bool exists = await _studentProfileRepo.ProfileExistsAsync(userId, cancellationToken);
            if (exists) throw new InvalidInputException("The specified profile already exists.");

            return true;
        }

        public async Task<bool> IsValidProgram(int? programId, CancellationToken cancellationToken)
        {
            if (programId == null) throw new ApplicationException("The provided program ID is null when it was supposed to not be null.");

            bool result = await _academicProgramRepo.AcademicProgramExistsByIdAsync((int)programId, cancellationToken);

            if (!result) throw new InvalidInputException("The specified program does not exist.");

            return true;
        }

        public async Task<bool> IsInProgram(int studentProfileId, int? programId, CancellationToken cancellationToken)
        {
            if (programId == null) throw new ApplicationException("The provided program ID is null when it was supposed to not be null.");

            bool result = await _programEnrollmentRepo.ProgramEnrollmentExistsAsync(studentProfileId, (int)programId, cancellationToken);

            if (!result) throw new InvalidInputException("The specified student is not enrolled in the specified program.");

            return true;
        }
    }
}
