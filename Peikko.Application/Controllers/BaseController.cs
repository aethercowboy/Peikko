using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Peikko.BusinessLogic.Interfaces;

namespace Peikko.Application.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ViewData["SiteName"] = "Peikko";
        }
    }

    public class BaseController<TEntity, TService, TKey> : BaseController
        where TService : IService<TEntity, TKey>
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
