using FluentValidation;
using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Universities
{
    public class UniversityUpdateDtoValidator: AbstractValidator<UniversityUpdateDto>
    {
        public UniversityUpdateDtoValidator(IUniversityValidator universityValidator)
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 100).WithMessage("Name must be between 5 and 50 characters.")
                .MustAsync(universityValidator.BeUniqueUniversityNameAsync);

            RuleFor(u => u.Abbreviation)
                .NotEmpty().WithMessage("Abbreviation is required.")
                .Length(2, 10).WithMessage("Abbreviation must be between 2 and 10 characters.")
                .MustAsync(universityValidator.BeUniqueUniversityAbbreviationAsync);

            RuleFor(u => u.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.");

            RuleFor(x => x.Domain)
                .NotEmpty().WithMessage("Domain is required.")
                .Matches(@"^(?!-)[A-Za-z0-9-]{2,63}(?<!-)\.(edu|edu\.[a-z]{2,3})$")
                .WithMessage("Domain must be a valid .edu or .edu.xx domain (e.g., example.edu, uni.edu.tr).");

            RuleFor(u => u.RectorId)
                .NotEmpty().WithMessage("RectorId is required.")
                .Length(36, 450).WithMessage("RectorId must be a valid GUID.")
                .MustAsync(universityValidator.BeValidRectorAsync);
        }
    }
}
