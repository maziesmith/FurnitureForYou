using FFY.MVP.Home;
using FFY.MVP.Tests.Home.HomePresenterTests.Mocks;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Home.HomePresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IHomeView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new HomePresenter(mockedView.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Products service cannot be null.";

            var mockedView = new Mock<IHomeView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new HomePresenter(mockedView.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IHomeView>();
            var mockedProductsService = new Mock<IProductsService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new HomePresenter(mockedView.Object,
                mockedProductsService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidProductsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IHomeView>();
            var mockedProductsService = new Mock<IProductsService>();

            // Act
            var homePresenter = new HomePresenter(mockedView.Object,
                mockedProductsService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IHomeView>>(homePresenter);
        }

        [Test]
        public void ShouldSubscribeToHomeViewOnListingDiscountProductsEvent()
        {
            // Arrange
            var mockedView = new MockedHomeView();
            var mockedProductsService = new Mock<IProductsService>();

            // Act
            var homePresenter = new HomePresenter(mockedView,
                mockedProductsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnListingDiscountProducts"));
        }

        [Test]
        public void ShouldSubscribeToHomeViewOnListingLatestProductsEvent()
        {
            // Arrange
            var mockedView = new MockedHomeView();
            var mockedProductsService = new Mock<IProductsService>();

            // Act
            var homePresenter = new HomePresenter(mockedView,
                mockedProductsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnListingLatestProducts"));
        }
    }
}
