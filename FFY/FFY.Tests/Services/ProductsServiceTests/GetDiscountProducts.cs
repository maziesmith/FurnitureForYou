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
    public class GetDiscountProducts
    {
        [TestCase(4)]
        [TestCase(6)]
        public void ShouldCallGetAllMethodOfProductsRepositoryWithExpressionOnce(int amount)
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr =>
                gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(), null, It.IsAny<int>())).Verifiable();

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            productsService.GetDiscountProducts(amount);

            // Assert
            mockedGenericRepository.Verify(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(), null, It.IsAny<int>()), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ShouldReturnCorrectAmountOfProductsFromProductsRepository(int amount)
        {
            // Arrange
            Expression<Func<Product, bool>> expression = p => p.DiscountPercentage > 0;

            var mockedProducts = new List<Product>
                {
                    new Product() { DiscountPercentage = 5 },
                    new Product() { DiscountPercentage = 10 },
                    new Product() { DiscountPercentage = 3 },
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(), null, It.IsAny<int>()))
                .Returns(mockedProducts.Where(expression).Take(amount).ToList());

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetDiscountProducts(amount).ToList();

            // Assert
            Assert.AreEqual(amount, result.Count);
        }

        [TestCase(4)]
        [TestCase(6)]
        public void ShouldReturnCorrectAmountOfProductsWithPositiveDiscountPercentageFromProductsRepository(int amount)
        {
            // Arrange
            Expression<Func<Product, bool>> expression = p => p.DiscountPercentage > 0;
            var expectedAmount = 2;

            var mockedProducts = new List<Product>
                {
                    new Product() { DiscountPercentage = 5 },
                    new Product() { DiscountPercentage = 10 },
                    new Product() { DiscountPercentage = 0 },
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(), null, It.IsAny<int>()))
                .Returns(mockedProducts.Where(expression).Take(amount).ToList());

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetDiscountProducts(amount).ToList();

            // Assert
            Assert.AreEqual(expectedAmount, result.Count);
        }

        [TestCase(4)]
        public void ShouldReturnZeroAmountOfProductsFromProductsRepository_WhenNoProductsMatchExpression(int amount)
        {
            // Arrange
            var expectedAmount = 0;
            Expression<Func<Product, bool>> expression = p => p.DiscountPercentage > 0;

            var mockedProducts = new List<Product>
                {
                    new Product() { DiscountPercentage = -5 },
                    new Product() { DiscountPercentage = -42 },
                    new Product() { DiscountPercentage = 0 },
                }
            .AsQueryable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedGenericRepository = new Mock<IGenericRepository<Product>>();
            mockedGenericRepository.Setup(gr => gr.GetAll(It.IsAny<Expression<Func<Product, bool>>>(), null, It.IsAny<int>()))
                .Returns(mockedProducts.Where(expression).Take(amount).ToList());

            var productsService = new ProductsService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

            // Act
            var result = productsService.GetDiscountProducts(amount).ToList();

            // Assert
            Assert.AreEqual(expectedAmount, result.Count);
        }


    }
}
