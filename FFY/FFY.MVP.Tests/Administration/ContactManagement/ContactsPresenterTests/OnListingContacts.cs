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
    public class OnListingContacts
    {
        [Test]
        public void ShouldCallGetContactsMethodFromContactsService()
        {
            // Arrange
            var mockedView = new Mock<IContactsView>();
            mockedView.Setup(v => v.Model).Returns(new ContactsViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs => cs.GetContacts()).Verifiable();

            var contactsPresenter = new ContactsPresenter(mockedView.Object,
                mockedContactsService.Object);

            // Act
            mockedView.Raise(v => v.ListingContacts += null, new EventArgs());

            // Assert
            mockedContactsService.Verify(cs => cs.GetContacts(), Times.Once);
        }

        [Test]
        public void ShouldAssignToViewModelContacts_ReceivedFromCallGetContactsMethodFromContactsService()
        {
            // Arrange
            var contacts = new List<Contact>()
            {
                new Contact() { Id = 30 },
                new Contact() { Id = 29 }
            };
            var mockedView = new Mock<IContactsView>();
            mockedView.Setup(v => v.Model).Returns(new ContactsViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs => cs.GetContacts())
                .Returns(contacts)
                .Verifiable();

            var contactsPresenter = new ContactsPresenter(mockedView.Object,
                mockedContactsService.Object);

            // Act
            mockedView.Raise(v => v.ListingContacts += null, new EventArgs());

            // Assert
            Assert.AreEqual(contacts, mockedView.Object.Model.Contacts);
        }
    }
}
