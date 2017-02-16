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
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            Assert.Throws<ArgumentNullException>(() => roomsService.AddRoom(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRoomIsPassed()
        {
            var expectedExMessage = "Room cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var exception = Assert.Throws<ArgumentNullException>(() => roomsService.AddRoom(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenARoomIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var room = new Mock<Room>();
            mockedGenericRepository.Setup(gr => gr.Add(room.Object)).Verifiable();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            roomsService.AddRoom(room.Object);

            mockedGenericRepository.Verify(gr => gr.Add(room.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenARoomIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var room = new Mock<Room>();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            roomsService.AddRoom(room.Object);

            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
