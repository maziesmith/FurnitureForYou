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
    public class Delete
    {
        [TestCase("")]
        [TestCase(null)]
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
                shoppingCartsService.Remove(1, cartId));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrEmptyCartIdIsPassed(string cartId)
        {
            // Arrange
            var expectedExMessage = "Cart id cannot be null or empty.";

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
                shoppingCartsService.Remove(1, cartId));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [TestCase("42-424")]
        public void ShouldCallGetByIdMethodOfShoppingCartRepositoryOnce(string cartId)
        {
            // Arrange
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
            shoppingCartsService.Remove(1, cartId);
            
            // Assert
            mockedShoppingCartRepository.Verify(scr => scr.GetById(cartId), Times.Once);
        }


        [TestCase("42-424", 42)]
        public void ShouldCallDeleteMethodOfCartRepositoryOnce_WhenProductWithThisIdIsFoundInTemporaryProducts(string cartId, int productId)
        {
            // Arrange
            var product = new Product() { Id = productId };
            var cartProduct = new CartProduct() { Product = product, ProductId = productId };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            mockedCartProductRepository.Setup(cpr =>
                cpr.Delete(It.IsAny<CartProduct>()))
                .Verifiable();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(scr => scr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Remove(productId, cartId);

            // Assert
            mockedCartProductRepository.Verify(cpr => cpr.Delete(cartProduct), Times.Once);
        }

        [TestCase("42-424", 42)]
        public void ShouldCallDeleteMethodOfCartRepositoryTwice_WhenProductWithThisIdIsFoundInTemporaryAndPermanentProducts(string cartId, int productId)
        {
            // Arrange
            var product = new Product() { Id = productId };
            var cartProduct = new CartProduct() { Product = product, ProductId = productId };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct },
                PermamentProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            mockedCartProductRepository.Setup(cpr =>
                cpr.Delete(It.IsAny<CartProduct>()))
                .Verifiable();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(scr => scr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Remove(productId, cartId);

            // Assert
            mockedCartProductRepository.Verify(cpr => cpr.Delete(cartProduct), Times.Exactly(2));
        }

        [TestCase("42-424", 42)]
        public void ShoulRecalculateTotalOfShoppingCart_WhenCartProductIsRemoved(string cartId, int productId)
        {
            // Arrange
            var price = 10.0M;
            var quantity = 3;

            var product = new Product() { Id = productId, DiscountedPrice = price };
            var cartProduct = new CartProduct() { Quantity = quantity, Product = product, ProductId = productId };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct, cartProduct },
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            mockedCartProductRepository.Setup(cpr =>
                cpr.Delete(It.IsAny<CartProduct>()))
                .Callback(() => shoppingCart.TemporaryProducts.Remove(cartProduct));
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(scr => scr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Remove(productId, cartId);
            var expectedTotal = price * quantity * shoppingCart.TemporaryProducts.Count;

            // Assert
            Assert.AreEqual(expectedTotal, shoppingCart.Total);
        }

        [TestCase("42-424")]
        public void ShouldCallUpdateMethodOfShoppingCartRepositoryOnce_WhenOperationsAreDone(string cartId)
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var product = new Mock<Product>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(scr => scr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);
            mockedShoppingCartRepository.Setup(scr => scr.Update(It.IsAny<ShoppingCart>()))
                .Verifiable();
            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Remove(1, cartId);

            // Assert
            mockedShoppingCartRepository.Verify(scr => scr.Update(shoppingCart), Times.Once);
        }

        [TestCase("42-424")]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenOperationsAreDone(string cartId)
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var product = new Mock<Product>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
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
            shoppingCartsService.Remove(1, cartId);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
