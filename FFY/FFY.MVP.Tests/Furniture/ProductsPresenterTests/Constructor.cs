using FFY.MVP.Furniture.Products;
using FFY.MVP.Furniture.Utilities;
using FFY.MVP.Tests.Furniture.ProductsPresenterTests.Mocks;
using FFY.Services.Contracts;
using FFY.Services.Handlers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Furniture.ProductsPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductsHandlerIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IProductsView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new ProductsPresenter(mockedView.Object,
                null,
                mockedProductsService.Object,
                mockedQueryBuilder.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductsHandlerIsPassed()
        {
            // Arrange
            var expectedExMessage = "Products handler cannot be null.";

            var mockedView = new Mock<IProductsView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new ProductsPresenter(mockedView.Object,
                null, 
                mockedProductsService.Object,
                mockedQueryBuilder.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IProductsView>();
            var mockedProductsHandler = new Mock<IHandler>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                null,
                mockedQueryBuilder.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Products service cannot be null.";

            var mockedView = new Mock<IProductsView>();
            var mockedProductsHandler = new Mock<IHandler>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                null,
                mockedQueryBuilder.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullQueryBuilderIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IProductsView>();
            var mockedProductsHandler = new Mock<IHandler>();
            var mockedProductsService = new Mock<IProductsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullQueryBuilderIsPassed()
        {
            // Arrange
            var expectedExMessage = "Query builder cannot be null.";

            var mockedView = new Mock<IProductsView>();
            var mockedProductsHandler = new Mock<IHandler>();
            var mockedProductsService = new Mock<IProductsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IProductsView>();
            var mockedProductsHandler = new Mock<IHandler>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();

            // Act and Assert
            Assert.DoesNotThrow(() => new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                mockedQueryBuilder.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IProductsView>();
            var mockedProductsHandler = new Mock<IHandler>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();

            // Act
            var productsPresenter = new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                mockedQueryBuilder.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IProductsView>>(productsPresenter);
        }

        [Test]
        public void ShouldSubscribeToProductsRoomsViewOnListingProductsEvent()
        {
            // Arrange
            var mockedView = new MockedProductsView();
            var mockedProductsHandler = new Mock<IHandler>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();

            // Act
            var productsPresenter = new ProductsPresenter(mockedView,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                mockedQueryBuilder.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnListingProducts"));
        }

        [Test]
        public void ShouldSubscribeToProductsRoomsViewOnBuildingQueryEvent()
        {
            // Arrange
            var mockedView = new MockedProductsView();
            var mockedProductsHandler = new Mock<IHandler>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();

            // Act
            var productsPresenter = new ProductsPresenter(mockedView,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                mockedQueryBuilder.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnBuildingQuery"));
        }
    }
}
