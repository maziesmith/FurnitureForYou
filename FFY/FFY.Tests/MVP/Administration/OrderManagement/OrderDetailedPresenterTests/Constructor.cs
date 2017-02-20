using FFY.MVP.OrderManagement.OrderDetailed;
using FFY.Services.Contracts;
using FFY.Tests.MVP.Administration.OrderManagement.OrderDetailedPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.Tests.MVP.Administration.OrderManagement.OrderDetailedPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullOrdersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IOrderDetailedView>();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new OrderDetailedPresenter(mockedView.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrdersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Orders service cannot be null.";

            var mockedView = new Mock<IOrderDetailedView>();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new OrderDetailedPresenter(mockedView.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidOrdersServiceArePassed()
        {
            // Arrange
            var mockedView = new Mock<IOrderDetailedView>();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new OrderDetailedPresenter(mockedView.Object,
                mockedOrdersService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidOrdersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IOrderDetailedView>();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act
            var orderDetailedPresenter = new OrderDetailedPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IOrderDetailedView>>(orderDetailedPresenter);
        }

        [Test]
        public void ShouldSubscribeToContactDetailedViewOnInitialEvent()
        {
            // Arrange
            var mockedView = new MockedOrderDetailedView();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act
            var orderDetailedPresenter = new OrderDetailedPresenter(mockedView,
                mockedOrdersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnInitial"));
        }

        [Test]
        public void ShouldSubscribeToLoginViewOnEdittingOrderStatusEvent()
        {
            // Arrange
            var mockedView = new MockedOrderDetailedView();
            var mockedOrdersService = new Mock<IOrdersService>();

            // Act
            var orderDetailedPresenter = new OrderDetailedPresenter(mockedView,
                mockedOrdersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnEdittingOrderStatus"));
        }
    }
}
