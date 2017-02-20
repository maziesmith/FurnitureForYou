using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;

namespace FFY.Tests.Services.CategoriesServiceTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUnitOfWorkIsPassed()
        {
            // Arrange
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CategoriesService(null, 
                mockedCategoryRepository.Object,
                mockedProductRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
        {
            // Arrange
            var expectedExMessage = "Unit of work cannot be null.";

            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CategoriesService(null,
                mockedCategoryRepository.Object,
                mockedProductRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCategoryRepositoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CategoriesService(mockedUnitOfWork.Object, 
                null,
                mockedProductRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoryRepositoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Categories repository cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CategoriesService(mockedUnitOfWork.Object,
                null,
                mockedProductRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductsRepositoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();


            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CategoriesService(mockedUnitOfWork.Object,
                            mockedCategoryRepository.Object,
                            null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductRepositoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Products repository cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CategoriesService(mockedUnitOfWork.Object,
                mockedCategoryRepository.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUnitOfWorkAndCategoryRepositoryArePassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            // Act and Assert
            Assert.DoesNotThrow(() =>
                new CategoriesService(mockedUnitOfWork.Object,
                mockedCategoryRepository.Object,
                mockedProductRepository.Object));
        }
    }
}
