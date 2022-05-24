namespace Microservices.MarketPlace.Example.Product.Models
{
    public class Category : Base
    {
        public string Name { get; set; }
        public int MainCategoryId { get; set; }
        public int CategoryId { get; set; }
    }
}
