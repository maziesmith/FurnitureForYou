using FFY.Data.Contracts;
using FFY.Data.Factories;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Services.ShoppingCartsServiceTests
{
    [TestFixture]
    public class GetCart
    {
        [TestCase(null)]
        [TestCase("")]
        public void ShouldThrowArgumentNullException_WhenNullOrEmptyCartIdIsPassed(string cartId)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                shoppingCartsService.GetCart(cartId));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrEmptyCartIdIsPassed(string cartId)
        {
            // Arrange
            var expectedExMessage = "Cart id cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                shoppingCartsService.GetCart(cartId));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallGetByIdMethodOfShoppingCartRepository()
        {
            // Arrange
            var cartId = "42-424";

            var shoppingCart = new ShoppingCart();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(scr => scr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart)
                .Verifiable();
            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.GetCart(cartId);

            // Assert
            mockedShoppingCartRepository.Verify(scr => scr.GetById(cartId), Times.Once);
        }
    }
}
