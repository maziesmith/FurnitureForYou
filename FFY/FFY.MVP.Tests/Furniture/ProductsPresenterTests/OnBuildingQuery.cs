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
    public class OnBuildingQuery
    {
        [TestCase("all/", "tables", "4", "41")]
        [TestCase("latest/", "red", "1", "150")]
        public void ShouldCallBuildProductSearchQueryMethodOfQueryBuilder(string path,
           string search,
           string from,
           string to)
        {
            // Arrange
            var mockedView = new Mock<IProductsView>();
            mockedView.Setup(v => v.Model).Returns(new ProductsViewModel());

            var mockedProductsHandler = new Mock<IHandler>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();
            mockedQueryBuilder.Setup(qb => qb.BuildProductSearchQuery(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>())).Verifiable();

            var categoryByRoomPresenter = new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                mockedQueryBuilder.Object);

            // Act
            mockedView.Raise(v => v.BuildingQuery += null, this, new QueryEventArgs(path, search, from, to));

            // Assert
            mockedQueryBuilder.Verify(ph => ph.BuildProductSearchQuery(path, 
                search,
                from,
                to), Times.Once);
        }

        [TestCase("all?search=tables&from=4&to=41", "all", "tables", "4", "41")]
        [TestCase("latest?search=red&from=1&to=150", "latest", "red", "1", "150")]
        public void ShouldAssignQueryToViewModel_ReceivedFromBuildProductSearchQueryMethodOfQueryBuilder(string expectedQuery,
            string path,
            string search,
            string from,
            string to)
        {
            // Arrange
            var mockedView = new Mock<IProductsView>();
            mockedView.Setup(v => v.Model).Returns(new ProductsViewModel());

            var mockedProductsHandler = new Mock<IHandler>();
            var mockedProductsService = new Mock<IProductsService>();
            var mockedQueryBuilder = new Mock<IQueryBuilder>();
            mockedQueryBuilder.Setup(qb => qb.BuildProductSearchQuery(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>())).Returns(expectedQuery);

            var categoryByRoomPresenter = new ProductsPresenter(mockedView.Object,
                mockedProductsHandler.Object,
                mockedProductsService.Object,
                mockedQueryBuilder.Object);

            // Act
            mockedView.Raise(v => v.BuildingQuery += null, this, new QueryEventArgs(path, search, from, to));

            // Assert
            Assert.AreEqual(expectedQuery, mockedView.Object.Model.Query);
        }
    }
}
