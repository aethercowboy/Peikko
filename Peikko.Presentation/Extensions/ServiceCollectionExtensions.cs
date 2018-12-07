using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Piekko.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddViews(this IServiceCollection services, IEnumerable<string> paths)
        {
            services.Configure<RazorViewEngineOptions>(o =>
            {
                o.ViewLocationFormats.Clear();

                foreach (var path in paths)
                {
                    o.ViewLocationFormats.Add(path);
                }

                o.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
                o.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
                o.ViewLocationFormats.Add("/Pages/Shared/{0}.cshtml");
            });
        }
    }
}
