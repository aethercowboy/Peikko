using Peikko.BusinessLogic.Interfaces;
using Peikko.BusinessLogic.Services;
using Peikko.DataAccess.Interfaces;
using Sample.Domain.Interfaces;
using System;

namespace Sample.BusinessLogic.Services
{
    public interface IService<TEntity> : IService<TEntity, Guid>
    {

    }

    public class Service<TEntity> : Service<TEntity, Guid>
        where TEntity : class, IEntity
    {
        public Service(IRepository<TEntity, Guid> repository, IRuleCollection<TEntity, Guid> rules) : base(repository, rules)
        {
        }
    }
}
