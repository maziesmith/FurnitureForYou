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

namespace FFY.Tests.Services.AddressesServiceTests
{
    [TestFixture]
    class AddAddress
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullAddressIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();

            var addressesService = new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            Assert.Throws<ArgumentNullException>(() => addressesService.AddAddress(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullAddressIsPassed()
        {
            var expectedExMessage = "Address cannot be null.";
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();

            var addressesService = new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var exception = Assert.Throws<ArgumentNullException>(() => addressesService.AddAddress(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfAddressRepositoryOnce_WhenAAddressIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var address = new Mock<Address>();
            mockedGenericRepository.Setup(gr => gr.Add(address.Object)).Verifiable();

            var addressesService = new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            addressesService.AddAddress(address.Object);

            mockedGenericRepository.Verify(gr => gr.Add(address.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAAddressIsPassed()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var address = new Mock<Address>();

            var addressesService = new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            addressesService.AddAddress(address.Object);

            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
