using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Configuration;
using WebApi.Domain.Queries;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<ApplicationConfiguration>(Configuration);

            services.AddMvc();
            
            // Configuration
            services.AddTransient<DbConnectionFactory, DbConnectionFactory>();
            services.AddTransient<EvolveConfiguration, EvolveConfiguration>();
            
            // Services
            services.AddTransient<DapperService, DapperService>();
            
            // Domain
            services.AddTransient<GetProductsQuery, GetProductsQuery>();
            services.AddTransient<SearchProductsQuery, SearchProductsQuery>();
            services.AddTransient<GetProductBundlesQuery, GetProductBundlesQuery>();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
            app.ApplicationServices.GetService<EvolveConfiguration>().Migrate();
        }
    }
}
