using Peikko.Domain.PeikkoDomain.Interfaces;
using Peikko.Repository.Interfaces;
using Peikko.Service.Interfaces;
using Peikko.Service.Services;
using System;

namespace Peikko.Service.PeikkoService.Services
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
