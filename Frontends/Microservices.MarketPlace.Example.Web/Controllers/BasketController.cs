using Microservices.MarketPlace.Example.Web.Models.Baskets;
using Microservices.MarketPlace.Example.Web.Models.Discounts;
using Microservices.MarketPlace.Example.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public BasketController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _basketService.Get());
        }

        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var product = await _productService.GetByProductId(productId);

            var basketItem = new BasketItemViewModel { ProductId = product.Id, ProductName = product.Name, Price = product.SalePrice };

            await _basketService.AddBasketItem(basketItem);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            var result = await _basketService.RemoveBasketItem(productId);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ApplyDiscount(DiscountApplyInput discountApplyInput)
        {
            if (!ModelState.IsValid)
            {
                TempData["discountError"] = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).First();
                return RedirectToAction(nameof(Index));
            }
            var discountStatus = await _basketService.ApplyDiscount(discountApplyInput.Code);

            TempData["discountStatus"] = discountStatus;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CancelApplyDiscount()
        {
            await _basketService.CancelApplyDiscount();
            return RedirectToAction(nameof(Index));
        }
    }
}
