using Peikko.DataAccess.EFCore.Contexts;
using Peikko.DataAccess.EFCore.Repositories;
using Sample.Domain.Interfaces;
using System;

namespace Sample.DataAccess.Repositories
{
    public class Repository<TEntity> : RepositoryAsync<TEntity, Guid>
        where TEntity : class, IEntity
    {
        public Repository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
