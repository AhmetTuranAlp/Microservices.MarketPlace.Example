using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Microservices.MarketPlace.Example.Web.Models.Products
{
    public class ProductUpdateInput
    {
        public string Id { get; set; }
        public string ProductId { get; set; }

        [Display(Name = "Ürün İsmi")]
        public string Name { get; set; }

        [Display(Name = "Ürün Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Ürün Fiyat")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Ürün Stok")]
        public int Stock { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }


        [Display(Name = "Ürün Kategori")]
        public string CategoryId { get; set; }

        [Display(Name = "Ürün Marka")]
        public string BrandId { get; set; }

        [Display(Name = "Ürün Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
