using FFY.MVP.Furniture.CategoryByRoom;
using FFY.MVP.Tests.Furniture.CategoryByRoomPresenterTests.Mocks;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Furniture.CategoryByRoomPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCategoriesServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICategoryByRoomView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CategoryByRoomPresenter(mockedView.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoriesServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Categories service cannot be null.";

            var mockedView = new Mock<ICategoryByRoomView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CategoryByRoomPresenter(mockedView.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICategoryByRoomView>();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new CategoryByRoomPresenter(mockedView.Object,
                mockedCategoriesService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ICategoryByRoomView>();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            // Act
            var categoryByRoomPresenter = new CategoryByRoomPresenter(mockedView.Object,
                mockedCategoriesService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<ICategoryByRoomView>>(categoryByRoomPresenter);
        }

        [Test]
        public void ShouldSubscribeToCategoryByRoomViewOnListingCategoriesByRoomEvent()
        {
            // Arrange
            var mockedView = new MockedCategoryByRoomView();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            // Act
            var categoryByRoomPresenter = new CategoryByRoomPresenter(mockedView,
                mockedCategoriesService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnListingCategoriesByRoom"));
        }
    }
}
