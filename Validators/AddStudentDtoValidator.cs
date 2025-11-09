using BackendChallenge.DTOs;
using FluentValidation;

namespace BackendChallenge.Validators;

public class AddStudentDtoValidator : AbstractValidator<AddStudentDto>
{
    public AddStudentDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Phone).MaximumLength(10);
    }
}
