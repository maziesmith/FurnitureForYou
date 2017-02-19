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
    public class GetProductsByRoomSpecialFiltered
    {
        [TestCase("Bedroom")]
        [TestCase("Kitchen")]
        public void ShouldCallGetAllMethodOfProductsRepositoryWithSpecialExpressionOnce(string value)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>())).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            productsService.GetProductsByRoom(value);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        }

        [TestCase("bath", 1)]
        [TestCase("kitchen", 2)]
        public void ShouldReturnCorrectAmountOfProductsFromProductsRepository(string roomName, int expectedCount)
        {
            // Arrange
            Expression<Func<Product, bool>> expression = r => r.Room.Name.ToLower().Replace(@"\s+", "") == roomName;

            var mockedProducts = new List<Product>
                {
                    new Product() { Name = "First Product", Room = new Room { Name = "Kitchen"} },
                    new Product() { Name = "Second Product", Room = new Room { Name = "Bath"} },
                    new Product() { Name = "Third Product", Room = new Room { Name = "Kitchen"} },
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns(mockedProducts.Where(expression).ToList());

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetProductsByRoom(roomName).ToList();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestCase("bedroom", 0)]
        public void ShouldReturnZeroProductsFromProductsRepository_WhenNoProductFromSuchRoomIsFound(string roomName, int expectedCount)
        {
            // Arrange
            Expression<Func<Product, bool>> expression = r => r.Room.Name.ToLower().Replace(@"\s+", "") == roomName;

            var mockedProducts = new List<Product>
                {
                    new Product() { Name = "First Product", Room = new Room { Name = "Kitchen"} },
                    new Product() { Name = "Second Product", Room = new Room { Name = "Bath"} },
                    new Product() { Name = "Third Product", Room = new Room { Name = "Kitchen"} },
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns(mockedProducts.Where(expression).ToList());

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetProductsByRoom(roomName).ToList();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }
    }
}
