using MassTransit;
using Microservices.MarketPlace.Example.CommonUses.Base;
using Microservices.MarketPlace.Example.CommonUses.Messages;
using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Payment.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Payment.Controllers
{
    public class PaymentController : CustomBaseController
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public PaymentController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }
        [HttpPost]
        public async Task<IActionResult> ReceivePayment(PaymentDto paymentDto)
        {
            //paymentDto ile ödeme işlemi gerçekleştir.
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));

            var createOrderMessageCommand = new CreateOrderMessageCommand();

            createOrderMessageCommand.BuyerId = paymentDto.Order.BuyerId;
            createOrderMessageCommand.Province = paymentDto.Order.Address.Province;
            createOrderMessageCommand.District = paymentDto.Order.Address.District;
            createOrderMessageCommand.Street = paymentDto.Order.Address.Street;
            createOrderMessageCommand.Line = paymentDto.Order.Address.Line;
            createOrderMessageCommand.ZipCode = paymentDto.Order.Address.ZipCode;

            paymentDto.Order.OrderItems.ForEach(x =>
            {
                createOrderMessageCommand.OrderItems.Add(new OrderItem
                {
                    PictureUrl = x.PictureUrl,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName
                });
            });

            await sendEndpoint.Send<CreateOrderMessageCommand>(createOrderMessageCommand);

            return CreateActionResultInstance(CommonUses.Result.Response<NoContent>.Success(200));
        }

    }
}
