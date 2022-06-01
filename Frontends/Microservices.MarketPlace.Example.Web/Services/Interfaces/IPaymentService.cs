using Microservices.MarketPlace.Example.Web.Models.Payments;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
    }
}
