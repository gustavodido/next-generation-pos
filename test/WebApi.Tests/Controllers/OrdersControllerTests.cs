using FakeItEasy;
using WebApi.Controllers;
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

        public OrdersControllersTests()
        {
            _createOrderCommand = A.Fake<CreateOrderCommand>();
            
            _ordersController = new OrdersController(_createOrderCommand);
        }

        [Fact]
        public void PostShouldCreateNewOrder()
        {
            // Given
            A.CallTo(() => _createOrderCommand.Run()).Returns(Constants.IphoneCaseOrder);
            
            // When
            var order = _ordersController.Post();
            
            // Then
            Assert.Equal(Constants.IphoneCaseOrder, order);

            A.CallTo(() => _createOrderCommand.Run()).MustHaveHappened();
        }
    }
}
