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
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            productsService.GetProducts();

            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [Test]
        public void ShouldReturnAllProductsFromProductsRepository()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            // It is mocked, but it is plain object and not sure whether interface is required for mocking
            var mockedProduct = new Mock<Product>();

            var mockedProducts = new List<Product>
            {
                mockedProduct.Object,
                mockedProduct.Object
            };
            mockedGenericRepository.Setup(gr => gr.GetAll()).Returns(mockedProducts);

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = productsService.GetProducts();

            Assert.AreSame(mockedProducts, result);
        }
    }
}
