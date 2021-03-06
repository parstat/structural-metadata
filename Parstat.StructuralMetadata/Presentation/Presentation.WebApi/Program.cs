
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Presentation.Persistence;
using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;

namespace Presentation.WebApi
{
    public class Program
    {
         public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var structuralMetadataContext = services.GetRequiredService<StructuralMetadataDbContext>();
                    //structuralMetadataContext.Database.Migrate();
/* 
                    var identityContext = services.GetRequiredService<ApplicationDbContext>();
                    identityContext.Database.Migrate();
*/
                    var mediator = services.GetRequiredService<IMediator>();
                    //await mediator.Send(new SeedSampleDataCommand(), CancellationToken.None); 
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    if(env.IsProduction()) 
                    {
                        Console.WriteLine("Production...");
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                            //.AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true);
                    }

                    if (env.IsDevelopment())
                    {
                        Console.WriteLine("Development...");
                        config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                        if (appAssembly != null)
                        {
                            config.AddUserSecrets(appAssembly, optional: true);
                        }
                    }

                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .UseStartup<Startup>();
    }
}
