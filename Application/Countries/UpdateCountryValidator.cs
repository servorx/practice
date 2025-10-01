using Application.Countries;
using FluentValidation;

namespace Application.Countries;

public class UpdateCountryValidator : AbstractValidator<UpdateCountry>
{
    public UpdateCountryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");

        RuleFor(x => x.Name)
            .NotNull().WithMessage("Country name is required")
            .WithMessage("Country name cannot be empty");
    }
}
