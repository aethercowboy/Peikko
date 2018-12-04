using Microsoft.AspNetCore.Mvc;
using Peikko.Service.Interfaces;

namespace Peikko.Application.Controllers
{
    public class BaseController<TEntity, TService, TKey> : Controller
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
