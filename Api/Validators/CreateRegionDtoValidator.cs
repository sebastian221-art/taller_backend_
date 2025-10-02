using Api.DTOs;
using Api.DTOs.Region;
using FluentValidation;

namespace Api.Validators;
public class CreateRegionDtoValidator : AbstractValidator<CreateRegionDto>
{
    public CreateRegionDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CountryId).NotEmpty();
    }
}
