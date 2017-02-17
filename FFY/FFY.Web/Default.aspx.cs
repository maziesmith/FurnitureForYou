using FFY.MVP.Home;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class _Default : MvpPage<HomeViewModel>, IHomeView
    {
        private const int Amount = 3;
        public event EventHandler<HomeEventArgs> ListingDiscountProducts;
        public event EventHandler<HomeEventArgs> ListingLatestProducts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListingLatestProducts?.Invoke(this, new HomeEventArgs(Amount));
            this.LatestProducts.DataSource = this.Model.LatestProducts;
            this.LatestProducts.DataBind();


            this.ListingDiscountProducts?.Invoke(this, new HomeEventArgs(Amount));
            this.DiscountProducts.DataSource = this.Model.DiscountProducts;
            this.DiscountProducts.DataBind();
        }
    }
}