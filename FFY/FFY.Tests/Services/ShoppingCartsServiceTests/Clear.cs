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
    public class Clear
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartIsPassed()
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
                shoppingCartsService.Clear(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping cart cannot be null.";

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
                shoppingCartsService.Clear(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldClearShoppingCartTemporaryProducts()
        {
            // Arrange
            var cartProduct = new CartProduct();
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct, cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Clear(shoppingCart);

            // Assert
            Assert.AreEqual(0, shoppingCart.TemporaryProducts.Count);
        }

        [Test]
        public void ShouldZeroShoppingCartTotal()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Clear(shoppingCart);

            // Assert
            Assert.AreEqual(0, shoppingCart.Total);
        }

        [Test]
        public void ShouldCallUpdateMethodOfCartRepositoryOnce()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(scr => scr.Update(It.IsAny<ShoppingCart>()))
                .Verifiable();
            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Clear(shoppingCart);

            // Assert
            mockedShoppingCartRepository.Verify(scr => scr.Update(shoppingCart), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(uow => uow.Commit())
                .Verifiable();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Clear(shoppingCart);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
