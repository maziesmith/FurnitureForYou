using FFY.Models;
using FFY.MVP.ContactManagement.ContactDetailed;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.ContactManagement.ContactDetailedPresenterTests
{
    [TestFixture]
    public class OnEdittingContactStatus
    {
        [TestCase(2, "4")]
        [TestCase(3, "10")]
        public void ShouldCallGetUserByIdMethodFromUsersService(int statusType, string id)
        {
            // Arrange
            var contact = new Contact();

            var mockedView = new Mock<IContactDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new ContactDetailedViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(us => us.GetUserById(It.IsAny<string>())).Verifiable();

            var contactDetailedPresenter = new ContactDetailedPresenter(mockedView.Object,
                mockedContactsService.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.EdittingContactStatus += null, 
                new EditContactStatusEventArgs(contact, statusType, id));

            // Assert
            mockedUsersService.Verify(us => us.GetUserById(id), Times.Once);
        }

        [TestCase(2, "4")]
        [TestCase(3, "10")]
        public void ShouldCallChangeContactStatusMethodFromContactsService(int statusType, string id)
        {
            // Arrange 
            var user = new User() { Id = id };
            var contact = new Contact();

            var mockedView = new Mock<IContactDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new ContactDetailedViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs => cs.ChangeContactStatus(It.IsAny<Contact>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<User>()))
                .Verifiable();

            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(us => us.GetUserById(It.IsAny<string>()))
                .Returns(user)
                .Verifiable();

            var contactDetailedPresenter = new ContactDetailedPresenter(mockedView.Object,
                mockedContactsService.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.EdittingContactStatus += null,
                new EditContactStatusEventArgs(contact, statusType, id));

            // Assert
            mockedContactsService.Verify(cs => 
            cs.ChangeContactStatus(contact, statusType, id, user), Times.Once);
        }
    }
}
