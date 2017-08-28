using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Entities;
using WebApi.Services;

namespace WebApi.Domain.Queries
{
    public class GetOrderByIdQuery
    {
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;
        private readonly DapperService _dapperService;

        public GetOrderByIdQuery(IOptions<ApplicationConfiguration> applicationConfiguration,
            DapperService dapperService)
        {
            _applicationConfiguration = applicationConfiguration;
            _dapperService = dapperService;
        }

        public virtual IEnumerable<Product> Run(Guid id)
        {
            return _dapperService.List<Product>(_applicationConfiguration.Value.GetOrderByIdQuery, new
            {
                OrderId = id
            });
        }
    }
}