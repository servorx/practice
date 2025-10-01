

using FluentValidation;

namespace Application.Cities;

public class CreateCityValidator : AbstractValidator<CreateCity>
{
    public CreateCityValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("City name is required.")
            .MaximumLength(120).WithMessage("City name cannot exceed 120 characters.");

        RuleFor(c => c.RegionId)
            .GreaterThan(0).WithMessage("Valid RegionId is required.");
    }
}
