using Application.Countries;
using FluentValidation;

namespace Application.Countries;

public class CreateCountryValidator : AbstractValidator<CreateCountry>
{
    public CreateCountryValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Country name is required")
            .WithMessage("Country name cannot be empty");
    }
}
