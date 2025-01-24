using API_PeopleManagement.Domain.Entities;
using FluentValidation;

namespace API_PeopleManagement.Service.Validators;

public class VacationValidator : AbstractValidator<VacationRecord>
{
    public VacationValidator()
    {
        // RuleFor(c => c.endIn)
        //     .NotEmpty().WithMessage("Please enter the Admission Date.");
        //
        // RuleFor(c => c.startedIn)
        //     .NotEmpty().WithMessage("Please enter the Admission Date.");
    }
}