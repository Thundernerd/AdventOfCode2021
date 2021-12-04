using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AdventOfCode2021
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            IHost build = CreateHostBuilder(args).Build();
            PuzzleSolver puzzleSolver = build.Services.GetRequiredService<PuzzleSolver>();
            await puzzleSolver.Run(CancellationToken.None);
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((_, configuration) =>
                {
                    configuration
                        .MinimumLevel.Debug()
                        .WriteTo.Console();
                })
                .ConfigureServices((_, services) =>
                {
                    services
                        .AddTransient<PuzzleSolver>()
                        .AddHttpClient()
                        .AddTransient<PuzzleDownloader>()
                        .AddServicesThatImplementInterface<IPuzzle>()
                        .AddCustomServices();
                });

        private static IServiceCollection AddServicesThatImplementInterface<TInterface>(
            this IServiceCollection services)
        {
            IEnumerable<Type> types = typeof(TInterface).Assembly.GetTypes()
                .Where(x => typeof(TInterface).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface);

            foreach (Type type in types)
            {
                services.AddTransient(typeof(TInterface), type);
            }

            return services;
        }
        
        private static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            IEnumerable<Type> types = typeof(ICustomServiceBuilder).Assembly.GetTypes()
                .Where(x => typeof(ICustomServiceBuilder).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface);
        
            foreach (Type type in types)
            {
                ICustomServiceBuilder builder = (ICustomServiceBuilder)Activator.CreateInstance(type);
                builder.Build(services);
            }
        
            return services;
        }
    }
}