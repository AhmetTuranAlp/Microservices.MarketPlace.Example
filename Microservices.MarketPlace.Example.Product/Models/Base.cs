using Microservices.MarketPlace.Example.Product.Enumeration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using static Microservices.MarketPlace.Example.Product.Enumeration.Status;

namespace Microservices.MarketPlace.Example.Product.Models
{
    public abstract class Base
    {
        public Base()
        {
            StatusType = StatusType.NewRecord;
            UpdateDate = DateTime.Now;
            UploadDate = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        private StatusType _status = StatusType.Active;
        public virtual StatusType StatusType
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

  
        private DateTime? _uploadDate = null;

        [BsonRepresentation(BsonType.DateTime)]
        public virtual DateTime UploadDate
        {
            get
            {
                return _uploadDate.HasValue ? Convert.ToDateTime(_uploadDate.Value) : Convert.ToDateTime(DateTime.Now);
            }
            set
            {
                _uploadDate = Convert.ToDateTime(value);
            }
        }

        private DateTime? _updateDate = null;

        [BsonRepresentation(BsonType.DateTime)]
        public virtual DateTime UpdateDate
        {
            get
            {
                return _updateDate.HasValue ? Convert.ToDateTime(_updateDate.Value) : Convert.ToDateTime(DateTime.Now);
            }
            set
            {
                _updateDate = Convert.ToDateTime(value);
            }
        }
    }
}
