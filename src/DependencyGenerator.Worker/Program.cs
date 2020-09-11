using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyGenerator.Worker.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace DependencyGenerator.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<InternalServerErrorDependencyGeneratorJob>();
                    services.AddHostedService<PaymentRequiredDependencyGeneratorJob>();
                    services.AddHostedService<TooManyRequestsDependencyGeneratorJob>();
                    services.AddHostedService<OkDependencyGeneratorJob>();
                })
                .UseSerilog(UpdateLoggerConfiguration);


        private static void UpdateLoggerConfiguration(HostBuilderContext hostBuilderContext, LoggerConfiguration currentLoggerConfiguration)
        {
            currentLoggerConfiguration
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithVersion()
                .Enrich.WithComponentName("Promitor Generator")
                .WriteTo.Console()
                .WriteTo.AzureApplicationInsights("<application-insights-key>");
        }
    }
}
