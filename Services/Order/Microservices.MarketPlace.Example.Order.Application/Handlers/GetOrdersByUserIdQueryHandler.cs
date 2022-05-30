using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Order.Application.Dtos;
using Microservices.MarketPlace.Example.Order.Application.Mapping;
using Microservices.MarketPlace.Example.Order.Application.Queries;
using Microservices.MarketPlace.Example.Order.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Order.Application.Handlers
{
    internal class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDbContext _context;

        public GetOrdersByUserIdQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();
            if (!orders.Any()) { return Response<List<OrderDto>>.Success(new List<OrderDto>(), StaticValue._successReturnModelId); }
            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);
            return Response<List<OrderDto>>.Success(ordersDto, StaticValue._successReturnModelId);
        }
    }
}
