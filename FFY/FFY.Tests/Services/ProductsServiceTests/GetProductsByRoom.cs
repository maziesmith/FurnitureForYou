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

namespace FFY.Tests.Services.ProductsServiceTests
{
    [TestFixture]
    public class GetProductsByRoom
    {
        [TestCase("Bedroom")]
        [TestCase("Kitchen")]
        public void ShouldCallGetAllMethodOfProductsRepositoryWithExpressionOnce(string value)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>())).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            productsService.GetProductsByRoom(value);

            mockedGenericRepository.Verify(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        }

        [TestCase("Bath", 1)]
        [TestCase("Kitchen", 2)]
        public void ShouldReturnCorrectAmountOfProductsFromProductsRepository(string roomName, int expectedCount)
        {
            Expression<Func<Product, bool>> expression = r => r.Room.Name == roomName;

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var mockedProducts = new List<Product>
                {
                    new Product() { Name = "First Product", Room = new Room { Name = "Kitchen"} },
                    new Product() { Name = "Second Product", Room = new Room { Name = "Bath"} },
                    new Product() { Name = "Third Product", Room = new Room { Name = "Kitchen"} },
                }
            .AsQueryable();

            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns(mockedProducts.Where(expression).ToList());

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = productsService.GetProductsByRoom(roomName).ToList();

            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestCase("Bedroom", 0)]
        public void ShouldReturnZeroProductsFromProductsRepository_WhenNoProductFromSuchRoomIsFound(string roomName, int expectedCount)
        {
            Expression<Func<Product, bool>> expression = r => r.Room.Name == roomName;

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var mockedProducts = new List<Product>
                {
                    new Product() { Name = "First Product", Room = new Room { Name = "Kitchen"} },
                    new Product() { Name = "Second Product", Room = new Room { Name = "Bath"} },
                    new Product() { Name = "Third Product", Room = new Room { Name = "Kitchen"} },
                }
            .AsQueryable();

            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns(mockedProducts.Where(expression).ToList());

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = productsService.GetProductsByRoom(roomName).ToList();

            Assert.AreEqual(expectedCount, result.Count);
        }
    }
}

