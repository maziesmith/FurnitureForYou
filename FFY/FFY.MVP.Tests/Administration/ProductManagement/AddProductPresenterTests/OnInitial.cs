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
    public class OnInitial
    {
        [Test]
        public void ShouldCallGetRoomsMethodFromRoomsServices()
        {
            // Arrange
            var mockedView = new Mock<IAddProductView>();
            mockedView.Setup(v => v.Model).Returns(new AddProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            var mockedRoomsServices = new Mock<IRoomsService>();
            mockedRoomsServices.Setup(rs => rs.GetRooms()).Verifiable();
            var mockedImageUploader = new Mock<IImageUploader>();

            var addProductPresenter = new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new EventArgs());

            // Assert
            mockedRoomsServices.Verify(rs => rs.GetRooms(), Times.Once);
        }

        [Test]
        public void ShouldAssignToViewModelRooms_ReceivedFromGetRoomsMethod()
        {
            // Arrange
            var rooms = new List<Room>()
            {
                new Room() { Id = 1 },
                new Room() { Id = 2 }
            };

            var mockedView = new Mock<IAddProductView>();
            mockedView.Setup(v => v.Model).Returns(new AddProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            var mockedRoomsServices = new Mock<IRoomsService>();
            mockedRoomsServices.Setup(rs => rs.GetRooms())
                .Returns(rooms)
                .Verifiable();

            var mockedImageUploader = new Mock<IImageUploader>();

            var addProductPresenter = new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new EventArgs());

            // Assert
            CollectionAssert.AreEquivalent(rooms, mockedView.Object.Model.Rooms);
        }

        [Test]
        public void ShouldCallGetCategoriesMethodFromCategoriesServices()
        {
            // Arrange
            var mockedView = new Mock<IAddProductView>();
            mockedView.Setup(v => v.Model).Returns(new AddProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
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
            mockedView.Raise(v => v.Initial += null, new EventArgs());

            // Assert
            mockedCategoriesServices.Verify(cs => cs.GetCategories(), Times.Once);
        }

        [Test]
        public void ShouldAssignToViewModelCategories_ReceivedFromGetCategories()
        {
            // Arrange
            var categories = new List<Category>()
            {
                new Category() { Id = 3 },
                new Category () { Id = 4 }
            };

            var mockedView = new Mock<IAddProductView>();
            mockedView.Setup(v => v.Model).Returns(new AddProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            mockedCategoriesServices.Setup(cs => cs.GetCategories())
                .Returns(categories)
                .Verifiable();
            var mockedRoomsServices = new Mock<IRoomsService>();

            var mockedImageUploader = new Mock<IImageUploader>();

            var addProductPresenter = new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new EventArgs());

            // Assert
            CollectionAssert.AreEquivalent(categories, mockedView.Object.Model.Categories);
        }
    }
}
