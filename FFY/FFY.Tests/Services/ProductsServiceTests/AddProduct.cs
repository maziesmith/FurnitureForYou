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
    public class AddProduct
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            Assert.Throws<ArgumentNullException>(() => productsService.AddProduct(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductIsPassed()
        {
            var expectedExMessage = "Product cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var exception = Assert.Throws<ArgumentNullException>(() => productsService.AddProduct(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenAProductIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var product = new Mock<Product>();
            mockedGenericRepository.Setup(gr => gr.Add(product.Object)).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            productsService.AddProduct(product.Object);

            mockedGenericRepository.Verify(gr => gr.Add(product.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAProductIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var product = new Mock<Product>();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            productsService.AddProduct(product.Object);

            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
