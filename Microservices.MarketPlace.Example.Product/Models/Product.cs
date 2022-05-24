using Microservices.MarketPlace.Example.Product.Enumeration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microservices.MarketPlace.Example.Product.Models
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
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

        public int Stock { get; set; }

        public Currency.CurrencyType CurrencyType { get; set; }
    }
}
