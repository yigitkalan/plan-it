using planit.Domain.Base;

namespace planit.Application.Abstractions;
public interface IRepositoryGetter
{
    IGenericRepository<T> GenericRepository<T>() where T:class, IEntity, new();

}
