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

namespace FFY.Tests.Services.RoomsServiceTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUnitOfWorkIsPassed()
        {
            // Arrange
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new RoomsService(null, mockedGenericRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
        {
            // Arrange
            var expectedExMessage = "Unit of work cannot be null.";

            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new RoomsService(null, mockedGenericRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullRoomRepositoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new RoomsService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRoomRepositoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Rooms repository cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new RoomsService(mockedUnitOfWork.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUnitOfWorkAndRoomRepositoryArePassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            // Act and Assert
            Assert.DoesNotThrow(() =>
                new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object));
        }
    }
}
