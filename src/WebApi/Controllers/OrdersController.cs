using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Models;
using WebApi.Domain.Commands;
using WebApi.Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController
    {
        private readonly CreateOrderCommand _createOrderCommand;
        private readonly AddProductToOrderCommand _addProductToOrderCommand;

        public OrdersController(CreateOrderCommand createOrderCommand, AddProductToOrderCommand addProductToOrderCommand)
        {
            _createOrderCommand = createOrderCommand;
            _addProductToOrderCommand = addProductToOrderCommand;
        }

        [HttpPost]
        public Order Create()
        {
            return _createOrderCommand.Run();
        }

        [HttpPut("{id}")]
        public void AddProduct(Guid id, [FromBody]  ProductWrapper product)
        {
            _addProductToOrderCommand.Run(id, product.ProductId);
        }
    }
}