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

namespace FFY.Tests.Services.UsersServiceTests
{
    [TestFixture]
    public class GetUserByUsername
    {
        [TestCase("nobby")]
        [TestCase("nobbs")]
        public void ShouldCallGetAllMethodOfUsersRepositoryWithExpressionOnce(string value)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>()).Verifiable();

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            usersService.GetUserByUsername(value);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }

        [TestCase("nobby", "1")]
        [TestCase("havlock", "3")]
        [TestCase("sam", "2")]
        public void ShouldReturnCorrectUserFromUsersRepository(string username, string expectedId)
        {
            // Arrange
            Expression<Func<User, bool>> expression = r => r.UserName == username;

            var mockedUsers = new List<User>
                {
                    new User() { UserName = "nobby", Id="1" },
                    new User() { UserName = "sam", Id="2" },
                    new User() { UserName = "havlock", Id="3" },
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(mockedUsers.Where(expression).ToList());

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = usersService.GetUserByUsername(username);

            // Assert
            Assert.AreEqual(expectedId, result.Id);
        }

        [TestCase("anonymous")]
        [TestCase("randomnotfounduser")]
        public void ShouldReturnNull_WhenNoUserWithSuchUsernameIsFound(string username)
        {
            // Arrange
            Expression<Func<User, bool>> expression = r => r.UserName == username;

            var mockedUsers = new List<User>
                {
                    new User() { UserName = "nobby", Id="1" },
                    new User() { UserName = "sam", Id="2" },
                    new User() { UserName = "havlock", Id="3" },
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(mockedUsers.Where(expression).ToList());

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = usersService.GetUserByUsername(username);
            
            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
