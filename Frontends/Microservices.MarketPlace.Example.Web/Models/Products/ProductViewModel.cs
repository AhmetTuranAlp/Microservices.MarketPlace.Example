using System;

namespace Microservices.MarketPlace.Example.Web.Models.Products
{
    public class ProductViewModel
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string StockPictureUrl { get; set; }
        public string Image { get; set; }
        public BrandViewModel Brand { get; set; }
        public CategoryViewModel Category { get; set; }
        public decimal MarketPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal KDV { get; set; }
        public int Stock { get; set; }
        public int CurrencyType { get; set; }
        public int StatusType { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
