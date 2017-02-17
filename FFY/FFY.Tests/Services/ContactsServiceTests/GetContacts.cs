using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            mockedGenericRepository.Setup(gr => gr.GetAll<DateTime>(null, It.IsAny<Expression<Func<Contact, DateTime>>>()))
                .Returns(new List<Contact>())
                .Verifiable();

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            contactsService.GetContacts();

            mockedGenericRepository.Verify(gr => gr.GetAll<DateTime>(null, It.IsAny<Expression<Func<Contact, DateTime>>>()), Times.Once);
        }

        [Test]
        public void ShouldReturnAllContactsFromContactsRepository()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Contact>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking

            var mockedContacts = new List<Contact>
            {
                new Contact() { SendOn = new DateTime(2017, 2, 17)},
                new Contact() { SendOn = new DateTime(2017, 2, 14)},
                new Contact() { SendOn = new DateTime(2017, 2, 16)},
            };
            mockedGenericRepository.Setup(gr => 
                gr.GetAll<DateTime>(null, It.IsAny<Expression<Func<Contact, DateTime>>>()))
                .Returns(mockedContacts.OrderBy(s => s.SendOn));

            var contactsService = new ContactsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = contactsService.GetContacts().ToList();

            Assert.AreEqual(result[0].SendOn, new DateTime(2017, 2, 17));
            Assert.AreEqual(result[1].SendOn, new DateTime(2017, 2, 16));
            Assert.AreEqual(result[2].SendOn, new DateTime(2017, 2, 14));
        }
    }
}
