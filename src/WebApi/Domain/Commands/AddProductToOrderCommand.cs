using System;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Entities;
using WebApi.Services;

namespace WebApi.Domain.Commands
{
    public class AddProductToOrderCommand
    {
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;
        private readonly DapperService _dapperService;

        public AddProductToOrderCommand(IOptions<ApplicationConfiguration> applicationConfiguration, DapperService dapperService)
        {
            _applicationConfiguration = applicationConfiguration;
            _dapperService = dapperService;
        }

        public virtual void Run(Guid id, Guid productId)
        {
            _dapperService.Execute(_applicationConfiguration.Value.AddProductToOrderCommand, new
            {
                OrderId = id,
                ProductId = productId
            });
        }
    }
}