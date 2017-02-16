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
    public class GetUsers
    {
        [Test]
        public void ShouldCallGetAllMethodOfUsersRepositoryOnce()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            usersService.GetUsers();

            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [Test]
        public void ShouldReturnAllUsersFromUsersRepository()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<User>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var mockedUser = new Mock<User>();

            var mockedUsers = new List<User>
            {
                mockedUser.Object,
                mockedUser.Object
            };
            mockedGenericRepository.Setup(gr => gr.GetAll()).Returns(mockedUsers);

            var usersService = new UsersService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = usersService.GetUsers();

            Assert.AreSame(mockedUsers, result);
        }
    }
}
