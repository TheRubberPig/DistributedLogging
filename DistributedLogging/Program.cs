using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DistributedLogging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logTest = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logTest, new FileInfo("log4net.config"));
            var logger = LogManager.GetLogger(typeof(Program));
            logger.Info("Hello World");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
