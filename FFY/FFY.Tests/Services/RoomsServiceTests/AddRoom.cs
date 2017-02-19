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
    public class AddRoom
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullRoomIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => roomsService.AddRoom(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRoomIsPassed()
        {
            // Arrange
            var expectedExMessage = "Room cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => roomsService.AddRoom(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenARoomIsPassed()
        {
            // Arrange
            var room = new Mock<Room>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();
            mockedGenericRepository.Setup(gr => gr.Add(room.Object)).Verifiable();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            roomsService.AddRoom(room.Object);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Add(room.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenARoomIsPassed()
        {
            // Arrange
            var room = new Mock<Room>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            roomsService.AddRoom(room.Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
