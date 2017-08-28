using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Entities;
using WebApi.Services;

namespace WebApi.Domain.Queries
{
    public class GetProductBundlesQuery
    {
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;
        private readonly DapperService _dapperService;

        public GetProductBundlesQuery(IOptions<ApplicationConfiguration> applicationConfiguration,
            DapperService dapperService)
        {
            _applicationConfiguration = applicationConfiguration;
            _dapperService = dapperService;
        }

        public virtual IEnumerable<Bundle> Run(Guid id)
        {
            var resultSet = _dapperService.List<BundleProductMap>(
                _applicationConfiguration.Value.GetProductBundlesQuery, new
                {
                    @SourceProductId = id
                });

            return AggregateResults(resultSet);
        }

        private IEnumerable<Bundle> AggregateResults(IEnumerable<BundleProductMap> resultSet)
        {
            var bundles = new Dictionary<Guid, Bundle>();
            foreach (var result in resultSet)
            {
                if (!bundles.ContainsKey(result.BundleId)) bundles.Add(result.BundleId, result.ToBundle());
                
                bundles[result.BundleId].Products.Add(result.ToProduct());
            }

            return bundles.Values.ToArray();
        }
    }
}