namespace Microservices.MarketPlace.Example.Product.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string BrandColletionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
