using FFY.MVP.Products.ListProductsRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web
{
    [PresenterBinding(typeof(ListProductsRoomsPresenter))]
    public partial class Furniture : MvpPage<ListProductsRoomsViewModel>, IListProductsRoomsView
    {
        public event EventHandler ListingProductsRooms;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListingProductsRooms?.Invoke(this, e);

            if (!Page.IsPostBack)
            {
                this.FurnitureRooms.DataSource = this.Model.Rooms;
                this.FurnitureRooms.DataBind();
            }
        }
    }
}