using FFY.Models;
using FFY.MVP.Furniture.Products;
using FFY.MVP.Furniture.Utilities;
using FFY.Services.Contracts;
using FFY.Services.Handlers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.ProductsPresenterTests
{
    [TestFixture]
    public class OnListingProducts
    {
        [TestCase("all/", "kitchen", "tables", "green", false, 4, 200)]
        [TestCase("latest/", "bathroom", "sinks", "white", false, 1, 150)]
        public void ShouldCallHandleProductsMethodOfProductsHandler(string path,
            string room,
            string category,
            string search,
            bool rangeProvided,
            int from,
            int to)
        {
            // Arrange
            var mockedView = new Mock<IProductsView>();
            mockedView.Setup(v => v.Model).Returns(new ProductsViewModel());

            var mockedProductsHandler = new Mock<IHandler>();
            mockedProductsHandler.Setup(ph => ph.HandleProducts(It.IsAny<IProductsService>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<int>(),
                It.IsAny<int>())).Verifiable();

            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();


            var categoryByRoomPresenter = new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                mockedQueryBuilder.Object);

            // Act
            mockedView.Raise(v => v.ListingProducts += null, new ProductsEventArgs(path,
                room,
                category,
                search,
                rangeProvided,
                from,
                to));

            // Assert
            mockedProductsHandler.Verify(ph => ph.HandleProducts(mockedProductsService.Object,
                path,
                room,
                category,
                search,
                rangeProvided,
                from,
                to), Times.Once);
        }

        [TestCase("all/", "kitchen", "tables", "green", false, 4, 200)]
        [TestCase("latest/", "bathroom", "sinks", "white", false, 1, 150)]
        public void ShouldAssignProductsToViewModel_ReceivedFromHanldeProductsMethodOfProductsHandler(string path,
            string room,
            string category,
            string search,
            bool rangeProvided,
            int from,
            int to)
        {
            // Arrange
            var products = new List<Product>()
                {
                    new Product() { Id=4, Name="Table" },
                    new Product() { Id=6, Name="Bed" }
                };

            var mockedView = new Mock<IProductsView>();
            mockedView.Setup(v => v.Model).Returns(new ProductsViewModel());

            var mockedProductsHandler = new Mock<IHandler>();
            mockedProductsHandler.Setup(ph => ph.HandleProducts(It.IsAny<IProductsService>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<int>(),
                It.IsAny<int>())).Returns(products);

            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();


            var categoryByRoomPresenter = new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                mockedQueryBuilder.Object);

            // Act
            mockedView.Raise(v => v.ListingProducts += null, new ProductsEventArgs(path,
                room,
                category,
                search,
                rangeProvided,
                from,
                to));

            // Assert
            CollectionAssert.AreEquivalent(products, mockedView.Object.Model.Products);
        }
    }
}

