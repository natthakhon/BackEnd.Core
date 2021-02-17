using BackEnd.Core.Model;
using BackEnd.Core.Model.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IGetCustomer repo;

        public CustomerController(IGetCustomer repo)
        {
            this.repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        { 
            var customer = await this.repo.GetByCustomerIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<List<Customer>>> GetCustomers(string name)
        {
            var customers = await this.repo.GetByNameAsync(name);
            if (customers == null)
            {
                return NotFound();
            }
            return customers;
        }
    }
}
