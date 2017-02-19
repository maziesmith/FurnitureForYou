using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Services.OrdersServiceTests
{
    [TestFixture]
    public class GetOrderById
    {
        [TestCase(42)]
        [TestCase(2)]
        public void ShouldCallGetOrderByIdMethodOfOrdersRepositoryOnce(int id)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.GetOrderById(id);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetById(id), Times.Once);
        }

        [TestCase(2, "9876543")]
        [TestCase(4, "1234567")]
        public void ShouldReturnCorrectOrderFromOrdersRepository(int id, string expectedPhoneNumber)
        {
            // Arrange
            var mockedOrders = new List<Order>
            {
                new Order() { Id = 2, PhoneNumber = "9876543"},
                new Order() { Id = 4, PhoneNumber = "1234567" }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.GetById(id))
                .Returns(mockedOrders.Find(p => p.Id == id));

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = ordersService.GetOrderById(id);

            // Assert
            Assert.AreEqual(expectedPhoneNumber, result.PhoneNumber);
        }
    }
}
