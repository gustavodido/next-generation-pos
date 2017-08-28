using System;

namespace WebApi.Controllers.Models
{
    public class BundleWrapper
    {
        public BundleWrapper(Guid bundleId)
        {
            BundleId = bundleId;
        }

        public Guid BundleId { get; set; }
    }
}