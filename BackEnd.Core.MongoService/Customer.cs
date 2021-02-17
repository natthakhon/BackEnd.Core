using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.MongoService
{
    public class Customer : BaseMongoModel
    {
        public string CustomerId { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string BOD { set; get; }
        public string Gender { set; get; }
        public List<Address> Addresses { set; get; }

    }
}
