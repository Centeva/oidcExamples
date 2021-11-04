
using Ardalis.Specification;

namespace CentevaArchitecture.Domain.Interfaces
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IAggregateRoot
    {
    }
}
