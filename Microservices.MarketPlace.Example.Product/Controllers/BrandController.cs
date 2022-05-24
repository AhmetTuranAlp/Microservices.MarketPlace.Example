using Microservices.MarketPlace.Example.CommonUses.Base;
using Microservices.MarketPlace.Example.Product.Dtos;
using Microservices.MarketPlace.Example.Product.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : CustomBaseController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _brandService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _brandService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandDto brandDto)
        {
            var response = await _brandService.CreateAsync(brandDto);
            return CreateActionResultInstance(response);
        }
    }
}