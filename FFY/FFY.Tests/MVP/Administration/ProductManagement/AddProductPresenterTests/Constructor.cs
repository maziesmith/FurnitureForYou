using FFY.Data.Factories;
using FFY.MVP.Administration.ProductManagement.AddProduct;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using FFY.Tests.MVP.Administration.ProductManagement.AddProductPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.Tests.MVP.Administration.ProductManagement.AddProductPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductFactoryIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IAddProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                null,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Product factory cannot be null.";

            var mockedView = new Mock<IAddProductView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                null,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
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

            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
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
            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
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

            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
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
            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
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

            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
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
            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
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

            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.DoesNotThrow(() => new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IAddProductView>();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addProductPresenter = new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IAddProductView>>(addProductPresenter);
        }

        [Test]
        public void ShouldSubscribeToAddProductViewOnInitialEvent()
        {
            // Arrange
            var mockedView = new MockedAddProductView();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addProductPresenter = new AddProductPresenter(mockedView,
                mockedProductFactory.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnInitial"));
        }

        [Test]
        public void ShouldSubscribeToAddProductViewOnAddingProductEvent()
        {
            // Arrange
            var mockedView = new MockedAddProductView();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addProductPresenter = new AddProductPresenter(mockedView,
                mockedProductFactory.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnAddingProduct"));
        }

        [Test]
        public void ShouldSubscribeToAddProductViewOnUploadingImageEvent()
        {
            // Arrange
            var mockedView = new MockedAddProductView();
            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedRoomsService = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addProductPresenter = new AddProductPresenter(mockedView,
                mockedProductFactory.Object,
                mockedProductsService.Object,
                mockedCategoriesService.Object,
                mockedRoomsService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnUploadingImage"));
        }
    }
}
