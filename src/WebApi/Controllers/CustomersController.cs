using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Commands;
using WebApi.Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController
    {
        private readonly CreateCustomerCommand _createCustomerCommand;

        public CustomersController(CreateCustomerCommand createCustomerCommand)
        {
            _createCustomerCommand = createCustomerCommand;
        }

        [HttpPost]
        public Customer Create([FromBody] Customer customer)
        {
            return _createCustomerCommand.Run(customer);
        }   
    }
}