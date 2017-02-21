using FFY.MVP.Administration.UserManagement.Users;
using FFY.Services.Contracts;
using FFY.MVP.Tests.Administration.UserManagement.UsersPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Administration.UserManagement.UsersPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IUsersView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new UsersPresenter(mockedView.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Users service cannot be null.";

            var mockedView = new Mock<IUsersView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => 
                new UsersPresenter(mockedView.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IUsersView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new UsersPresenter(mockedView.Object,
                mockedUsersService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IUsersView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var usersPresenter = new UsersPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IUsersView>>(usersPresenter);
        }

        [Test]
        public void ShouldSubscribeToUsersViewOnListingUsersEvent()
        {
            // Arrange
            var mockedView = new MockedUsersView();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var usersPresenter = new UsersPresenter(mockedView,
                mockedUsersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnListingUsers"));
        }

        [Test]
        public void ShouldSubscribeToUsersViewOnFilteringUsersEvent()
        {
            // Arrange
            var mockedView = new MockedUsersView();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var usersPresenter = new UsersPresenter(mockedView,
                mockedUsersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnFilteringUsers"));
        }
    }
}
