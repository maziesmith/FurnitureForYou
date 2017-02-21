using FFY.Models;
using FFY.MVP.Administration.ContactManagement.Contacts;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.ContactManagement.ContactsPresenterTests
{
    [TestFixture]
    public class OnFilteringContacts
    {
        [TestCase(1, "word")]
        [TestCase(3, "error")]
        public void ShouldCallGetContactsByStatusTypeAndTitleOrSenderMethodFromContactsService(int statusType, string search)
        {
            // Arrange
            var mockedView = new Mock<IContactsView>();
            mockedView.Setup(v => v.Model).Returns(new ContactsViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs =>
                cs.GetContactsByStatusTypeAndTitleOrSender(It.IsAny<int>(),
                    It.IsAny<string>()))
                    .Verifiable();

            var contactsPresenter = new ContactsPresenter(mockedView.Object,
                mockedContactsService.Object);

            // Act
            mockedView.Raise(v => v.FilterContacts += null,
                new FilterEventArgs(statusType, search));

            // Assert
            mockedContactsService.Verify(cs =>
                cs.GetContactsByStatusTypeAndTitleOrSender(statusType, search),
                Times.Once);
        }

        [TestCase(1, "word")]
        [TestCase(3, "error")]
        public void ShouldAssignViewModelWithContacts_ReceivedFromGetContactsByStatusTypeAndTitleOrSender(int statusType, string search)
        {
            // Arrange
            var contacts = new List<Contact>()
            {
                new Contact() { Id = 1 },
                new Contact() { Id = 4 }
            };

            var mockedView = new Mock<IContactsView>();
            mockedView.Setup(v => v.Model).Returns(new ContactsViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs =>
                cs.GetContactsByStatusTypeAndTitleOrSender(It.IsAny<int>(),
                    It.IsAny<string>()))
                    .Returns(contacts)
                    .Verifiable();

            var contactsPresenter = new ContactsPresenter(mockedView.Object,
                mockedContactsService.Object);

            // Act
            mockedView.Raise(v => v.FilterContacts += null,
                new FilterEventArgs(statusType, search));

            // Assert
            CollectionAssert.AreEquivalent(contacts, mockedView.Object.Model.Contacts);
        }
    }
}
