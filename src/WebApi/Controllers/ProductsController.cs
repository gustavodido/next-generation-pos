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

        public ProductsController(GetProductsQuery getProductsQuery)
        {
            _getProductsQuery = getProductsQuery;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _getProductsQuery.Run();
        }
    }
}
