using FakeItEasy;
using Microsoft.Extensions.Options;
using WebApi.Configuration;
using WebApi.Domain.Commands;
using WebApi.Domain.Entities;
using WebApi.Services;
using WebApi.Tests.Common;
using Xunit;

namespace WebApi.Tests.Domain.Commands
{
    public class AddBundleToOrderCommandTests
    {
        private readonly DapperService _dapperService;

        private readonly AddProductToOrderCommand _addProductToOrderCommand;

        private readonly AddBundleToOrderCommand _addBundleToOrderCommand;

        public AddBundleToOrderCommandTests()
        {
            _dapperService = A.Fake<DapperService>();
            _addProductToOrderCommand = A.Fake<AddProductToOrderCommand>();

            _addBundleToOrderCommand =
                new AddBundleToOrderCommand(A.Fake<IOptions<ApplicationConfiguration>>(), _dapperService, _addProductToOrderCommand);
        }

        [Fact]
        public void RunShouldAddProductsFromBundleToOrder()
        {
            var expectedProducts = new[] {Constants.IphoneCase};
            
            // Given
            A.CallTo(() => _dapperService.List<Product>(A<string>.Ignored, A<object>.Ignored))
                .Returns(expectedProducts);

            A.CallTo(() => _addProductToOrderCommand.Run(Constants.IphoneCaseOrder.Id, Constants.IphoneCase.Id))
                .DoesNothing();

            // When
            _addBundleToOrderCommand.Run(Constants.IphoneCaseOrder.Id, Constants.IphoneBundle.Id);

            // Then
            A.CallTo(() => _dapperService.List<Product>(A<string>.Ignored, A<object>.Ignored))
                .MustHaveHappened();

            A.CallTo(() => _addProductToOrderCommand.Run(Constants.IphoneCaseOrder.Id, Constants.IphoneCase.Id))
                .MustHaveHappened();
        }
    }
}