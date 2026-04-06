using Ardalis.Specification.EntityFrameworkCore;
using Hotline.Domain.Interfaces;
using Hotline.Infrastructure.Database;

namespace Hotline.Infrastructure.Repositories;

public class Repository<T>(AppDbContext dbContext) : RepositoryBase<T>(dbContext), IRepository<T> where T: class
{
	
}
