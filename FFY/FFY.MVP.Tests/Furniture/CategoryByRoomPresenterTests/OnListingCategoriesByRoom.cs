using FFY.Models;
using FFY.MVP.Furniture.CategoryByRoom;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.CategoryByRoomPresenterTests
{
    [TestFixture]
    public class OnListingCategoriesByRoom
    {
        [TestCase("kitchen")]
        [TestCase("bedroom")]
        public void ShouldCallGetCategoriesByRoomSpecialFilteredWithExactEventArgument(string roomName)
        {
            // Arrange
            var mockedView = new Mock<ICategoryByRoomView>();
            mockedView.Setup(v => v.Model).Returns(new CategoryByRoomViewModel());

            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedCategoriesService.Setup(cs => 
                cs.GetCategoriesByRoomSpecialFiltered(It.IsAny<string>()))
                .Verifiable();

            var categoryByRoomPresenter = new CategoryByRoomPresenter(mockedView.Object,
                mockedCategoriesService.Object);

            // Act
            mockedView.Raise(v => v.ListingCategoriesByRoom += null, new CategoryByRoomEventArgs(roomName));

            // Assert
            mockedCategoriesService.Verify(cs => cs.GetCategoriesByRoomSpecialFiltered(roomName), Times.Once);
        }

        [Test]
        public void ShouldSetProperCategoriesToViewModel_ReceivedFromGetCategoriesByRoomSpecialFiltered()
        {
            // Arrange
            var categories = new List<Category>()
            {
                new Category { Name = "Category1" },
                new Category { Name = "Category2" }
            };

            var mockedView = new Mock<ICategoryByRoomView>();
            mockedView.Setup(v => v.Model).Returns(new CategoryByRoomViewModel());

            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedCategoriesService.Setup(cs =>
                cs.GetCategoriesByRoomSpecialFiltered(It.IsAny<string>()))
                .Returns(categories);

            var categoryByRoomPresenter = new CategoryByRoomPresenter(mockedView.Object,
                mockedCategoriesService.Object);

            // Act
            mockedView.Raise(v => v.ListingCategoriesByRoom += null, new CategoryByRoomEventArgs("room"));

            // Assert
            CollectionAssert.AreEquivalent(categories, mockedView.Object.Model.Categories);
        }
    }
}
