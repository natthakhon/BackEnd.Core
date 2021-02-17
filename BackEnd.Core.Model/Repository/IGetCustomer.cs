using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Model.Repository
{
    public interface IGetCustomer : IGenericGetRepo<Customer>
    {
        Customer GetByCustomerId(string customerId);
        Task<Customer> GetByCustomerIdAsync(string customerId);
    }
}
