using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Peikko.DataAccess.EFCore.Extensions;
using Peikko.DataAccess.EFCore.SqlServer.Extensions;
using Piekko.Presentation.Extensions;
using Sample.BusinessLogic.Extensions;
using Sample.DataAccess.Contexts;
using Sample.DataAccess.Repositories;
using Sample.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            // Peikko code!
            services.AddSqlDAL<PeikkoDbContext>(Configuration.GetConnectionString("DefaultConnection"));
            //


            services.AddMvc();



            // Peikko code!
            services.AddRepositories<IEntity, Guid>(typeof(Repository<>));
            services.AddBusinessLogic();
            services.AddViews(new List<string>());
            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
