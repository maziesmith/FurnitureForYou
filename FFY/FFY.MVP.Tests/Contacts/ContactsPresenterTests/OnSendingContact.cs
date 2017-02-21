using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Contacts.ContactSender;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Contacts.ContactsPresenterTests
{
    [TestFixture]
    public class OnSendingContact
    {
        [TestCase("Message", "me@mail.com", "Content", ContactStatusType.NotProcessed)]
        [TestCase("Important", "me@mail.com", "Joking", ContactStatusType.Processed)]
        public void ShouldCallCreateContactMethodOfContactService(string title,
            string email,
            string emailContent,
            ContactStatusType statusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 1, 1);

            var mockedView = new Mock<IContactView>();
            mockedView.Setup(v => v.Model).Returns(new ContactViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            var mockedContactFactory = new Mock<IContactFactory>();
            mockedContactFactory.Setup(cf => cf.CreateContact(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<ContactStatusType>())).Verifiable();

            var contactPresenter = new ContactPresenter(mockedView.Object,
                mockedContactFactory.Object,
                mockedContactsService.Object);

            // Act
            mockedView.Raise(v => v.SendingContact += null, new ContactEventArgs(title,
                email,
                emailContent,
                sendOn,
                statusType));

            // Assert
            mockedContactFactory.Verify(cf => 
                cf.CreateContact(title, email, emailContent, sendOn, statusType), Times.Once);
        }

        [TestCase("Message", "me@mail.com", "Content", ContactStatusType.NotProcessed)]
        [TestCase("Important", "me@mail.com", "Joking", ContactStatusType.Processed)]
        public void ShouldCallAddContactMethodOfContactService(string title,
            string email,
            string emailContent,
            ContactStatusType statusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 1, 1);

            var mockedView = new Mock<IContactView>();
            mockedView.Setup(v => v.Model).Returns(new ContactViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs => cs.AddContact(It.IsAny<Contact>())).Verifiable();

            var mockedContactFactory = new Mock<IContactFactory>();

            var contactPresenter = new ContactPresenter(mockedView.Object,
                mockedContactFactory.Object,
                mockedContactsService.Object);

            // Act
            mockedView.Raise(v => v.SendingContact += null, new ContactEventArgs(title,
                email,
                emailContent,
                sendOn,
                statusType));

            // Assert
            mockedContactsService.Verify(cs => cs.AddContact(It.IsAny<Contact>()), Times.Once);
        }

        [TestCase("Message", "me@mail.com", "Content", ContactStatusType.NotProcessed)]
        [TestCase("Important", "me@mail.com", "Joking", ContactStatusType.Processed)]
        public void ShouldCallAddContactMethodOfContactServiceWithCorrectContact(string title,
            string email,
            string emailContent,
            ContactStatusType statusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 1, 1);

            var contact = new Contact(title, email, emailContent, sendOn, statusType);

            var mockedView = new Mock<IContactView>();
            mockedView.Setup(v => v.Model).Returns(new ContactViewModel());

            var mockedContactsService = new Mock<IContactsService>();
            mockedContactsService.Setup(cs => cs.AddContact(It.IsAny<Contact>())).Verifiable();

            var mockedContactFactory = new Mock<IContactFactory>();
            mockedContactFactory.Setup(cf => cf.CreateContact(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<ContactStatusType>())).
                Returns(contact);

            var contactPresenter = new ContactPresenter(mockedView.Object,
                mockedContactFactory.Object,
                mockedContactsService.Object);

            // Act
            mockedView.Raise(v => v.SendingContact += null, new ContactEventArgs(title,
                email,
                emailContent,
                sendOn,
                statusType));

            // Assert
            mockedContactsService.Verify(cs => cs.AddContact(contact), Times.Once);
        }
    }
}
