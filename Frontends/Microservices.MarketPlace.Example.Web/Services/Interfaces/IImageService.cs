using Microservices.MarketPlace.Example.Web.Models.Images;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services.Interfaces
{
    public interface IImageService
    {
        Task<ImageViewModel> UploadPhoto(IFormFile photo);

        Task<bool> DeletePhoto(string photoUrl);
    }
}
