using System;
using System.Collections.Generic;

namespace WebApi.Domain.Entities
{
    public class Bundle
    {
        public Bundle()
        {
        }

        public Bundle(Guid id, decimal discount, IList<Product> products)
        {
            Id = id;
            Discount = discount;
            Products = products;
        }

        public Guid Id { get; set; }
        public decimal Discount { get; set; }
        public IList<Product> Products { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Bundle;
            return other != null && other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}