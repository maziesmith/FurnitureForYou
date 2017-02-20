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
    //    [Test]
    //    public void ShouldThrowArgumentNullException_WhenNullUnitOfWorkIsPassed()
    //    {
    //        // Arrange
    //        var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

    //        // Act and Assert
    //        Assert.Throws<ArgumentNullException>(() => new CategoriesService(null, mockedGenericRepository.Object));
    //    }

    //    [Test]
    //    public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
    //    {
    //        // Arrange
    //        var expectedExMessage = "Unit of work cannot be null.";

    //        var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

    //        // Act and Assert
    //        var exception = Assert.Throws<ArgumentNullException>(() => 
    //            new CategoriesService(null, mockedGenericRepository.Object));
    //        StringAssert.Contains(expectedExMessage, exception.Message);
    //    }

    //    [Test]
    //    public void ShouldThrowArgumentNullException_WhenNullCategoryRepositoryIsPassed()
    //    {
    //        // Arrange
    //        var mockedUnitOfWork = new Mock<IUnitOfWork>();

    //        // Act and Assert
    //        Assert.Throws<ArgumentNullException>(() => new CategoriesService(mockedUnitOfWork.Object, null));
    //    }

    //    [Test]
    //    public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoryRepositoryIsPassed()
    //    {
    //        // Arrange
    //        var expectedExMessage = "Categories repository cannot be null.";

    //        var mockedUnitOfWork = new Mock<IUnitOfWork>();

    //        // Act and Assert
    //        var exception = Assert.Throws<ArgumentNullException>(() =>
    //            new CategoriesService(mockedUnitOfWork.Object, null));
    //        StringAssert.Contains(expectedExMessage, exception.Message);
    //    }

    //    [Test]
    //    public void ShouldNotThrow_WhenValidUnitOfWorkAndCategoryRepositoryArePassed()
    //    {
    //        // Arrange
    //        var mockedUnitOfWork = new Mock<IUnitOfWork>();
    //        var mockedGenericRepository = new Mock<IGenericRepository<Category>>();

    //        // Act and Assert
    //        Assert.DoesNotThrow(() =>
    //            new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object));
    //    }
    }
}
