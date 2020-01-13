namespace MojBudzet
{
    using LiteDB;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MojBudzet.BussinessLayer.Application.Budget;
    using MojBudzet.BussinessLayer.Domain.Budget;
    using MojBudzet.BussinessLayer.Domain.Exception;
    using MojBudzet.BussinessLayer.Infrastructure.Budget;
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Startup application class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Application key/value properties.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Registered services collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddLogging();

            services.AddTransient<BudgetService, BudgetLocalService>();
            services.AddSingleton<MonthlyBudgetFactory>();
            services.AddSingleton<Repository<MonthlyBudgetAggregate>, LiteDbMonthlyBudgetRepository>();
            services.AddSingleton(new LiteDatabase("database.db"));

            //services.AddSingleton<ExceptionMiddleware>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Configure application.</param>
        /// <param name="env">Application enviroment information.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseExceptionHandler(configure => configure.Run(async context => await HandleException(context)));

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private static async Task HandleException(HttpContext context)
        {
            var exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandler.Error is MonthlyBudgetExistsException mbee)
            {
                var response = context.Response;
                response.StatusCode = StatusCodes.Status400BadRequest;

                var responseMessage = new
                {
                    Error = true,
                    Message = mbee.Message,
                };

                await response.WriteAsync(JsonConvert.SerializeObject(responseMessage));
            }
        }
    }
}
