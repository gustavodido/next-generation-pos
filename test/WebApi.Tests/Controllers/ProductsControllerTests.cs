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
        private readonly SearchProductsQuery _searchProductsQuery;

        public ProductControllersTests()
        {
            _getProductsQuery = A.Fake<GetProductsQuery>();
            _searchProductsQuery = A.Fake<SearchProductsQuery>();
            
            _productController = new ProductsController(_getProductsQuery, _searchProductsQuery);
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

        [Fact]
        public void SearchSouldReturnFilteredProducts()
        {
            // Given
            var expectedProducts = new[] {Constants.Monitor };
            
            A.CallTo(() => _searchProductsQuery.Run(Constants.Monitor.Name)).Returns(expectedProducts);
            
            // When
            var products = _productController.Search(Constants.Monitor.Name);
            
            // Then
            Assert.Equal(expectedProducts, products);

            A.CallTo(() => _searchProductsQuery.Run(Constants.Monitor.Name)).MustHaveHappened();
        }
        
    }
}
