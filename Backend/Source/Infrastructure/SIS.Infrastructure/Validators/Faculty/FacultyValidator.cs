using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Common.Constants;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;
using SIS.Domain.Exceptions.Repositories.Faculty;

namespace SIS.Infrastructure.Validators.Faculty
{
    /// <summary>
    /// Provides validation logic for faculty-related operations.
    /// Implements the <see cref="IFacultyValidator"/> interface.
    /// </summary>
    public class FacultyValidator : IFacultyValidator
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUserService _userService;
        private readonly IUniversityRepository _universityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacultyValidator"/> class.
        /// </summary>
        /// <param name="facultyRepository">The repository for faculty-related data operations.</param>
        /// <param name="userService">The service for user-related operations.</param>
        /// <param name="universityRepository">The repository for university-related data operations.</param>
        public FacultyValidator(IFacultyRepository facultyRepository, IUserService userService, IUniversityRepository universityRepository)
        {
            _facultyRepository = facultyRepository;
            _userService = userService;
            _universityRepository = universityRepository;
        }

        /// <inheritdoc />
        public async Task<bool> BeUniqueDeanId(string deanId, CancellationToken cancellationToken)
        {
            bool deanAlreadyExists = await _facultyRepository.FacultyExistsByDeanIdAsync(deanId, cancellationToken);
            if (deanAlreadyExists) throw new DuplicateDeanException();

            User? dean = await _userService.GetUserByIdAsync(deanId) ?? throw new InvalidInputException($"The specified dean account does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(dean);
            if (roles == null || !roles.Any()) throw new InvalidInputException("The provided user doesn't have any roles associated with it.");

            if (!roles.Contains(RoleConstants.Dean)) throw new InvalidInputException("The provided user is not a dean.");

            return true;
        }
        /// <inheritdoc />
        public async Task<bool> BeUniqueDeanId(string deanId, int facultyId, CancellationToken cancellationToken)
        {
            bool deanAlreadyExists = await _facultyRepository.FacultyExistsByDeanIdAsync(deanId, facultyId, cancellationToken);
            if (deanAlreadyExists) throw new DuplicateDeanException();

            User? dean = await _userService.GetUserByIdAsync(deanId) ?? throw new InvalidInputException($"The specified dean account does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(dean);
            if (roles == null || !roles.Any()) throw new InvalidInputException("The provided user doesn't have any roles associated with it.");

            return roles.Contains(RoleConstants.Dean);
        }

        /// <inheritdoc />
        public async Task<bool> BeUniqueFacultyCode(int uniId, string code, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.CodeExistsInUniAsync(code, uniId, cancellationToken);
            if (result) throw new DuplicateAbbreviationException($"Faculty with code {code} already exists in the specified university.");

            return true;
        }
        /// <inheritdoc />
        public async Task<bool> BeUniqueFacultyCode(int uniId, int facultyId, string code, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.CodeExistsInUniAsync(code, facultyId, uniId, cancellationToken);
            if (result) throw new DuplicateAbbreviationException($"Faculty with code {code} already exists in the specified university.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeUniqueFacultyName(int uniId, string name, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.FacultyExistsInUniAsync(name, uniId, cancellationToken);
            if (result) throw new DuplicateNameException($"Faculty with name {name} already exists in the specified university.");

            return true;
        }
        /// <inheritdoc />
        public async Task<bool> BeUniqueFacultyName(int uniId, int facultyId ,string name, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.FacultyExistsInUniAsync(name, facultyId, uniId, cancellationToken);
            if (result) throw new DuplicateNameException($"Faculty with name {name} already exists in the specified university.");

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> BeUniqueFacultyPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.FacultyExistsByPhoneNumberAsync(phoneNumber, cancellationToken);
            if (result) throw new DuplicatePhoneNumberException();

            return true;
        }
        /// <inheritdoc />
        public async Task<bool> BeUniqueFacultyPhoneNumber(string phoneNumber, int facultyId, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.FacultyExistsByPhoneNumberAsync(phoneNumber, facultyId, cancellationToken);
            if (result) throw new DuplicatePhoneNumberException();

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> UniversityExistsAsync(int? uniId, CancellationToken cancellationToken)
        {
            if (uniId == null) throw new InvalidInputException($"The specified university ID is null.");

            return await _universityRepository.UniversityExistsByIdAsync(uniId.Value, cancellationToken);
        }
        /// <inheritdoc />
        public async Task<bool> UniversityExistsAsync(int uniId, CancellationToken cancellationToken)
        {
            return await _universityRepository.UniversityExistsByIdAsync(uniId, cancellationToken);
        }
    }
}
