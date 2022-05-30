using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        #region Uygulamanın ayağa kalktığı ortama ait configuration dosyasının tanımlaması yapılmıştır.
        public static IHostBuilder CreateHostBuilder(string[] args) =>

         Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
         {
             config.AddJsonFile($"configuration.{hostingContext.HostingEnvironment.EnvironmentName.ToLower()}.json").AddEnvironmentVariables();
         })
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.UseStartup<Startup>();
         }); 
        #endregion
    }
}
