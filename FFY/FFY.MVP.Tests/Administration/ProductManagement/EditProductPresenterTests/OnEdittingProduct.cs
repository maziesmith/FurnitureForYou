using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Administration.ProductManagement.EditProduct;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.ProductManagement.EditProductPresenterTests
{
    [TestFixture]
    public class OnEdittingProduct
    {
        [TestCase(20, 40, 5)]
        [TestCase(35, 60, 2)]
        public void ShouldRecalculateProductDiscountPriceBaseOnNewPriceAndDiscountPercentage(decimal oldDiscountPrice,
            decimal price,
            int discountPercentage)
        {
            // Arrange
            var product = new Product()
            {
                DiscountedPrice = oldDiscountPrice,
                Price = price,
                DiscountPercentage = discountPercentage
            };

            var newDiscountPrice = price - (price * (discountPercentage / 100.0M));

            var mockedView = new Mock<IEditProductView>();
            mockedView.Setup(v => v.Model).Returns(new EditProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            var mockedRoomsServices = new Mock<IRoomsService>();

            var mockedImageUploader = new Mock<IImageUploader>();

            var editProductPresenter = new EditProductPresenter(mockedView.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.EdittingProduct += null,
                new EditProductEventArgs(product));

            // Assert
            Assert.AreEqual(product.DiscountedPrice, newDiscountPrice);
            Assert.AreNotEqual(product.DiscountedPrice, oldDiscountPrice);
        }

        [Test]
        public void ShouldCallEditProductMethodFromProductsService()
        {
            // Arrange
            var product = new Product();

            var mockedView = new Mock<IEditProductView>();
            mockedView.Setup(v => v.Model).Returns(new EditProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsServices = new Mock<IProductsService>();
            mockedProductsServices.Setup(ps => ps.EditProduct(It.IsAny<Product>()))
                .Verifiable();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            var mockedRoomsServices = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            var editProductPresenter = new EditProductPresenter(mockedView.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.EdittingProduct += null,
                new EditProductEventArgs(product));

            // Assert
            mockedProductsServices.Verify(ps => ps.EditProduct(product), Times.Once);
        }
    }
}
