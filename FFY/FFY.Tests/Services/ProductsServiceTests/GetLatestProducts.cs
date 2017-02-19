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
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll()).Returns(new List<Product>()).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            productsService.GetLatestProducts(amount);

            mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ShouldReturnCorrectAmountOfProductsFromProductsRepository(int amount)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
            var mockedProducts = new List<Product>
                {
                    new Product(),
                    new Product(),
                    new Product(),
                }
            .AsQueryable();

            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(), null, It.IsAny<int>()))
                .Returns(mockedProducts);

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = productsService.GetDiscountProducts(amount).ToList();

            Assert.AreEqual(amount, result.Count);
        }

        [TestCase(3)]
        public void ShouldReturnCorrectProductsFromProductsRepository(int amount)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();

            // It is NOT mocked, but it is plain object and not sure whether interface is required for mocking
           
            // Products are added to the database chronologically, 
            // so it is expected the latest added product to be the last added
            var mockedProducts = new List<Product>
                {
                    new Product() { Name = "Third" },
                    new Product() { Name = "Second" },
                    new Product() { Name = "First"},
                }
            .AsQueryable();

            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(), null, It.IsAny<int>()))
                .Returns(mockedProducts);

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            var result = productsService.GetDiscountProducts(amount).ToList();

            Assert.AreEqual(result[0].Name, "First");
            Assert.AreEqual(result[1].Name, "Second");
            Assert.AreEqual(result[1].Name, "Third");
        }
    }
}
