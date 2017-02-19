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
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            var user = new Mock<User>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(null, 2, "user-id", user.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactIsPassed()
        {
            var expectedExMessage = "Contact cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            var user = new Mock<User>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var exception = Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(null, 2, "user-id", user.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUserIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            var contact = new Mock<Contact>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(contact.Object, 2, "user-id", null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUserIsPassed()
        {
            var expectedExMessage = "User cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            var contact = new Mock<Contact>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var exception = Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(contact.Object, 2, "user-id", null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowInvalidCastException_WhenInvalidStatusTypeIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var contact = new Mock<Contact>();
            var user = new Mock<User>();
            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

           Assert.Throws<InvalidCastException>(() => contactsService.ChangeContactStatus(contact.Object, 4, "user-id", user.Object));
        }

        [Test]
        public void ShouldThrowInvalidCastExceptionWithCorrectMessage_WhenInvalidStatusTypeIsPassed()
        {
            var expectedExMessage = "Contact status type is out of enumeration range.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var contact = new Mock<Contact>();
            var user = new Mock<User>();
            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var exception = Assert.Throws<InvalidCastException>(() => contactsService.ChangeContactStatus(contact.Object, 4, "user-id", user.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void ShouldAssignNewContactStatus_WhenValidStatusTypeIsPassed(int statusType)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var user = new Mock<User>();
            var contact = new Contact();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.ChangeContactStatus(contact, statusType, "user-id", user.Object);

            Assert.AreEqual((ContactStatusType)statusType, contact.ContactStatusType);
        }

        [TestCase(1)]
        public void ShouldAssignUserProccessedByToNull_WhenStatusTypeIsNotProcessed(int statusType)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var user = new Mock<User>();
            var contact = new Contact();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.ChangeContactStatus(contact, statusType, "user-id", user.Object);

            Assert.AreEqual(null, contact.UserProcessedBy);
        }

        [TestCase(1)]
        public void ShouldAssignUserProccessedByIdToNull_WhenStatusTypeIsNotProcessed(int statusType)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var user = new Mock<User>();
            var contact = new Contact();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.ChangeContactStatus(contact, statusType, "user-id", user.Object);

            Assert.AreEqual(null, contact.UserProccessedById);
        }

        [TestCase(2)]
        [TestCase(3)]
        public void ShouldAssignUserProccessedByWithPassedUser_WhenStatusTypeIsProccessedOrProccessing(int statusType)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var user = new Mock<User>();
            var contact = new Contact();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.ChangeContactStatus(contact, statusType, "user-id", user.Object);

            Assert.AreEqual(user.Object, contact.UserProcessedBy);
        }

        [TestCase(2, "428212-44")]
        [TestCase(3, "138272-63")]
        public void ShouldAssignUserProccessedByWithPassedUser_WhenStatusTypeIsProccessedOrProccessing(int statusType, string userId)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var user = new Mock<User>();
            var contact = new Contact();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.ChangeContactStatus(contact, statusType, userId, user.Object);

            Assert.AreEqual(userId, contact.UserProccessedById);
        }

        [Test]
        public void ShouldCallUpdateMethodOfCategoryRepositoryOnce_WhenAContactIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var contact = new Mock<Contact>();
            var user = new Mock<User>();
            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.ChangeContactStatus(contact.Object, 2, "user-id", user.Object);

            mockedGenericRepository.Verify(gr => gr.Update(contact.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAContactIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var contact = new Mock<Contact>();
            var user = new Mock<User>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.ChangeContactStatus(contact.Object, 2, "user-id", user.Object);

            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
