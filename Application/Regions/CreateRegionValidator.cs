using FluentValidation;

namespace Application.Regions;

public class CreateRegionValidator : AbstractValidator<CreateRegion>
{
    public CreateRegionValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Region name is required.")
            .MaximumLength(100).WithMessage("Region name cannot exceed 100 characters.");

        RuleFor(r => r.CountryId)
            .GreaterThan(0).WithMessage("Valid CountryId is required.");
    }
}
