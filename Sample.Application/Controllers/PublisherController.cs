using Sample.BusinessLogic.Services;
using Sample.Domain.Models;

namespace Sample.Application.Controllers
{
    public class PublisherController : BaseController<Publisher, IPublisherService>
    {
        public PublisherController(IPublisherService service) : base(service)
        {
        }
    }
}
