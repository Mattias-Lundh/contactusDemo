using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web.AspNetCore;
using Microsoft.Extensions.Logging;
using NLog.Web;
using NLog;

namespace ContactusDemo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var logger = NLogBuilder.ConfigureNLog("").GetCurrentClassLogger();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog()
                .Build();
    }
}
