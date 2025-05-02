using FluentValidation;
using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Universities
{
    public class UniversityCreateDtoValidator: AbstractValidator<UniversityCreateDto>
    {
        private readonly IUserService _userService;
        private readonly IUniversityValidator _universityValidator;
        public UniversityCreateDtoValidator(IUserService userService, IUniversityValidator universityValidator)
        {
            _userService = userService;
            _universityValidator = universityValidator;

            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(3, 100)
                .WithMessage("Name must be between 3 and 100 characters.");

            RuleFor(u => u.RectorId)
                .NotEmpty()
                .WithMessage("RectorId is required.");
        }
    }
}
