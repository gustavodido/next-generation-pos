using System;
using WebApi.Domain.Entities;

namespace WebApi.Tests.Common
{
    public class Constants
    {
        public static Product Monitor = new Product(Guid.NewGuid(), "PHILIPS 243S7EHMB/0", "781535", 159.00m);
        public static Product Notebook = new Product(Guid.NewGuid(), "HP PAVILION 15-CC593ND", "780842", 749.00m);

        public static Product IphoneCase =
            new Product(Guid.NewGuid(), "APPLE IPHONE 5/5S/SE FRE CASE BLACK", "701524", 79.99m);

        public static Product IphoneScreenProtector =
            new Product(Guid.NewGuid(), "AZURI APPLE IPHONE 5/5S/SE SCREENPROTECTOR", "757997", 24.99m);

        public static Bundle IphoneBundle =
            new Bundle(Guid.NewGuid(), decimal.One, new[] {IphoneCase, IphoneScreenProtector});

        public static BundleProductMap IphoneCaseBundleMap =
            BundleProductMap.Parse(IphoneBundle, IphoneCase);

        public static BundleProductMap IphoneScreenProtectorBundleMap =
            BundleProductMap.Parse(IphoneBundle, IphoneScreenProtector);
    }
}