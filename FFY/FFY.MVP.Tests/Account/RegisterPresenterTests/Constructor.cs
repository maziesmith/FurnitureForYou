using FFY.Data.Factories;
using FFY.MVP.Account.Register;
using FFY.Services.Contracts;
using FFY.MVP.Tests.Account.RegisterPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Account.RegisterPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUserFactoryIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IRegisterView>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(mockedView.Object, 
                null,
                mockedShoppingCartFactory.Object,
                mockedShoppingCartsService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUserFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "User factory cannot be null.";

            var mockedView = new Mock<IRegisterView>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(mockedView.Object,
                null,
                mockedShoppingCartFactory.Object,
                mockedShoppingCartsService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartFactoryIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IRegisterView>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(mockedView.Object,
                mockedUserFactory.Object,
                null,
                mockedShoppingCartsService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping cart factory cannot be null.";

            var mockedView = new Mock<IRegisterView>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(mockedView.Object,
                mockedUserFactory.Object,
                null,
                mockedShoppingCartsService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IRegisterView>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(mockedView.Object,
                mockedUserFactory.Object,
                mockedShoppingCartFactory.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullShoppingCartsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Shopping cart repository cannot be null.";

            var mockedView = new Mock<IRegisterView>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(mockedView.Object,
                mockedUserFactory.Object,
                mockedShoppingCartFactory.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IRegisterView>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new RegisterPresenter(mockedView.Object,
                mockedUserFactory.Object,
                mockedShoppingCartFactory.Object,
                mockedShoppingCartsService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidDependenciesArePassed()
        {
            // Arrange
            var mockedView = new Mock<IRegisterView>();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var registerPresenter = new RegisterPresenter(mockedView.Object,
                mockedUserFactory.Object,
                mockedShoppingCartFactory.Object,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IRegisterView>>(registerPresenter);
        }

        [Test]
        public void ShouldSubscribeToRegisterViewOnRegisteringEvent()
        {
            // Arrange
            var mockedView = new MockedRegisterView();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var registerPresenter = new RegisterPresenter(mockedView,
                mockedUserFactory.Object,
                mockedShoppingCartFactory.Object,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnRegistering"));
        }

        [Test]
        public void ShouldSubscribeToRegisterViewOnSigningEvent()
        {
            // Arrange
            var mockedView = new MockedRegisterView();
            var mockedUserFactory = new Mock<IUserFactory>();
            var mockedShoppingCartFactory = new Mock<IShoppingCartFactory>();
            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();

            // Act
            var registerPresenter = new RegisterPresenter(mockedView,
                mockedUserFactory.Object,
                mockedShoppingCartFactory.Object,
                mockedShoppingCartsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnSigningIn"));
        }
    }
}
