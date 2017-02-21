using FFY.Data.Factories;
using FFY.MVP.Administration.ProductManagement.AddCategory;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using FFY.MVP.Tests.Administration.ProductManagement.AddCategoryPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddCategoryPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCategoryFactoryIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IAddCategoryView>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddCategoryPresenter(mockedView.Object,
                null,
                mockedCategoriesService.Object,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoryFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Category factory cannot be null.";

            var mockedView = new Mock<IAddCategoryView>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddCategoryPresenter(mockedView.Object,
                null,
                mockedCategoriesService.Object,
                mockedImageUploader.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCategoriesServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IAddCategoryView>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddCategoryPresenter(mockedView.Object,
                mockedCategoryFactory.Object,
                null,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoriesServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Categories service cannot be null.";

            var mockedView = new Mock<IAddCategoryView>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddCategoryPresenter(mockedView.Object,
                mockedCategoryFactory.Object,
                null,
                mockedImageUploader.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullImageUploaderIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IAddCategoryView>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddCategoryPresenter(mockedView.Object,
                mockedCategoryFactory.Object,
                mockedCategoriesService.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullImageUploaderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Image uploader cannot be null.";

            var mockedView = new Mock<IAddCategoryView>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new AddCategoryPresenter(mockedView.Object,
                mockedCategoryFactory.Object,
                mockedCategoriesService.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IAddCategoryView>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act and Assert
            Assert.DoesNotThrow(() => new AddCategoryPresenter(mockedView.Object,
                mockedCategoryFactory.Object,
                mockedCategoriesService.Object,
                mockedImageUploader.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IAddCategoryView>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addCategoryPresenter = new AddCategoryPresenter(mockedView.Object,
                mockedCategoryFactory.Object,
                mockedCategoriesService.Object,
                mockedImageUploader.Object);


            // Assert
            Assert.IsInstanceOf<Presenter<IAddCategoryView>>(addCategoryPresenter);
        }

        [Test]
        public void ShouldSubscribeToAddCategoryViewOnAddingCategoryEvent()
        {
            // Arrange
            var mockedView = new MockedAddCategoryView();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addCategoryPresenter = new AddCategoryPresenter(mockedView,
                mockedCategoryFactory.Object,
                mockedCategoriesService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnAddingCategory"));
        }

        [Test]
        public void ShouldSubscribeToAddCategoryViewOnUploadingImageEvent()
        {
            // Arrange
            var mockedView = new MockedAddCategoryView();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            // Act
            var addCategoryPresenter = new AddCategoryPresenter(mockedView,
                mockedCategoryFactory.Object,
                mockedCategoriesService.Object,
                mockedImageUploader.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnUploadingImage"));
        }
    }
}
