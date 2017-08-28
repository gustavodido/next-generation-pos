using System;
using FakeItEasy;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Commands;
using WebApi.Domain.Entities;
using WebApi.Domain.Queries;
using WebApi.Services;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Domain.Commands
{
    public class CreateOrderCommandTests
    {
        private readonly DapperService _dapperService;

        private readonly CreateOrderCommand _createOrderCommand;

        public CreateOrderCommandTests()
        {
            _dapperService = A.Fake<DapperService>();

            _createOrderCommand =
                new CreateOrderCommand(A.Fake<IOptions<ApplicationConfiguration>>(), _dapperService);
        }

        [Fact]
        public void RunShouldReturnAggregatedBundlesForProduct()
        {
            // Given
            A.CallTo(() => _dapperService.ExecuteScalar<Guid>(A<string>.Ignored))
                .Returns(Constants.IphoneCaseOrder.Id);
            
            // When
            var order = _createOrderCommand.Run();
            
            // Then
            Assert.Equal(Constants.IphoneCaseOrder, order);

            A.CallTo(() => _dapperService.ExecuteScalar<Guid>(A<string>.Ignored))
                .MustHaveHappened();
        }
    }
}