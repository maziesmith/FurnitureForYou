using FFY.Data.Factories;
using FFY.MVP.Administration.ProductManagement.AddRoom;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using FFY.MVP.Tests.Administration.ProductManagement.AddRoomPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddRoomPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullRoomFactoryIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IAddRoomView>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddRoomPresenter(mockedView.Object,
                null,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRoomFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Room factory cannot be null.";

            var mockedView = new Mock<IAddRoomView>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddRoomPresenter(mockedView.Object,
                null,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullRoomsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IAddRoomView>();
            var mockedRoomFactory = new Mock<IRoomFactory>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddRoomPresenter(mockedView.Object,
                mockedRoomFactory.Object,
                null,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRoomsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Rooms service cannot be null.";

            var mockedView = new Mock<IAddRoomView>();
            var mockedRoomFactory = new Mock<IRoomFactory>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddRoomPresenter(mockedView.Object,
                mockedRoomFactory.Object,
                null,
                mockedImageUploader.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullImageUploaderIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IAddRoomView>();
            var mockedRoomFactory = new Mock<IRoomFactory>();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddRoomPresenter(mockedView.Object,
                mockedRoomFactory.Object,
                mockedRoomsService.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullImageUploaderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Image uploader cannot be null.";

            var mockedView = new Mock<IAddRoomView>();
            var mockedRoomFactory = new Mock<IRoomFactory>();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddRoomPresenter(mockedView.Object,
                mockedRoomFactory.Object,
                mockedRoomsService.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IAddRoomView>();
            var mockedRoomFactory = new Mock<IRoomFactory>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.DoesNotThrow(() => new AddRoomPresenter(mockedView.Object,
                mockedRoomFactory.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IAddRoomView>();
            var mockedRoomFactory = new Mock<IRoomFactory>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addRoomPresenter = new AddRoomPresenter(mockedView.Object,
                mockedRoomFactory.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IAddRoomView>>(addRoomPresenter);
        }

        [Test]
        public void ShouldSubscribeToAddProductViewOnAddingRoomEvent()
        {
            // Arrange
            var mockedView = new MockedAddRoomView();
            var mockedRoomFactory = new Mock<IRoomFactory>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addRoomPresenter = new AddRoomPresenter(mockedView,
                mockedRoomFactory.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnAddingRoom"));
        }

        [Test]
        public void ShouldSubscribeToAddProductViewOnUploadingImageEvent()
        {
            // Arrange
            var mockedView = new MockedAddRoomView();
            var mockedRoomFactory = new Mock<IRoomFactory>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addRoomPresenter = new AddRoomPresenter(mockedView,
                mockedRoomFactory.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnUploadingImage"));
        }
    }
}
