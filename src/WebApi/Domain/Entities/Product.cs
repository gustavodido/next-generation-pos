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
        public String Description { get; set; }
        public decimal Prive { get; set; }
    }
}