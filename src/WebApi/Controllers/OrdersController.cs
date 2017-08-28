using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Commands;
using WebApi.Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController
    {
        private readonly CreateOrderCommand _createOrderCommand;

        public OrdersController(CreateOrderCommand createOrderCommand)
        {
            _createOrderCommand = createOrderCommand;
        }

        [HttpPost]
        public Order Post()
        {
            return _createOrderCommand.Run();
        }
    }
}