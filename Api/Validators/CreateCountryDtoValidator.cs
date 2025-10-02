using Api.DTOs;
using Api.DTOs.Country;
using FluentValidation;

namespace Api.Validators;
public class CreateCountryDtoValidator : AbstractValidator<CreateCountryDto>
{
    public CreateCountryDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
