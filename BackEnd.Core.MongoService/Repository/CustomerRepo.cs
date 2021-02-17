using BackEnd.Core.Model.Repository;
using BackEnd.Core.MongoService.Connection;
using BackEnd.Core.MongoService.Converter;
using BackEnd.Core.MongoService.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mongo = BackEnd.Core.MongoService;

namespace BackEnd.Core.MongoService.Repository
{
    public class CustomerRepo : BaseRepo<Mongo.Customer, Model.Customer>, IGetCustomer
    {
        public CustomerRepo() { }
        
        public CustomerRepo(CustomerService service,
            CustomerConverter converter) : base(service,converter) { }

        public CustomerRepo(IMongoDbConnection mongoDbConnection) 
            : base(mongoDbConnection) 
        {
            this.service = new CustomerService(mongoDbConnection);
            
            this.converter = new CustomerConverter();
        }

        protected override List<Customer> get()
        {
            return this.service.GetAll();
        }

        protected override Customer getById(string id)
        {
            return this.service.Get(id);
        }

        protected override Customer getById(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<Customer> getByIdAsync(string id)
        {
            return this.service.GetAsync(id);
        }

        protected override List<Customer> getByName(string name)
        {
            return ((CustomerService)this.service).GetByCustomerName(name);
        }

        public Model.Customer GetByCustomerId(string customerId)
        {
            Customer customer = ((CustomerService)this.service).GetByCustomerId(customerId);
            if (customer != null)
                return this.converter.Convert(customer);
            return null;
        }

        public Task<Model.Customer> GetByCustomerIdAsync(string customerId)
        {
            return Task.Run<Model.Customer>(() =>
            {
                Customer customer = ((CustomerService)this.service).GetByCustomerId(customerId);
                if (customer != null)
                    return this.converter.Convert(customer);
                return null;
            });
        }


        
    }
}
