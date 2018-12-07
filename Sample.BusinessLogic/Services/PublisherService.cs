using Peikko.BusinessLogic.Interfaces;
using Peikko.DataAccess.Interfaces;
using Sample.Domain.Models;
using System;

namespace Sample.BusinessLogic.Services
{
    public interface IPublisherService : IService<Publisher>
    {

    }

    public class PublisherService : Service<Publisher>, IPublisherService
    {
        public PublisherService(IRepositoryAsync<Publisher, Guid> repository, IRuleCollection<Publisher, Guid> rules) : base(repository, rules)
        {
        }
    }
}
