using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Piekko.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddViews(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(o =>
            {
                o.ViewLocationFormats.Add("/Areas/Peikko/Views/{1}/{0}.cshtml");
                o.ViewLocationFormats.Add("/Areas/Peikko/Views/Shared/{0}.cshtml");
            });
        }
    }
}
