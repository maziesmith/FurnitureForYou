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
    public class OnAddingToShoppingCart
    {
        [TestCase(15, "4214")]
        [TestCase(6, "13456")]
        public void ShouldCallAddMethodOfShoppingCartsServiceWithExactParameters(int quantity, string id)
        {
            // Arrange
            var mockedView = new Mock<IFurnitureDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new FurnitureDetailedViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs => scs.Add(It.IsAny<int>(),
                It.IsAny<Product>(),
                It.IsAny<string>()))
                .Verifiable();

            var mockedProductsService = new Mock<IProductsService>();

            var furnitureDetailedPresenter = new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v => v.AddingToShoppingCart += null,
                new AddToShoppingCartEventArgs(quantity, id));

            // Assert
            mockedShoppingCartsService.Verify(scs =>
                scs.Add(quantity, mockedView.Object.Model.Product, id), Times.Once);
        }

        [TestCase(15, "4214")]
        [TestCase(6, "13456")]
        public void ShouldAddCartProductCountToViewModelCartCount(int quantity, string id)
        {
            // Arrange
            var mockedView = new Mock<IFurnitureDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new FurnitureDetailedViewModel());

            var mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs => scs.CartProductsCount(id))
                .Returns(quantity);

            var mockedProductsService = new Mock<IProductsService>();

            var furnitureDetailedPresenter = new FurnitureDetailedPresenter(mockedView.Object,
                mockedProductsService.Object,
                mockedShoppingCartsService.Object);

            // Act
            mockedView.Raise(v => v.AddingToShoppingCart += null,
                new AddToShoppingCartEventArgs(quantity, id));

            // Assert
            Assert.AreEqual(quantity, mockedView.Object.Model.CartCount);
        }
    }
}
