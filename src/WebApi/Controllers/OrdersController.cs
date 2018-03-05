using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Models;
using WebApi.Domain.Commands;
using WebApi.Domain.Entities;
using WebApi.Domain.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController
    {
        private readonly AddProductToOrderCommand _addProductToOrderCommand;
        private readonly AddBundleToOrderCommand _addBundleToOrderCommand;
        private readonly CreateOrderCommand _createOrderCommand;
        private readonly GetOrderByIdQuery _getOrderByIdQuery;

        public OrdersController(CreateOrderCommand createOrderCommand, AddProductToOrderCommand addProductToOrderCommand, GetOrderByIdQuery getOrderByIdQuery, AddBundleToOrderCommand addBundleToOrderCommand)
        {
            _createOrderCommand = createOrderCommand;
            _addProductToOrderCommand = addProductToOrderCommand;
            _getOrderByIdQuery = getOrderByIdQuery;
            _addBundleToOrderCommand = addBundleToOrderCommand;
        }

        [HttpGet("{id}")]
        public IEnumerable<Product> Get(Guid id)
        {
            return _getOrderByIdQuery.Run(id);
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
        
        [HttpPut("{id}/bundle")]
        public void AddBundle(Guid id, [FromBody]  BundleWrapper bundle)
        {
            _addBundleToOrderCommand.Run(id, bundle.BundleId);
        }

    }
}