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
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            Assert.Throws<ArgumentNullException>(() => categoriesService.AddCategory(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoryIsPassed()
        {
            var expectedExMessage = "Category cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var exception = Assert.Throws<ArgumentNullException>(() => categoriesService.AddCategory(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenACategoryIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var category = new Mock<Category>();
            mockedGenericRepository.Setup(gr => gr.Add(category.Object)).Verifiable();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            categoriesService.AddCategory(category.Object);

            mockedGenericRepository.Verify(gr => gr.Add(category.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenACategoryIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var category = new Mock<Category>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            categoriesService.AddCategory(category.Object);

            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
