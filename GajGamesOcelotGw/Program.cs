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

namespace GajGamesOcelotGw
{
    public class Program
    {
        public static void Main(string[] args)
        {                          
            BuildWebHost(args).Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();

        public static IWebHost BuildWebHost(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            builder.ConfigureServices(s => s.AddSingleton(builder))
                   .UseKestrel()
                   .ConfigureAppConfiguration(config =>
                   {                    
                       config.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
                   })
                   .UseStartup<Startup>()
                   .UseUrls("http://localhost:5500");

            var host = builder.Build();
            return host;
        }
    }
}
