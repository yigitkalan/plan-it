using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using planit.Application.Interfaces;
using planit.Domain.Base;
using planit.Persistance.Contexts;

namespace planit.Persistance.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
{
    private readonly AppDbContext dbContext;

    public GenericRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private DbSet<T> Entities => dbContext.Set<T>();

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>,
     IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
      bool enableTracking = false)
    {
        IQueryable<T> queryable = Entities;
        //since we're just reading the data, we don't need to track the changes
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToListAsync();

        await dbContext.SaveChangesAsync();    
        return await queryable.ToListAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> queryable = Entities.AsNoTracking();
        if (predicate != null)
            return await queryable.CountAsync(predicate);

        await dbContext.SaveChangesAsync();    
        return await queryable.CountAsync();
    }


    public async Task<List<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int pageSize = 5, int currentPage = 1)
    {
        IQueryable<T> queryable = Entities;
        //since we're just reading the data, we don't need to track the changes
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

        await dbContext.SaveChangesAsync();    
        return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Entities;
        //since we're just reading the data, we don't need to track the changes
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        queryable = queryable.Where(predicate);

        await dbContext.SaveChangesAsync();    
        return await queryable.FirstOrDefaultAsync();
    }

    public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        IQueryable<T> queryable = Entities;
        if (!enableTracking)
            queryable = Entities.AsNoTracking();
        await dbContext.SaveChangesAsync();    
        return queryable.Where(predicate);
    }

    public async Task AddAsync(T entity)
    {
        await Entities.AddAsync(entity);
        await dbContext.SaveChangesAsync();    
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Entities.AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();    
    }
    public async Task<T> UpdateAsync(T entity)
    {
        //update processes cannot be run asynchronously so we can combine it with Run
        await Task.Run(() => Entities.Update(entity));
        await dbContext.SaveChangesAsync();    
        return entity;
    }

    public async Task HardDeleteAsync(T entity)
    {
        await Task.Run(() => Entities.Remove(entity));
        await dbContext.SaveChangesAsync();    
    }
}