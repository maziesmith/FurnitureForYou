using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Services.CategoriesServiceTests
{
    [TestFixture]
    public class GetCategories
    {
        //[Test]
        //public void ShouldCallGetAllMethodOfCategoryRepositoryOnce()
        //{
        //    // Arrange
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var mockedGenericRepository = new Mock<IGenericRepository<Category>>();
        //    mockedGenericRepository.Setup(gr => gr.GetAll()).Verifiable();

        //    var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

        //    // Act
        //    categoriesService.GetCategories();

        //    // Assert
        //    mockedGenericRepository.Verify(gr => gr.GetAll(), Times.Once);
        //}

        //[Test]
        //public void ShouldReturnAllCategoriesFromCategoryRepository()
        //{
        //    // Arrange
        //    var mockedCategory = new Mock<Category>();
        //    var mockedCategories = new List<Category>
        //    {
        //        mockedCategory.Object,
        //        mockedCategory.Object
        //    };
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var mockedGenericRepository = new Mock<IGenericRepository<Category>>();
        //    mockedGenericRepository.Setup(gr => gr.GetAll()).Returns(mockedCategories);

        //    var categoriesService = new CategoriesService(mockedUnitOfWork.Object, mockedGenericRepository.Object);

        //    // Act
        //    var result = categoriesService.GetCategories();

        //    // Assert
        //    Assert.AreSame(mockedCategories, result);
        //}
    }
}
