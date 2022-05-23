using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Microservices.MarketPlace.Example.Product.Models
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }

        private decimal _marketPrice;

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal MarketPrice
        {
            get { return _marketPrice; }
            set { _marketPrice = Math.Round(value, 2); }
        }

        private decimal _salePrice;
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal SalePrice
        {
            get { return _salePrice; }
            set { _salePrice = Math.Round(value, 2); }
        }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal KDV { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public int Stock { get; set; }
    }
}
