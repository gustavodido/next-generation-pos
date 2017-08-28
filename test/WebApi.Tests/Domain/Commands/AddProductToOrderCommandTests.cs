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
    public class AddProductToOrderCommandTests
    {
        private readonly DapperService _dapperService;

        private readonly AddProductToOrderCommand _addProductToOrderCommand;

        public AddProductToOrderCommandTests()
        {
            _dapperService = A.Fake<DapperService>();

            _addProductToOrderCommand =
                new AddProductToOrderCommand(A.Fake<IOptions<ApplicationConfiguration>>(), _dapperService);
        }

        [Fact]
        public void RunShouldReturnAggregatedBundlesForProduct()
        {
            // Given
            A.CallTo(() => _dapperService.Execute(A<string>.Ignored, A<object>.Ignored))
                .DoesNothing();

            // When
            _addProductToOrderCommand.Run(Constants.IphoneCaseOrder.Id, Constants.IphoneCase.Id);

            // Then

            A.CallTo(() => _dapperService.Execute(A<string>.Ignored, A<object>.Ignored))
                .MustHaveHappened();
        }
    }
}