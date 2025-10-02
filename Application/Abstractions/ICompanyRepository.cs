using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;
public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Company>> GetByCityIdAsync(Guid cityId, CancellationToken ct = default);
    Task<IReadOnlyList<Company>> GetPagedAsync(int page, int size, string? q, CancellationToken ct = default);
    Task<int> CountAsync(string? q, CancellationToken ct = default);
    Task AddAsync(Company company, CancellationToken ct = default);
    Task UpdateAsync(Company company, CancellationToken ct = default);
    Task RemoveAsync(Company company, CancellationToken ct = default);
}