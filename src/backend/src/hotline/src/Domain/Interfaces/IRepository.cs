using System.Linq.Expressions;
using Ardalis.Specification;

namespace Hotline.Domain.Interfaces;

public interface IRepository<T>: IRepositoryBase<T> where T: class
{
    Task<IReadOnlyList<TResult>> ListBySpecAndProjAsync<TResult>(
        ISpecification<T> spec,
        Expression<Func<T, TResult>> projection,
        CancellationToken ct = default);
}
