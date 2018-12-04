using Peikko.Application.Controllers;
using Peikko.Service.PeikkoService.Services;
using System;

namespace Peikko.Application.PeikkoApplication.Controllers
{
    public class BaseController<TEntity, TService> : BaseController<TEntity, TService, Guid>
        where TService : IService<TEntity>
    {
        public BaseController(TService service) : base(service)
        {
        }
    }
}
