using FluentValidation;
using SIS.Application.DTOs.FacultyDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Faculty
{
    /// <summary>
    /// Validator for the <see cref="FacultyPatchDto"/> class.
    /// Ensures that the data provided for partially updating a faculty meets the required rules and constraints.
    /// </summary>
    public class FacultyPatchDtoValidator : AbstractValidator<FacultyPatchDto>
    {
        private readonly IFacultyValidator _facultyValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="FacultyPatchDtoValidator"/> class.
        /// </summary>
        /// <param name="facultyValidator">An instance of <see cref="IFacultyValidator"/> to perform custom validation logic.</param>
        public FacultyPatchDtoValidator(IFacultyValidator facultyValidator)
        {
            _facultyValidator = facultyValidator;
            // Define validation rules for each property of the FacultyCreateDto class.

            // The Id property must not be empty, must be greater than 0,
            RuleFor(f => f.Id)
                .NotEmpty().WithMessage("Faculty ID is required.")
                .GreaterThan(0).WithMessage("Faculty ID must be greater than 0.");

            // If the UniId property is not null, it must be greater than 0 and the university must exist.
            RuleFor(f => f.UniId)
                .NotNull().WithMessage("University ID is required to patch any of the following fields: 'name', 'code', 'dean'.")
                .GreaterThan(0).WithMessage("University ID must be greater than 0. It is required to patch any of the following fields: 'name', 'code', 'dean'")
                .MustAsync(facultyValidator.UniversityExistsAsync).WithMessage("University ID doesn't exist. It is required to patch any of the following fields: 'name', 'code', 'dean'.")
                .When(f => !string.IsNullOrEmpty(f.Name) || !string.IsNullOrEmpty(f.Code) || !string.IsNullOrEmpty(f.DeanId), ApplyConditionTo.CurrentValidator)
                .DependentRules(() =>
                {
                    // The following rules are only applied if the UniId is not null and valid and the Name, Code, or DeanId properties are not null.

                    // If the Name property is not null, it must be between 3 and 100 characters long,
                    RuleFor(f => f.Name)
                        .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.")
                        .MustAsync((BeUniqueFacultyName))
                        .When(u => !string.IsNullOrEmpty(u.Name), ApplyConditionTo.CurrentValidator);

                    // If the Code property is not null, it must be between 2 and 15 characters long,
                    RuleFor(f => f.Code)
                        .Length(2, 15).WithMessage("Code must be between 2 and 15 characters.")
                        .MustAsync(BeUniqueFacultyCode)
                        .When(u => !string.IsNullOrEmpty(u.Code), ApplyConditionTo.CurrentValidator);

                    // If the DeanId property is not null, it must be a valid GUID,
                    RuleFor(f => f.DeanId)
                        .Length(36, 450).WithMessage("Dean ID must be a valid GUID.")
                        .MustAsync(BeUniqueDeanId).WithMessage("The specified user is not a dean.")
                        .When(u => !string.IsNullOrEmpty(u.DeanId), ApplyConditionTo.CurrentValidator);
                });

            // If the Address property is not null, it must be between 5 and 100 characters long,
            RuleFor(f => f.Address)
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
                .When(u => !string.IsNullOrEmpty(u.Address), ApplyConditionTo.CurrentValidator);

            // If the PhoneNumber property is not null, it must be a valid phone number format,
            RuleFor(f => f.PhoneNumber)
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits long.")
                .When(u => !string.IsNullOrEmpty(u.PhoneNumber), ApplyConditionTo.CurrentValidator)
                .MustAsync(BeUniqueFacultyPhoneNumber);
        }

        private async Task<bool> BeUniqueFacultyName(FacultyPatchDto faculty, string name, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueFacultyName(faculty.UniId!.Value, faculty.Id, name, cancellationToken);
        }

        private async Task<bool> BeUniqueFacultyCode(FacultyPatchDto faculty, string code, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueFacultyCode(faculty.UniId!.Value, faculty.Id, code, cancellationToken);
        }

        private async Task<bool> BeUniqueDeanId(FacultyPatchDto faculty, string deanId, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueDeanId(deanId, faculty.Id, cancellationToken);
        }

        private async Task<bool> BeUniqueFacultyPhoneNumber(FacultyPatchDto faculty, string phoneNumber, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueFacultyPhoneNumber(phoneNumber, faculty.Id, cancellationToken);
        }
    }
}
