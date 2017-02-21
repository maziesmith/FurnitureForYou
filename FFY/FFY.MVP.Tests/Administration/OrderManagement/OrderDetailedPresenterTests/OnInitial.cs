using FFY.Models;
using FFY.MVP.OrderManagement.OrderDetailed;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Administration.OrderManagement.OrderDetailedPresenterTests
{
    [TestFixture]
    public class OnInitial
    {
        [TestCase(4)]
        [TestCase(20)]
        public void ShouldCallGetOrderByIdMethodFromOrdersService(int id)
        {
            // Arrange
            var mockedView = new Mock<IOrderDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new OrderDetailedViewModel());

            var mockedOrdersService = new Mock<IOrdersService>();
            mockedOrdersService.Setup(os => os.GetOrderById(It.IsAny<int>()))
                    .Verifiable();

            var orderDetailedPresenter = new OrderDetailedPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetOrderByIdEventArgs(id));

            // Assert
            mockedOrdersService.Verify(os => os.GetOrderById(id), Times.Once);
        }

        [TestCase(4)]
        [TestCase(20)]
        public void ShouldAssignToModelViewOrder_ReceivedFromCallGetOrderByIdMethodFromOrdersService(int id)
        {
            // Arrange
            var order = new Order() { Id = id };
            var mockedView = new Mock<IOrderDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new OrderDetailedViewModel());

            var mockedOrdersService = new Mock<IOrdersService>();
            mockedOrdersService.Setup(os => os.GetOrderById(It.IsAny<int>()))
                .Returns(order)
                .Verifiable();

            var orderDetailedPresenter = new OrderDetailedPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Act
            mockedView.Raise(v => v.Initial += null, new GetOrderByIdEventArgs(id));

            // Assert
            Assert.AreEqual(order, mockedView.Object.Model.Order);
        }
    }
}
