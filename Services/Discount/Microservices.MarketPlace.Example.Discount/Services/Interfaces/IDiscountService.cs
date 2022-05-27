using Microservices.MarketPlace.Example.CommonUses.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Discount.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<Response<List<Dtos.DiscountDto>>> GetAll();

        Task<Response<Dtos.DiscountDto>> GetById(int id);

        Task<Response<NoContent>> Save(Dtos.DiscountDto discount);

        Task<Response<NoContent>> Update(Dtos.DiscountDto discount);

        Task<Response<NoContent>> Delete(int id);

        Task<Response<Dtos.DiscountDto>> GetByCodeAndUserId(string code, string userId);
    }
}
