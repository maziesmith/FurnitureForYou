using FFY.MVP.Furniture.Products;
using System;
using System.Linq;
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
        public event EventHandler<QueryEventArgs> BuildingQuery;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ListingProducts?.Invoke(this, new ProductsEventArgs(DefaultProductsPath, null, null, null, false, DefaultFrom, DefaultTo));
                this.ProductList.DataSource = this.Model.Products;
                this.ProductList.DataBind();
            }
        }

        protected void ProductListPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.Filter();
            this.ProductList.PageIndex = e.NewPageIndex;
            this.ProductList.DataBind();
        }

        protected void SearchButtonClick(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void Filter()
        {
            this.ListingProducts?.Invoke(this, new ProductsEventArgs(DefaultProductsPath, null, null, this.SearchBox.Text, false, DefaultFrom, DefaultTo));
            this.ProductList.DataSource = this.Model.Products.ToList();
            this.ProductList.DataBind();
        }
    }
}