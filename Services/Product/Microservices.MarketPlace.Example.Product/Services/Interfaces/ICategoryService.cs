using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Product.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Product.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);

        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
