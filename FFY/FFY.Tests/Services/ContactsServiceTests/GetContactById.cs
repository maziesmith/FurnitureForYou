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
    public class GetContactById
    {
        [TestCase(42)]
        [TestCase(2)]
        public void ShouldCallGetContactByIdMethodOfContactsRepositoryOnce(int id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.GetContactById(id);

            mockedGenericRepository.Verify(gr => gr.GetById(id), Times.Once);
        }

        [TestCase(2, "Really important message!")]
        [TestCase(4, "You want to loose weight?")]
        public void ShouldReturnCorrectContactFromContactsRepository(int id, string expectedContactTitle)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var mockedContacts = new List<Contact>
            {
                new Contact() { Id = 2, Title = "Really important message!"},
                new Contact() { Id = 4, Title = "You want to loose weight?" }
            };

            mockedGenericRepository.Setup(gr => gr.GetById(id))
                .Returns(mockedContacts.Find(p => p.Id == id));

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = contactsService.GetContactById(id);

            Assert.AreEqual(expectedContactTitle, result.Title);
        }
    }
}
