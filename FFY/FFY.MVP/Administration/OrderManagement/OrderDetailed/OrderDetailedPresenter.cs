using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.OrderManagement.OrderDetailed
{
    public class OrderDetailedPresenter : Presenter<IOrderDetailedView>
    {
        private IOrdersService ordersService;

        public OrderDetailedPresenter(IOrderDetailedView view,
            IOrdersService ordersService) : base(view)
        {
            if(ordersService == null)
            {
                throw new ArgumentNullException("Orders service cannot be null.");
            }

            this.ordersService = ordersService;
            this.View.Initial += OnInitial;
            this.View.EdittingOrderStatus += OnEdittingOrderStatus;
        }

        private void OnInitial(object sender, GetOrderByIdEventArgs e)
        {
            this.View.Model.Order = this.ordersService.GetOrderById(e.Id);
        }

        private void OnEdittingOrderStatus(object sender, EditOrderStatusEventArgs e)
        {
            this.ordersService.ChangeOrderStatus(e.Order, e.StatusType, e.PaymentStatusType);
        }
    }
}
