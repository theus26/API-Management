using API_PeopleManagement.Domain.Entities;
using FluentValidation;

namespace API_PeopleManagement.Service.Validators;

public class EmployeeValidator : AbstractValidator<Employees>
{
    public EmployeeValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Please enter the Name.")
            .NotNull().WithMessage("Please enter the Name.");
        
        RuleFor(c => c.Position)
            .NotEmpty().WithMessage("Please enter the Position.")
            .NotNull().WithMessage("Please enter the Position.");

        RuleFor(c => c.AdmissionDate)
            .NotEmpty().WithMessage("Please enter the Admission Date.")
            .Must(date => date != DateTime.MinValue).WithMessage("Admission Date is invalid.");

        RuleFor(c => c.Wage)
            .GreaterThan(0).WithMessage("Wage must be greater than zero.");
    }
}