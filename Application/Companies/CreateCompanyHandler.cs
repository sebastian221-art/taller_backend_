using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Companies;
public sealed class CreateCompanyHandler(ICompanyRepository repo, Application.Abstractions.IUnitOfWork unitOfWork) : IRequestHandler<CreateCompany, Guid>
{
    public async Task<Guid> Handle(CreateCompany req, CancellationToken ct)
    {
        var company = new Company(req.Name, req.Nit, req.Address, req.Email)
        {
            CityId = req.CityId
        };

        await repo.AddAsync(company, ct);
        
        await unitOfWork.SaveChangesAsync(ct);
return company.Id;
    }
}
