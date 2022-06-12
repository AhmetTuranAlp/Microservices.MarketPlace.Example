using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Web.Helpers;
using Microservices.MarketPlace.Example.Web.Models.Products;
using Microservices.MarketPlace.Example.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services
{

    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly IImageService _imageService;
        private readonly ImageHelper _imageHelper;

        public ProductService(HttpClient client, IImageService imageService, ImageHelper imageHelper)
        {
            _client = client;
            _imageService = imageService;
            _imageHelper = imageHelper;
        }

        public async Task<bool> CreateProductAsync(ProductCreateInput productCreateInput)
        {
            var resultPhotoService = await _imageService.UploadImage(productCreateInput.ImageFormFile);

            if (resultPhotoService != null)
            {
                productCreateInput.Image = resultPhotoService.Url;
            }

            var response = await _client.PostAsJsonAsync<ProductCreateInput>("products", productCreateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(string productId)
        {
            var response = await _client.DeleteAsync($"products/{productId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryViewModel>> GetAllBrandAsync()
        {
            var response = await _client.GetAsync("brands");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var response = await _client.GetAsync("categories");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<List<ProductViewModel>> GetAllProductAsync()
        {
            var response = await _client.GetAsync("products");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();
            responseSuccess.Data.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x.Image))
                    x.ImageUrl = _imageHelper.GetImageUrl(x.Image);
            });
            return responseSuccess.Data;
        }

        public async Task<List<ProductViewModel>> GetAllProductByUserIdAsync(string userId)
        {
            var response = await _client.GetAsync($"products/GetAllByUserId/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();

            responseSuccess.Data.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x.Image))
                    x.ImageUrl = _imageHelper.GetImageUrl(x.Image);
            });

            return responseSuccess.Data;
        }

        public async Task<ProductViewModel> GetByProductId(string productId)
        {
            var response = await _client.GetAsync($"products/{productId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ProductViewModel>>();

            responseSuccess.Data.ImageUrl = _imageHelper.GetImageUrl(responseSuccess.Data.Image);

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateProductAsync(ProductUpdateInput productUpdateInput)
        {
            var resultPhotoService = await _imageService.UploadImage(productUpdateInput.PhotoFormFile);

            if (resultPhotoService != null)
            {
                await _imageService.DeleteImage(productUpdateInput.Image);
                productUpdateInput.Image = resultPhotoService.Url;
            }

            var response = await _client.PutAsJsonAsync<ProductUpdateInput>("products", productUpdateInput);

            return response.IsSuccessStatusCode;
        }
    }
}
