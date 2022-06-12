using Microservices.MarketPlace.Example.Web.Models;
using Microsoft.Extensions.Options;

namespace Microservices.MarketPlace.Example.Web.Helpers
{
    public class ImageHelper
    {
        private readonly ServiceApiSettings _serviceApiSettings;

        public ImageHelper(IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public string GetImageUrl(string imageUrl)
        {
            return $"{_serviceApiSettings.ImageUri}/images/{imageUrl}";
        }
    }
}
