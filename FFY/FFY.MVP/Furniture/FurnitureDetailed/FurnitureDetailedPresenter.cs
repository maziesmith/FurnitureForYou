using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.FurnitureDetailed
{
    public class FurnitureDetailedPresenter : Presenter<IFurnitureDetailedView>
    {
        private readonly IProductsService productsService;
        private readonly IShoppingCartsService shoppingCartsService;

        public FurnitureDetailedPresenter(IFurnitureDetailedView view,
            IProductsService productsService,
            IShoppingCartsService shoppingCartsService) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            if (shoppingCartsService == null)
            {
                throw new ArgumentNullException("Shopping Carts service cannot be null");
            }

            this.productsService = productsService;
            this.shoppingCartsService = shoppingCartsService;
            this.View.GettingProductById += OnGettingProductById;
            this.View.AddingToShoppingCart += OnAddingToShoppingCart;
        }

        private void OnGettingProductById(object sender, FurnitureDetailedEventArgs e)
        {
            this.View.Model.Product = this.productsService.GetProductById(e.Id);
        }

        private void OnAddingToShoppingCart(object sender, AddToShoppingCartEventArgs e)
        {
            this.shoppingCartsService.Add(e.Quantity, this.View.Model.Product, e.CartId);
            this.View.Model.CartCount = this.shoppingCartsService.CartProductsCount(e.CartId);
        }
    }
}
