using FFY.Data.Factories;
using FFY.MVP.Tests.Users.CheckOutPresenterTests.Mocks;
using FFY.MVP.Users.CheckOut;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Users.CheckOutPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICheckOutView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                null,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping carts service cannot be null.";

            var mockedView = new Mock<ICheckOutView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                null,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                null,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Users service cannot be null.";

            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                null,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullOrdersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                null,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrdersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Orders service cannot be null.";

            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                null,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullAddressesServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                null,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullAddressesServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Addresses service cannot be null.";

            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                null,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullAddressesFactoryIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                null,
                mockedOrdersFactory.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullAddressesFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Addresses factory cannot be null.";

            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                null,
                mockedOrdersFactory.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullOrdersFactoryIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrdersFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Orders factory cannot be null.";

            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act and Assert
            Assert.DoesNotThrow(() => new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<ICheckOutView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act
            var checkOutPresenter = new CheckOutPresenter(mockedView.Object,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<ICheckOutView>>(checkOutPresenter);
        }

        [Test]
        public void ShouldSubscribeToCheckOutViewOnCheckingOutEvent()
        {
            // Arrange
            var mockedView = new MockedCheckOutView();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act
            var checkOutPresenter = new CheckOutPresenter(mockedView,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnCheckingOut"));
        }

        [Test]
        public void ShouldSubscribeToCheckOutViewOnCartClearingEvent()
        {
            // Arrange
            var mockedView = new MockedCheckOutView();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();

            // Act
            var checkOutPresenter = new CheckOutPresenter(mockedView,
                mockedShoppingCartsService.Object,
                mockedUsersService.Object,
                mockedOrdersService.Object,
                mockedAddressesService.Object,
                mockedAddressesFactory.Object,
                mockedOrdersFactory.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnCartClearing"));
        }
    }
}
