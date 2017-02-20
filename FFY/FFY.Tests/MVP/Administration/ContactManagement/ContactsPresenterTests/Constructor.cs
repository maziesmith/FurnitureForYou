using FFY.MVP.Administration.ContactManagement.Contacts;
using FFY.Services.Contracts;
using FFY.Tests.MVP.Administration.ContactManagement.ContactsPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.Tests.MVP.Administration.ContactManagement.ContactsPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContactsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IContactsView>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new ContactsPresenter(mockedView.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Contacts service cannot be null.";

            var mockedView = new Mock<IContactsView>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => 
                new ContactsPresenter(mockedView.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidContactsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IContactsView>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new ContactsPresenter(mockedView.Object, 
                mockedContactsService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidContactsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IContactsView>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act
            var contactsPresenter = new ContactsPresenter(mockedView.Object,
                mockedContactsService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IContactsView>>(contactsPresenter);
        }

        [Test]
        public void ShouldSubscribeToContactsViewOnListingContactsEvent()
        {
            // Arrange
            var mockedView = new MockedContactsView();
            var mockedContactsService = new Mock<IContactsService>();

            // Act
            var contactsPresenter = new ContactsPresenter(mockedView,
                mockedContactsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnListingContacts"));
        }

        [Test]
        public void ShouldSubscribeToContactsViewOnFilteringContactsEvent()
        {
            // Arrange
            var mockedView = new MockedContactsView();
            var mockedContactsService = new Mock<IContactsService>();

            // Act
            var contactsPresenter = new ContactsPresenter(mockedView,
                mockedContactsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnFilteringContacts"));
        }
    }
}
