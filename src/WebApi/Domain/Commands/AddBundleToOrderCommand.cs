using System;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Entities;
using WebApi.Services;

namespace WebApi.Domain.Commands
{
    public class AddBundleToOrderCommand
    {
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;
        private readonly DapperService _dapperService;

        private readonly AddProductToOrderCommand _addProductToOrderCommand;

        public AddBundleToOrderCommand(IOptions<ApplicationConfiguration> applicationConfiguration, DapperService dapperService, AddProductToOrderCommand addProductToOrderCommand)
        {
            _applicationConfiguration = applicationConfiguration;
            _dapperService = dapperService;
            _addProductToOrderCommand = addProductToOrderCommand;
        }

        public virtual void Run(Guid id, Guid bundleId)
        {
            var products = _dapperService.List<Product>(
                _applicationConfiguration.Value.GetProductsInBundleQuery, new
                {
                    @BundleId = bundleId
                });

            foreach (var product in products)
            {
                _addProductToOrderCommand.Run(id, product.Id);
            }
        }
    }
}