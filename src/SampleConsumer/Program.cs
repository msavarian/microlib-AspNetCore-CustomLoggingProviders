using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomLogProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace SampleConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureLogging((context,logging) =>
                {
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));

                    logging.ClearProviders();

                    // add builtin providers

                    logging.AddConsole();

                    logging.AddDebug();

                    // add my own log provider
                    logging.AddFileLogger(options =>
                    {
                        options.MaxFileSizeInMB = 5;
                    });
                })


                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}