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
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            usersService.GetUserById(id);

            mockedGenericRepository.Verify(gr => gr.GetById(id), Times.Once);
        }

        [TestCase("2", "mr.second")]
        [TestCase("4", "mrs.forth")]
        public void ShouldReturnCorrectUserFromUsersRepository(string id, string expectedUserName)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            // Required AspNet.Identity.EntityFramework as well for Id
            var mockedUsers = new List<User>
            {
                new User() { Id = "2", UserName = "mr.second"},
                new User() { Id = "4", UserName = "mrs.forth" }
            };

            mockedGenericRepository.Setup(gr => gr.GetById(id))
                .Returns(mockedUsers.Find(p => p.Id == id));

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = usersService.GetUserById(id);

            Assert.AreEqual(expectedUserName, result.UserName);
        }
    }
}
