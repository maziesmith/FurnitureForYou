using FFY.Services.Contracts;
using FFY.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.Products
{
    public class ProductsPresenter : Presenter<IProductsView>
    {
        private readonly IProductsService productsService;
        private readonly IHandler productsHandler;

        public ProductsPresenter(IProductsView view,
            IHandler productsHandler,
            IProductsService productsService) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null.");
            }

            if (productsHandler == null)
            {
                throw new ArgumentNullException("Products handler cannot be null.");
            }

            this.productsService = productsService;
            this.productsHandler = productsHandler;
            this.View.ListingProducts += OnListingProducts;
        }

        private void OnListingProducts(object sender, ProductsEventArgs e)
        {
            this.View.Model.Products = this.productsHandler.HandleProducts(e.Path, e.Room, e.Category, this.productsService);
        }
    }
}
