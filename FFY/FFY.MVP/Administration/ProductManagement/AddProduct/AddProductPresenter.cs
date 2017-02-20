using FFY.Data.Factories;
using FFY.MVP.Administration.ProductManagement.Utilities;
using FFY.Services.Contracts;
using System;
using WebFormsMvp;

namespace FFY.MVP.Administration.ProductManagement.AddProduct
{
    public class AddProductPresenter : Presenter<IAddProductView>
    {

        private readonly IProductsService productsServices;
        private readonly ICategoriesService categoriesServices;
        private readonly IRoomsService roomsServices;
        private readonly IProductFactory productFactory;
        private readonly IImageUploader imageUploader;

        private string imageFileName;

        public AddProductPresenter(IAddProductView view,
            IProductFactory productFactory, 
            IProductsService productsService,
            ICategoriesService categoriesService,
            IRoomsService roomsService,
            IImageUploader imageUploader) : base(view)
        {
            if(productsService == null)
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

            if(productFactory == null)
            {
                throw new ArgumentNullException("Product factory cannot be null.");
            }

            if (imageUploader == null)
            {
                throw new ArgumentNullException("Image uploader cannot be null.");
            }

            this.productsServices = productsService;
            this.categoriesServices = categoriesService;
            this.roomsServices = roomsService;
            this.productFactory = productFactory;
            this.imageUploader = imageUploader;
            this.View.Initial += OnInitial;
            this.View.AddingProduct += OnAddingProduct;
            this.View.UploadingImage += OnUploadingImage;
        }

        private void OnInitial(object sender, EventArgs e)
        {
            this.View.Model.Rooms = this.roomsServices.GetRooms();
            this.View.Model.Categories = this.categoriesServices.GetCategories();
        }

        private void OnAddingProduct(object sender, AddProductEventArgs e)
        {
            var discountedPrice = e.Price - (e.Price * (e.DiscountPercentage / 100.0M));

            var product = this.productFactory.CreateProduct(e.Name,
                e.Price,
                discountedPrice,
                e.DiscountPercentage,
                e.HasDiscount,
                e.Description,
                e.CategoryId,
                e.Category,
                e.RoomId,
                e.Room,
                this.imageFileName);

            this.productsServices.AddProduct(product);
        }

        private void OnUploadingImage(object sender, UploadImageEventArgs e)
        {
            this.imageFileName = this.imageUploader.Upload(e.Image, e.Server, e.ImageFileName, e.FolderName);
        }
    }
}
