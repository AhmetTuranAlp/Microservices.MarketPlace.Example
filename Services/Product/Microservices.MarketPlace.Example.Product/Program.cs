using Microservices.MarketPlace.Example.Product.Enumeration;
using Microservices.MarketPlace.Example.Product.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Product
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    var host = CreateHostBuilder(args).Build();

        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var serviceProvider = scope.ServiceProvider;

        //        var productService = serviceProvider.GetRequiredService<IProductService>();

        //        if (!productService.GetAllAsync().Result.Data.Any())
        //        {
        //            productService.CreateAsync(
        //                new Dtos.ProductDto
        //                {
        //                    Name = "Iphone 12 Plus",
        //                    SalePrice = 12,
        //                    MarketPrice = 14,
        //                    CurrencyType = Convert.ToInt32(Currency.CurrencyType.TRY),
        //                    Description="des",
        //                    ShortDescription= "sDes",
        //                    StatusType = Convert.ToInt32(Status.StatusType.NewRecord),
        //                    UploadDate = new DateTime(),
        //                    Stock = 10,
        //                    KDV = 10,
        //                    ProductId = "sdas",
        //                    Brand = new Dtos.BrandDto()
        //                    {
        //                        BrandId = 1,
        //                        Name = "Apple",
        //                        StatusType = Convert.ToInt32(Status.StatusType.NewRecord),
        //                        UploadDate = new DateTime()
        //                    },
        //                    Category = new Dtos.CategoryDto() 
        //                    { 
        //                        Name = "Notebook",
        //                        StatusType = Convert.ToInt32(Status.StatusType.NewRecord),
        //                        UploadDate = new DateTime(),
        //                        MainCategoryId = 0,
        //                        CategoryId = 1
        //                    }
        //                }).Wait();
        //        }
        //    }

        //    host.Run();
        //}

        public static void Main(string[] args)
        {
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
