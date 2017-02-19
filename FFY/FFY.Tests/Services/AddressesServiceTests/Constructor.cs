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
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUnitOfWorkIsPassed()
        {
            // Arrange
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddressesService(null, mockedGenericRepository.Object));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUnitOfWorkIsPassed()
        {
            // Arrange
            var expectedExMessage = "Unit of work cannot be null.";

            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AddressesService(null, mockedGenericRepository.Object));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenNullAddressRepositoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddressesService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullAddressRepositoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Addresses repository cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new AddressesService(mockedUnitOfWork.Object, null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldNotThrow_WhenValidUnitOfWorkAndAddressRepositoryArePassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Address>>();

            // Act and Assert
            Assert.DoesNotThrow(() =>
                new AddressesService(mockedUnitOfWork.Object, mockedGenericRepository.Object));
        }
    }
}
