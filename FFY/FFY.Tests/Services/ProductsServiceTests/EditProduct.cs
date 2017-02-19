using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Services.ProductsServiceTests
{
    [TestFixture]
    public class EditProduct
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);
            
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => productsService.EditProduct(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductIsPassed()
        {
            // Arrange
            var expectedExMessage = "Product cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => productsService.EditProduct(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallUpdateMethodOfCategoryRepositoryOnce_WhenAProductIsPassed()
        {
            // Arrange
            var product = new Mock<Product>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.Update(product.Object)).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            productsService.EditProduct(product.Object);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Update(product.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAProductIsPassed()
        {
            // Arrange
            var product = new Mock<Product>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
          
            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            productsService.EditProduct(product.Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
