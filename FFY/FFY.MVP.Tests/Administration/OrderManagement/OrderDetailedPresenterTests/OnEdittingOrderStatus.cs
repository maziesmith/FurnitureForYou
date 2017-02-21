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
    public class OnEdittingOrderStatus
    {
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        public void ShouldCallGetOrderByIdMethodFromOrdersService(int statusType, int paymentStatusType)
        {
            // Arrange
            var order = new Order();

            var mockedView = new Mock<IOrderDetailedView>();
            mockedView.Setup(v => v.Model).Returns(new OrderDetailedViewModel());

            var mockedOrdersService = new Mock<IOrdersService>();
            mockedOrdersService.Setup(os => os.ChangeOrderStatus(It.IsAny<Order>(),
                It.IsAny<int>(),
                It.IsAny<int>()))
                .Verifiable();

            var orderDetailedPresenter = new OrderDetailedPresenter(mockedView.Object,
                mockedOrdersService.Object);

            // Act
            mockedView.Raise(v => v.EdittingOrderStatus += null, 
                new EditOrderStatusEventArgs(order, statusType, paymentStatusType));

            // Assert
            mockedOrdersService.Verify(os => 
                os.ChangeOrderStatus(order, statusType, paymentStatusType), Times.Once);
        }
    }
}
