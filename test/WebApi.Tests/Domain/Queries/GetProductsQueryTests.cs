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
    public class GetProductsQueryTests
    {
        private readonly DapperService _dapperService;

        private readonly GetProductsQuery _getProductsQuery;

        public GetProductsQueryTests()
        {
            _dapperService = A.Fake<DapperService>();

            _getProductsQuery = new GetProductsQuery(A.Fake<IOptions<ApplicationConfiguration>>(), _dapperService);
        }

        [Fact]
        public void RunShouldReturnAllProducts()
        {
            // Given
            var expectedProducts = new[] {Constants.Monitor, Constants.Notebook};

            A.CallTo(() => _dapperService.List<Product>(A<string>.Ignored)).Returns(expectedProducts);

            // When
            var products = _getProductsQuery.Run();

            // Then
            Assert.Equal(expectedProducts, products);

            A.CallTo(() => _dapperService.List<Product>(A<string>.Ignored)).MustHaveHappened();
        }
    }
}