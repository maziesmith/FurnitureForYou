using FFY.MVP.Furniture.ListProductsRooms;
using FFY.MVP.Tests.Furniture.FurnitureRoomsPresenterTests.Mocks;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Furniture.FurnitureRoomsPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullRoomsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IFurnitureRoomsView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new FurnitureRoomsPresenter(mockedView.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRoomsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Rooms service cannot be null.";

            var mockedView = new Mock<IFurnitureRoomsView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new FurnitureRoomsPresenter(mockedView.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidRoomsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IFurnitureRoomsView>();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new FurnitureRoomsPresenter(mockedView.Object,
                mockedRoomsService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidRoomsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IFurnitureRoomsView>();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act
            var furnitureRoomsPresenter = new FurnitureRoomsPresenter(mockedView.Object,
                mockedRoomsService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IFurnitureRoomsView>>(furnitureRoomsPresenter);
        }

        [Test]
        public void ShouldSubscribeToFurnitureRoomsViewOnListingProductsRoomsEvent()
        {
            // Arrange
            var mockedView = new MockedFurnitureRoomsView();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act
            var furnitureRoomsPresenter = new FurnitureRoomsPresenter(mockedView,
                mockedRoomsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnListingProductsRooms"));
        }
    }
}
