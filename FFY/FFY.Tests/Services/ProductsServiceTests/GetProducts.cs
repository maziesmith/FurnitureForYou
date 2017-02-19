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
    public class GetProducts
    {
        [Test]
        public void ShouldCallGetAllMethodOfProductsRepositoryOnce()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            productsService.GetProducts();

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [Test]
        public void ShouldReturnAllProductsFromProductsRepository()
        {
            // Arrange
            var mockedProduct = new Mock<Product>();
            var mockedProducts = new List<Product>
            {
                mockedProduct.Object,
                mockedProduct.Object
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Returns(mockedProducts);

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetProducts();

            // Assert
            Assert.AreSame(mockedProducts, result);
        }
    }
}
