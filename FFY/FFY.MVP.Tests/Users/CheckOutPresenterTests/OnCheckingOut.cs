using FFY.Data.Factories;
using FFY.Models;
using FFY.MVP.Users.CheckOut;
using FFY.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Users.CheckOutPresenterTests
{
    [TestFixture]
    public class OnCheckingOut
    {
        private Mock<IOrdersFactory> mockedOrdersFactory;
        private Mock<IAddressesFactory> mockedAddressesFactory;
        private Mock<IAddressesService> mockedAddressesService;
        private Mock<IOrdersService> mockedOrdersService;
        private Mock<IUsersService> mockedUsersService;
        private Mock<IShoppingCartsService> mockedShoppingCartsService;
        private Mock<ICheckOutView> mockedView;
        private ShoppingCart shoppingCart;
        private Address address;
        private User user;
        private Order order;

        [SetUp]
        public void Init()
        {
            // Arrange
            var permanentProducts = new List<CartProduct>()
            {
                new CartProduct() { Id=1, Total=120 },
                new CartProduct() { Id=5, Total=200 },
            };
            this.shoppingCart = new ShoppingCart() { Total = 42, PermamentProducts = permanentProducts };
            this.address = new Address() { Id = 2 };
            this.user = new User();
            this.order = new Order();

            this.mockedView = new Mock<ICheckOutView>();
            mockedView.Setup(v => v.Model).Returns(new CheckOutViewModel());

            this.mockedShoppingCartsService = new Mock<IShoppingCartsService>();
            mockedShoppingCartsService.Setup(scs => scs.GetCart(It.IsAny<string>()))
                .Returns(shoppingCart)
                .Verifiable();

            this.mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(us => us.GetUserById(It.IsAny<string>()))
                .Returns(user)
                .Verifiable();

            this.mockedOrdersService = new Mock<IOrdersService>();
            mockedOrdersService.Setup(os => os.AddOrder(It.IsAny<Order>())).Verifiable();

            this.mockedAddressesService = new Mock<IAddressesService>();
            mockedAddressesService.Setup(ads => ads.AddAddress(It.IsAny<Address>())).Verifiable();

            this.mockedAddressesFactory = new Mock<IAddressesFactory>();
            mockedAddressesFactory.Setup(af => af.CreateAddress(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(address)
                .Verifiable();

            this.mockedOrdersFactory = new Mock<IOrdersFactory>();
            mockedOrdersFactory.Setup(of => of.CreateOrder(It.IsAny<string>(),
              It.IsAny<User>(),
              It.IsAny<DateTime>(),
              It.IsAny<decimal>(),
              It.IsAny<int>(),
              It.IsAny<Address>(),
              It.IsAny<string>(),
              It.IsAny<OrderPaymentStatusType>(),
              It.IsAny<OrderStatusType>()))
              .Returns(order)
              .Verifiable();

            var checkOutPresenter = new CheckOutPresenter(this.mockedView.Object,
                this.mockedShoppingCartsService.Object,
                this.mockedUsersService.Object,
                this.mockedOrdersService.Object,
                this.mockedAddressesService.Object,
                this.mockedAddressesFactory.Object,
                this.mockedOrdersFactory.Object);
        }

        [TestCase("123", "Street1", "City1", "Country1", "12345", OrderPaymentStatusType.Payed, OrderStatusType.Sent)]
        [TestCase("145", "Street2", "City2", "Country2", "98576", OrderPaymentStatusType.PaymentOnDelivery, OrderStatusType.Processing)]
        public void ShouldCallGetCartMethodFromShoppingCartsService(string userId,
            string street,
            string city,
            string country,
            string phoneNumber,
            OrderPaymentStatusType orderPaymentStatusType,
            OrderStatusType orderStatusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 4, 6);

            // Act
            this.mockedView.Raise(v => v.CheckingOut += null, new CheckOutEventArgs(userId,
                street,
                city,
                country,
                phoneNumber,
                sendOn,
                orderPaymentStatusType,
                orderStatusType));

            // Assert
            this.mockedShoppingCartsService.Verify(scs => scs.GetCart(userId), Times.Once);
        }

        [TestCase("123", "Street1", "City1", "Country1", "12345", OrderPaymentStatusType.Payed, OrderStatusType.Sent)]
        [TestCase("145", "Street2", "City2", "Country2", "98576", OrderPaymentStatusType.PaymentOnDelivery, OrderStatusType.Processing)]
        public void ShouldCallCreateAddressMethodFromAddressesFactory(string userId,
            string street,
            string city,
            string country,
            string phoneNumber,
            OrderPaymentStatusType orderPaymentStatusType,
            OrderStatusType orderStatusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 4, 6);

            // Act
            this.mockedView.Raise(v => v.CheckingOut += null, new CheckOutEventArgs(userId,
                street,
                city,
                country,
                phoneNumber,
                sendOn,
                orderPaymentStatusType,
                orderStatusType));

            // Assert
            this.mockedAddressesFactory.Verify(scs => 
                scs.CreateAddress(street, city, country), Times.Once);
        }

        [TestCase("123", "Street1", "City1", "Country1", "12345", OrderPaymentStatusType.Payed, OrderStatusType.Sent)]
        [TestCase("145", "Street2", "City2", "Country2", "98576", OrderPaymentStatusType.PaymentOnDelivery, OrderStatusType.Processing)]
        public void ShouldCallGetUserByIdMethodFromUsersService(string userId,
            string street,
            string city,
            string country,
            string phoneNumber,
            OrderPaymentStatusType orderPaymentStatusType,
            OrderStatusType orderStatusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 4, 6);

            // Act
            this.mockedView.Raise(v => v.CheckingOut += null, new CheckOutEventArgs(userId,
                street,
                city,
                country,
                phoneNumber,
                sendOn,
                orderPaymentStatusType,
                orderStatusType));

            // Assert
            this.mockedUsersService.Verify(us =>
                us.GetUserById(userId), Times.Once);
        }

        [TestCase("123", "Street1", "City1", "Country1", "12345", OrderPaymentStatusType.Payed, OrderStatusType.Sent)]
        [TestCase("145", "Street2", "City2", "Country2", "98576", OrderPaymentStatusType.PaymentOnDelivery, OrderStatusType.Processing)]
        public void ShouldCallAddAddressMethodFromAddressesService(string userId,
            string street,
            string city,
            string country,
            string phoneNumber,
            OrderPaymentStatusType orderPaymentStatusType,
            OrderStatusType orderStatusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 4, 6);

            // Act
            this.mockedView.Raise(v => v.CheckingOut += null, new CheckOutEventArgs(userId,
                street,
                city,
                country,
                phoneNumber,
                sendOn,
                orderPaymentStatusType,
                orderStatusType));

            // Assert
            this.mockedAddressesService.Verify(ads =>
                ads.AddAddress(this.address), Times.Once);
        }

        [TestCase("123", "Street1", "City1", "Country1", "12345", OrderPaymentStatusType.Payed, OrderStatusType.Sent)]
        [TestCase("145", "Street2", "City2", "Country2", "98576", OrderPaymentStatusType.PaymentOnDelivery, OrderStatusType.Processing)]
        public void ShouldCallCreateOrderMethodFromOrdersFactory(string userId,
            string street,
            string city,
            string country,
            string phoneNumber,
            OrderPaymentStatusType orderPaymentStatusType,
            OrderStatusType orderStatusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 4, 6);

            // Act
            this.mockedView.Raise(v => v.CheckingOut += null, new CheckOutEventArgs(userId,
                street,
                city,
                country,
                phoneNumber,
                sendOn,
                orderPaymentStatusType,
                orderStatusType));

            // Assert
            this.mockedOrdersFactory.Verify(of => of.CreateOrder(userId,
                this.user,
                sendOn,
                this.shoppingCart.Total,
                this.address.Id,
                this.address,
                phoneNumber,
                orderPaymentStatusType,
                orderStatusType), Times.Once);
        }

        [TestCase("123", "Street1", "City1", "Country1", "12345", OrderPaymentStatusType.Payed, OrderStatusType.Sent)]
        [TestCase("145", "Street2", "City2", "Country2", "98576", OrderPaymentStatusType.PaymentOnDelivery, OrderStatusType.Processing)]
        public void ShouldSetOrderProductsFromShoppingCartPermanentProducts(string userId,
            string street,
            string city,
            string country,
            string phoneNumber,
            OrderPaymentStatusType orderPaymentStatusType,
            OrderStatusType orderStatusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 4, 6);

            // Act
            this.mockedView.Raise(v => v.CheckingOut += null, new CheckOutEventArgs(userId,
                street,
                city,
                country,
                phoneNumber,
                sendOn,
                orderPaymentStatusType,
                orderStatusType));

            // Assert
            CollectionAssert.AreEquivalent(this.shoppingCart.PermamentProducts, this.order.Products);
        }

        [TestCase("123", "Street1", "City1", "Country1", "12345", OrderPaymentStatusType.Payed, OrderStatusType.Sent)]
        [TestCase("145", "Street2", "City2", "Country2", "98576", OrderPaymentStatusType.PaymentOnDelivery, OrderStatusType.Processing)]
        public void ShouldAddOrderMethodFromOrdersService(string userId,
            string street,
            string city,
            string country,
            string phoneNumber,
            OrderPaymentStatusType orderPaymentStatusType,
            OrderStatusType orderStatusType)
        {
            // Arrange
            var sendOn = new DateTime(2017, 4, 6);

            // Act
            this.mockedView.Raise(v => v.CheckingOut += null, new CheckOutEventArgs(userId,
                street,
                city,
                country,
                phoneNumber,
                sendOn,
                orderPaymentStatusType,
                orderStatusType));

            // Assert
            this.mockedOrdersService.Verify(os => os.AddOrder(order), Times.Once);
        }
    }
}
