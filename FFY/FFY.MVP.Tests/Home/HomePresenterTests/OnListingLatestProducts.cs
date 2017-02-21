using FFY.Models;
using FFY.MVP.Home;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Home.HomePresenterTests
{
    [TestFixture]
    public class OnListingLatestProducts
    {
        [TestCase(30)]
        [TestCase(50)]
        public void ShouldCallGetLatestProductsMethodOfProductsService(int amount)
        {
            // Arrange
            var mockedView = new Mock<IHomeView>();
            mockedView.Setup(v => v.Model).Returns(new HomeViewModel());

            var mockedProductsService = new Mock<IProductsService>();
            mockedProductsService.Setup(ps =>
                ps.GetLatestProducts(It.IsAny<int>())).Verifiable();

            var homePresenter = new HomePresenter(mockedView.Object, mockedProductsService.Object);

            // Act
            mockedView.Raise(v => v.ListingLatestProducts += null, new HomeEventArgs(amount));

            // Assert
            mockedProductsService.Verify(ps => ps.GetLatestProducts(amount), Times.Once);
        }

        [TestCase(30)]
        [TestCase(50)]
        public void ShouldAssignProductsToViewModel_ReceivedFromGetLatestProductsMethod(int amount)
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() { Id=1, Name="Chair" },
                new Product() { Id=2, Name="Couch" }
            };

            var mockedView = new Mock<IHomeView>();
            mockedView.Setup(v => v.Model).Returns(new HomeViewModel());

            var mockedProductsService = new Mock<IProductsService>();
            mockedProductsService.Setup(ps =>
                ps.GetLatestProducts(It.IsAny<int>())).Returns(products);

            var homePresenter = new HomePresenter(mockedView.Object, mockedProductsService.Object);

            // Act
            mockedView.Raise(v => v.ListingLatestProducts += null, new HomeEventArgs(amount));

            // Assert
            CollectionAssert.AreEquivalent(products, mockedView.Object.Model.LatestProducts);
        }
    }
}
