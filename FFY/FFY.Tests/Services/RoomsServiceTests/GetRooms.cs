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
    public class GetRooms
    {
        [Test]
        public void ShouldCallGetAllMethodOfRoomsRepositoryOnce()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            roomsService.GetRooms();

            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [Test]
        public void ShouldReturnAllRoomsFromRoomsRepository()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Room>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var mockedRoom = new Mock<Room>();

            var mockedRooms = new List<Room>
            {
                mockedRoom.Object,
                mockedRoom.Object
            };
            mockedGenericRepository.Setup(gr => gr.GetAll()).Returns(mockedRooms);

            var roomsService = new RoomsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = roomsService.GetRooms();

            Assert.AreSame(mockedRooms, result);
        }

    }
}
