using System.Linq.Expressions;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Hotline.Domain.Interfaces;
using Hotline.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hotline.Infrastructure.Repositories;

public class Repository<T>(AppDbContext  dbContext) : RepositoryBase<T>(dbContext), IRepository<T>
    where T : class
{
    public async Task<IReadOnlyList<TResult>> ListBySpecAndProjAsync<TResult>(
        ISpecification<T> spec, 
        Expression<Func<T, TResult>> projection, 
        CancellationToken ct = default)
    {
        return await ApplySpecification(spec)
            .Select(projection)
            .ToListAsync(ct);
    }
}
