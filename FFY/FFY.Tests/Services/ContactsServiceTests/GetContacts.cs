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
    public class GetContacts
    {
        [Test]
        public void ShouldCallGetAllMethodOfContactsRepositoryOnce()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.GetContacts();

            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [Test]
        public void ShouldReturnAllContactsFromContactsRepository()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();

            var mockedContacts = new List<Contact>
            {
                new Contact(),
                new Contact()
            };
            mockedGenericRepository.Setup(gr => gr.GetAll()).Returns(mockedContacts);

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = contactsService.GetContacts();

            Assert.AreSame(mockedContacts, result);
        }
    }
}
