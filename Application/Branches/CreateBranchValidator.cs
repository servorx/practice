using FluentValidation;

namespace Application.Branches;

public class CreateBranchValidator : AbstractValidator<CreateBranch>
{
    public CreateBranchValidator()
    {
        RuleFor(b => b.NumberCommercial)
            .NotEmpty().WithMessage("Branch commercial number is required.");

        RuleFor(b => b.Address)
            .NotEmpty().WithMessage("Branch address is required.")
            .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

        RuleFor(b => b.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(b => b.ContactName)
            .NotEmpty().WithMessage("Contact name is required.")
            .MaximumLength(120).WithMessage("Contact name cannot exceed 120 characters.");

        RuleFor(b => b.Phone)
            .NotEmpty().WithMessage("Phone number is required.");

        RuleFor(b => b.CityId)
            .GreaterThan(0).WithMessage("Valid CityId is required.");

        RuleFor(b => b.CompanyId)
            .GreaterThan(0).WithMessage("Valid CompanyId is required.");
    }
}
