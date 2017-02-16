using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Products.ListAllProducts
{
    public class ListAllProductsPresenter : Presenter<IListAllProductsView>
    {
        private readonly IProductsService productsService;

        public ListAllProductsPresenter(IListAllProductsView view,
            IProductsService productsService) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            this.productsService = productsService;
            this.View.ListingAllProducts += OnListingProductsByRoom;
        }

        private void OnListingProductsByRoom(object sender, EventArgs e)
        {
            this.View.Model.Products = this.productsService.GetProducts();
        }
    }
}
