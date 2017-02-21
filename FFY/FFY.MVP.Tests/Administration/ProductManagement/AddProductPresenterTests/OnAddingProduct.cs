using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddProduct;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddProductPresenterTests
{
    [TestFixture]
    public class OnAddingProduct
    {
        [TestCase("cool chair", 42, 5, true, "Desc", 1, 2)]
        [TestCase("white bed", 116, 2, true, "Desc", 2, 1)]
        [TestCase("white bed", 50, 0, true, "Desc", 2, 1)]
        public void ShouldCallCreateProductMethodFromProductFactory(string name,
            decimal price,
            int discountPercentage,
            bool hasDiscount,
            string description,
            int categoryId,
            int roomId)
        {
            // Arrange
            var room = new Room();
            var category = new Category();

            var discountedPrice = price - (price * (discountPercentage / 100.0M));

            var mockedView = new Mock<IAddProductView>();
            mockedView.Setup(v => v.Model).Returns(new AddProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            mockedProductFactory.Setup(pf => pf.CreateProduct(It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<Category>(),
                It.IsAny<int>(),
                It.IsAny<Room>(),
                It.IsAny<string>(),
                It.IsAny<bool>()))
                .Verifiable();
            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            mockedCategoriesServices.Setup(cs => cs.GetCategories()).Verifiable();
            var mockedRoomsServices = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            var addProductPresenter = new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.AddingProduct += null,
                new AddProductEventArgs(name,
                    price,
                    discountPercentage,
                    hasDiscount,
                    description,
                    categoryId,
                    category,
                    roomId,
                    room));

            // Assert
            mockedProductFactory.Verify(pf => pf.CreateProduct(name,
                price,
                discountedPrice,
                discountPercentage,
                hasDiscount,
                description,
                categoryId,
                category,
                roomId,
                room,
                It.IsAny<string>(),
                It.IsAny<bool>()), Times.Once);
        }

        [TestCase("cool chair", 42, 5, true, "Desc", 1, 2)]
        [TestCase("white bed", 116, 2, true, "Desc", 2, 1)]
        [TestCase("white bed", 50, 0, true, "Desc", 2, 1)]
        public void ShouldAddProductMethodFromProductsService(string name,
            decimal price,
            int discountPercentage,
            bool hasDiscount,
            string description,
            int categoryId,
            int roomId)
        {
            // Arrange
            var room = new Room();
            var category = new Category();
            var product = new Product() { Id = 1 };

            var discountedPrice = price - (price * (discountPercentage / 100.0M));

            var mockedView = new Mock<IAddProductView>();
            mockedView.Setup(v => v.Model).Returns(new AddProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            mockedProductFactory.Setup(pf => pf.CreateProduct(It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<Category>(),
                It.IsAny<int>(),
                It.IsAny<Room>(),
                It.IsAny<string>(),
                It.IsAny<bool>()))
                .Returns(product)
                .Verifiable();
            var mockedProductsServices = new Mock<IProductsService>();
            mockedProductsServices.Setup(ps => 
                ps.AddProduct(It.IsAny<Product>())).Verifiable();

            var mockedCategoriesServices = new Mock<ICategoriesService>();
            mockedCategoriesServices.Setup(cs => cs.GetCategories()).Verifiable();
            var mockedRoomsServices = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            var addProductPresenter = new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.AddingProduct += null,
                new AddProductEventArgs(name,
                    price,
                    discountPercentage,
                    hasDiscount,
                    description,
                    categoryId,
                    category,
                    roomId,
                    room));

            // Assert
            mockedProductsServices.Verify(ps => ps.AddProduct(product), Times.Once);
        }
    }
}
