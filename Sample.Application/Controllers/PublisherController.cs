using Peikko.Domain.PeikkoDomain.Models;
using Peikko.Service.PeikkoService.Services;

namespace Peikko.Application.PeikkoApplication.Controllers
{
    public class PublisherController : BaseController<Publisher, IPublisherService>
    {
        public PublisherController(IPublisherService service) : base(service)
        {
        }
    }
}
