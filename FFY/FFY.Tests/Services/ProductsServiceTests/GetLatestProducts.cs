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
    public class GetLatestProducts
    {
        [TestCase(4)]
        [TestCase(3)]
        public void ShouldCallGetAllMethodOfProductsRepositoryOnce(int amount)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Returns(new List<Product>()).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            productsService.GetLatestProducts(amount);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ShouldReturnCorrectAmountOfProductsFromProductsRepository(int amount)
        {
            // Arrange
            var mockedProducts = new List<Product>
                {
                    new Product(),
                    new Product(),
                    new Product(),
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(mockedProducts);

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetLatestProducts(amount).ToList();

            // Assert
            Assert.AreEqual(amount, result.Count);
        }

        [TestCase(3)]
        public void ShouldReturnCorrectProductsOrderFromProductsRepository(int amount)
        {
            // Arrange
            // Products are added to the database chronologically, 
            // so it is expected the latest added product to be the last added
            var mockedProducts = new List<Product>
                {
                    new Product() { Name = "Third" },
                    new Product() { Name = "Second" },
                    new Product() { Name = "First" },
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll())
                .Returns(mockedProducts);

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetLatestProducts(amount).ToList();

            // Assert
            Assert.AreEqual(result[0].Name, "First");
            Assert.AreEqual(result[1].Name, "Second");
            Assert.AreEqual(result[2].Name, "Third");
        }
    }
}
