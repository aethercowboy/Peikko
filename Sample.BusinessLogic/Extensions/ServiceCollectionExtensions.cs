using Microsoft.Extensions.DependencyInjection;
using Peikko.Service.Extensions;
using Peikko.Service.PeikkoService.Services;

namespace Peikko.Service.PeikkoService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPeikkoServiceInjections(this IServiceCollection services)
        {
            services.AddServiceInjection();

            services.AddScoped<IPublisherService, PublisherService>();
        }
    }
}
