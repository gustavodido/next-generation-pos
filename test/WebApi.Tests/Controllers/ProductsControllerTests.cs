using FakeItEasy;
using WebApi.Controllers;
using WebApi.Domain.Queries;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Controllers
{
    public class ProductControllersTests
    {
        private readonly ProductsController _productController;
        private readonly GetProductsQuery _getProductsQuery;

        public ProductControllersTests()
        {
            _getProductsQuery = A.Fake<GetProductsQuery>();
            
            _productController = new ProductsController(_getProductsQuery);
        }

        [Fact]
        public void GetAllShouldReturnAllProducts()
        {
            // Given
            var expectedProducts = new[] {Constants.Monitor, Constants.Notebook};
            
            A.CallTo(() => _getProductsQuery.Run()).Returns(expectedProducts);
            
            // When
            var products = _productController.GetAll();
            
            // Then
            Assert.Equal(expectedProducts, products);

            A.CallTo(() => _getProductsQuery.Run()).MustHaveHappened();
        }
    }
}
