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
    public class OnListingUsers
    {
        [Test]
        public void ShouldCallGetUsersMethodFromUsersService()
        {
            // Arrange
            var mockedView = new Mock<IUsersView>();
            mockedView.Setup(v => v.Model).Returns(new UsersViewModel());

            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(cs => cs.GetUsers()).Verifiable();

            var usersPresenter = new UsersPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.ListingUsers += null, new EventArgs());

            // Assert
            mockedUsersService.Verify(cs => cs.GetUsers(), Times.Once);
        }

        [Test]
        public void ShouldAssignToViewModelUsers_ReceivedFromCallGetUsersMethodFromContactsService()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { Id = "42" },
                new User() { Id = "24" }
            };
            var mockedView = new Mock<IUsersView>();
            mockedView.Setup(v => v.Model).Returns(new UsersViewModel());

            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(cs => cs.GetUsers())
                .Returns(users)
                .Verifiable();

            var usersPresenter = new UsersPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.ListingUsers += null, new EventArgs());

            // Assert
            Assert.AreEqual(users, mockedView.Object.Model.Users);
        }
    }
}
