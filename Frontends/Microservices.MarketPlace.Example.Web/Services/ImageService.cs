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

        public async Task<bool> DeleteImage(string imageUrl)
        {
            var response = await _httpClient.DeleteAsync($"image?imageUrl={imageUrl}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ImageViewModel> UploadImage(IFormFile image)
        {
            if (image == null || image.Length <= 0)
            {
                return null;
            }
            var randonFilename = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

            using var ms = new MemoryStream();

            await image.CopyToAsync(ms);

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
