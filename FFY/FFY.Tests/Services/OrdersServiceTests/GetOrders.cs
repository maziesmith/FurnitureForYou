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
        public void ShouldReturnAllOrdersFromOrdersRepository()
        {
            // Arrange
            var mockedOrder = new Mock<Order>();
            var mockedOrders = new List<Order>
            {
                mockedOrder.Object,
                mockedOrder.Object
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => 
                gr.GetAll(null, It.IsAny<Expression<Func<Order, DateTime>>>()))
                .Returns(mockedOrders);

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = ordersService.GetOrders().ToList();

            // Assert
            Assert.AreEqual(mockedOrders, result);
        }

    }
}
