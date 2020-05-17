using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PhoneBook.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "UzcardBusiness Seller Api";
            Console.WriteLine($@"Process Id: {Process.GetCurrentProcess().Id}");    
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://*:6080").UseStartup<Startup>();
                });
    }
}
