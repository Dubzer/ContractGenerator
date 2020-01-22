using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ContractGenerator
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config => config.AddJsonFile("appsettings.json"))
                .UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration, "Serilog"))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel((context, options) =>
                        options.Configure(context.Configuration.GetSection("Kestrel")));
                });
    }
}