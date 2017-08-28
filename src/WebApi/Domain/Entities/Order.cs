using System;

namespace WebApi.Domain.Entities
{
    public class Order
    {
        public Order()
        {
        }

        public Order(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        
        public override bool Equals(object obj)
        {
            var other = obj as Order;
            return other != null && (other.Id.Equals(Id));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}