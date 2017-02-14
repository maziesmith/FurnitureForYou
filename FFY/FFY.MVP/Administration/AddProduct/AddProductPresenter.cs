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

        private readonly IProductsService productsServices;
        private readonly ICategoriesService categoriesServices;

        public AddProductPresenter(IAddProductView view, 
            IProductsService productsService,
            ICategoriesService categoriesServices) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            if (categoriesServices == null)
            {
                throw new ArgumentNullException("Categories service cannot be null");
            }

            this.productsServices = productsService;
            this.categoriesServices = categoriesServices;
            this.View.Initial += OnInitial;
            this.View.AddingProduct += OnAddingProduct;
        }

        private void OnInitial(object sender, EventArgs e)
        {
            this.View.Model.Rooms = this.productsServices.GetRooms();
            this.View.Model.Categories = this.categoriesServices.GetCategories();
        }

        private void OnAddingProduct(object sender, AddProductEventArgs e)
        {
            this.productsServices.AddProduct(e.Product);
        }
    }
}
