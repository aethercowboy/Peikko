using Peikko.Application.Controllers;
using Sample.BusinessLogic.Services;
using System;

namespace Sample.Application.Controllers
{
    public class BaseController<TEntity, TService> : BaseController<TEntity, TService, Guid>
        where TService : IService<TEntity>
    {
        public BaseController(TService service) : base(service)
        {
        }
    }
}
