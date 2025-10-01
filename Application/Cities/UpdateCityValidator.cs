using FluentValidation;

namespace Application.Cities;

public class UpdateCityValidator : AbstractValidator<UpdateCity>
{
    public UpdateCityValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0).WithMessage("City Id must be greater than 0.");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("City name is required.")
            .MaximumLength(120).WithMessage("City name cannot exceed 120 characters.");

        RuleFor(c => c.RegionId)
            .GreaterThan(0).WithMessage("Valid RegionId is required.");
    }
}
