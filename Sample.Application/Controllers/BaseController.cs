using Microsoft.AspNetCore.Mvc.Filters;
using Peikko.Application.Controllers;
using Sample.BusinessLogic.Services;
using System;

namespace Sample.Application.Controllers
{
    public class BaseController : Peikko.Application.Controllers.BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ViewData["SiteName"] = "Sample";
        }
    }

    public class BaseController<TEntity, TService> : BaseController<TEntity, TService, Guid>
        where TService : IService<TEntity>
    {
        public BaseController(TService service) : base(service)
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ViewData["SiteName"] = "Sample";
        }
    }
}
