using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddCategory;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.ProductManagement.AddCategoryPresenterTests
{
    [TestFixture]
    public class OnAddingCategory
    {
        [TestCase("beds")]
        [TestCase("tables")]
        public void ShouldCallCreateCategoryMethodFromCategoryFactory(string name)
        {
            // Arrange
            var category = new Category();
            var mockedView = new Mock<IAddCategoryView>();
            mockedView.Setup(v => v.Model).Returns(new AddCategoryViewModel());

            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            mockedCategoryFactory.Setup(cf => cf.CreateCategory(It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(category)
                .Verifiable();

            var mockedCategoriesServices = new Mock<ICategoriesService>();
            var mockedImageUploader = new Mock<IImageUploader>();
            
            var addCategoryPresenter = new AddCategoryPresenter(mockedView.Object,
                mockedCategoryFactory.Object,
                mockedCategoriesServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.AddingCategory += null,
                new AddCategoryEventArgs(name));

            // Assert
            mockedCategoryFactory.Verify(cf =>
            cf.CreateCategory(name, It.IsAny<string>()), Times.Once);
        }

        [TestCase("beds")]
        [TestCase("tables")]
        public void ShouldCallAddCategoryMethodFromCategoryServices(string name)
        {
            // Arrange
            var category = new Category();
            var mockedView = new Mock<IAddCategoryView>();
            mockedView.Setup(v => v.Model).Returns(new AddCategoryViewModel());

            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            mockedCategoryFactory.Setup(cf => cf.CreateCategory(It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(category)
                .Verifiable();

            var mockedCategoriesServices = new Mock<ICategoriesService>();
            mockedCategoriesServices.Setup(cs =>
                cs.AddCategory(It.IsAny<Category>()))
                .Verifiable();

            var mockedImageUploader = new Mock<IImageUploader>();

            var addCategoryPresenter = new AddCategoryPresenter(mockedView.Object,
                mockedCategoryFactory.Object,
                mockedCategoriesServices.Object,
                mockedImageUploader.Object);

            // Act
            mockedView.Raise(v => v.AddingCategory += null,
                new AddCategoryEventArgs(name));

            // Assert
            mockedCategoriesServices.Verify(cs => cs.AddCategory(category), Times.Once);
        }
    }
}
