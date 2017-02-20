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
    public class GetContactsByStatusTypeAndTitleOrSender
    {
        [Test]
        public void ShouldCallGetAllMethodOfContactsRepositoryOnce()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(new List<Contact>())
                .Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            contactsService.GetContactsByStatusTypeAndTitleOrSender(0, string.Empty);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [TestCase("a", 4)]
        [TestCase("tac", 2)]
        [TestCase("zz", 2)]
        [TestCase("xx", 0)]
        public void ShouldReturnCorrectAmountOfFilteredContacts_WhenSearchWordIsProvided(string search, int expectedAmount)
        {
            // Arrange
            var contacts = new List<Contact>()
            {
                new Contact() { Title = "Contact", Email = "Tac" },
                new Contact() { Title = "tAct", Email = "zzz" },
                new Contact() { Title = "abc", Email = "bcd" },
                new Contact() { Title = "a", Email = "zz" },
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(contacts);

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = contactsService.GetContactsByStatusTypeAndTitleOrSender(0, search);

            // Assert
            Assert.AreEqual(expectedAmount, result.Count());
        }

        [TestCase("zz")]
        public void ShouldReturnCorrectFilteredContacts_WhenSearchWordIsProvided(string search)
        {
            // Arrange
            var contacts = new List<Contact>()
            {
                new Contact() { Title = "Contact", Email = "Tac" },
                new Contact() { Title = "tAct", Email = "zzz" },
                new Contact() { Title = "abc", Email = "bcd" },
                new Contact() { Title = "a", Email = "zz" },
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(contacts);

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = contactsService.GetContactsByStatusTypeAndTitleOrSender(0, search).ToList();

            // Assert
            Assert.AreEqual("zzz", result[0].Email);
            Assert.AreEqual("zz", result[1].Email);
        }

        [TestCase(42)]
        [TestCase(-10)]
        public void ShouldThrowInvalidCastException_WhenInvalidContactStatusTypeIsPassed(int statusType)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(new List<Contact>());

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<InvalidCastException>(() => 
                contactsService.GetContactsByStatusTypeAndTitleOrSender(statusType, string.Empty).ToList());
        }

        [TestCase(-10)]
        public void ShouldThrowInvalidCastExceptionWithCorrectMessage_WhenInvalidContactStatusTypeIsPassed(int statusType)
        {
            // Arrange
            var expectedExMessage = "Contact status type is out of enumeration range.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(new List<Contact>());

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidCastException>(() =>
                contactsService.GetContactsByStatusTypeAndTitleOrSender(statusType, string.Empty).ToList());
            StringAssert.Contains(exception.Message, expectedExMessage);
        }

        [TestCase("zz", 1, 1)]
        [TestCase("a", 1, 2)]
        [TestCase("tac", 3, 0)]
        public void ShouldReturnCorrectFilteredContacts_WhenSearchWordAndStatusTypeAreProvided(string search, int statusType, int expectedAmount)
        {
            // Arrange
            var contacts = new List<Contact>()
            {
                new Contact() { Title = "Contact", Email = "Tac", ContactStatusType = ContactStatusType.NotProcessed },
                new Contact() { Title = "tAct", Email = "zzz", ContactStatusType = ContactStatusType.NotProcessed },
                new Contact() { Title = "abc", Email = "bcd", ContactStatusType = ContactStatusType.Processed },
                new Contact() { Title = "a", Email = "zz", ContactStatusType = ContactStatusType.Processing },
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(contacts);

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = contactsService.GetContactsByStatusTypeAndTitleOrSender(statusType, search);

            // Assert
            Assert.AreEqual(expectedAmount, result.Count());
        }
    }
}