using FFY.MVP.Furniture.ListProductsRooms;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Furniture
{
    [PresenterBinding(typeof(FurnitureRoomsPresenter))]
    public partial class _Default : MvpPage<FurnitureRoomsViewModel>, IFurnitureRoomsView
    {
        public event EventHandler ListingFurnitureRooms;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListingFurnitureRooms?.Invoke(this, e);

            if (!Page.IsPostBack)
            {
                this.FurnitureRooms.DataSource = this.Model.Rooms;
                this.FurnitureRooms.DataBind();
            }
        }
    }
}