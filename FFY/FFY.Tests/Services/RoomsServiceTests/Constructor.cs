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
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            Assert.Throws<ArgumentNullException>(() =>
                new RoomsService(null, mockedGenericRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
        {
            var expectedExMessage = "Unit of work cannot be null.";
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new RoomsService(null, mockedGenericRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullRoomRepositoryIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() =>
                new RoomsService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRoomRepositoryIsPassed()
        {
            var expectedExMessage = "Rooms repository cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new RoomsService(mockedUnitOfWork.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUnitOfWorkAndRoomRepositoryArePassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();

            Assert.DoesNotThrow(() =>
                new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object));
        }
    }
}
