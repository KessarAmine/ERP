using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DevKbfSteel.Helpers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.IO;
using Autofac.Extensions.DependencyInjection;

namespace DevKbfSteel
{
    public class Program
    {

        public static void Main(string[] args)
        {
            XpertHelper.InitiRhConfig();
            var host = CreateHostBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory()).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.MaxConcurrentConnections = 100;
                serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
                serverOptions.Limits.MaxRequestBodySize = 10 * 1024;
                serverOptions.Limits.MinRequestBodyDataRate =
                    new MinDataRate(bytesPerSecond: 100,
                        gracePeriod: TimeSpan.FromSeconds(10));
                serverOptions.Limits.MinResponseDataRate =
                    new MinDataRate(bytesPerSecond: 100,
                        gracePeriod: TimeSpan.FromSeconds(10));
                serverOptions.Limits.KeepAliveTimeout =
                    TimeSpan.FromMinutes(2);
                serverOptions.Limits.RequestHeadersTimeout =
                    TimeSpan.FromMinutes(1);
            })
            .CaptureStartupErrors(true)
            .UseSetting("detailedErrors", "true")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIIS()
            .UseIISIntegration()
            .UseStartup<Startup>();
        });
    }
}
