using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using MaryShoppins.Infrastructure.Data;
using MaryShoppins.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace MaryShoppins.PublicApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(new Serilog.Formatting.Compact.RenderedCompactJsonFormatter(), "../../logs/publicapi.log")
                .CreateLogger();

            var host = CreateHostBuilder(args)
                        .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var catalogContext = services.GetRequiredService<CatalogContext>();
                    await CatalogContextSeed.SeedAsync(catalogContext, loggerFactory);

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await AppIdentityDbContextSeed.SeedAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
