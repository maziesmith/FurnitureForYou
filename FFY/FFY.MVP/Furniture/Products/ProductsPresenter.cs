using FFY.MVP.Furniture.Utilities;
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
        private readonly IQueryBuilder queryBuilder;

        public ProductsPresenter(IProductsView view,
            IHandler productsHandler,
            IProductsService productsService,
            IQueryBuilder queryBuilder) : base(view)
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
            this.queryBuilder = queryBuilder;
            this.View.ListingProducts += OnListingProducts;
            this.View.BuildingQuery += OnBuildingQuery;
        }

        private void OnListingProducts(object sender, ProductsEventArgs e)
        {
            this.View.Model.Products = 
                this.productsHandler.HandleProducts(this.productsService,
                    e.Path, 
                    e.Room, 
                    e.Category,
                    e.Search,
                    e.RangeProvided,
                    e.From,
                    e.To);
        }

        private void OnBuildingQuery(object sender, QueryEventArgs e)
        {
            this.View.Model.Query = this.queryBuilder.BuildProductSearchQuery(e.Path, e.Search, e.From, e.To);
        }
    }
}
