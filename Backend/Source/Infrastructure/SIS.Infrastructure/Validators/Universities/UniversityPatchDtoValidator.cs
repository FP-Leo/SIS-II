using FluentValidation;
using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Universities
{
    public class UniversityPatchDtoValidator: AbstractValidator<UniversityPatchDto>
    {
        public UniversityPatchDtoValidator(IUniversityValidator universityValidator)
        {
            RuleFor(u => u.Name)
                .Length(3, 100).WithMessage("Name must be between 5 and 50 characters.")
                .MustAsync(universityValidator.BeUniqueUniversityNameAsync)
                .When(u => !string.IsNullOrEmpty(u.Name), ApplyConditionTo.CurrentValidator);

            RuleFor(u => u.Abbreviation)
                .Length(2, 10).WithMessage("Abbreviation must be between 2 and 10 characters.")
                .MustAsync(universityValidator.BeUniqueUniversityAbbreviationAsync)
                .When(u => !string.IsNullOrEmpty(u.Abbreviation), ApplyConditionTo.CurrentValidator);

            RuleFor(u => u.Address)
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
                .When(u => !string.IsNullOrEmpty(u.Address), ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.Domain)
                .Matches(@"^(?!-)[A-Za-z0-9-]{2,63}(?<!-)\.(edu|edu\.[a-z]{2,3})$")
                .WithMessage("Domain must be a valid .edu or .edu.xx domain (e.g., example.edu, uni.edu.tr).")
                .When(u => !string.IsNullOrEmpty(u.Domain), ApplyConditionTo.CurrentValidator);

            RuleFor(u => u.RectorId)
                .Length(36, 450).WithMessage("RectorId must be a valid GUID.")
                .MustAsync(universityValidator.BeValidRectorAsync)
                .When(u => !string.IsNullOrEmpty(u.RectorId), ApplyConditionTo.CurrentValidator);
        }
    }
}
