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

namespace FFY.Tests.Services.CategoriesServiceTests
{
    [TestFixture]
    public class GetCategoriesByRoomSpecialFiltered
    {
        [Test]
        public void ShouldCallGetAllMethodWithExpressionOfProductRepositoryOnce()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();
            mockedProductRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(),
                It.IsAny<Expression<Func<Product, string>>>(),
                It.IsAny<Expression<Func<Product, Category>>>()))
                .Returns(new List<Category>())
                .Verifiable();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object,
                mockedCategoryRepository.Object,
                mockedProductRepository.Object);

            // Act
            categoriesService.GetCategoriesByRoomSpecialFiltered("room");

            // Assert
            mockedProductRepository.Verify(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(),
                It.IsAny<Expression<Func<Product, string>>>(),
                It.IsAny<Expression<Func<Product, Category>>>()), Times.Once);
        }

        [Test]
        public void ShouldGetDistinctCategoriesBasedOnTheExpression()
        {
            // Arrange
            var roomName = "abc";
            Func<Product, bool> filterFunction = 
                p => p.Room.Name.ToLower().Replace(@"\s+", "") == roomName;
            Func<Product, string> sortFunction = p => p.Category.Name;
            Func<Product, Category> selectFunction = p => p.Category;

            var rooms = new List<Room>()
            {
                new Room() { Name = "abcd" },
                new Room() { Name = "aBc" },
                new Room() { Name = "bcd" }
            };
            var categories = new List<Category>()
            {
                new Category() { Name = "category0" },
                new Category() { Name = "category1" },
                new Category() { Name = "category2" },
                new Category() { Name = "category0" }
            };

            var products = new List<Product>
            {
                new Product() { Room = rooms[0], Category = categories[0] },
                new Product() { Room = rooms[1], Category = categories[1] },
                new Product() { Room = rooms[1], Category = categories[3] },
                new Product() { Room = rooms[2], Category = categories[2] },
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();
            mockedProductRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(),
                It.IsAny<Expression<Func<Product, string>>>(),
                It.IsAny<Expression<Func<Product, Category>>>()))
                .Returns(products.Where(filterFunction)
                    .OrderBy(sortFunction)
                    .Select(selectFunction));

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object,
                mockedCategoryRepository.Object,
                mockedProductRepository.Object);

            // Act
            var result = categoriesService.GetCategoriesByRoomSpecialFiltered(roomName);

            // Assert
            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        public void ShouldGetMatchingCategoriesBasedOnTheExpression()
        {
            // Arrange
            var roomName = "abc";
            Func<Product, bool> filterFunction =
                p => p.Room.Name.ToLower().Replace(@"\s+", "") == roomName;
            Func<Product, string> sortFunction = p => p.Category.Name;
            Func<Product, Category> selectFunction = p => p.Category;

            var rooms = new List<Room>()
            {
                new Room() { Name = "abcd" },
                new Room() { Name = "aBc" },
                new Room() { Name = "bcd" }
            };
            var categories = new List<Category>()
            {
                new Category() { Name = "category0" },
                new Category() { Name = "category1" },
                new Category() { Name = "category2" },
                new Category() { Name = "category0" }
            };

            var products = new List<Product>
            {
                new Product() { Room = rooms[0], Category = categories[0] },
                new Product() { Room = rooms[1], Category = categories[1] },
                new Product() { Room = rooms[1], Category = categories[3] },
                new Product() { Room = rooms[2], Category = categories[2] },
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();
            mockedProductRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(),
                It.IsAny<Expression<Func<Product, string>>>(),
                It.IsAny<Expression<Func<Product, Category>>>()))
                .Returns(products.Where(filterFunction)
                    .OrderBy(sortFunction)
                    .Select(selectFunction));

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object,
                mockedCategoryRepository.Object,
                mockedProductRepository.Object);

            // Act
            var result = categoriesService.GetCategoriesByRoomSpecialFiltered(roomName).ToList();

            // Assert
            Assert.AreEqual(result[0].Name, "category0");
            Assert.AreEqual(result[1].Name, "category1");
        }
    }
}
