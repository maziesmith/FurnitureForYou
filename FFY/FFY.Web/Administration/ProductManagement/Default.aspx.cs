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
        private readonly string AllProductsPath = "/furniture/all";
        public event EventHandler<ProductsEventArgs> ListingProducts;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.ListingProducts?.Invoke(this, new ProductsEventArgs(AllProductsPath, null, null));

            if (!Page.IsPostBack)
            {
                this.FurnitureProducts.DataSource = this.Model.Products;
                this.FurnitureProducts.DataBind();
            }
        }
    }
}