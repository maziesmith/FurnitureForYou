using FFY.Models;
using FFY.MVP.Administration.UserManagement.UserDetailed;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.UserManagement.UserDetailedPresenterTests
{
    [TestFixture]
    public class OnInitial
    {
        [TestCase("42")]
        [TestCase("1245")]
        public void ShouldCallGetUserByIdMethodFromUsersService(string id)
        {
            // Arrange
            var mockedView = new Mock<IUserDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new UserDetailedViewModel());
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(us => us.GetUserById(It.IsAny<string>())).Verifiable();

            var userDetailedPresenter = new UserDetailedPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetUserByIdEventArgs(id));

            // Assert
            mockedUsersService.Verify(us => us.GetUserById(id), Times.Once);
        }

        [TestCase("42")]
        [TestCase("1245")]
        public void ShouldAssignToViewModelUser_ReceivedFromGetUserByIdMethodFromUsersService(string id)
        {
            // Arrange
            var user = new User() { Id = id};
            var mockedView = new Mock<IUserDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new UserDetailedViewModel());
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(us => us.GetUserById(It.IsAny<string>()))
                .Returns(user)
                .Verifiable();

            var userDetailedPresenter = new UserDetailedPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetUserByIdEventArgs(id));

            // Assert
            Assert.AreEqual(user, mockedView.Object.Model.User);
        }
    }
}
