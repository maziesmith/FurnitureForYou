using FFY.MVP.Tests.Users.Mocks.CartPresenterTests;
using FFY.MVP.Users.Cart;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Users.CartPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICartView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CartPresenter(mockedView.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping carts service cannot be null.";
            var mockedView = new Mock<ICartView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CartPresenter(mockedView.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidShoppingCartsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICartView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new CartPresenter(mockedView.Object,
                mockedShoppingCartsService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidShoppingCartsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICartView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var cartPresenter = new CartPresenter(mockedView.Object,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<ICartView>>(cartPresenter);
        }

        [Test]
        public void ShouldSubscribeToCartViewOnInitialEvent()
        {
            // Arrange
            var mockedView = new MockedCartView();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var cartPresenter = new CartPresenter(mockedView,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnInitial"));
        }

        [Test]
        public void ShouldSubscribeToCartViewOnRemovingFromCartEvent()
        {
            // Arrange
            var mockedView = new MockedCartView();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var cartPresenter = new CartPresenter(mockedView,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnRemovingFromCart"));
        }
    }
}
