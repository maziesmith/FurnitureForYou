using FFY.MVP.Furniture.Products;
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
    [PresenterBinding(typeof(ProductsPresenter))]
    public partial class _Default : MvpPage<ProductsViewModel>, IProductsView
    {
        private const string DefaultProductsPath = "/furniture/all";
        private const int DefaultFrom = 0;
        private const int DefaultTo = 100000;

        public event EventHandler<ProductsEventArgs> ListingProducts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListingProducts?.Invoke(this, new ProductsEventArgs(DefaultProductsPath, null, null, null, false, DefaultFrom, DefaultTo));

            if (!Page.IsPostBack)
            {
                this.FurnitureProducts.DataSource = this.Model.Products;
                this.FurnitureProducts.DataBind();
            }
        }
    }
}