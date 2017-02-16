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
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUnitOfWorkIsPassed()
        {
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            Assert.Throws<ArgumentNullException>(() => 
                new ProductsService(null, mockedGenericRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
        {
            var expectedExMessage = "Unit of work cannot be null.";
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ProductsService(null, mockedGenericRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductRepositoryIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() =>
                new ProductsService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductRepositoryIsPassed()
        {
            var expectedExMessage = "Products repository cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ProductsService(mockedUnitOfWork.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUnitOfWorkAndProductRepositoryArePassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            Assert.DoesNotThrow(() =>
                new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object));
        }
    }
}
