using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Users.CheckOut;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Users.CheckOutPresenterTests
{
    [TestFixture]
    public class OnCartClearing
    {
        [Test]
        public void ShouldCallGetCartMethodFromShoppingCartsService()
        {   
            // Arrange
            var cartId = "4212345";
            var shoppingCart = new ShoppingCart();

            var mockedView = new Mock<ICheckOutView>();
            mockedView.Setup(v => v.Model).Returns(new CheckOutViewModel());
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs =>
                scs.GetCart(It.IsAny<string>()))
                .Returns(shoppingCart)
                .Verifiable();

            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();


            var checkOutPresenter = new CheckOutPresenter(mockedView.Object,
                 mockedShoppingCartsService.Object,
                 mockedUsersService.Object,
                 mockedOrdersService.Object,
                 mockedAddressesService.Object,
                 mockedAddressesFactory.Object,
                 mockedOrdersFactory.Object);

            // Act
            mockedView.Raise(v => v.CartClearing += null, new CartClearEventArgs(cartId));

            // Assert
            mockedShoppingCartsService.Verify(scs => scs.GetCart(cartId), Times.Once);
        }

        [Test]
        public void ShouldCallClearMethodFromShoppingCartsService()
        {
            // Arrange
            var cartId = "4212345";
            var shoppingCart = new ShoppingCart();

            var mockedView = new Mock<ICheckOutView>();
            mockedView.Setup(v => v.Model).Returns(new CheckOutViewModel());
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs =>
                scs.GetCart(It.IsAny<string>()))
                .Returns(shoppingCart)
                .Verifiable();

            mockedShoppingCartsService.Setup(scs => scs.Clear(It.IsAny<ShoppingCart>())).Verifiable();

            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrdersService>();
            var mockedAddressesService = new Mock<IAddressesService>();
            var mockedAddressesFactory = new Mock<IAddressesFactory>();
            var mockedOrdersFactory = new Mock<IOrdersFactory>();


            var checkOutPresenter = new CheckOutPresenter(mockedView.Object,
                 mockedShoppingCartsService.Object,
                 mockedUsersService.Object,
                 mockedOrdersService.Object,
                 mockedAddressesService.Object,
                 mockedAddressesFactory.Object,
                 mockedOrdersFactory.Object);

            // Act
            mockedView.Raise(v => v.CartClearing += null, new CartClearEventArgs(cartId));

            // Assert
            mockedShoppingCartsService.Verify(scs => scs.Clear(shoppingCart), Times.Once);
        }
    }
}
