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
    public class OnInitial
    {
        [TestCase(4)]
        [TestCase(10)]
        public void ShouldCallGetContactByIdMethodFromContactsService(int id)
        {
            // Arrange
            var mockedView = new Mock<IContactDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new ContactDetailedViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs => cs.GetContactById(It.IsAny<int>())).Verifiable();
            var mockedUsersService = new Mock<IUsersService>();

            var contactDetailedPresenter = new ContactDetailedPresenter(mockedView.Object,
                mockedContactsService.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetContactByIdEventArgs(id));

            // Assert
            mockedContactsService.Verify(cs => cs.GetContactById(id), Times.Once);
        }

        [TestCase(4)]
        [TestCase(10)]
        public void ShouldSetViewModelWithContact_ReceivedByGetContactByIdMethodFromContactsService(int id)
        {
            // Arrange
            var contact = new Contact() { Id = id };

            var mockedView = new Mock<IContactDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new ContactDetailedViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs => cs.GetContactById(It.IsAny<int>()))
                .Returns(contact)
                .Verifiable();
            var mockedUsersService = new Mock<IUsersService>();

            var contactDetailedPresenter = new ContactDetailedPresenter(mockedView.Object,
                mockedContactsService.Object,
                mockedUsersService.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetContactByIdEventArgs(id));

            // Assert
            Assert.AreEqual(contact, mockedView.Object.Model.Contact);
        }
    }
}
