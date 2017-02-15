using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Products.ListProductsRooms
{
    public class ListProductsRoomsPresenter : Presenter<IListProductsRoomsView>
    {
        private readonly IRoomsService roomsService;

        public ListProductsRoomsPresenter(IListProductsRoomsView view,
            IRoomsService roomsService) : base(view)
        {
            if(roomsService == null)
            {
                throw new ArgumentNullException("Rooms service cannot be null");
            }

            this.roomsService = roomsService;
            this.View.ListingProductsRooms += OnListingProductsRooms;
        }

        private void OnListingProductsRooms(object sender, EventArgs e)
        {
            this.View.Model.Rooms = this.roomsService.GetRooms();
        }
    }
}
