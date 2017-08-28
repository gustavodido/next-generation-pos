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
    public class GetOrderByIdQueryTests
    {
        private readonly DapperService _dapperService;

        private readonly GetOrderByIdQuery _getOrderByIdQuery;

        public GetOrderByIdQueryTests()
        {
            _dapperService = A.Fake<DapperService>();

            _getOrderByIdQuery = new GetOrderByIdQuery(A.Fake<IOptions<ApplicationConfiguration>>(), _dapperService);
        }

        [Fact]
        public void RunShouldReturnAllProducts()
        {
            // Given
            var expectedProductsInOrder = new[] {Constants.IphoneCase};

            A.CallTo(() => _dapperService.List<Product>(A<string>.Ignored, A<object>.Ignored)).Returns(expectedProductsInOrder);

            // When
            var products = _getOrderByIdQuery.Run(Constants.IphoneCaseOrder.Id);

            // Then
            Assert.Equal(expectedProductsInOrder, products);

            A.CallTo(() => _dapperService.List<Product>(A<string>.Ignored, A<object>.Ignored)).MustHaveHappened();
        }
    }
}