using Microservices.MarketPlace.Example.Web.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProductAsync();

        Task<List<CategoryViewModel>> GetAllCategoryAsync();

        Task<List<CategoryViewModel>> GetAllBrandAsync();

        Task<List<ProductViewModel>> GetAllProductByUserIdAsync(string userId);

        Task<ProductViewModel> GetByProductId(string productId);

        Task<bool> CreateProductAsync(ProductCreateInput productCreateInput);

        Task<bool> UpdateProductAsync(ProductUpdateInput productUpdateInput);

        Task<bool> DeleteProductAsync(string productId);
    }
}
