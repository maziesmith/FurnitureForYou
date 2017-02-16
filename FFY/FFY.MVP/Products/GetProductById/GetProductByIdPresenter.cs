using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Products.GetProductById
{
    public class GetProductByIdPresenter : Presenter<IGetProductByIdView>
    {
        private readonly IProductsService productsService;

        public GetProductByIdPresenter(IGetProductByIdView view,
            IProductsService productsService) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            this.productsService = productsService;
            this.View.GettingProductById += OnGettingProductById;
        }

        private void OnGettingProductById(object sender, GetProductByIdEventArgs e)
        {
            this.View.Model.Product = this.productsService.GetProductById(e.Id);
        }
    }
}
