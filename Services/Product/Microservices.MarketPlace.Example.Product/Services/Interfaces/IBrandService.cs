using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Product.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Product.Services.Interfaces
{
    public interface IBrandService
    {
        Task<Response<List<BrandDto>>> GetAllAsync();

        Task<Response<BrandDto>> CreateAsync(BrandDto brandDto);

        Task<Response<BrandDto>> GetByIdAsync(string id);
    }
}
