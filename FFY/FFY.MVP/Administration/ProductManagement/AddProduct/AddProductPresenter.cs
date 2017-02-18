using FFY.Data.Factories;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ProductManagement.AddProduct
{
    public class AddProductPresenter : Presenter<IAddProductView>
    {

        private readonly IProductsService productsServices;
        private readonly ICategoriesService categoriesServices;
        private readonly IRoomsService roomsServices;
        private readonly IProductFactory productFactory;

        public AddProductPresenter(IAddProductView view,
            IProductFactory productFactory, 
            IProductsService productsService,
            ICategoriesService categoriesServices,
            IRoomsService roomsServices) : base(view)
        {
            if(productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null.");
            }

            if (categoriesServices == null)
            {
                throw new ArgumentNullException("Categories service cannot be null.");
            }

            if (roomsServices == null)
            {
                throw new ArgumentNullException("Rooms service cannot be null.");
            }

            if(productFactory == null)
            {
                throw new ArgumentNullException("Product factory cannot be null.");
            }

            this.productsServices = productsService;
            this.categoriesServices = categoriesServices;
            this.roomsServices = roomsServices;
            this.productFactory = productFactory;
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
            var product = this.productFactory.CreateProduct(e.Name,
                e.Price,
                e.DiscountPercentage,
                e.HasDiscount,
                e.Description,
                e.CategoryId,
                e.Category,
                e.RoomId,
                e.Room,
                e.ImagePath);

            this.productsServices.AddProduct(product);
        }

        private void OnUploadingImage(object sender, UploadImageEventArgs e)
        {
            if (e.Image.HasFile)
            {
                if (e.Image.PostedFile.ContentType == "image/png" || e.Image.PostedFile.ContentType == "image/jpeg")
                {
                    string subPath = @"~\Images\products";

                    bool exists = Directory.Exists(e.Server.MapPath(subPath));

                    if (!exists)
                    {
                        Directory.CreateDirectory(e.Server.MapPath(subPath));
                    }

                    // Not testable, but if we want to assure uniqueness of a file name we have to use some random factor
                    e.ImageFileName = (DateTime.Now - new DateTime(1970, 1, 1)).TotalMinutes.ToString() + Path.GetFileName(e.Image.FileName);

                    e.Image.SaveAs(Server.MapPath(subPath + @"\" + e.ImageFileName));
                }
            }
        }
    }
}
