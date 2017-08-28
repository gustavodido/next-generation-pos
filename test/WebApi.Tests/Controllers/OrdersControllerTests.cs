using FakeItEasy;
using WebApi.Controllers;
using WebApi.Controllers.Models;
using WebApi.Domain.Commands;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Controllers
{
    public class OrdersControllersTests
    {
        private readonly OrdersController _ordersController;
        
        private readonly CreateOrderCommand _createOrderCommand;
        private readonly AddProductToOrderCommand _addProductToOrderCommand;

        public OrdersControllersTests()
        {
            _createOrderCommand = A.Fake<CreateOrderCommand>();
            _addProductToOrderCommand = A.Fake<AddProductToOrderCommand>();
            
            _ordersController = new OrdersController(_createOrderCommand, _addProductToOrderCommand);
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

    }
}
