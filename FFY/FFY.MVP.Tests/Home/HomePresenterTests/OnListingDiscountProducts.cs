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
    public class OnListingDiscountProducts
    {
        [TestCase(100)]
        [TestCase(150)]
        public void ShouldCallGetDiscountProductsMethodOfProductsService(int amount)
        {
            // Arrange
            var mockedView = new Mock<IHomeView>();
            mockedView.Setup(v => v.Model).Returns(new HomeViewModel());

            var mockedProductsService = new Mock<IProductsService>();
            mockedProductsService.Setup(ps => 
                ps.GetDiscountProducts(It.IsAny<int>())).Verifiable();

            var homePresenter = new HomePresenter(mockedView.Object, mockedProductsService.Object);

            // Act
            mockedView.Raise(v => v.ListingDiscountProducts += null, new HomeEventArgs(amount));

            // Assert
            mockedProductsService.Verify(ps => ps.GetDiscountProducts(amount), Times.Once);
        }

        [TestCase(100)]
        [TestCase(150)]
        public void ShouldAssignProductsToViewModel_ReceivedFromGetDiscountProductsMethod(int amount)
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product() { Id=1, Name="Desk" },
                new Product() { Id=2, Name="Lamp" }
            };

            var mockedView = new Mock<IHomeView>();
            mockedView.Setup(v => v.Model).Returns(new HomeViewModel());

            var mockedProductsService = new Mock<IProductsService>();
            mockedProductsService.Setup(ps =>
                ps.GetDiscountProducts(It.IsAny<int>())).Returns(products);

            var homePresenter = new HomePresenter(mockedView.Object, mockedProductsService.Object);

            // Act
            mockedView.Raise(v => v.ListingDiscountProducts += null, new HomeEventArgs(amount));

            // Assert
            CollectionAssert.AreEquivalent(products, mockedView.Object.Model.DiscountProducts);
        }
    }
}
