using Microsoft.AspNetCore.Mvc;
using Peikko.Application.Attributes;
using Sample.BusinessLogic.Services;
using Sample.Domain.Models;
using System.Threading.Tasks;

namespace Sample.Application.Controllers
{
    [MenuItem]
    public class PublisherController : BaseController<Publisher, IPublisherService>
    {
        public PublisherController(IPublisherService service) : base(service)
        {
        }

        public async Task<IActionResult> Test()
        {
            return View();
        }
    }
}
