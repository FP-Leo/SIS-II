using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Common.Constants;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.LecturerProfile
{
    /// <summary>
    /// Provides validation logic for Lecturer profile-related operations.
    /// Implements the <see cref="ILecturerProfileValidator"/> interface.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="LecturerProfileValidator"/> class.
    /// </remarks>
    /// <param name="departmentRepository">The repository for department-related data operations.</param>
    /// <param name="lecturerProfileRepo">The repository for Lecturer profile-related data operations.</param>
    /// <param name="userService">The service for user-related operations.</param>
    public class LecturerProfileValidator(ILecturerProfileRepository lecturerProfileRepo, IUserService userService) : ILecturerProfileValidator
    {
        private readonly ILecturerProfileRepository _lecturerProfileRepo = lecturerProfileRepo;
        private readonly IUserService _userService = userService;

        /// <inheritdoc/>
        public async Task<bool> IsValidLecturer(string userId, CancellationToken cancellationToken)
        {
            User lecturer = await _userService.GetUserByIdAsync(userId) ?? throw new InvalidInputException("The specified user does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(lecturer);
            if (roles == null || !roles.Any()) throw new InvalidInputException("The provided user doesn't have any roles associated with it.");

            if (!roles.Contains(RoleConstants.Lecturer)) throw new InvalidInputException("The provided user is not a lecturer.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidProfile(int id, CancellationToken cancellationToken)
        {
            bool exists = await _lecturerProfileRepo.ProfileExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException("The specified profile does not exist.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueProfile(string userId, CancellationToken cancellationToken)
        {
            bool exists = await _lecturerProfileRepo.ProfileExistsAsync(userId, cancellationToken);
            if (exists) throw new InvalidInputException("The specified profile already exists.");

            return true;
        }
    }
}
