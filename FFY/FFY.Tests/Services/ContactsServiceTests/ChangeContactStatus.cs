using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Services.ContactsServiceTests
{
    [TestFixture]
    public class ChangeContactStatus
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContactIsPassed()
        {
            // Arrange
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(null, 2, "user-id", user.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactIsPassed()
        {
            // Arrange
            var expectedExMessage = "Contact cannot be null.";

            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(null, 2, "user-id", user.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUserIsPassed()
        {
            // Arrange
            var contact = new Mock<Contact>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(contact.Object, 2, "user-id", null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUserIsPassed()
        {
            // Arrange
            var expectedExMessage = "User cannot be null.";

            var contact = new Mock<Contact>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(contact.Object, 2, "user-id", null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowInvalidCastException_WhenInvalidStatusTypeIsPassed()
        {
            // Arrange
            var contact = new Mock<Contact>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<InvalidCastException>(() => contactsService.ChangeContactStatus(contact.Object, 4, "user-id", user.Object));
        }

        [Test]
        public void ShouldThrowInvalidCastExceptionWithCorrectMessage_WhenInvalidStatusTypeIsPassed()
        {
            // Arrange
            var expectedExMessage = "Contact status type is out of enumeration range.";

            var contact = new Mock<Contact>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidCastException>(() => contactsService.ChangeContactStatus(contact.Object, 4, "user-id", user.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void ShouldAssignNewContactStatus_WhenValidStatusTypeIsPassed(int statusType)
        {
            // Arrange
            var user = new Mock<User>();
            var contact = new Contact();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.ChangeContactStatus(contact, statusType, "user-id", user.Object);

            // Assert
            Assert.AreEqual((ContactStatusType)statusType, contact.ContactStatusType);
        }

        [TestCase(1)]
        public void ShouldAssignUserProccessedByToNull_WhenStatusTypeIsNotProcessed(int statusType)
        {
            // Arrange
            var user = new Mock<User>();
            var contact = new Contact();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.ChangeContactStatus(contact, statusType, "user-id", user.Object);

            // Assert
            Assert.AreEqual(null, contact.UserProcessedBy);
        }

        [TestCase(1)]
        public void ShouldAssignUserProccessedByIdToNull_WhenStatusTypeIsNotProcessed(int statusType)
        {
            // Arrange
            var user = new Mock<User>();
            var contact = new Contact();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.ChangeContactStatus(contact, statusType, "user-id", user.Object);

            // Assert
            Assert.AreEqual(null, contact.UserProccessedById);
        }

        [TestCase(2)]
        [TestCase(3)]
        public void ShouldAssignUserProccessedByWithPassedUser_WhenStatusTypeIsProccessedOrProccessing(int statusType)
        {
            // Arrange
            var user = new Mock<User>();
            var contact = new Contact();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.ChangeContactStatus(contact, statusType, "user-id", user.Object);

            // Assert
            Assert.AreEqual(user.Object, contact.UserProcessedBy);
        }

        [TestCase(2, "428212-44")]
        [TestCase(3, "138272-63")]
        public void ShouldAssignUserProccessedByWithPassedUser_WhenStatusTypeIsProccessedOrProccessing(int statusType, string userId)
        {
            // Arrange
            var user = new Mock<User>();
            var contact = new Contact();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.ChangeContactStatus(contact, statusType, userId, user.Object);

            // Assert
            Assert.AreEqual(userId, contact.UserProccessedById);
        }

        [Test]
        public void ShouldCallUpdateMethodOfContactRepositoryOnce_WhenAContactIsPassed()
        {
            // Arrange
            var contact = new Mock<Contact>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.ChangeContactStatus(contact.Object, 2, "user-id", user.Object);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Update(contact.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAContactIsPassed()
        {
            // Arrange
            var contact = new Mock<Contact>();
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.ChangeContactStatus(contact.Object, 2, "user-id", user.Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
