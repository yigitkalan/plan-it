using planit.Application.Interfaces;
using planit.Persistance.Contexts;
using planit.Persistance.Repository;

namespace planit.Persistance.Getter;
public class RepositoryGetter : IRepositoryGetter
{
    private AppDbContext dbContext;


    public RepositoryGetter(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    IGenericRepository<T> IRepositoryGetter.GenericRepository<T>() => new GenericRepository<T>(dbContext);
}
