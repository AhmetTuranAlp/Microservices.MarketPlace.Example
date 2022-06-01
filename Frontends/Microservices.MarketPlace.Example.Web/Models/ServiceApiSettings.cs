namespace Microservices.MarketPlace.Example.Web.Models
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public string ImageUri { get; set; }
        public ServiceApi Product { get; set; }
        public ServiceApi Image { get; set; }
        public ServiceApi Basket { get; set; }
        public ServiceApi Discount { get; set; }
        public ServiceApi Payment { get; set; }
        public ServiceApi Order { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
