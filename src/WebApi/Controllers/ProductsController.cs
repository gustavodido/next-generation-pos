using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Entities;
using WebApi.Domain.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly GetProductsQuery _getProductsQuery;
        private readonly SearchProductsQuery _searchProductsQuery;
        private readonly GetProductBundlesQuery _getProductBundlesQuery;

        public ProductsController(GetProductsQuery getProductsQuery, SearchProductsQuery searchProductsQuery, GetProductBundlesQuery getProductBundlesQuery)
        {
            _getProductsQuery = getProductsQuery;
            _searchProductsQuery = searchProductsQuery;
            _getProductBundlesQuery = getProductBundlesQuery;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _getProductsQuery.Run();
        }
        
        [HttpGet]
        [Route("{term}")]
        public IEnumerable<Product> Search(string term)
        {
            return _searchProductsQuery.Run(term);
        }

        [HttpGet]
        [Route("{id}/bundles")]
        public IEnumerable<Bundle> GetBundles(Guid id)
        {
            return _getProductBundlesQuery.Run(id);
        }
    }
}
