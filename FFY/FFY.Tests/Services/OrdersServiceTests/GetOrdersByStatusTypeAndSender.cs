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
    public class GetOrdersByStatusTypeAndSender
    {
        [Test]
        public void ShouldCallGetAllMethodOfOrdersRepositoryOnce()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr =>
                gr.GetAll())
                .Returns(new List<Order>())
                .Verifiable();

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            ordersService.GetOrdersByStatusTypeAndSender(0, string.Empty);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [TestCase("sam", 2)]
        [TestCase("vi", 2)]
        [TestCase("mail", 4)]
        [TestCase("xx", 0)]
        public void ShouldReturnCorrectAmountOfFilteredOrders_WhenSearchWordIsProvided(string search, int expectedAmount)
        {
            // Arrange
            var orders = new List<Order>()
            {
                new Order() { User = new User() { FirstName = "Samuel", LastName = "Vimes", Email = "sam@mail.com" } },
                new Order() { User = new User() { FirstName = "Sam", LastName = "Johnson", Email = "sj@mail.com" } },
                new Order() { User = new User() { FirstName = "Johny", LastName = "Cash", Email = "johnyc@mail.com" } },
                new Order() { User = new User() { FirstName = "Victor", LastName = "The Great", Email = "victor@mail.com" } }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(orders);

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = ordersService.GetOrdersByStatusTypeAndSender(0, search);

            // Assert
            Assert.AreEqual(expectedAmount, result.Count());
        }

        [TestCase("vi")]
        public void ShouldReturnCorrectFilteredOrders_WhenSearchWordIsProvided(string search)
        {
            // Arrange
            var orders = new List<Order>()
            {
                new Order() { User = new User() { FirstName = "Samuel", LastName = "Vimes", Email = "sam@mail.com" } },
                new Order() { User = new User() { FirstName = "Sam", LastName = "Johnson", Email = "sj@mail.com" } },
                new Order() { User = new User() { FirstName = "Johny", LastName = "Cash", Email = "johnyc@mail.com" } },
                new Order() { User = new User() { FirstName = "Victor", LastName = "The Great", Email = "victor@mail.com" } }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(orders);

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = ordersService.GetOrdersByStatusTypeAndSender(0, search).ToList();

            // Assert
            Assert.AreEqual("Victor", result[0].User.FirstName);
            Assert.AreEqual("Vimes", result[1].User.LastName);
        }

        [TestCase(42)]
        [TestCase(-10)]
        public void ShouldThrowInvalidCastException_WhenInvalidOrderStatusTypeIsPassed(int statusType)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(new List<Order>());

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<InvalidCastException>(() =>
                ordersService.GetOrdersByStatusTypeAndSender(statusType, string.Empty).ToList());
        }

        [TestCase(-10)]
        public void ShouldThrowInvalidCastExceptionWithCorrectMessage_WhenInvalidOrderStatusTypeIsPassed(int statusType)
        {
            // Arrange
            var expectedExMessage = "Order status type is out of enumeration range.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(new List<Order>());

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidCastException>(() =>
                ordersService.GetOrdersByStatusTypeAndSender(statusType, string.Empty).ToList());
            StringAssert.Contains(exception.Message, expectedExMessage);
        }

        [TestCase("vi", 1, 2)]
        [TestCase("a", 1, 2)]
        [TestCase("sam", 2, 0)]
        public void ShouldReturnCorrectFilteredOrders_WhenSearchWordAndStatusTypeAreProvided(string search, int statusType, int expectedAmount)
        {
            // Arrange
            var orders = new List<Order>()
            {
                new Order()
                {
                    User = new User() { FirstName = "Samuel", LastName = "Vimes", Email = "sam@mail.com" },
                    OrderStatusType = OrderStatusType.Processing
                },
                new Order()
                {
                    User = new User() { FirstName = "Sam", LastName = "Johnson", Email = "sj@mail.com" },
                    OrderStatusType = OrderStatusType.Delivered
                },

                new Order()
                {
                    User = new User() { FirstName = "Johny", LastName = "Cash", Email = "johnyc@mail.com" },
                    OrderStatusType = OrderStatusType.Sent
                },
                new Order()
                {
                    User = new User() { FirstName = "Victor", LastName = "The Great", Email = "victor@mail.com" },
                    OrderStatusType = OrderStatusType.Processing
                }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Order>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(orders);

            var ordersService = new OrdersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = ordersService.GetOrdersByStatusTypeAndSender(statusType, search);

            // Assert
            Assert.AreEqual(expectedAmount, result.Count());
        }
    }
}