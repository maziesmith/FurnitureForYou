using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Home
{
    public class HomePresenter : Presenter<IHomeView>
    {
        private readonly IProductsService productsService;

        public HomePresenter(IHomeView view,
            IProductsService productsService) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null.");
            }

            this.productsService = productsService;
            this.View.ListingDiscountProducts += OnListingDiscountProducts;
            this.View.ListingLatestProducts += OnListingLatestProducts;
        }

        private void OnListingDiscountProducts(object sender, HomeEventArgs e)
        {
            this.View.Model.DiscountProducts = this.productsService.GetDiscountProducts(e.Amount).Reverse();
        }

        private void OnListingLatestProducts(object sender, HomeEventArgs e)
        {
            this.View.Model.LatestProducts = this.productsService.GetLatestProducts(e.Amount);
        }
    }
}
