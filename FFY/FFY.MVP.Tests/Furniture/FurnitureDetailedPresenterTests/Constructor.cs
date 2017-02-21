using FFY.MVP.Furniture.FurnitureDetailed;
using FFY.MVP.Tests.Furniture.FurnitureDetailedPresenterTests.Mocks;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Furniture.FurnitureDetailedPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IFurnitureDetailedView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new FurnitureDetailedPresenter(mockedView.Object,
                null,
                mockedShoppingCartsService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Products service cannot be null.";

            var mockedView = new Mock<IFurnitureDetailedView>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new FurnitureDetailedPresenter(mockedView.Object,
                null,
                mockedShoppingCartsService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IFurnitureDetailedView>();
            var mockedProductsService = new Mock<IProductsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping carts service cannot be null.";

            var mockedView = new Mock<IFurnitureDetailedView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidProductsServiceAndShoppingCartsServiceArePassed()
        {
            // Arrange
            var mockedView = new Mock<IFurnitureDetailedView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidProductsServiceAndShoppingCartsServiceArePassed()
        {
            // Arrange
            var mockedView = new Mock<IFurnitureDetailedView>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var furnitureDetailedPresenter = new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IFurnitureDetailedView>>(furnitureDetailedPresenter);
        }

        [Test]
        public void ShouldSubscribeToFurnitureDetailedViewOnGettingProductByIdEvent()
        {
            // Arrange
            var mockedView = new MockedFurnitureDetailedView();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var furnitureDetailedPresenter = new FurnitureDetailedPresenter(mockedView,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnGettingProductById"));
        }

        [Test]
        public void ShouldSubscribeToFurnitureDetailedViewOnAddingToShoppingCartEvent()
        {
            // Arrange
            var mockedView = new MockedFurnitureDetailedView();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var furnitureDetailedPresenter = new FurnitureDetailedPresenter(mockedView,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnAddingToShoppingCart"));
        }
    }
}
