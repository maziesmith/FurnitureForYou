using FFY.Models;
using FFY.MVP.Furniture.FurnitureDetailed;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.FurnitureDetailedPresenterTests
{
    [TestFixture]
    public class OnGettingProductById
    {
        [TestCase(42)]
        [TestCase(1)]
        public void ShouldCallGetCategoriesByRoomSpecialFilteredWithExactEventArgument(int id)
        {
            // Arrange
            var mockedView = new Mock<IFurnitureDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new FurnitureDetailedViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedProductsService = new Mock<IProductsService>();
            mockedProductsService.Setup(ps =>
                ps.GetProductById(It.IsAny<int>()))
                .Verifiable();

            var furnitureDetailedPresenter = new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v => v.GettingProductById += null, 
                new FurnitureDetailedEventArgs(id));

            // Assert
            mockedProductsService.Verify(ps => 
                ps.GetProductById(id), Times.Once);
        }

        [TestCase(42, "Forty second")]
        [TestCase(1, "First")]
        [TestCase(13, "Thirteen")]
        public void ShouldSetProperProductToViewModel_ReceivedFromGetProductById(int id, string expectedProductName)
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "First" },
                new Product() { Id = 42, Name = "Forty second" },
                new Product() { Id = 13, Name = "Thirteen" },
            };

            var mockedView = new Mock<IFurnitureDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new FurnitureDetailedViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedProductsService = new Mock<IProductsService>();
            mockedProductsService.Setup(ps =>
                ps.GetProductById(It.IsAny<int>()))
                .Returns(products.FirstOrDefault(p => p.Id == id));

            var furnitureDetailedPresenter = new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v => v.GettingProductById += null,
                new FurnitureDetailedEventArgs(id));

            // Assert
            Assert.AreEqual(expectedProductName, mockedView.Object.Model.Product.Name);
        }

        [TestCase(16, null)]
        [TestCase(7, null)]
        public void ShouldReturnNullProductToViewModel_WhenNoProductIsFoundFromGetProductById(int id, object expectedProduct)
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "First" },
                new Product() { Id = 42, Name = "Forty second" },
                new Product() { Id = 13, Name = "Thirteen" },
            };

            var mockedView = new Mock<IFurnitureDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new FurnitureDetailedViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            var mockedProductsService = new Mock<IProductsService>();
            mockedProductsService.Setup(ps =>
                ps.GetProductById(It.IsAny<int>()))
                .Returns(products.FirstOrDefault(p => p.Id == id));

            var furnitureDetailedPresenter = new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v => v.GettingProductById += null,
                new FurnitureDetailedEventArgs(id));

            // Assert
            Assert.AreEqual(expectedProduct, mockedView.Object.Model.Product);
        }
    }
}
