using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Controllers;
using MyShop.Web.Models;
using System;

namespace MyShop.Web.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void CanCreateOrderWithCorrectModel()
        {
            var orderRepo = new Mock<IRepository<Order>>();
            var productRepo = new Mock<IRepository<Product>>();

            var orderController = new OrderController(orderRepo.Object, productRepo.Object);


            var createOrderModel = new CreateOrderModel()
            {
                Customer = new CustomerModel()
                {
                    Name = "Filip Ekberg",
                    ShippingAddress = "Test Address",
                    City = "Gothenburg",
                    PostalCode = "43317",
                    Country = "Sweden"
                },
                LineItems = new[]
                {
                    new LineItemModel(){ProductId = Guid.NewGuid(), Quantity=2},
                    new LineItemModel(){ProductId = Guid.NewGuid(), Quantity=12}
                }
            };

            orderController.Create(createOrderModel);

            orderRepo.Verify(repo => repo.Add(It.IsAny<Order>()), Times.AtMostOnce);
        }
    }
}
