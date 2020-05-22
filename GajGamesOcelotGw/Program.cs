using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

namespace GajGamesOcelotGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, config) =>
                {
                    config
                        .SetBasePath(context.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json",
                            true, true)
                        .AddJsonFile("configuration.json")
                        .AddEnvironmentVariables();
                })                
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                })
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build()
                .Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();

        //public static IWebHost BuildWebHost(string[] args)
        //{
        //    var builder = WebHost.CreateDefaultBuilder(args);

        //    builder.ConfigureServices(s => s.AddSingleton(builder))
        //           .UseKestrel()
        //           .ConfigureAppConfiguration(config =>
        //           {
        //               config.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
        //           })
        //           .UseStartup<Startup>();
                   

        //    var host = builder.Build();
        //    return host;
        //}
    }
}
