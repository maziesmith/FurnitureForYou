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
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => contactsService.AddContact(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactIsPassed()
        {
            // Arrange
            var expectedExMessage = "Contact cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => contactsService.AddContact(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenAContactIsPassed()
        {
            // Arrange
            var contact = new Mock<Contact>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.Add(contact.Object)).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.AddContact(contact.Object);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Add(contact.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAContactIsPassed()
        {
            // Arrange
            var contact = new Mock<Contact>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.AddContact(contact.Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
