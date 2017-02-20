using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ProductManagement.EditProduct
{
    public class EditProductPresenter : Presenter<IEditProductView>
    {
        private readonly IProductsService productsServices;
        private readonly ICategoriesService categoriesServices;
        private readonly IRoomsService roomsServices;
        private readonly IImageUploader imageUploader;

        private string imageFileName;

        public EditProductPresenter(IEditProductView view,
            IProductsService productsService,
            ICategoriesService categoriesService,
            IRoomsService roomsService,
            IImageUploader imageUploader) : base(view)
        {
            if (productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null.");
            }

            if (categoriesService == null)
            {
                throw new ArgumentNullException("Categories service cannot be null.");
            }

            if (roomsService == null)
            {
                throw new ArgumentNullException("Rooms service cannot be null.");
            }

            if (imageUploader == null)
            {
                throw new ArgumentNullException("Image uploader cannot be null.");
            }

            this.productsServices = productsService;
            this.categoriesServices = categoriesService;
            this.roomsServices = roomsService;
            this.imageUploader = imageUploader;
            this.View.Initial += OnInitial;
            this.View.EdittingProduct += OnEdittingProduct;
            this.View.UploadingImage += OnUploadingImage;
        }

        private void OnInitial(object sender, GetProductEventArgs e)
        {
            this.View.Model.Product = this.productsServices.GetProductById(e.Id);
            this.View.Model.Rooms = this.roomsServices.GetRooms();
            this.View.Model.Categories = this.categoriesServices.GetCategories();
        }

        private void OnEdittingProduct(object sender, EditProductEventArgs e)
        {
            e.Product.ImagePath = this.imageFileName;
            e.Product.DiscountedPrice = e.Product.Price - (e.Product.Price * (e.Product.DiscountPercentage / 100.0M));

            this.productsServices.EditProduct(e.Product);
        }

        private void OnUploadingImage(object sender, UploadImageEventArgs e)
        {
            this.imageFileName = this.imageUploader.Upload(e.Image, e.Server, e.ImageFileName, e.FolderName);
        }
    }
}
