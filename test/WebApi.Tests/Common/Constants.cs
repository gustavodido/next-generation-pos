using System;
using WebApi.Domain.Entities;

namespace WebApi.Tests.Common
{
    public class Constants
    {
        public static Product Monitor = new Product(Guid.NewGuid(), "PHILIPS 243S7EHMB/0", "781535", 159.00m);
        public static Product Notebook = new Product(Guid.NewGuid(), "HP PAVILION 15-CC593ND", "780842", 749.00m);
    }
}