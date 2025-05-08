using SIS.Application.DTOs.FacultyDTOs;

namespace SIS.Application.Interfaces.Validators
{
    public interface IFacultyValidator
    {
        Task<bool> BeUniqueFacultyName(int uniId, string name, CancellationToken cancellationToken);
        Task<bool> BeUniqueFacultyCode(int uniId, string code, CancellationToken cancellationToken);
        Task<bool> BeUniqueFacultyPhoneNumber(string phoneNumber, CancellationToken cancellationToken);
        Task<bool> BeUniqueDeanId(string deanId, CancellationToken cancellationToken);
        Task<bool> UniversityExistsAsync(int?  uniId, CancellationToken cancellationToken);
        Task<bool> UniversityExistsAsync(int uniId, CancellationToken cancellationToken);
    }
}
