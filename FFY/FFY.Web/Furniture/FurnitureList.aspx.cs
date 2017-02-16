using FFY.MVP.Products.ListProductsByRoom;
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
    [PresenterBinding(typeof(ListProductsByRoomPresenter))]
    public partial class FurnitureList : MvpPage<ListProductsByRoomViewModel>, IListProductsByRoomView
    {
        public event EventHandler<ListProductsByRoomEventArgs> ListingProductsByRoom;

        protected void Page_Load(object sender, EventArgs e)
        {
            var roomParameter = this.Page.RouteData.Values["roomName"].ToString();

            if(string.IsNullOrEmpty(roomParameter))
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.ListingProductsByRoom?.Invoke(this, new ListProductsByRoomEventArgs(roomParameter));

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