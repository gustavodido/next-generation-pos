using System;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Entities;
using WebApi.Services;

namespace WebApi.Domain.Commands
{
    public class CreateCustomerCommand
    {
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;
        private readonly DapperService _dapperService;

        public CreateCustomerCommand(IOptions<ApplicationConfiguration> applicationConfiguration, DapperService dapperService)
        {
            _applicationConfiguration = applicationConfiguration;
            _dapperService = dapperService;
        }

        public virtual Customer Run(Customer customer)
        {
            var customerId = _dapperService.ExecuteScalar<Guid>(_applicationConfiguration.Value.CreateUserCommand, new
            {
                customer.Name
            });
            
            return new Customer(customerId, customer.Name);
        }
    }
}