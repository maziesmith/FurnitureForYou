using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddCategory;
using FFY.MVP.Administration.ProductManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.ProductManagement
{
    [PresenterBinding(typeof(AddCategoryPresenter))]
    public partial class AddCategory : MvpPage<AddCategoryViewModel>, IAddCategoryView
    {
        private const string DefaultProductImageFileName = "default-category-image";
        private const string DefaultProductFolderName = "categories";
        private const string ExistingCategoryErrorMessage = "Category addition was unsuccessful. The category may already exist";

        public event EventHandler<AddCategoryEventArgs> AddingCategory;
        public event EventHandler<UploadImageEventArgs> UploadingImage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddCategoryClick(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                string imageFileName = DefaultProductImageFileName;
                string folderName = DefaultProductFolderName;

                this.UploadingImage?.Invoke(this, new UploadImageEventArgs(this.Image,
                    Server,
                    imageFileName,
                    folderName));

                var name = this.Name.Text;

                try
                {
                    this.AddingCategory?.Invoke(this, new AddCategoryEventArgs(name));
                }
                catch (Exception)
                {
                    this.ErrorMessage.Text = ExistingCategoryErrorMessage;
                }
            }
        }
    }
}