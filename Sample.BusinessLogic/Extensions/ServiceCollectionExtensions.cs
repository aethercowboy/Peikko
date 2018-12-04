using Microsoft.Extensions.DependencyInjection;
using Peikko.BusinessLogic.Extensions;
using Sample.BusinessLogic.Services;

namespace Sample.BusinessLogic.Extensions
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
