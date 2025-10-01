using FluentValidation;

namespace Application.Companies;

public class CreateCompanyValidator : AbstractValidator<CreateCompany>
{
    public CreateCompanyValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(120).WithMessage("Company name cannot exceed 120 characters.");

        RuleFor(c => c.UkNiu)
            .NotEmpty().WithMessage("UkNiu is required.");

        RuleFor(c => c.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

        RuleFor(c => c.Email)
            .NotEmpty().EmailAddress().WithMessage("Valid email is required.");

        RuleFor(c => c.CityId)
            .GreaterThan(0).WithMessage("Valid CityId is required.");
    }
}
