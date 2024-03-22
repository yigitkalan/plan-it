using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using planit.Domain.Base;

namespace planit.Application.Interfaces;
public interface IGenericRepository<T> where T : class, IEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
     Func<IQueryable<T>, IIncludableQueryable<T,object>>? include = null,
     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
     bool enableTracking = false);

    Task<List<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
     Func<IQueryable<T>, IIncludableQueryable<T,object>>? include = null,
     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
     bool enableTracking = false , int pageSize = 5, int currentPage = 1);

    Task<T> GetAsync(Expression<Func<T, bool>> predicate,
     Func<IQueryable<T>, IIncludableQueryable<T,object>>? include = null,
     bool enableTracking = false );

    IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);


    Task AddAsync(T entity);

    Task AddRangeAsync(IList<T> entities);

    Task<T> UpdateAsync(T entity);

    Task HardDeleteAsync(T entity);

}
