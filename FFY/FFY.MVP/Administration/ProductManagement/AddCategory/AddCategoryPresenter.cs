using FFY.Data.Factories;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;
using FFY.MVP.Administration.ProductManagement.Utilities;

namespace FFY.MVP.Administration.ProductManagement.AddCategory
{
    public class AddCategoryPresenter : Presenter<IAddCategoryView>
    {
        private readonly ICategoriesService categoriesServices;
        private readonly ICategoryFactory categoryFactory;
        private readonly IImageUploader imageUploader;

        private string imageFileName;

        public AddCategoryPresenter(IAddCategoryView view,
            ICategoryFactory categoryFactory,
            ICategoriesService categoriesServices,
            IImageUploader imageUploader) : base(view)
        {
            if (categoriesServices == null)
            {
                throw new ArgumentNullException("Categories service cannot be null.");
            }
            
            if(categoryFactory == null)
            {
                throw new ArgumentNullException("Category factory cannot be null.");
            }

            if(imageUploader == null)
            {
                throw new ArgumentNullException("Image uploader cannot be null.");
            }

            this.categoriesServices = categoriesServices;
            this.categoryFactory = categoryFactory;
            this.imageUploader = imageUploader;
            this.View.AddingCategory += OnAddingCategory;
            this.View.UploadingImage += OnUploadingImage;
        }

        private void OnAddingCategory(object sender, AddCategoryEventArgs e)
        {
            var category = this.categoryFactory.CreateCategory(e.Name, this.imageFileName);

            this.categoriesServices.AddCategory(category);
        }

        private void OnUploadingImage(object sender, UploadImageEventArgs e)
        {
            this.imageFileName = this.imageUploader.Upload(e.Image, e.Server, e.ImageFileName, e.FolderName);
        }
    }
}
