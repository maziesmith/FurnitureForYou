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

namespace FFY.Tests.Services.ProductsServiceTests
{
    [TestFixture]
    public class GetProductById
    {
        [TestCase(42)]
        [TestCase(2)]
        public void ShouldCallGetProductsByIdMethodOfProductsRepositoryOnce(int id)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            productsService.GetProductById(id);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetById(id), Times.Once);
        }

        [TestCase(2, "Second product")]
        [TestCase(4, "Forth product")]
        public void ShouldReturnCorrectProductFromProductsRepository(int id, string expectedProductName)
        {
            // Arrange
            var mockedProducts = new List<Product>
            {
                new Product() { Id = 2, Name = "Second product"},
                new Product() { Id = 4, Name = "Forth product" }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetById(id))
                .Returns(mockedProducts.Find(p => p.Id == id));

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetProductById(id);

            // Assert
            Assert.AreEqual(expectedProductName, result.Name);
        }
    }
}
