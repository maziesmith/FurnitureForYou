using FFY.Models;
using FFY.MVP.Administration.UserManagement.Users;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.UserManagement.UsersPresenterTests
{
    [TestFixture]
    public class OnFilteringUsers
    {
        [TestCase(1, "frank")]
        [TestCase(3, "john")]
        public void ShouldCallGetUsersByStatusTypeAndTitleOrSenderMethodFromUsersService(int roleType, string name)
        {
            // Arrange
            var mockedView = new Mock<IUsersView>();
            mockedView.Setup(v => v.Model).Returns(new UsersViewModel());

            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(cs =>
                cs.GetUsersByRoleTypeAndName(It.IsAny<int>(),
                    It.IsAny<string>()))
                    .Verifiable();

            var usersPresenter = new UsersPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.FilterUsers += null,
                new FilterEventArgs(roleType, name));

            // Assert
            mockedUsersService.Verify(cs =>
                cs.GetUsersByRoleTypeAndName(roleType, name),
                Times.Once);
        }

        [TestCase(1, "fred")]
        [TestCase(3, "elon")]
        public void ShouldAssignViewModelWithUsers_ReceivedFromGetUsersByStatusTypeAndTitleOrSender(int roleType, string search)
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { Id = "12" },
                new User() { Id = "3" }
            };

            var mockedView = new Mock<IUsersView>();
            mockedView.Setup(v => v.Model).Returns(new UsersViewModel());

            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(cs =>
                cs.GetUsersByRoleTypeAndName(It.IsAny<int>(),
                    It.IsAny<string>()))
                    .Returns(users)
                    .Verifiable();

            var usersPresenter = new UsersPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.FilterUsers += null,
                new FilterEventArgs(roleType, search));

            // Assert
            CollectionAssert.AreEquivalent(users, mockedView.Object.Model.Users);
        }
    }
}
