using Ardalis.Specification;
using Hotline.Domain.Entities;
using Hotline.Domain.Shared;

namespace Hotline.Domain.Interfaces;

public interface IRepository<T>: IRepositoryBase<T> where T: class
{
}
