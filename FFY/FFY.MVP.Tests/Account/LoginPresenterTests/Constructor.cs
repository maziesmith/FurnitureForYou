using FFY.MVP.Account.Login;
using FFY.Services.Contracts;
using FFY.MVP.Tests.Account.LoginPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Account.LoginPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ILoginView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new LoginPresenter(mockedView.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping carts service cannot be null.";

            var mockedView = new Mock<ILoginView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => 
                new LoginPresenter(mockedView.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidShoppingCartServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ILoginView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new LoginPresenter(mockedView.Object, mockedShoppingCartsService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidShoppingCartServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ILoginView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            var loginPresenter = new LoginPresenter(mockedView.Object, mockedShoppingCartsService.Object);

            Assert.IsInstanceOf<Presenter<ILoginView>>(loginPresenter);
        }

        [Test]
        public void ShouldSubscribeToLoginViewOnLogingEvent()
        {
            // Arrange
            var mockedView = new MockedLoginView();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            var loginPresenter = new LoginPresenter(mockedView, mockedShoppingCartsService.Object);

            Assert.IsTrue(mockedView.IsSubscribedMethod("OnLoggingIn"));
        }

        [Test]
        public void ShouldSubscribeToLoginViewOnRegisteringEvent()
        {
            // Arrange
            var mockedView = new MockedLoginView();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            var loginPresenter = new LoginPresenter(mockedView, mockedShoppingCartsService.Object);

            Assert.IsTrue(mockedView.IsSubscribedMethod("OnLoggingCartCount"));
        }
    }
}
