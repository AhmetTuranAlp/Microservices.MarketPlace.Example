using AutoMapper;
using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Product.Dtos;
using Microservices.MarketPlace.Example.Product.Models;
using Microservices.MarketPlace.Example.Product.Services.Interfaces;
using Microservices.MarketPlace.Example.Product.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Models.Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Models.Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandColletionName);
            _mapper = mapper;
        }

        public async Task<Response<ProductDto>> CreateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Models.Product>(productDto);

            product.UploadDate = DateTime.Now;
            await _productCollection.InsertOneAsync(product);

            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), StaticValue._successReturnModelId);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(StaticValue._successReturnNotModelId);
            }
            else
            {
                return Response<NoContent>.Fail(StaticValue._productNotFound, StaticValue._notFoundId);
            }
        }

        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productCollection.Find(product => true).ToListAsync();

            if (products.Any())
            {
                foreach (var product in products)
                {
                    product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.Category.Id).FirstAsync();
                    product.Brand = await _brandCollection.Find<Brand>(x => x.Id == product.Brand.Id).FirstAsync();
                }
            }
            else
            {
                products = new List<Models.Product>();
            }

            return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), StaticValue._successReturnModelId);
        }

        public async Task<Response<ProductDto>> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find<Models.Product>(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return Response<ProductDto>.Fail(StaticValue._productNotFound, StaticValue._notFoundId);
            }
            product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.Category.Id).FirstAsync();

            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), StaticValue._successReturnModelId);
        }

        public async Task<Response<NoContent>> UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Models.Product>(productDto);

            var result = await _productCollection.FindOneAndReplaceAsync(x => x.Id == productDto.Id, product);

            if (result == null)
            {
                return Response<NoContent>.Fail(StaticValue._productNotFound, StaticValue._notFoundId);
            }

            return Response<NoContent>.Success(StaticValue._successReturnNotModelId);
        }
    }
}
