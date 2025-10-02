using Api.DTOs;
using FluentValidation;

namespace Api.Validators;
public class CreateCityDtoValidator : AbstractValidator<CreateCityDto>
{
    public CreateCityDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.RegionId).NotEmpty();
    }
}
