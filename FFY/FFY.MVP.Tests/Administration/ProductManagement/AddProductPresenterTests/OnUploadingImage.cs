using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddCategory;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Web;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.MVP.Administration.ProductManagement.AddProduct;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddProductPresenterTests
{
    [TestFixture]
    public class OnUploadingImage
    {
        // Dependent tests
        [TestCase("image-4", "products")]
        [TestCase("image-8", "users")]
        public void ShouldCallUploadMethodFromImageUploader(string imageFileName, string folderName)
        {
            // Arrange
            var fileUpload = new FileUpload();

            var mockedView = new Mock<IAddProductView>();
            mockedView.Setup(v => v.Model).Returns(new AddProductViewModel());

            var mockedProductFactory = new Mock<IProductFactory>();
            var mockedProductsServices = new Mock<IProductsService>();
            var mockedCategoriesServices = new Mock<ICategoriesService>();
            var mockedRoomsServices = new Mock<IRoomsService>();
            var mockedImageUploader = new Mock<IImageUploader>();
            mockedImageUploader.Setup(iu => iu.Upload(It.IsAny<FileUpload>(),
                It.IsAny<HttpServerUtility>(),
                It.IsAny<string>(),
                It.IsAny<string>())).Verifiable();

            var addProductPresenter = new AddProductPresenter(mockedView.Object,
                mockedProductFactory.Object,
                mockedProductsServices.Object,
                mockedCategoriesServices.Object,
                mockedRoomsServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.UploadingImage += null,
                new UploadImageEventArgs(fileUpload, It.IsAny<HttpServerUtility>(), imageFileName, folderName));

            // Assert
            mockedImageUploader.Verify(iu => 
                iu.Upload(fileUpload, It.IsAny<HttpServerUtility>(), imageFileName, folderName), Times.Once);
        }
    }
}
