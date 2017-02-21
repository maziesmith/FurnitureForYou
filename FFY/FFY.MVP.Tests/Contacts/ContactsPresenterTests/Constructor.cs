using FFY.Data.Factories;
using FFY.MVP.Contacts.ContactSender;
using FFY.MVP.Tests.Contacts.ContactsPresenterTests.Mocks;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Contacts.ContactsPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContactFactoryIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IContactView>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new ContactPresenter(mockedView.Object,
                null,
                mockedContactsService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactFactoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Contact factory cannot be null.";

            var mockedView = new Mock<IContactView>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new ContactPresenter(mockedView.Object,
                null,
                mockedContactsService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContactsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IContactView>();
            var mockedContactFactory = new Mock<IContactFactory>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new ContactPresenter(mockedView.Object,
                mockedContactFactory.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Contacts service cannot be null.";

            var mockedView = new Mock<IContactView>();
            var mockedContactFactory = new Mock<IContactFactory>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new ContactPresenter(mockedView.Object,
                mockedContactFactory.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidContactFatoryAndContactsServiceArePassed()
        {
            // Arrange
            var mockedView = new Mock<IContactView>();
            var mockedContactFactory = new Mock<IContactFactory>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new ContactPresenter(mockedView.Object,
                mockedContactFactory.Object,
                mockedContactsService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidContactFatoryAndContactsServiceArePassed()
        {
            // Arrange
            var mockedView = new Mock<IContactView>();
            var mockedContactFactory = new Mock<IContactFactory>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act
            var contactPresenter = new ContactPresenter(mockedView.Object,
                mockedContactFactory.Object,
                mockedContactsService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IContactView>>(contactPresenter);
        }

        [Test]
        public void ShouldSubscribeToContactViewOnSendingContactEvent()
        {
            // Arrange
            var mockedView = new MockedContactView();
            var mockedContactFactory = new Mock<IContactFactory>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act
            var contactPresenter = new ContactPresenter(mockedView,
                mockedContactFactory.Object,
                mockedContactsService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnSendingContact"));
        }
    }
}
