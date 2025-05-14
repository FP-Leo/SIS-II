using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Common.Constants;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;
using SIS.Domain.Exceptions.Repositories.Department;

namespace SIS.Infrastructure.Validators.Department
{
    /// <summary>
    /// Provides validation logic for department-related operations.
    /// Implements the <see cref="IDepartmentValidator"/> interface.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="DepartmentValidator"/> class.
    /// </remarks>
    /// <param name="departmentRepository">The repository for department-related data operations.</param>
    /// <param name="userService">The service for user-related operations.</param>
    /// <param name="facultyRepository">The repository for faculty-related data operations.</param>
    public class DepartmentValidator(IDepartmentRepository departmentRepository, IUserService userService, IFacultyRepository facultyRepository) : IDepartmentValidator
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IUserService _userService = userService;
        private readonly IFacultyRepository _facultyRepository = facultyRepository;

        /// <inheritdoc />
        public async Task<bool> ValidateDepartmentId(int departmentId, CancellationToken cancellationToken)
        {
            var result= await _departmentRepository.DepartmentExistsByIdAsync(departmentId, cancellationToken);
            if (!result) throw new InvalidInputException($"The specified department does not exist.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeUniqueHeadOfDepartmentId(string hodId, CancellationToken cancellationToken)
        {
            bool hodAlreadyExists = await _departmentRepository.DepartmentExistsByHodIdAsync(hodId, cancellationToken);
            if (hodAlreadyExists) throw new DuplicateHoDException();

            User? hod = await _userService.GetUserByIdAsync(hodId) ?? throw new InvalidInputException($"The specified head of department account does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(hod);
            if (roles == null || !roles.Any()) throw new InvalidInputException("The provided user doesn't have any roles associated with it.");

            return roles.Contains(RoleConstants.HoD);
        }
        /// <inheritdoc />
        public async Task<bool> BeUniqueHeadOfDepartmentId(string hodId, int depId, CancellationToken cancellationToken)
        {
            bool hodAlreadyExists = await _departmentRepository.DepartmentExistsByHodIdAsync(hodId, depId, cancellationToken);
            if (hodAlreadyExists) throw new DuplicateHoDException();

            User? hod = await _userService.GetUserByIdAsync(hodId) ?? throw new InvalidInputException($"The specified head of department account does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(hod);
            if (roles == null || !roles.Any()) throw new InvalidInputException("The provided user doesn't have any roles associated with it.");

            if (!roles.Contains(RoleConstants.HoD)) throw new InvalidInputException("The provided user is not a head of department.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeUniqueDepartmentCode(string code, int facultyId, CancellationToken cancellationToken)
        {
            bool result = await _departmentRepository.CodeExistsInUniAsync(code, facultyId, cancellationToken);
            if (result) throw new DuplicateAbbreviationException($"Department with code {code} already exists in the specified faculty.");

            return true;
        }
        /// <inheritdoc />
        public async Task<bool> BeUniqueDepartmentCode(string code, int depId, int facultyId, CancellationToken cancellationToken)
        {
            bool result = await _departmentRepository.CodeExistsInUniAsync(code, depId, facultyId, cancellationToken);
            if (result) throw new DuplicateAbbreviationException($"Department with code {code} already exists in the specified faculty.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeUniqueDepartmentName(string name,  int facultyId, CancellationToken cancellationToken)
        {
            bool result = await _departmentRepository.DepartmentExistsInUniAsync(name, facultyId, cancellationToken);
            if (result) throw new DuplicateNameException($"Department with name {name} already exists in the specified faculty.");

            return true;
        }
        /// <inheritdoc />
        public async Task<bool> BeUniqueDepartmentName(string name, int depId, int facultyId, CancellationToken cancellationToken)
        {
            bool result = await _departmentRepository.DepartmentExistsInUniAsync(name, depId, facultyId, cancellationToken);
            if (result) throw new DuplicateNameException($"Department with name {name} already exists in the specified faculty.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeUniqueDepartmentPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            bool result = await _departmentRepository.DepartmentExistsByPhoneNumberAsync(phoneNumber, cancellationToken);
            if (result) throw new DuplicatePhoneNumberException();

            return true;
        }
        /// <inheritdoc />
        public async Task<bool> BeUniqueDepartmentPhoneNumber(string phoneNumber, int depId, CancellationToken cancellationToken)
        {
            bool result = await _departmentRepository.DepartmentExistsByPhoneNumberAsync(phoneNumber, depId, cancellationToken);
            if (result) throw new DuplicatePhoneNumberException();

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> FacultyExistsAsync(int? facultyId, CancellationToken cancellationToken)
        {
            if (facultyId == null) throw new InvalidInputException($"The specified faculty ID is null.");

            return await _facultyRepository.FacultyExistsByIdAsync(facultyId.Value, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<bool> FacultyExistsAsync(int facultyId, CancellationToken cancellationToken)
        {
            return await _facultyRepository.FacultyExistsByIdAsync(facultyId, cancellationToken);
        }
    }
}
