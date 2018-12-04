using Microsoft.Extensions.DependencyInjection;
using Peikko.Service.Factories;
using Peikko.Service.Interfaces;

namespace Peikko.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRuleCollection<,>), typeof(RuleFactory<,>));
        }
    }
}
