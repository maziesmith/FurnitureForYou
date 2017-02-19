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
    public class AssignShoppingCart
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
            Assert.Throws<ArgumentNullException>(() => shoppingCartsService.AssignShoppingCart(null));
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
                shoppingCartsService.AssignShoppingCart(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfShoppingCartRepositoryOnce_WhenShoppingCartIsPassed()
        {
            // Arrange
            var shoppingCart = new Mock<ShoppingCart>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.Add(shoppingCart.Object)).Verifiable();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.AssignShoppingCart(shoppingCart.Object);

            // Assert
            mockedShoppingCartRepository.Verify(gr => gr.Add(shoppingCart.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenShoppingCartIsPassed()
        {
            // Arrange
            var shoppingCart = new Mock<ShoppingCart>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.AssignShoppingCart(shoppingCart.Object);

            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
