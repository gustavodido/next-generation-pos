using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return new[] { new Product() };
        }
    }
}
