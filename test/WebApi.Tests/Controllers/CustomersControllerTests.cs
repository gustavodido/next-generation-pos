using FakeItEasy;
using WebApi.Controllers;
using WebApi.Domain.Commands;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly CustomersController _customersController;
        
        private readonly CreateCustomerCommand _createCustomerCommand;

        public CustomersControllerTests()
        {
            _createCustomerCommand = A.Fake<CreateCustomerCommand>();
            
            _customersController = new CustomersController(_createCustomerCommand);
        }

        [Fact]
        public void CreateShouldCreateNewCustomer()
        {
            // Given
            A.CallTo(() => _createCustomerCommand.Run(Constants.CoolCustomer)).Returns(Constants.CoolCustomer);
            
            // When
            var customer = _customersController.Create(Constants.CoolCustomer);
            
            // Then
            Assert.Equal(Constants.CoolCustomer, customer);

            A.CallTo(() => _createCustomerCommand.Run(Constants.CoolCustomer)).MustHaveHappened();
        }
    }
}