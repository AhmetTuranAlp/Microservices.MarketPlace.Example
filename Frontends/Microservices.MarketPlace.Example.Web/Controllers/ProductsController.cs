﻿using Microservices.MarketPlace.Example.CommonUses.Services.Interfaces;
using Microservices.MarketPlace.Example.Web.Models.Products;
using Microservices.MarketPlace.Example.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public ProductsController(IProductService productService, ISharedIdentityService sharedIdentityService)
        {
            _productService = productService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllProductByUserIdAsync(_sharedIdentityService.GetUserId));
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _productService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            var brands = await _productService.GetAllBrandAsync();
            ViewBag.brandList = new SelectList(brands, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateInput productCreateInput)
        {
            var categories = await _productService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }

            var brands = await _productService.GetAllBrandAsync();
            ViewBag.brandList = new SelectList(brands, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }

            productCreateInput.UserId = _sharedIdentityService.GetUserId;

            await _productService.CreateProductAsync(productCreateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
             var product = await _productService.GetByProductId(id);

            var categories = await _productService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
            var brands = await _productService.GetAllBrandAsync();
            ViewBag.brandList = new SelectList(brands, "Id", "Name");

            if (product == null)
            {
                //mesaj göster
                RedirectToAction(nameof(Index));
            }
        
            ProductUpdateInput productUpdateInput = new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                SalePrice = product.SalePrice,
                CategoryId = product.Category.Id,
                BrandId = product.Brand.Id,
                UserId = product.UserId,
                Image = product.Image
            };

            return View(productUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateInput productUpdateInput)
        {
            var categories = await _productService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            var brands = await _productService.GetAllBrandAsync();
            ViewBag.brandList = new SelectList(brands, "Id", "Name");

            await _productService.UpdateProductAsync(productUpdateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
