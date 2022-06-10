using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Web.Models.Images;
using Microservices.MarketPlace.Example.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services
{
    public class ImageService : IImageService
    {
        private readonly HttpClient _httpClient;

        public ImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeletePhoto(string photoUrl)
        {
            var response = await _httpClient.DeleteAsync($"image?imageUrl={photoUrl}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ImageViewModel> UploadPhoto(IFormFile photo)
        {
            if (photo == null || photo.Length <= 0)
            {
                return null;
            }
            var randonFilename = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";

            using var ms = new MemoryStream();

            await photo.CopyToAsync(ms);

            var multipartContent = new MultipartFormDataContent();

            //image ismi microservis tarafında controller da belirnen parametre ismi verildi.
            multipartContent.Add(new ByteArrayContent(ms.ToArray()), "image", randonFilename);
            //image ismi microservis tarafında controller adı.
            var response = await _httpClient.PostAsync("image", multipartContent);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ImageViewModel>>();

            return responseSuccess.Data;
        }
    }
}
