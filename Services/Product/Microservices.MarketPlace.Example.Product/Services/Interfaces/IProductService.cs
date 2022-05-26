using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Product.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Product.Services.Interfaces
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();

        Task<Response<ProductDto>> GetByIdAsync(string id);

        Task<Response<ProductDto>> CreateAsync(ProductDto productDto);

        Task<Response<NoContent>> UpdateAsync(ProductDto productDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
