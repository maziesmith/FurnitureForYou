using FFY.MVP.Users.Cart;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Users.CartPresenterTests
{
    [TestFixture]
    public class OnRemovingFromCart
    {
        [TestCase(4, "123")]
        [TestCase(42, "473")]
        public void ShouldCallRemoveMethodFromShoppingCartsService(int productId, string cartId)
        {
            // Arrange
            var mockedView = new Mock<ICartView>();
            mockedView.Setup(v => v.Model).Returns(new CartViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs => scs.Remove(It.IsAny<int>(),
                It.IsAny<string>())).Verifiable();

            var cartPresenter = new CartPresenter(mockedView.Object, 
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v =>
            v.RemovingFromCart += null, new RemoveFromCartArgs(productId, cartId));

            // Assert
            mockedShoppingCartsService.Verify(scs => scs.Remove(productId, cartId), Times.Once);
        }

        [TestCase(4, "123")]
        [TestCase(42, "473")]
        public void ShouldCallCartProductsCountMethodFromShoppingCartsService(int productId, string cartId)
        {
            // Arrange
            var mockedView = new Mock<ICartView>();
            mockedView.Setup(v => v.Model).Returns(new CartViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs => 
                scs.CartProductsCount(It.IsAny<string>())).Verifiable();

            var cartPresenter = new CartPresenter(mockedView.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v =>
            v.RemovingFromCart += null, new RemoveFromCartArgs(productId, cartId));

            // Assert
            mockedShoppingCartsService.Verify(scs => scs.CartProductsCount(cartId), Times.Once);
        }

        [TestCase(4, "123", 15)]
        [TestCase(42, "473", 20)]
        public void ShouldAssignProductsCountToViewModel_ReceivedFromCartProductsCountMethodFromShoppingCartsService(int productId, 
            string cartId,
            int expectedCount)
        {
            // Arrange
            var mockedView = new Mock<ICartView>();
            mockedView.Setup(v => v.Model).Returns(new CartViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs =>
                scs.CartProductsCount(It.IsAny<string>())).Returns(expectedCount);

            var cartPresenter = new CartPresenter(mockedView.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v =>
            v.RemovingFromCart += null, new RemoveFromCartArgs(productId, cartId));

            // Assert
            Assert.AreEqual(expectedCount, mockedView.Object.Model.CartCount);
        }
    }
}
