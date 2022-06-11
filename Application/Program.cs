using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API_TTTN
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();

            var configurations = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            new WebHostBuilder()
                .UseConfiguration(configurations)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build()
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
