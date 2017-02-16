using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.EditProduct
{
    public class EditProductPresenter : Presenter<IEditProductView>
    {
        private readonly IProductsService productsServices;
        private readonly ICategoriesService categoriesServices;
        private readonly IRoomsService roomsServices;

        public EditProductPresenter(IEditProductView view,
            IProductsService productsService,
            ICategoriesService categoriesServices,
            IRoomsService roomsServices) : base(view)
        {
            if (productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            if (categoriesServices == null)
            {
                throw new ArgumentNullException("Categories service cannot be null");
            }

            if (roomsServices == null)
            {
                throw new ArgumentNullException("Rooms service cannot be null");
            }

            this.productsServices = productsService;
            this.categoriesServices = categoriesServices;
            this.roomsServices = roomsServices;
            this.View.Initial += OnInitial;
            this.View.EdittingProduct += OnEdittingProduct;
        }

        private void OnInitial(object sender, GetProductEventArgs e)
        {
            this.View.Model.Product = this.productsServices.GetProductById(e.Id);
            this.View.Model.Rooms = this.roomsServices.GetRooms();
            this.View.Model.Categories = this.categoriesServices.GetCategories();
        }

        private void OnEdittingProduct(object sender, EditProductEventArgs e)
        {
            this.productsServices.EditProduct(e.Product);
        }
    }
}
