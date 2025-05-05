using SIS.Application.DTOs.FacultyDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;

namespace SIS.Infrastructure.Validators.Faculty
{
    public class FacultyValidator(IFacultyRepository facultyRepository, IUserService userService, IUniversityRepository universityRepository) : IFacultyValidator
    {
        private readonly IFacultyRepository _facultyRepository = facultyRepository;
        private readonly IUserService _userService = userService;
        private readonly IUniversityRepository _universityRepository = universityRepository;

        public async Task<bool> BeUniqueDeanId(string deanId, CancellationToken cancellationToken)
        {
            User? dean = await _userService.GetUserByIdAsync(deanId) ?? throw new InvalidInputException($"The specified dean account does not exist.");

            IList<string> roles = await _userService.GetUserRolesAsync(dean);
            if (!roles.Contains("Dean")) throw new InvalidInputException($"The specified user is not a dean.");

            bool result = await _facultyRepository.FacultyExistsByDeanIdAsync(deanId, cancellationToken);
            if (result) throw new InvalidInputException($"The specified dean is already assigned to a faculty in the university.");

            return true;
        }

        public async Task<bool> BeUniqueFacultyCode(int uniId, string code, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.CodeExistsInUniAsync(code, uniId, cancellationToken);
            if (result) throw new InvalidInputException($"Faculty with code {code} already exists in the specified university.");

            return true;
        }

        public async Task<bool> BeUniqueFacultyName(int uniId, string name, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.FacultyExistsInUniAsync(name, uniId, cancellationToken);
            if (result) throw new InvalidInputException($"Faculty with name {name} already exists in the specified university.");

            return true;
        }

        public async Task<bool> BeUniqueFacultyPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            bool result = await _facultyRepository.FacultyExistsByPhoneNumberAsync(phoneNumber, cancellationToken);
            if (result) throw new InvalidInputException($"Faculty with phone number {phoneNumber} already exists.");

            return true;
        }

        public async Task<bool> UniversityExistsAsync(int? uniId, CancellationToken cancellationToken)
        {
            if (uniId == null) throw new InvalidInputException($"The specified university ID is null.");

            return await _universityRepository.UniversityExistsByIdAsync(uniId.Value, cancellationToken);
        }

        public async Task<bool> UniversityExistsAsync(int uniId, CancellationToken cancellationToken)
        {
            return await _universityRepository.UniversityExistsByIdAsync(uniId, cancellationToken);
        }
    }
}
