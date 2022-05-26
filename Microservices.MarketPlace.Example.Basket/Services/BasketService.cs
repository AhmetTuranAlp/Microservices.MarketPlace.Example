using Microservices.MarketPlace.Example.Basket.Dtos;
using Microservices.MarketPlace.Example.Basket.Services.Interfaces;
using Microservices.MarketPlace.Example.CommonUses.Result;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(StaticValue._successReturnNotModelId) : Response<bool>.Fail(StaticValue._basketNotFound, StaticValue._notFoundId);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if (String.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail(StaticValue._basketNotFound, StaticValue._notFoundId);
            }

            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), StaticValue._successReturnModelId);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));

            return status ? Response<bool>.Success(StaticValue._successReturnNotModelId) : Response<bool>.Fail(StaticValue._basketCouldNot, StaticValue._couldNot);
        }
    }
}
