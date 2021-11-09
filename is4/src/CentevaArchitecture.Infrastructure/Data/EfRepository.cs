using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using CentevaArchitecture.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CentevaArchitecture.Infrastructure.Data
{
    public class EfRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity>, IReadRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        public EfRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
