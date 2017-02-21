using FFY.MVP.Administration.UserManagement.UserDetailed;
using FFY.Services.Contracts;
using FFY.MVP.Tests.Administration.UserManagement.UserDetailedPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Administration.UserManagement.UserDetailedPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IUserDetailedView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new UserDetailedPresenter(mockedView.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Users service cannot be null.";

            var mockedView = new Mock<IUserDetailedView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new UserDetailedPresenter(mockedView.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUsersServiceArePassed()
        {
            // Arrange
            var mockedView = new Mock<IUserDetailedView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new UserDetailedPresenter(mockedView.Object,
                mockedUsersService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IUserDetailedView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var userDetailedPresenter = new UserDetailedPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IUserDetailedView>>(userDetailedPresenter);
        }

        [Test]
        public void ShouldSubscribeToContactDetailedViewOnInitialEvent()
        {
            // Arrange
            var mockedView = new MockedUserDetailedView();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var userDetailedPresenter = new UserDetailedPresenter(mockedView,
                mockedUsersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnInitial"));
        }

        [Test]
        public void ShouldSubscribeToLoginViewOnEdditingUserRoleEvent()
        {
            // Arrange
            var mockedView = new MockedUserDetailedView();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var userDetailedPresenter = new UserDetailedPresenter(mockedView,
                mockedUsersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnEdditingUserRole"));
        }
    }
}
