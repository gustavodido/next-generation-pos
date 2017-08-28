using System.Collections.Generic;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Entities;
using WebApi.Services;

namespace WebApi.Domain.Queries
{
    public class SearchProductsQuery
    {
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;
        private readonly DapperService _dapperService;

        public SearchProductsQuery(IOptions<ApplicationConfiguration> applicationConfiguration,
            DapperService dapperService)
        {
            _applicationConfiguration = applicationConfiguration;
            _dapperService = dapperService;
        }

        public virtual IEnumerable<Product> Run(string term)
        {
            return _dapperService.List<Product>(_applicationConfiguration.Value.SearchProductsQuery, new
            {
                Term = term.ToLower()
            });
        }
    }
}