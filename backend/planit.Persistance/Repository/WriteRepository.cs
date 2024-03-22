using Microsoft.EntityFrameworkCore;
using planit.Application.Interfaces;
using planit.Domain.Base;
using planit.Persistance.Contexts;

namespace planit.Persistance.Repository;
public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntity, new()
{
    private readonly AppDbContext dbContext;

    public WriteRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private DbSet<T> Entities => dbContext.Set<T>();

    public async Task AddAsync(T entity)
    {
        await Entities.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Entities.AddRangeAsync(entities);
    }
    public async Task<T> UpdateAsync(T entity)
    {
        //update processes cannot be run asynchronously so we can combine it with Run
        await Task.Run(() => Entities.Update(entity));
        return entity;
    }

    public async Task HardDeleteAsync(T entity)
    {
        await Task.Run(() => Entities.Remove(entity));
    }
}
