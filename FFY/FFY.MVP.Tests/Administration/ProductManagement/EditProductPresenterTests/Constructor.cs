using FFY.MVP.Administration.ProductManagement.EditProduct;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using FFY.MVP.Tests.Administration.ProductManagement.EditProductPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Administration.ProductManagement.EditProductPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new EditProductPresenter(mockedView.Object,
                null,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Products service cannot be null.";

            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new EditProductPresenter(mockedView.Object,
                null,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCategoriesServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new EditProductPresenter(mockedView.Object,
                mockedProductsService.Object,
                null,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoriesServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Categories service cannot be null.";

            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new EditProductPresenter(mockedView.Object,
                mockedProductsService.Object,
                null,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullRoomsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new EditProductPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                null,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullRoomsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Rooms service cannot be null.";

            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new EditProductPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                null,
                mockedImageUploader.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullImageUploaderIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new EditProductPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullImageUploaderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Image uploader cannot be null.";

            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new EditProductPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        public void ShouldNotThrow_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.DoesNotThrow(() => new EditProductPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
        }

        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IEditProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var editProductPresenter = new EditProductPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            Assert.IsInstanceOf<Presenter<IEditProductView>>(editProductPresenter);
        }

        [Test]
        public void ShouldSubscribeToAddProductViewOnInitialEvent()
        {
            // Arrange
            var mockedView = new MockedEditProductView();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var editProductPresenter = new EditProductPresenter(mockedView,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnInitial"));
        }

        [Test]
        public void ShouldSubscribeToAddProductViewOnEdittingProductEvent()
        {
            // Arrange
            var mockedView = new MockedEditProductView();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var editProductPresenter = new EditProductPresenter(mockedView,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnEdittingProduct"));
        }

        [Test]
        public void ShouldSubscribeToAddProductViewOnUploadingImageEvent()
        {
            // Arrange
            var mockedView = new MockedEditProductView();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var editProductPresenter = new EditProductPresenter(mockedView,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnUploadingImage"));
        }
    }
}
