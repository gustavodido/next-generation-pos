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
    public class SearchProductsQueryTests
    {
        private readonly DapperService _dapperService;
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;

        private readonly SearchProductsQuery _searchProductsQuery;

        public SearchProductsQueryTests()
        {
            _dapperService = A.Fake<DapperService>();
            _applicationConfiguration = A.Fake<IOptions<ApplicationConfiguration>>();

            _searchProductsQuery = new SearchProductsQuery(_applicationConfiguration, _dapperService);
        }

        [Fact]
        public void RunShouldReturnFilteredProducts()
        {
            // Given
            var expectedProducts = new[] {Constants.Monitor, Constants.Notebook};

            A.CallTo(() => _dapperService.List<Product>(A<string>.Ignored, A<object>.Ignored)).Returns(expectedProducts);

            // When
            var products = _searchProductsQuery.Run(Constants.Monitor.Name);

            // Then
            Assert.Equal(expectedProducts, products);

            A.CallTo(() => _dapperService.List<Product>(A<string>.Ignored, A<object>.Ignored)).MustHaveHappened();
        }
    }
}