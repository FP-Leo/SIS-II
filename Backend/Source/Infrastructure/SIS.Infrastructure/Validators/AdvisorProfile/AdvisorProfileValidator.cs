using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Common.Constants;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.AdvisorProfile
{
    /// <summary>
    /// Provides validation logic for Advisor profile-related operations.
    /// Implements the <see cref="IAdvisorProfileValidator"/> interface.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AdvisorProfileValidator"/> class.
    /// </remarks>
    /// <param name="advisorProfileRepo">The repository for Advisor profile-related data operations.</param>
    /// <param name="departmentRepository">The repository for department-related data operations.</param>
    /// <param name="userService">The service for user-related operations.</param>
    public class AdvisorProfileValidator(IAdvisorProfileRepository advisorProfileRepo, IDepartmentRepository departmentRepository, IUserService userService) : IAdvisorProfileValidator
    {

        private readonly IAdvisorProfileRepository _advisorProfileRepo = advisorProfileRepo;
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
            bool result = await _advisorProfileRepo.ProfileExistsAsync(depId, userId, cancellationToken);
            if (result) throw new InvalidInputException($"The specified profile already exists in the specified department.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsUniqueProfile(int profileId, int depId, CancellationToken cancellationToken)
        {
            bool result = await _advisorProfileRepo.ProfileExistsAsync(profileId, depId, cancellationToken);
            if (result) throw new InvalidInputException($"The specified profile already exists in the specified department.");

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidAdvisor(string userId, CancellationToken cancellationToken)
        {
            User user = await _userService.GetUserByIdAsync(userId) ?? throw new InvalidInputException("The specified user does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(user);
            if (roles == null || !roles.Any()) throw new InvalidInputException("The provided user doesn't have any roles associated with it.");

            return roles.Contains(RoleConstants.Advisor);
        }

        /// <inheritdoc/>  
        public async Task<bool> IsValidProfile(int id, CancellationToken cancellationToken)
        {
            bool exists = await _advisorProfileRepo.ProfileExistsByIdAsync(id, cancellationToken);
            if (!exists) throw new InvalidInputException("The specified profile does not exist.");

            return exists;
        }
    }
}
