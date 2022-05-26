using Microservices.MarketPlace.Example.Basket.Dtos;
using Microservices.MarketPlace.Example.CommonUses.Result;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Basket.Services.Interfaces
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);

        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

        Task<Response<bool>> Delete(string userId);
    }
}
