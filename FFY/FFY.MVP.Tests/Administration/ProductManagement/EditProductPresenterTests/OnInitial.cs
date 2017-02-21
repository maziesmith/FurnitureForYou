using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddProduct;
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
    public class OnInitial
    {

        [TestCase(1)]
        [TestCase(42)]
        public void ShouldCallGetProductByIdMethodFromProductsServices(int id)
        {
            // Arrange
            var mockedView = new Mock<IEditProductView>();
            mockedView.Setup(v => v.Model).Returns(new EditProductViewModel());

            var mockedProductsServices = new Mock<IProductsService>();
            mockedProductsServices.Setup(ps => ps.GetProductById(It.IsAny<int>()))
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
            mockedView.Raise(v => v.Initial += null, new GetProductEventArgs(id));

            // Assert
            mockedProductsServices.Verify(ps => ps.GetProductById(id), Times.Once);
        }

        [TestCase(2)]
        [TestCase(30)]
        public void ShouldAssignToViewModelProduct_ReceivedFromGetProductById(int id)
        {
            // Arrange
            var product = new Product() { Id = 1 };

            var mockedView = new Mock<IEditProductView>();
            mockedView.Setup(v => v.Model).Returns(new EditProductViewModel());

            var mockedProductsServices = new Mock<IProductsService>();
            mockedProductsServices.Setup(ps => ps.GetProductById(It.IsAny<int>()))
                .Returns(product)
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
            mockedView.Raise(v => v.Initial += null, new GetProductEventArgs(id));

            // Assert
            Assert.AreEqual(product, mockedView.Object.Model.Product);
        }

        [Test]
        public void ShouldCallGetRoomsMethodFromRoomsServices()
        {
            int id = 2;

            // Arrange
            var mockedView = new Mock<IEditProductView>();
            mockedView.Setup(v => v.Model).Returns(new EditProductViewModel());

            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            var mockedRoomsServices = new Mock<IRoomsService>();
            mockedRoomsServices.Setup(rs => rs.GetRooms()).Verifiable();
            var mockedImageUploader = new Mock<IImageUploader>();

            var editProductPresenter = new EditProductPresenter(mockedView.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetProductEventArgs(id));

            // Assert
            mockedRoomsServices.Verify(rs => rs.GetRooms(), Times.Once);
        }

        [Test]
        public void ShouldAssignToViewModelRooms_ReceivedFromGetRoomsMethod()
        {
            // Arrange
            int id = 3;
            var rooms = new List<Room>()
            {
                new Room() { Id = 1 },
                new Room() { Id = 2 }
            };

            var mockedView = new Mock<IEditProductView>();
            mockedView.Setup(v => v.Model).Returns(new EditProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            var mockedRoomsServices = new Mock<IRoomsService>();
            mockedRoomsServices.Setup(rs => rs.GetRooms())
                .Returns(rooms)
                .Verifiable();

            var mockedImageUploader = new Mock<IImageUploader>();

            var editProductPresenter = new EditProductPresenter(mockedView.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetProductEventArgs(id));

            // Assert
            CollectionAssert.AreEquivalent(rooms, mockedView.Object.Model.Rooms);
        }

        [Test]
        public void ShouldCallGetCategoriesMethodFromCategoriesServices()
        {
            // Arrange
            int id = 4;
            var mockedView = new Mock<IEditProductView>();
            mockedView.Setup(v => v.Model).Returns(new EditProductViewModel());

            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            mockedCategoriesServices.Setup(cs => cs.GetCategories()).Verifiable();
            var mockedRoomsServices = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();

            var editProductPresenter = new EditProductPresenter(mockedView.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetProductEventArgs(id));

            // Assert
            mockedCategoriesServices.Verify(cs => cs.GetCategories(), Times.Once);
        }

        [Test]
        public void ShouldAssignToViewModelCategories_ReceivedFromGetCategories()
        {
            // Arrange
            int id = 5;
            var categories = new List<Category>()
            {
                new Category() { Id = 3 },
                new Category () { Id = 4 }
            };

            var mockedView = new Mock<IEditProductView>();
            mockedView.Setup(v => v.Model).Returns(new EditProductViewModel());

            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            mockedCategoriesServices.Setup(cs => cs.GetCategories())
                .Returns(categories)
                .Verifiable();
            var mockedRoomsServices = new Mock<IRoomsService>();

            var mockedImageUploader = new Mock<IImageUploader>();

            var editProductPresenter = new EditProductPresenter(mockedView.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetProductEventArgs(id));

            // Assert
            CollectionAssert.AreEquivalent(categories, mockedView.Object.Model.Categories);
        }
    }
}
