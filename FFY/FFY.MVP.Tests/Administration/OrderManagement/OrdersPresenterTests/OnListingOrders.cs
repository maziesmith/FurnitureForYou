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
    public class OnListingOrders
    {
        [Test]
        public void ShouldCallGetOrdersMethodFromOrdersService()
        {
            // Arrange
            var mockedView = new Mock<IOrdersView>();
            mockedView.Setup(v => v.Model).Returns(new OrdersViewModel());

            var mockedOrdersService = new Mock<IOrdersService>();
            mockedOrdersService.Setup(os => os.GetOrders()).Verifiable();

            var ordersPresenter = new OrdersPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Act
            mockedView.Raise(v => v.ListingOrders += null, new EventArgs());

            // Assert
            mockedOrdersService.Verify(os => os.GetOrders(), Times.Once);
        }

        [Test]
        public void ShouldAssignToViewModelOrders_ReceivedFromGetOrdersMethodFromOrdersService()
        {
            // Arrange
            var orders = new List<Order>()
            {
                new Order() { Id = 2 },
                new Order() { Id = 5 }
            };

            var mockedView = new Mock<IOrdersView>();
            mockedView.Setup(v => v.Model).Returns(new OrdersViewModel());

            var mockedOrdersService = new Mock<IOrdersService>();
            mockedOrdersService.Setup(os => os.GetOrders())
                .Returns(orders)
                .Verifiable();

            var ordersPresenter = new OrdersPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Act
            mockedView.Raise(v => v.ListingOrders += null, new EventArgs());

            // Assert
            CollectionAssert.AreEquivalent(orders, mockedView.Object.Model.Orders);
        }
    }
}
