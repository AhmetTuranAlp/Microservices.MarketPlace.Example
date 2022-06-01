using Microservices.MarketPlace.Example.Web.Models.Discounts;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}
