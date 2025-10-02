using Api.DTOs;
using Api.DTOs.Branch;
using FluentValidation;

namespace Api.Validators;
public class CreateBranchDtoValidator : AbstractValidator<CreateBranchDto>
{
    public CreateBranchDtoValidator()
    {
        RuleFor(x => x.ContactName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CompanyId).NotEmpty();
        RuleFor(x => x.CityId).NotEmpty();
    }
}
