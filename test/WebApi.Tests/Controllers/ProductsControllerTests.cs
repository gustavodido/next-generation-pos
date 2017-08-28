using FakeItEasy;
using WebApi.Controllers;
using WebApi.Domain.Queries;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Controllers
{
    public class ProductsControllersTests
    {
        private readonly ProductsController _productController;
        
        private readonly GetProductsQuery _getProductsQuery;
        private readonly SearchProductsQuery _searchProductsQuery;
        private readonly GetProductBundlesQuery _getProductBundles;

        public ProductsControllersTests()
        {
            _getProductsQuery = A.Fake<GetProductsQuery>();
            _searchProductsQuery = A.Fake<SearchProductsQuery>();
            _getProductBundles = A.Fake<GetProductBundlesQuery>();
            
            _productController = new ProductsController(_getProductsQuery, _searchProductsQuery, _getProductBundles, null);
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

        [Fact]
        public void GetBundlesSouldReturnFilteredProducts()
        {
            // Given
            var expectedBundles = new[] {Constants.IphoneBundle };
            
            A.CallTo(() => _getProductBundles.Run(Constants.IphoneCase.Id)).Returns(expectedBundles);
            
            // When
            var bundles = _productController.GetBundles(Constants.IphoneCase.Id);
            
            // Then
            Assert.Equal(expectedBundles, bundles);

            A.CallTo(() => _getProductBundles.Run(Constants.IphoneCase.Id)).MustHaveHappened();
        }

    }
}
