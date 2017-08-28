using System;

namespace WebApi.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public override bool Equals(object obj)
        {
            var other = obj as Customer;
            return other != null && (other.Id.Equals(Id));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}