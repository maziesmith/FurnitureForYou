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
    public class CartProductsCount
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
                shoppingCartsService.CartProductsCount(cartId));
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
                shoppingCartsService.CartProductsCount(cartId));
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
            shoppingCartsService.CartProductsCount(cartId);

            // Assert
            mockedShoppingCartRepository.Verify(scr => scr.GetById(cartId), Times.Once);
        }

        [Test]
        public void ShouldReturnCorrectAmountOfTemporaryCartProductsInShoppingCart()
        {
            // Arrange
            var cartId = "42-424";
            var expectedCount = 2;

            var cartProduct = new CartProduct();
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct, cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(scr => scr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);
            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            var count = shoppingCartsService.CartProductsCount(cartId);

            // Assert
            Assert.AreEqual(expectedCount, count);
        }
    }
}
