using IssueTracker.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace issueTracker.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                 .Build()
                 .MigrateDatabase<ApplicationDbContext>((context, services) =>
                 {
                     var logger = services.GetService<ILogger<OrderContextSeed>>();
                     OrderContextSeed
                         .SeedAsync(context, logger)
                         .Wait();
                 })
                 .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
