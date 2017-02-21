using FFY.Models;
using FFY.MVP.Furniture.ListProductsRooms;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.FurnitureRoomsPresenterTests
{
    [TestFixture]
    public class OnListingProductsRooms
    {
        [Test]
        public void ShouldCallGetRoomsMethodOfRoomsService()
        {
            // Arrange
            var mockedView = new Mock<IFurnitureRoomsView>();
            mockedView.Setup(v => v.Model).Returns(new FurnitureRoomsViewModel());

            var mockedRoomsService = new Mock<IRoomsService>();
            mockedRoomsService.Setup(rs => rs.GetRooms()).Verifiable();

            var furnitureRoomsPresenter = new FurnitureRoomsPresenter(mockedView.Object,
                mockedRoomsService.Object);

            // Act
            mockedView.Raise(v => v.ListingFurnitureRooms += null, new EventArgs());

            // Assert
            mockedRoomsService.Verify(rs => rs.GetRooms(), Times.Once);
        }

        [Test]
        public void ShouldAssignRoomsToViewModel_ReceivedFromGetRoomsMethodOfRoomsService()
        {
            // Arrange
            var rooms = new List<Room>()
            {
                new Room() { Name="Kitchen" },
                new Room() { Name="Bedroom" }
            };

            var mockedView = new Mock<IFurnitureRoomsView>();
            mockedView.Setup(v => v.Model).Returns(new FurnitureRoomsViewModel());

            var mockedRoomsService = new Mock<IRoomsService>();
            mockedRoomsService.Setup(rs => rs.GetRooms()).Returns(rooms);

            var furnitureRoomsPresenter = new FurnitureRoomsPresenter(mockedView.Object,
                mockedRoomsService.Object);

            // Act
            mockedView.Raise(v => v.ListingFurnitureRooms += null, new EventArgs());

            // Assert
            CollectionAssert.AreEquivalent(rooms, mockedView.Object.Model.Rooms);
        }
    }
}
