using BackEnd.Core.MongoService.Connection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.MongoService.Services
{
    public class CustomerService:BaseMongoService<Customer>
    {
        public CustomerService(string connectionString
            , string dbName) : base(connectionString, dbName) { }

        public CustomerService(IMongoDbConnection mongoDbConnection) : base(mongoDbConnection) { }
        protected override string CollectionName => "Customer";

        public Customer GetByCustomerId(string customerId)
        {
            return this.Collection.Find(p => p.CustomerId == customerId).FirstOrDefault();
        }

        public List<Customer> GetByCustomerName(string name)
        {
            return this.Collection.Find(p => p.Name.Contains(name) || p.LastName.Contains(name)).ToList();
        }
        
    }
}
