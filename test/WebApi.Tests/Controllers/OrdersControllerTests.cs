using FakeItEasy;
using WebApi.Controllers;
using WebApi.Controllers.Models;
using WebApi.Domain.Commands;
using WebApi.Domain.Queries;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Controllers
{
    public class OrdersControllersTests
    {
        private readonly OrdersController _ordersController;
        
        private readonly CreateOrderCommand _createOrderCommand;
        private readonly AddProductToOrderCommand _addProductToOrderCommand;
        private readonly GetOrderByIdQuery _getOrderByIdQuery;
        private readonly AddBundleToOrderCommand _addBundleToOrderCommand;

        public OrdersControllersTests()
        {
            _createOrderCommand = A.Fake<CreateOrderCommand>();
            _addProductToOrderCommand = A.Fake<AddProductToOrderCommand>();
            _getOrderByIdQuery = A.Fake<GetOrderByIdQuery>();
            _addBundleToOrderCommand = A.Fake<AddBundleToOrderCommand>();
            
            _ordersController = new OrdersController(_createOrderCommand, _addProductToOrderCommand, _getOrderByIdQuery, _addBundleToOrderCommand);
        }

        [Fact]
        public void CreateShouldCreateNewOrder()
        {
            // Given
            A.CallTo(() => _createOrderCommand.Run()).Returns(Constants.IphoneCaseOrder);
            
            // When
            var order = _ordersController.Create();
            
            // Then
            Assert.Equal(Constants.IphoneCaseOrder, order);

            A.CallTo(() => _createOrderCommand.Run()).MustHaveHappened();
        }
        
        [Fact]
        public void AddProductShouldAddProductToOrder()
        {
            // Given
            A.CallTo(() => _addProductToOrderCommand.Run(Constants.IphoneCaseOrder.Id, Constants.IphoneCase.Id))
                .DoesNothing();
            
            // When
             _ordersController.AddProduct(Constants.IphoneCaseOrder.Id, new ProductWrapper(Constants.IphoneCase.Id));
            
            // Then
            A.CallTo(() => _addProductToOrderCommand.Run(Constants.IphoneCaseOrder.Id, Constants.IphoneCase.Id))
                .MustHaveHappened();
        }
        
        [Fact]
        public void GetShouldReturnOrderById()
        {
            // Given
            var expectedProductsInOrder = new [] { Constants.IphoneCase };

            A.CallTo(() => _getOrderByIdQuery.Run(Constants.IphoneCaseOrder.Id))
                .Returns(expectedProductsInOrder);
            
            // When
            var products = _ordersController.Get(Constants.IphoneCaseOrder.Id);
            
            // Then
            Assert.Equal(expectedProductsInOrder, products);

            A.CallTo(() => _getOrderByIdQuery.Run(Constants.IphoneCaseOrder.Id))
                .MustHaveHappened();
        }
        
        [Fact]
        public void AddBundleShouldAddBundleProductsToOrder()
        {
            // Given
            A.CallTo(() => _addBundleToOrderCommand.Run(Constants.IphoneCaseOrder.Id, Constants.IphoneBundle.Id))
                .DoesNothing();
            
            // When
            _ordersController.AddBundle(Constants.IphoneCaseOrder.Id, new BundleWrapper(Constants.IphoneBundle.Id));
            
            // Then
            A.CallTo(() => _addBundleToOrderCommand.Run(Constants.IphoneCaseOrder.Id, Constants.IphoneBundle.Id))
                .MustHaveHappened();
        }


    }
}
