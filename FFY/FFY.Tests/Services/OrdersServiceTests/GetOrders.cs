using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Services.OrdersServiceTests
{
    [TestFixture]
    public class GetOrders
    {
        [Test]
        public void ShouldCallGetAllMethodOfOrdersRepositoryOnce()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr =>
                gr.GetAll(null, It.IsAny<Expression<Func<Order, DateTime>>>()))
                .Returns(new List<Order>())
                .Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.GetOrders();

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(null, It.IsAny<Expression<Func<Order, DateTime>>>()), Times.Once);
        }

        [Test]
        public void ShouldReturnAllOrdersSortedBySendOnDateFromOrdersRepository()
        {
            // Arrange
            var order1 = new Order() { SendOn = new DateTime(2016, 1, 1) };
            var order2 = new Order() { SendOn = new DateTime(2017, 1, 1) };
            var order3 = new Order() { SendOn = new DateTime(2015, 1, 1) };
            var mockedOrders = new List<Order> { order1, order2, order3 };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => 
                gr.GetAll(null, It.IsAny<Expression<Func<Order, DateTime>>>()))
                .Returns(mockedOrders.OrderByDescending(s => s.SendOn));

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = ordersService.GetOrders().ToList();

            // Assert
            Assert.AreSame(order2, result[0]);
            Assert.AreEqual(order1, result[1]);
            Assert.AreEqual(order3, result[2]);
        }

    }
}
