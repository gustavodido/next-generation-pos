using System;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Entities;
using WebApi.Services;

namespace WebApi.Domain.Commands
{
    public class CreateOrderCommand
    {
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;
        private readonly DapperService _dapperService;

        public CreateOrderCommand(IOptions<ApplicationConfiguration> applicationConfiguration, DapperService dapperService)
        {
            _applicationConfiguration = applicationConfiguration;
            _dapperService = dapperService;
        }

        public virtual Order Run()
        {
            var orderId = _dapperService.ExecuteScalar<Guid>(_applicationConfiguration.Value.CreateOrderCommand);
            return new Order(orderId);
        }
    }
}