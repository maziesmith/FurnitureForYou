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

namespace FFY.Tests.Services.UsersServiceTests
{
    [TestFixture]
    public class ChangeUserRole
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullUserIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);
            
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => usersService.ChangeUserRole(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullUserIsPassed()
        {
            // Arrange
            var expectedExMessage = "User cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => usersService.ChangeUserRole(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallUpdateMethodOfCategoryRepositoryOnce_WhenAUserIsPassed()
        {
            // Arrange
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.Update(user.Object)).Verifiable();

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            usersService.ChangeUserRole(user.Object);

            // Assert
            mockedGenericRepository.Verify(gr => gr.Update(user.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenAUserIsPassed()
        {
            // Arrange
            var user = new Mock<User>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
          
            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            usersService.ChangeUserRole(user .Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
