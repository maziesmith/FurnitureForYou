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

namespace FFY.Tests.Services.CategoriesServiceTests
{
    [TestFixture]
    public class AddCategory
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCategoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.AddCategory(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Category cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => categoriesService.AddCategory(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenACategoryIsPassed()
        {
            // Arrange
            var category = new Mock<Category>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();
            mockedGenericRepository.Setup(gr => gr.Add(category.Object)).Verifiable();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            categoriesService.AddCategory(category.Object);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Add(category.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenACategoryIsPassed()
        {
            // Arrange
            var category = new Mock<Category>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            categoriesService.AddCategory(category.Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
