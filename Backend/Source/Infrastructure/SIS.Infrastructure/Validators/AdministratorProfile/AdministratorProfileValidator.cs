using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Common.Constants;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.AdministratorProfile
{
    /// <summary>
    /// Provides validation logic for administrator profile-related operations.
    /// Implements the <see cref="IAdministratorProfileValidator"/> interface.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AdministratorProfileValidator"/> class.
    /// </remarks>
    /// <param name="adminProfileRepo">The repository for administrator profile-related data operations.</param>
    /// <param name="departmentRepository">The repository for department-related data operations.</param>
    /// <param name="userService">The service for user-related operations.</param>
    public class AdministratorProfileValidator(IAdministratorProfileRepository adminProfileRepo, IDepartmentRepository departmentRepository, IUserService userService) : IAdministratorProfileValidator
    {

        private readonly IAdministratorProfileRepository _adminProfileRepo = adminProfileRepo;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IUserService _userService = userService;

        /// <inheritdoc/>
        public async Task<bool> IsValidDepartment(int depId, CancellationToken cancellationToken)
        {
            bool result = await _departmentRepository.DepartmentExistsByIdAsync(depId, cancellationToken);
            if(!result) throw new InvalidInputException("The specified department does not exist.");

            return true;
        }

        /// <inheritdoc/>
        public Task<bool> IsValidDepartment(int? depId, CancellationToken cancellationToken)
        {
            if(depId == null) throw new InvalidInputException("The specified Department ID is null.");

            return IsValidDepartment(depId.Value, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueProfile(string userId, int depId, CancellationToken cancellationToken)
        {
            bool result = await _adminProfileRepo.ProfileExistsAsync(depId, userId, cancellationToken);
            if (result) throw new InvalidInputException($"The specified profile already exists in the specified department.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueProfile(int profileId, int depId, CancellationToken cancellationToken)
        {
            bool result = await _adminProfileRepo.ProfileExistsAsync(profileId, depId, cancellationToken);
            if (result) throw new InvalidInputException($"The specified profile already exists in the specified department.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidAdministrator(string userId, CancellationToken cancellationToken)
        {
            User user = await _userService.GetUserByIdAsync(userId) ?? throw new InvalidInputException("The specified user does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(user);
            if (roles == null || !roles.Any()) throw new InvalidInputException("The provided user doesn't have any roles associated with it.");

            return roles.Contains(RoleConstants.Administrator);
        }

        /// <inheritdoc/>  
        public async Task<bool> IsValidProfile(int id, CancellationToken cancellationToken)
        {
            bool exists = await _adminProfileRepo.ProfileExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException("The specified profile does not exist.");

            return exists;
        }
    }
}
