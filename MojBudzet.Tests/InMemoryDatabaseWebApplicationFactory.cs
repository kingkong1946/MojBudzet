using LiteDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MojBudzet.Tests
{
    public class InMemoryDatabaseWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(LiteDatabase));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddSingleton(new LiteDatabase(new MemoryStream()));
            });

            base.ConfigureWebHost(builder);
        }
    }
}
