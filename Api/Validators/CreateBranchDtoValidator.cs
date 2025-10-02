using Api.DTOs;
using FluentValidation;

namespace Api.Validators;
public class CreateBranchDtoValidator : AbstractValidator<CreateBranchDto>
{
    public CreateBranchDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CompanyId).NotEmpty();
        RuleFor(x => x.CityId).NotEmpty();
    }
}
