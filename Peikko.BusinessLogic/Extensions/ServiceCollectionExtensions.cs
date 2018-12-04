using Microsoft.Extensions.DependencyInjection;
using Peikko.BusinessLogic.Factories;
using Peikko.BusinessLogic.Interfaces;

namespace Peikko.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRuleCollection<,>), typeof(RuleFactory<,>));
        }
    }
}
