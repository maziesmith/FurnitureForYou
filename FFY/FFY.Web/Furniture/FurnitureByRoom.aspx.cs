using FFY.MVP.Furniture.FurnitureByRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Furniture
{
    [PresenterBinding(typeof(FurnitureByRoomPresenter))]
    public partial class FurnitureByRoom : MvpPage<FurnitureByRoomViewModel>, IFurnitureByRoomView
    {
        public event EventHandler<FurnitureByRoomEventArgs> ListingFurnitureByRoom;

        protected void Page_Load(object sender, EventArgs e)
        {
            var roomParameter = this.Page.RouteData.Values["roomName"].ToString();

            if(string.IsNullOrEmpty(roomParameter))
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.ListingFurnitureByRoom?.Invoke(this, new FurnitureByRoomEventArgs(roomParameter));

            if(this.Model.Products.Count() == 0)
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            if (!Page.IsPostBack)
            {
                this.FurnitureProducts.DataSource = this.Model.Products;
                this.FurnitureProducts.DataBind();
            }
        }
    }
}