using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.AddProduct
{
    public class AddProductPresenter : Presenter<IAddProductView>
    {

        private readonly IProductsService productServices;

        public AddProductPresenter(IAddProductView view, IProductsService productServices) : base(view)
        {
            if(productServices == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            this.productServices = productServices;
            this.View.Initial += OnInitial;
            this.View.AddingProduct += OnAddingProduct;
        }

        private void OnInitial(object sender, EventArgs e)
        {
            this.View.Model.Rooms = this.productServices.GetRooms();
            this.View.Model.Categories = this.productServices.GetCategories();
        }

        private void OnAddingProduct(object sender, AddProductEventArgs e)
        {
            this.productServices.AddProduct(e.Product);
        }
    }
}
