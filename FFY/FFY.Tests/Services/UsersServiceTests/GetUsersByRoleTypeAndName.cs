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
    public class GetUsersByRoleTypeAndName
    {
        [Test]
        public void ShouldCallGetAllMethodOfUsersRepositoryOnce()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr =>
                gr.GetAll())
                .Returns(new List<User>())
                .Verifiable();

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            usersService.GetUsersByRoleTypeAndName(0, string.Empty);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [TestCase("v", 3)]
        [TestCase("mail", 5)]
        [TestCase("xx", 0)]
        public void ShouldReturnCorrectAmountOfFilteredUsers_WhenSearchWordIsProvided(string search, int expectedAmount)
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { UserName="sammy", FirstName = "Samuel", LastName = "Vimes", Email = "sam@mail.com" },
                new User() { UserName="vet123", FirstName = "Havlock", LastName = "Vetinari", Email = "sj@mail.com" },
                new User() { UserName="johny", FirstName = "Johny", LastName = "Cash", Email = "johnyc@mail.com" },
                new User() { UserName="vict", FirstName = "Victor", LastName = "The Great", Email = "victor@mail.com" },
                new User() { UserName="frank42", FirstName = "Frank", LastName = "Williams", Email = "f.will@mail.com" }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(users);

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = usersService.GetUsersByRoleTypeAndName(0, search);

            // Assert
            Assert.AreEqual(expectedAmount, result.Count());
        }

        [TestCase("v")]
        public void ShouldReturnCorrectFilteredUsers_WhenSearchWordIsProvided(string search)
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { UserName="sammy", FirstName = "Samuel", LastName = "Vimes", Email = "sam@mail.com" },
                new User() { UserName="vet123", FirstName = "Havlock", LastName = "Vetinari", Email = "sj@mail.com" },
                new User() { UserName="johny", FirstName = "Johny", LastName = "Cash", Email = "johnyc@mail.com" },
                new User() { UserName="vict", FirstName = "Victor", LastName = "The Great", Email = "victor@mail.com" },
                new User() { UserName="frank42", FirstName = "Frank", LastName = "Williams", Email = "f.will@mail.com" }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(users);

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = usersService.GetUsersByRoleTypeAndName(0, search).ToList();

            // Assert
            Assert.AreEqual("Vimes", result[0].LastName);
            Assert.AreEqual("Vetinari", result[1].LastName);
            Assert.AreEqual("Victor", result[2].FirstName);
        }

        [TestCase(42)]
        [TestCase(-10)]
        public void ShouldThrowInvalidCastException_WhenInvalidUserRoleTypeIsPassed(int roleType)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(new List<User>());

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            Assert.Throws<InvalidCastException>(() =>
                usersService.GetUsersByRoleTypeAndName(roleType, string.Empty).ToList());
        }

        [TestCase(-10)]
        public void ShouldThrowInvalidCastExceptionWithCorrectMessage_WhenInvalidUserRoleTypeIsPassed(int roleType)
        {
            // Arrange
            var expectedExMessage = "User role status type is out of enumeration range.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(new List<User>());

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidCastException>(() =>
                usersService.GetUsersByRoleTypeAndName(roleType, string.Empty).ToList());
            StringAssert.Contains(exception.Message, expectedExMessage);
        }

        [TestCase("v", 2, 2)]
        [TestCase("mail", 3, 1)]
        [TestCase("john", 1, 0)]
        public void ShouldReturnCorrectFilteredUsers_WhenSearchWordAndStatusTypeAreProvided(string search, int statusType, int expectedAmount)
        {
            // Arrange
            var users = new List<User>()
            {
                new User()
                {
                    UserName="sammy", FirstName = "Samuel", LastName = "Vimes", Email = "sam@mail.com",
                    UserRole = "User"
                },
                new User()
                {
                    UserName="vet123", FirstName = "Havlock", LastName = "Vetinari", Email = "sj@mail.com",
                    UserRole = "Moderator"
                },
                new User()
                {
                    UserName="johny", FirstName = "Johny", LastName = "Cash", Email = "johnyc@mail.com",
                    UserRole = "Administrator"
                },
                new User()
                {
                    UserName="vict", FirstName = "Victor", LastName = "The Great", Email = "victor@mail.com",
                    UserRole = "Moderator"
                },
                new User()
                {
                    UserName="frank42", FirstName = "Frank", LastName = "Williams", Email = "f.will@mail.com",
                    UserRole = "User"
                }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(users);

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = usersService.GetUsersByRoleTypeAndName(statusType, search);

            // Assert
            Assert.AreEqual(expectedAmount, result.Count());
        }
    }
}