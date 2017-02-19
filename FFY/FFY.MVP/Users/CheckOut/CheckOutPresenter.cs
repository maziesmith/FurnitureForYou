using FFY.Data.Factories;
using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Users.CheckOut
{
    public class CheckOutPresenter : Presenter<ICheckOutView>
    {
        private readonly IShoppingCartsService shoppingCartsService;
        private readonly IUsersService usersService;
        private readonly IOrdersService ordersService;
        private readonly IAddressesService addressesService;
        private readonly IAddressesFactory addressesFactory;
        private readonly IOrdersFactory ordersFactory;

        public CheckOutPresenter(ICheckOutView view,
            IShoppingCartsService shoppingCartsService,
            IUsersService usersService,
            IOrdersService ordersService,
            IAddressesService addressesService,
            IAddressesFactory addressesFactory,
            IOrdersFactory ordersFactory) : base(view)
        {
            if(shoppingCartsService == null)
            {
                throw new ArgumentNullException("Shopping carts service cannot be null.");
            }

            if (usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            if (ordersService == null)
            {
                throw new ArgumentNullException("Orders service cannot be null.");
            }

            if (addressesService == null)
            {
                throw new ArgumentNullException("Addresses service cannot be null.");
            }

            if (addressesFactory == null)
            {
                throw new ArgumentNullException("Addresses factory cannot be null.");
            }

            if (ordersFactory == null)
            {
                throw new ArgumentNullException("Orders factory cannot be null.");
            }

            this.shoppingCartsService = shoppingCartsService;
            this.usersService = usersService;
            this.ordersService = ordersService;
            this.addressesService = addressesService;
            this.addressesFactory = addressesFactory;
            this.ordersFactory = ordersFactory;
            this.View.CheckingOut += OnCheckingOut;
            this.View.CartClearing += OnCartClearing;
        }

        private void OnCheckingOut(object sender, CheckOutEventArgs e)
        {
            var shoppingCart = this.shoppingCartsService.GetCart(e.UserId);
            var address = this.addressesFactory.CreateAddress(e.Street, e.City, e.Country);
            var user = this.usersService.GetUserById(e.UserId);

            this.addressesService.AddAddress(address);

            var order = this.ordersFactory.CreateOrder(e.UserId,
                user,
                e.SendOn,
                shoppingCart.Total,
                address.Id,
                address,
                e.PhoneNumber,
                e.OrderPaymentStatusType,
                e.OrderStatusType);

            order.Products = shoppingCart.PermamentProducts;

            this.ordersService.AddOrder(order);
        }

        private void OnCartClearing(object sender, CartClearEventArgs e)
        {
            var shoppingCart = this.shoppingCartsService.GetCart(e.CartId);

            this.shoppingCartsService.Clear(shoppingCart);
        }
    }
}
