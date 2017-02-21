using FFY.MVP.Tests.Users.UserPresenterTests.Mocks;
using FFY.MVP.Users.Profile;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Users.UserPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IUserView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new UserPresenter(mockedView.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Users service cannot be null.";

            // Arrange
            var mockedView = new Mock<IUserView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new UserPresenter(mockedView.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrowArgumentNullException_WhenValidUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IUserView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new UserPresenter(mockedView.Object,
                mockedUsersService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IUserView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var userPresenter = new UserPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IUserView>>(userPresenter);
        }

        [Test]
        public void ShouldSubscribeToUserViewOnInitialEvent()
        {
            // Arrange
            var mockedView = new MockedUserView();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var userPresenter = new UserPresenter(mockedView,
                mockedUsersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnInitial"));
        }
    }
}
