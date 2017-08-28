using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using WebApi.Configuration;
using WebApi.Domain.Commands;
using WebApi.Domain.Queries;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .CreateLogger();
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
            services.AddTransient<CreateOrderCommand, CreateOrderCommand>();
            services.AddTransient<AddProductToOrderCommand, AddProductToOrderCommand>();
            services.AddTransient<GetOrderByIdQuery, GetOrderByIdQuery>();
            services.AddTransient<AddBundleToOrderCommand, AddBundleToOrderCommand>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddSerilog();

            app.UseMvc();

            app.ApplicationServices.GetService<EvolveConfiguration>().Migrate();
        }
    }
}