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
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUnitOfWorkIsPassed()
        {
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            Assert.Throws<ArgumentNullException>(() => new ContactsService(null, mockedGenericRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
        {
            var expectedExMessage = "Unit of work cannot be null.";
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ContactsService(null, mockedGenericRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContactRepositoryIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new ContactsService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullContactRepositoryIsPassed()
        {
            var expectedExMessage = "Contacts repository cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ContactsService(mockedUnitOfWork.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUnitOfWorkAndCategoryRepositoryArePassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            Assert.DoesNotThrow(() =>
                new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object));
        }
    }
}
