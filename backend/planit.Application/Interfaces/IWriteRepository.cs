using planit.Domain.Base;

namespace planit.Application.Interfaces;
public interface IWriteRepository<T> where T: class, IEntity, new()
{
    Task AddAsync(T entity);

    Task AddRangeAsync(IList<T> entities);

    Task<T> UpdateAsync(T entity);

    Task HardDeleteAsync(T entity);
}
