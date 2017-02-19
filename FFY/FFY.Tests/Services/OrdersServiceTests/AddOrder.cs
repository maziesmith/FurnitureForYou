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
    public class AddOrder
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullOrderIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => ordersService.AddOrder(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Order cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => ordersService.AddOrder(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenAOrderIsPassed()
        {
            // Arrange
            var order = new Mock<Order>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.Add(order.Object)).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.AddOrder(order.Object);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Add(order.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAOrderIsPassed()
        {
            // Arrange
            var order = new Mock<Order>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.AddOrder(order.Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
