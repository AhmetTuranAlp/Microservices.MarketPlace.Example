using Microservices.MarketPlace.Example.Web.Models.Images;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services.Interfaces
{
    public interface IImageService
    {
        Task<ImageViewModel> UploadImage(IFormFile iamge);

        Task<bool> DeleteImage(string imageUrl);
    }
}
