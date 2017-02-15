using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Products.ListProductsByRoom
{
    public class ListProductsByRoomPresenter : Presenter<IListProductsByRoomView>
    {
        private readonly IProductsService productsService;

        public ListProductsByRoomPresenter(IListProductsByRoomView view,
            IProductsService productsService) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            this.productsService = productsService;
            this.View.ListingProductsByRoom += OnListingProductsByRoom;
        }

        private void OnListingProductsByRoom(object sender, ListProductsByRoomEventArgs e)
        {
            this.View.Model.Products = this.productsService.GetProductsByRoomSpecialFiltered(e.RoomName);
        }
    }
}
