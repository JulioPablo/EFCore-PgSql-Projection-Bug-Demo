using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore_PgSQL_Bug_Example.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EFCore_PgSQL_Bug_Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IHost BuildWebHost(string[] args)
        {
            var webHost = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                using (var context = services.GetRequiredService<CustomerContext>())
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                }
            }

            return webHost;
        }
    }
}
