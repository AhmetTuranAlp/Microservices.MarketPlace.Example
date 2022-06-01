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

        public string GetPhotoStockUrl(string photoUrl)
        {
            return $"{_serviceApiSettings.ImageUri}/photos/{photoUrl}";
        }
    }
}
