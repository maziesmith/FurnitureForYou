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
    public class GetUserById
    {
        [TestCase("42")]
        [TestCase("2")]
        public void ShouldCallGetUserByIdMethodOfUsersRepositoryOnce(string id)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            usersService.GetUserById(id);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetById(id), Times.Once);
        }

        [TestCase("2", "mr.second")]
        [TestCase("4", "mrs.forth")]
        public void ShouldReturnCorrectUserFromUsersRepository(string id, string expectedUserName)
        {
            // Arrange
            var mockedUsers = new List<User>
            {
                new User() { Id = "2", UserName = "mr.second"},
                new User() { Id = "4", UserName = "mrs.forth" }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetById(id))
                .Returns(mockedUsers.Find(p => p.Id == id));

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = usersService.GetUserById(id);

            // Assert
            Assert.AreEqual(expectedUserName, result.UserName);
        }
    }
}
