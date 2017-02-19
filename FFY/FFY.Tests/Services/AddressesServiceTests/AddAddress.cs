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
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();

            var addressesService = new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => addressesService.AddAddress(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullAddressIsPassed()
        {
            // Arrange
            var expectedExMessage = "Address cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();

            var addressesService = new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => addressesService.AddAddress(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfAddressRepositoryOnce_WhenAAddressIsPassed()
        {
            // Arrange
            var address = new Mock<Address>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();
            mockedGenericRepository.Setup(gr => gr.Add(address.Object)).Verifiable();

            var addressesService = new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            addressesService.AddAddress(address.Object);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Add(address.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAAddressIsPassed()
        {
            // Arrange
            var address = new Mock<Address>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();

            var addressesService = new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            addressesService.AddAddress(address.Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
