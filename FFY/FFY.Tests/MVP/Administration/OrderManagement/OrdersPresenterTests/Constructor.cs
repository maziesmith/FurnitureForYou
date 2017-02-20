using FFY.MVP.Administration.OrderManagement.Orders;
using FFY.Services.Contracts;
using FFY.Tests.MVP.Administration.OrderManagement.OrdersPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.Tests.MVP.Administration.OrderManagement.OrdersPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullOrdersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IOrdersView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new OrdersPresenter(mockedView.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrdersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Orders service cannot be null.";

            var mockedView = new Mock<IOrdersView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => 
                new OrdersPresenter(mockedView.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidOrdersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IOrdersView>();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new OrdersPresenter(mockedView.Object,
                mockedOrdersService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidOrdersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IOrdersView>();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act
            var ordersPresenter = new OrdersPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IOrdersView>>(ordersPresenter);
        }

        [Test]
        public void ShouldSubscribeToOrdersViewOnListingOrdersEvent()
        {
            // Arrange
            var mockedView = new MockedOrdersView();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act
            var ordersPresenter = new OrdersPresenter(mockedView,
                mockedOrdersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnListingOrders"));
        }

        [Test]
        public void ShouldSubscribeToOrdersViewOnFilteringOrdersEvent()
        {
            // Arrange
            var mockedView = new MockedOrdersView();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act
            var ordersPresenter = new OrdersPresenter(mockedView,
                mockedOrdersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnFilteringOrders"));
        }
    }
}
