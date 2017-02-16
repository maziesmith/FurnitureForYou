using FFY.MVP.Products.ListAllProducts;
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
    [PresenterBinding(typeof(ListAllProductsPresenter))]
    public partial class FurnitureList : MvpPage<ListAllProductsViewModel>, IListAllProductsView
    {
        public event EventHandler<ListAllProductsEventArgs> ListingAllProducts;

        protected void Page_Load(object sender, EventArgs e)
        {
            var roomParameter = this.Page.RouteData.Values["roomName"].ToString();

            if(string.IsNullOrEmpty(roomParameter))
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.ListingAllProducts?.Invoke(this, new ListAllProductsEventArgs(roomParameter));

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