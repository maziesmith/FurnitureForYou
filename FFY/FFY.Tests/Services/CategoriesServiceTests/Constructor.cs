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
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

            Assert.Throws<ArgumentNullException>(() => new CategoriesService(null, mockedGenericRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
        {
            var expectedExMessage = "Unit of work cannot be null.";
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

            var exception = Assert.Throws<ArgumentNullException>(() => 
                new CategoriesService(null, mockedGenericRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCategoryRepositoryIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new CategoriesService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoryRepositoryIsPassed()
        {
            var expectedExMessage = "Categories repository cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new CategoriesService(mockedUnitOfWork.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUnitOfWorkAndCategoryRepositoryArePassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

            Assert.DoesNotThrow(() =>
                new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object));
        }
    }
}
