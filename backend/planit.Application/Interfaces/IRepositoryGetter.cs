using planit.Domain.Base;

namespace planit.Application.Interfaces;
public interface IRepositoryGetter
{
    IGenericRepository<T> GenericRepository<T>() where T: class, IEntity, new();

}
