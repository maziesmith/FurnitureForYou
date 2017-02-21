using FFY.Models;
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
    public class OnInitial
    {
        [TestCase("42123")]
        [TestCase("51256")]
        public void ShouldCallGetCartMethodFromShoppingCartsService(string cartId)
        {
            // Arrange
            var mockedView = new Mock<ICartView>();
            mockedView.Setup(v => v.Model).Returns(new CartViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs => 
                scs.GetCart(It.IsAny<string>())).Verifiable();

            var cartPresenter = new CartPresenter(mockedView.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v =>
            v.Initial += null, new CartEventArgs(cartId));

            // Assert
            mockedShoppingCartsService.Verify(scs => scs.GetCart(cartId), Times.Once);
        }

        [TestCase("42123")]
        [TestCase("51256")]
        public void ShouldCallRemoveMethodFromShoppingCartsService(string cartId)
        {
            // Arrange
            var shoppingCart = new ShoppingCart()
            {
                UserId = "4125621",
                Total = 42,
            };

            var mockedView = new Mock<ICartView>();
            mockedView.Setup(v => v.Model).Returns(new CartViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs =>
                scs.GetCart(It.IsAny<string>())).Returns(shoppingCart);

            var cartPresenter = new CartPresenter(mockedView.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v =>
            v.Initial += null, new CartEventArgs(cartId));

            // Assert
            Assert.AreEqual(shoppingCart, mockedView.Object.Model.ShoppingCart);
        }
    }
}
