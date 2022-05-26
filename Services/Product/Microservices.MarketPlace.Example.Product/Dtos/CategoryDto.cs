using System;

namespace Microservices.MarketPlace.Example.Product.Dtos
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MainCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int StatusType { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
