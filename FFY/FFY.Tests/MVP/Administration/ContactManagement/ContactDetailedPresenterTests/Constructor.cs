using FFY.MVP.ContactManagement.ContactDetailed;
using FFY.Services.Contracts;
using FFY.Tests.MVP.Administration.ContactManagement.ContactDetailedPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.Tests.MVP.Administration.ContactManagement.ContactDetailedPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContactsServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IContactDetailedView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new ContactDetailedPresenter(mockedView.Object,
                null,
                mockedUsersService.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactsServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Contacts service cannot be null.";

            var mockedView = new Mock<IContactDetailedView>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new ContactDetailedPresenter(mockedView.Object,
                null,
                mockedUsersService.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<IContactDetailedView>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new ContactDetailedPresenter(mockedView.Object,
                mockedContactsService.Object,
                null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUsersServiceIsPassed()
        {
            // Arrange
            var expectedExMessage = "Users service cannot be null.";

            var mockedView = new Mock<IContactDetailedView>();
            var mockedContactsService = new Mock<IContactsService>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new ContactDetailedPresenter(mockedView.Object,
                mockedContactsService.Object,
                null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidContacsServiceAndUsersServiceArePassed()
        {
            // Arrange
            var mockedView = new Mock<IContactDetailedView>();
            var mockedContactsService = new Mock<IContactsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new ContactDetailedPresenter(mockedView.Object,
                mockedContactsService.Object,
                mockedUsersService.Object));
        }

        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidContacsServiceAndUsersServiceArePassed()
        {
            // Arrange
            var mockedView = new Mock<IContactDetailedView>();
            var mockedContactsService = new Mock<IContactsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var contactDetailedPresenter = new ContactDetailedPresenter(mockedView.Object,
                mockedContactsService.Object,
                mockedUsersService.Object);

            // Assert
            Assert.IsInstanceOf<Presenter<IContactDetailedView>>(contactDetailedPresenter);
        }

        [Test]
        public void ShouldSubscribeToContactDetailedViewOnInitialEvent()
        {
            // Arrange
            var mockedView = new MockedContactDetailedView();
            var mockedContactsService = new Mock<IContactsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var contactDetailedPresenter = new ContactDetailedPresenter(mockedView,
                mockedContactsService.Object,
                mockedUsersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnInitial"));
        }

        [Test]
        public void ShouldSubscribeToLoginViewOnEdittingContactStatusEvent()
        {
            // Arrange
            var mockedView = new MockedContactDetailedView();
            var mockedContactsService = new Mock<IContactsService>();
            var mockedUsersService = new Mock<IUsersService>();

            // Act
            var contactDetailedPresenter = new ContactDetailedPresenter(mockedView,
                mockedContactsService.Object,
                mockedUsersService.Object);

            // Assert
            Assert.IsTrue(mockedView.IsSubscribedMethod("OnEdittingContactStatus"));
        }
    }
}
