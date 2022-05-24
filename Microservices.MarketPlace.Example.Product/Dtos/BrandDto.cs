using System;

namespace Microservices.MarketPlace.Example.Product.Dtos
{
    public class BrandDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int StatusType { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
