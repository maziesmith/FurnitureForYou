using FFY.MVP.Products.ListAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.ProductManagement
{
    [PresenterBinding(typeof(ListAllProductsPresenter))]
    public partial class _Default : MvpPage<ListAllProductsViewModel>, IListAllProductsView
    {
        public event EventHandler ListingAllProducts;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.ListingAllProducts?.Invoke(this, e);

            if (!Page.IsPostBack)
            {
                this.FurnitureProducts.DataSource = this.Model.Products;
                this.FurnitureProducts.DataBind();
            }
        }
    }
}