using FakeItEasy;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Entities;
using WebApi.Domain.Queries;
using WebApi.Services;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Domain.Queries
{
    public class GetProductsBundlesQueryTests
    {
        private readonly DapperService _dapperService;

        private readonly GetProductBundlesQuery _getProductBundlesQuery;

        public GetProductsBundlesQueryTests()
        {
            _dapperService = A.Fake<DapperService>();

            _getProductBundlesQuery =
                new GetProductBundlesQuery(A.Fake<IOptions<ApplicationConfiguration>>(), _dapperService);
        }

        [Fact]
        public void RunShouldReturnAggregatedBundlesForProduct()
        {
            // Given
            var expectedBundles = new[] {Constants.IphoneBundle};
            
            A.CallTo(() => _dapperService.List<BundleProductMap>(A<string>.Ignored, A<object>.Ignored))
                .Returns(new[] {Constants.IphoneCaseBundleMap, Constants.IphoneScreenProtectorBundleMap});

            // When
            var bundles = _getProductBundlesQuery.Run(Constants.IphoneCase.Id);

            // Then
            Assert.Equal(expectedBundles, bundles);

            A.CallTo(() => _dapperService.List<BundleProductMap>(A<string>.Ignored, A<object>.Ignored))
                .MustHaveHappened();
        }
    }
}