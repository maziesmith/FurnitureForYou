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

        public FurnitureDetailedPresenter(IFurnitureDetailedView view,
            IProductsService productsService) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            this.productsService = productsService;
            this.View.GettingProductById += OnGettingProductById;
        }

        private void OnGettingProductById(object sender, FurnitureDetailedEventArgs e)
        {
            this.View.Model.Product = this.productsService.GetProductById(e.Id);
        }
    }
}
