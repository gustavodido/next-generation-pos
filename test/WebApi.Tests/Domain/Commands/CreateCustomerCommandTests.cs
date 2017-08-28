using System;
using FakeItEasy;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Commands;
using WebApi.Services;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Domain.Commands
{
    public class CreateCustomerCommandTests
    {
        private readonly DapperService _dapperService;

        private readonly CreateCustomerCommand _createCustomerCommand;

        public CreateCustomerCommandTests()
        {
            _dapperService = A.Fake<DapperService>();

            _createCustomerCommand =
                new CreateCustomerCommand(A.Fake<IOptions<ApplicationConfiguration>>(), _dapperService);
        }

        [Fact]
        public void RunShouldCreateNewCustomer()
        {
            // Given
            var newCreatedGuid = Guid.NewGuid();
            
            A.CallTo(() => _dapperService.ExecuteScalar<Guid>(A<string>.Ignored, A<object>.Ignored))
                .Returns(newCreatedGuid);
            
            // When
            var customer = _createCustomerCommand.Run(Constants.CoolCustomer);
            
            // Then
            Assert.Equal(newCreatedGuid, customer.Id);

            A.CallTo(() => _dapperService.ExecuteScalar<Guid>(A<string>.Ignored, A<object>.Ignored))
                .MustHaveHappened();
        }

    }
}