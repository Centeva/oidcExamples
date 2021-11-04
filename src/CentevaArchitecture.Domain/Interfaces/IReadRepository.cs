using Ardalis.Specification;

namespace CentevaArchitecture.Domain.Interfaces
{
    public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity> where TEntity : class, IAggregateRoot
    {
    }
}
