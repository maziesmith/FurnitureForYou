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
    public class ChangeOrderStatus
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullOrderIsPassed()
        {
            // Arrange
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => ordersService.ChangeOrderStatus(null, 2, 3));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Order cannot be null.";

            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => ordersService.ChangeOrderStatus(null, 2, 3));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowInvalidCastException_WhenInvalidStatusTypeIsPassed()
        {
            // Arrange
            var order = new Mock<Order>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();

            mockedGenericRepository.Setup(gr => gr.Update(order.Object)).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<InvalidCastException>(() => ordersService.ChangeOrderStatus(order.Object, 404, 1));
        }

        [Test]
        public void ShouldThrowInvalidCastExceptionWithCorrectMessage_WhenInvalidStatusTypeIsPassed()
        {
            // Arrange
            var expectedExMessage = "Order status type is out of enumeration range.";

            var order = new Mock<Order>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.Update(order.Object)).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidCastException>(() => ordersService.ChangeOrderStatus(order.Object, 404, 1));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowInvalidCastException_WhenInvalidPaymentStatusTypeIsPassed()
        {
            // Arrange
            var order = new Mock<Order>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();

            mockedGenericRepository.Setup(gr => gr.Update(order.Object)).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<InvalidCastException>(() => ordersService.ChangeOrderStatus(order.Object, 1, 404));
        }

        [Test]
        public void ShouldThrowInvalidCastExceptionWithCorrectMessage_WhenInvalidPaymentStatusTypeIsPassed()
        {
            // Arrange
            var expectedExMessage = "Order payment status type is out of enumeration range.";

            var order = new Mock<Order>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.Update(order.Object)).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidCastException>(() => ordersService.ChangeOrderStatus(order.Object, 1, 404));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void ShouldAssignNewOrderStatus_WhenValidStatusTypeIsPassed(int statusType)
        {
            // Arrange
            var user = new Mock<User>();
            var order = new Order();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.ChangeOrderStatus(order, statusType, 1);

            // Assert
            Assert.AreEqual((OrderStatusType)statusType, order.OrderStatusType);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ShouldAssignNewOrderPaymentStatus_WhenValidStatusTypeIsPassed(int paymentStatusType)
        {
            // Arrange
            var user = new Mock<User>();
            var order = new Order();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.ChangeOrderStatus(order, 1, paymentStatusType);

            // Assert
            Assert.AreEqual((OrderPaymentStatusType)paymentStatusType, order.OrderPaymentStatusType);
        }

        [Test]
        public void ShouldCallUpdateMethodOfOrderRepositoryOnce_WhenAOrderIsPassed()
        {
            // Arrange
            var order = new Mock<Order>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.Update(order.Object)).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.ChangeOrderStatus(order.Object, 2, 2);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Update(order.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAOrderIsPassed()
        {
            // Arrange
            var order = new Mock<Order>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.ChangeOrderStatus(order.Object, 2, 2);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
