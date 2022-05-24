using AutoMapper;
using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Product.Dtos;
using Microservices.MarketPlace.Example.Product.Models;
using Microservices.MarketPlace.Example.Product.Services.Interfaces;
using Microservices.MarketPlace.Example.Product.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Product.Services
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;

        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandColletionName);
            _mapper = mapper;
        }
        public async Task<Response<BrandDto>> CreateAsync(BrandDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            await _brandCollection.InsertOneAsync(brand);

            return Response<BrandDto>.Success(_mapper.Map<BrandDto>(brand), StaticValue._successReturnModelId);
        }

        public async Task<Response<List<BrandDto>>> GetAllAsync()
        {
            var brands = await _brandCollection.Find(brand => true).ToListAsync();

            return Response<List<BrandDto>>.Success(_mapper.Map<List<BrandDto>>(brands), StaticValue._successReturnModelId);
        }

        public async Task<Response<BrandDto>> GetByIdAsync(string id)
        {
            var category = await _brandCollection.Find<Brand>(x => x.Id == id).FirstOrDefaultAsync();

            if (category == null)
            {
                return Response<BrandDto>.Fail(StaticValue._productNotFound, StaticValue._notFoundId);
            }

            return Response<BrandDto>.Success(_mapper.Map<BrandDto>(category), StaticValue._successReturnModelId);
        }
    }
}
