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
    public class ChangeStatus
    {
        // TODO
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContactIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(null, 2, "user-id"));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactIsPassed()
        {
            var expectedExMessage = "Contact cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // var exception = Assert.Throws<ArgumentNullException>(() => contactsService.ChangeContactStatus(null, 2, "user-id"));
            // StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowInvalidCastException_WhenInvalidStatusTypeIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var contact = new Mock<Contact>();
            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

           // Assert.Throws<InvalidCastException>(() => contactsService.ChangeContactStatus(contact.Object, 4, "user-id"));
        }

        [Test]
        public void ShouldThrowInvalidCastExceptionWithCorrectMessage_WhenInvalidStatusTypeIsPassed()
        {
            var expectedExMessage = "Contact status type is out of enumeration range.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var contact = new Mock<Contact>();
            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // var exception = Assert.Throws<InvalidCastException>(() => contactsService.ChangeContactStatus(contact.Object, 4, "user-id"));
            // StringAssert.Contains(expectedExMessage, exception.Message);
        }

        //TODO: more

        [Test]
        public void ShouldCallUpdateMethodOfCategoryRepositoryOnce_WhenAContactIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var contact = new Mock<Contact>();
            mockedGenericRepository.Setup(gr => gr.Update(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // contactsService.ChangeContactStatus(contact.Object, 2, "user-id");

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

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // contactsService.ChangeContactStatus(contact.Object, 2, "user-id");

            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
