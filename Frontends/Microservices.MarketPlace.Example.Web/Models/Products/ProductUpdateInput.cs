using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Microservices.MarketPlace.Example.Web.Models.Products
{
    public class ProductUpdateInput
    {
        public string Id { get; set; }
        public string ProductId { get; set; }

        [Display(Name = "Ürün ismi")]
        public string Name { get; set; }

        [Display(Name = "Ürün açıklama")]
        public string Description { get; set; }

        [Display(Name = "Ürün fiyat")]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }


        [Display(Name = "Ürün kategori")]
        public string CategoryId { get; set; }

        [Display(Name = "Ürün Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
