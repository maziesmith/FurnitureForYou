using FFY.Models;
using FFY.MVP.Administration.OrderManagement.Orders;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.OrderManagement.OrdersPresenterTests
{
    [TestFixture]
    public class OnFilteringOrders
    {
        [TestCase(2, "john")]
        [TestCase(1, "frank")]
        public void ShouldCallGetOrdersByStatusTypeAndSenderMethodFromOrdersService(int statusType, string search)
        {
            // Arrange
            var mockedView = new Mock<IOrdersView>();
            mockedView.Setup(v => v.Model).Returns(new OrdersViewModel());

            var mockedOrdersService = new Mock<IOrdersService>();
            mockedOrdersService.Setup(os => 
                os.GetOrdersByStatusTypeAndSender(It.IsAny<int>(), It.IsAny<string>()))
                .Verifiable();

            var ordersPresenter = new OrdersPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Act
            mockedView.Raise(v => v.FilterOrders += null, 
                new FilterEventArgs(statusType, search));

            // Assert
            mockedOrdersService.Verify(os => 
                os.GetOrdersByStatusTypeAndSender(statusType, search), Times.Once);
        }

        [TestCase(2, "john")]
        [TestCase(1, "frank")]
        public void ShouldAssignToViewModelOrders_ReceivedFromGetOrdersByStatusTypeAndSender(int statusType, string search)
        {
            // Arrange
            var orders = new List<Order>()
            {
                new Order() { Id = 1 },
                new Order() { Id = 2 }
            };

            var mockedView = new Mock<IOrdersView>();
            mockedView.Setup(v => v.Model).Returns(new OrdersViewModel());

            var mockedOrdersService = new Mock<IOrdersService>();
            mockedOrdersService.Setup(os =>
                os.GetOrdersByStatusTypeAndSender(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(orders)
                .Verifiable();

            var ordersPresenter = new OrdersPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Act
            mockedView.Raise(v => v.FilterOrders += null,
                new FilterEventArgs(statusType, search));

            // Assert
            CollectionAssert.AreEquivalent(orders, mockedView.Object.Model.Orders);
        }
    }
}
