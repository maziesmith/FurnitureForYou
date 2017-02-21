using FFY.Models;
using FFY.MVP.Users.Profile;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Users.UserPresenterTests
{
    [TestFixture]
    public class OnInitial
    {
        [TestCase("421")]
        [TestCase("123")]
        public void ShouldCallGetUserByIdMethodFromUsersService(string id)
        {
            // Arrange
            var mockedView = new Mock<IUserView>();
            mockedView.Setup(v => v.Model).Returns(new UserViewModel());

            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(us => 
                us.GetUserById(It.IsAny<string>())).Verifiable();

            var userPresenter = new UserPresenter(mockedView.Object, 
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new UserByIdEventArgs(id));

            // Assert
            mockedUsersService.Verify(us => us.GetUserById(id), Times.Once);
        }

        [TestCase("421", "Paolo", "Nutini")]
        [TestCase("123", "Damien", "Rice")]
        public void ShouldSetUserViewModelWithUser_ReceivedFromGetUserByIdMethodFromUsersService(string id, string firstName, string lastName)
        {
            // Arrange
            var user = new User() { FirstName = firstName, LastName = lastName };
            var mockedView = new Mock<IUserView>();
            mockedView.Setup(v => v.Model).Returns(new UserViewModel());

            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(us =>
                us.GetUserById(It.IsAny<string>()))
                .Returns(user)
                .Verifiable();

            var userPresenter = new UserPresenter(mockedView.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new UserByIdEventArgs(id));

            // Assert
            Assert.AreEqual(user, mockedView.Object.Model.User);
        }
    }
}
