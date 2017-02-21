using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.ListProductsRooms
{
    public class FurnitureRoomsPresenter : Presenter<IFurnitureRoomsView>
    {
        private readonly IRoomsService roomsService;

        public FurnitureRoomsPresenter(IFurnitureRoomsView view,
            IRoomsService roomsService) : base(view)
        {
            if(roomsService == null)
            {
                throw new ArgumentNullException("Rooms service cannot be null.");
            }

            this.roomsService = roomsService;
            this.View.ListingFurnitureRooms += OnListingProductsRooms;
        }

        private void OnListingProductsRooms(object sender, EventArgs e)
        {
            this.View.Model.Rooms = this.roomsService.GetRooms();
        }
    }
}
