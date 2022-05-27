using Dapper;
using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Discount.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;

            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where id=@Id", new { Id = id });

            return status > 0 ? Response<NoContent>.Success(StaticValue._successReturnNotModelId) : Response<NoContent>.Fail(StaticValue._discountNotFound, StaticValue._notFoundId);
        }

        public async Task<Response<List<Dtos.DiscountDto>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Dtos.DiscountDto>("Select * from discount");

            return Response<List<Dtos.DiscountDto>>.Success(discounts.ToList(), StaticValue._successReturnModelId);
        }

        public async Task<Response<Dtos.DiscountDto>> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _dbConnection.QueryAsync<Dtos.DiscountDto>("select * from discount where userid=@UserId and code=@Code", new { UserId = userId, Code = code });

            var hasDiscount = discounts.FirstOrDefault();

            if (hasDiscount == null)
            {
                return Response<Dtos.DiscountDto>.Fail(StaticValue._discountNotFound, StaticValue._notFoundId);
            }

            return Response<Dtos.DiscountDto>.Success(hasDiscount, StaticValue._successReturnModelId);
        }

        public async Task<Response<Dtos.DiscountDto>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Dtos.DiscountDto>("select * from discount where id=@Id", new { Id = id })).SingleOrDefault();

            if (discount == null)
            {
                return Response<Dtos.DiscountDto>.Fail(StaticValue._discountNotFound, StaticValue._notFoundId);
            }

            return Response<Dtos.DiscountDto>.Success(discount, StaticValue._successReturnModelId);
        }

        public async Task<Response<NoContent>> Save(Dtos.DiscountDto discount)
        {
            var saveStatus = await _dbConnection.ExecuteAsync("INSERT INTO discount (userid,rate,code) VALUES(@UserId,@Rate,@Code)", discount);

            if (saveStatus > 0)
            {
                return Response<NoContent>.Success(StaticValue._successReturnNotModelId);
            }

            return Response<NoContent>.Fail(StaticValue._discountAddError, StaticValue._couldNot);
        }

        public async Task<Response<NoContent>> Update(Dtos.DiscountDto discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserId, code=@Code, rate=@Rate where id=@Id", new { Id = discount.Id, UserId = discount.UserId, Code = discount.Code, Rate = discount.Rate });

            if (status > 0)
            {
                return Response<NoContent>.Success(StaticValue._successReturnNotModelId);
            }

            return Response<NoContent>.Fail(StaticValue._discountNotFound, StaticValue._notFoundId);
        }
    }
}
