using Peikko.Domain.PeikkoDomain.Models;
using Peikko.Repository.Interfaces;
using Peikko.Service.Interfaces;
using System;

namespace Peikko.Service.PeikkoService.Services
{
    public interface IPublisherService : IService<Publisher>
    {

    }

    public class PublisherService : Service<Publisher>, IPublisherService
    {
        public PublisherService(IRepository<Publisher, Guid> repository, IRuleCollection<Publisher, Guid> rules) : base(repository, rules)
        {
        }
    }
}
