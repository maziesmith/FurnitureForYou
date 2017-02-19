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
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUnitOfWorkIsPassed()
        {
            // Arrange
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ShoppingCartsService(null, 
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
        {
            // Arrange
            var expectedExMessage = "Unit of work cannot be null.";

            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ShoppingCartsService(null,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCartProductFactoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ShoppingCartsService(mockedUnitOfWork.Object,
                    null,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCartProductFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Cart product factory cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ShoppingCartsService(mockedUnitOfWork.Object,
                    null,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartRepositoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    null,
                    mockedCartProductRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartRepositoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping cart repository cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    null,
                    mockedCartProductRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCartProductRepositoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCartProductRepositoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Cart product repository cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            // Act and Assert
            Assert.DoesNotThrow(() =>
                new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object));
        }
    }
}
