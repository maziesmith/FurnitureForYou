using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.OrderManagement.Orders
{
    public class OrdersPresenter : Presenter<IOrdersView>
    {
        private readonly IOrdersService ordersService;

        public OrdersPresenter(IOrdersView view,
            IOrdersService ordersService) : base(view)
        {
            if (ordersService == null)
            {
                throw new ArgumentNullException("Orders service cannot be null.");
            }

            this.ordersService = ordersService;
            this.View.ListingOrders += OnListingOrders;
        }

        private void OnListingOrders(object sender, EventArgs e)
        {
            this.View.Model.Orders = this.ordersService.GetOrders();
        }
    }
}
