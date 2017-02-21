using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddCategory;
using FFY.MVP.Administration.ProductManagement.AddRoom;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddRoomPresenterTests
{
    [TestFixture]
    public class OnAddingRoom
    {
        [TestCase("beds")]
        [TestCase("tables")]
        public void ShouldCallCreateRoomMethodFromRoomFactory(string name)
        {
            // Arrange
            var room = new Room();
            var mockedView = new Mock<IAddRoomView>();
            mockedView.Setup(v => v.Model).Returns(new AddRoomViewModel());

            var mockedRoomFactory = new Mock<IRoomFactory>();
            mockedRoomFactory.Setup(cf => cf.CreateRoom(It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(room)
                .Verifiable();

            var mockedRoomsServices = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();
            
            var addRoomPresenter = new AddRoomPresenter(mockedView.Object,
                mockedRoomFactory.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.AddingRoom += null,
                new AddRoomEventArgs(name));

            // Assert
            mockedRoomFactory.Verify(cf =>
            cf.CreateRoom(name, It.IsAny<string>()), Times.Once);
        }

        [TestCase("beds")]
        [TestCase("tables")]
        public void ShouldCallAddRoomMethodFromRoomsServices(string name)
        {
            // Arrange
            var room = new Room();
            var mockedView = new Mock<IAddRoomView>();
            mockedView.Setup(v => v.Model).Returns(new AddRoomViewModel());

            var mockedRoomFactory = new Mock<IRoomFactory>();
            mockedRoomFactory.Setup(cf => cf.CreateRoom(It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(room)
                .Verifiable();

            var mockedRoomsServices = new Mock<IRoomsService>();
            mockedRoomsServices.Setup(cs =>
                cs.AddRoom(It.IsAny<Room>()))
                .Verifiable();

            var mockedImageUploader = new Mock<IImageUploader>();

            var addRoomPresenter = new AddRoomPresenter(mockedView.Object,
                mockedRoomFactory.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.AddingRoom += null,
                new AddRoomEventArgs(name));

            // Assert
            mockedRoomsServices.Verify(cs => cs.AddRoom(room), Times.Once);
        }
    }
}
