using Microservices.MarketPlace.Example.Web.Models.Baskets;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services.Interfaces
{
    public interface IBasketService
    {
        Task<bool> SaveOrUpdate(BasketViewModel basketViewModel);

        Task<BasketViewModel> Get();

        Task<bool> Delete();

        Task AddBasketItem(BasketItemViewModel basketItemViewModel);

        Task<bool> RemoveBasketItem(string productId);

        /// <summary>
        /// Sepete indirim Uygulama
        /// </summary>
        /// <param name="discountCode"></param>
        /// <returns></returns>
        Task<bool> ApplyDiscount(string discountCode);

        /// <summary>
        /// İndirim İptal Etme
        /// </summary>
        /// <returns></returns>
        Task<bool> CancelApplyDiscount();
    }
}
