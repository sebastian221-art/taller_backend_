using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private ICountryRepository? _countryRepository;
    private IRegionRepository? _regionRepository;
    private ICityRepository? _cityRepository;
    private ICompanyRepository? _companyRepository;
    private IBranchRepository? _branchRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public Task<int> SaveChangesAsync(CancellationToken ct = default)
        => _context.SaveChangesAsync(ct);
    public async Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken ct = default)
    {
        await using var tx = await _context.Database.BeginTransactionAsync(ct);
        try
        {
            await operation(ct);
            await _context.SaveChangesAsync(ct);
            await tx.CommitAsync(ct);
        }
        catch
        {
            await tx.RollbackAsync(ct);
            throw;
        }
    }
    // public IProductRepository Products
    // {
    //     get
    //     {
    //         if (_productRepository == null)
    //         {
    //             _productRepository = new ProductRepository(_context);
    //         }
    //         return _productRepository;
    //     }
    // }
    public ICountryRepository Countries => _countryRepository ??= new CountryRepository(_context);

    public IRegionRepository Regions => _regionRepository ??= new RegionRepository(_context);
    public ICityRepository Cities => _cityRepository ??= new CityRepository(_context);
    public ICompanyRepository Companies => _companyRepository ??= new CompanyRepository(_context);
    public IBranchRepository Branches => _branchRepository ??= new BranchRepository(_context);
    

}
