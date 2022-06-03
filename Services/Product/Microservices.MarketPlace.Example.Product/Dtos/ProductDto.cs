using System;
using System.Collections.Generic;

namespace Microservices.MarketPlace.Example.Product.Dtos
{
    public class ProductDto
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string StockPictureUrl { get; set; }
        public BrandDto Brand { get; set; }
        public CategoryDto Category { get; set; }
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
