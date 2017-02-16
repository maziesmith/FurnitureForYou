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
    public class AddContact
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContactIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            Assert.Throws<ArgumentNullException>(() => contactsService.AddContact(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactIsPassed()
        {
            var expectedExMessage = "Contact cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var exception = Assert.Throws<ArgumentNullException>(() => contactsService.AddContact(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenAContactIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var contact = new Mock<Contact>();
            mockedGenericRepository.Setup(gr => gr.Add(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.AddContact(contact.Object);

            mockedGenericRepository.Verify(gr => gr.Add(contact.Object), Times.Once);
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

            contactsService.AddContact(contact.Object);

            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
