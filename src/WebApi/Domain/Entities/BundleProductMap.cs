using System;
using System.Collections.Generic;

namespace WebApi.Domain.Entities
{
    // I don't have time to search how to do this mapping automatically using Dapper
    public class BundleProductMap
    {
        public Guid BundleId { get; set; }
        public decimal Discount { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string EanCode { get; set; }
        public decimal Price { get; set; }

        public Product ToProduct()
        {
            return new Product(ProductId, Name, EanCode, Price);
        }

        public Bundle ToBundle()
        {
            return new Bundle(BundleId, Discount, new List<Product>());
        }

        public static BundleProductMap Parse(Bundle bundle, Product product)
        {
            var bundleMap = new BundleProductMap();

            bundleMap.BundleId = bundle.Id;
            bundleMap.Discount = bundle.Discount;
            
            bundleMap.ProductId = product.Id;
            bundleMap.Name = product.Name;
            bundleMap.EanCode = product.EanCode;
            bundleMap.Price = product.Price;

            return bundleMap;
        }
    }
}