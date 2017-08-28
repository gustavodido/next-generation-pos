using System;

namespace WebApi.Domain.Entities
{
    public class Product
    {
        public Product()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EanCode { get; set; }
        public decimal Price { get; set; }
    }
}