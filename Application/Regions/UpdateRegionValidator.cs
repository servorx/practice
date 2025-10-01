using FluentValidation;

namespace Application.Regions;

public class UpdateRegionValidator : AbstractValidator<UpdateRegion>
{
    public UpdateRegionValidator()
    {
        RuleFor(r => r.Id)
            .GreaterThan(0).WithMessage("Region Id must be greater than 0.");

        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Region name is required.")
            .MaximumLength(100).WithMessage("Region name cannot exceed 100 characters.");

        RuleFor(r => r.IdCountry)
            .GreaterThan(0).WithMessage("Valid CountryId is required.");
    }
}
