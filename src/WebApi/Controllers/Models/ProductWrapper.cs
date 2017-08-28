using System;

namespace WebApi.Controllers.Models
{
    public class ProductWrapper
    {
        public ProductWrapper(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}