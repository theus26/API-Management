using API_PeopleManagement.Domain.Entities;
using FluentValidation;

namespace API_PeopleManagement.Service.Validators;

public class VacationValidator : AbstractValidator<VacationRecord>
{
    public VacationValidator()
    {
        RuleFor(c => c.VacationeEndDate)
            .NotEmpty().WithMessage("Please enter the Admission Date.");

        RuleFor(c => c.VacationStartDate)
            .NotEmpty().WithMessage("Please enter the Admission Date.");
    }
}