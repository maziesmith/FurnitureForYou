using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.FurnitureByRoom
{
    public class FurnitureByRoomPresenter : Presenter<IFurnitureByRoomView>
    {
        private readonly IProductsService productsService;

        public FurnitureByRoomPresenter(IFurnitureByRoomView view,
            IProductsService productsService) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            this.productsService = productsService;
            this.View.ListingFurnitureByRoom += OnListingProductsByRoom;
        }

        private void OnListingProductsByRoom(object sender, FurnitureByRoomEventArgs e)
        {
            this.View.Model.Products = this.productsService.GetProductsByRoomSpecialFiltered(e.RoomName);
        }
    }
}
