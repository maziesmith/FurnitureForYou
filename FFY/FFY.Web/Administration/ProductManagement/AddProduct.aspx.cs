using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddProduct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.ProductManagement
{
    [PresenterBinding(typeof(AddProductPresenter))]
    public partial class AddProduct : MvpPage<AddProductViewModel>, IAddProductView
    {
        private const string DefaultProductImageFileName = "default-product-image";

        public event EventHandler Initial;
        public event EventHandler<AddProductEventArgs> AddingProduct;
        public event EventHandler<UploadImageEventArgs> UploadingImage;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Initial?.Invoke(this, e);

            if (!Page.IsPostBack)
            {
                this.Rooms.DataSource = this.Model.Rooms;
                this.Rooms.DataBind();

                this.Categories.DataSource = this.Model.Categories;
                this.Categories.DataBind();
            }
        }

        protected void AddProductClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var selectedRoomId = int.Parse(this.Rooms.SelectedValue);
                var room = this.Model.Rooms.FirstOrDefault(r => r.Id == selectedRoomId);

                var selectedCategoryId = int.Parse(this.Categories.SelectedValue);
                var category = this.Model.Categories.FirstOrDefault(c => c.Id == selectedCategoryId);

                string imageFileName = DefaultProductImageFileName;

                this.UploadingImage?.Invoke(this, new UploadImageEventArgs(this.Image,
                    imageFileName,
                    Server));

                try
                {
                    var name = Name.Text;
                    var price = decimal.Parse(Price.Text);
                    var discountPercentage = int.Parse(DiscountPercentage.Text);
                    var hasDiscount = discountPercentage > 0 ? true : false;
                    var description = Description.Text;
                    var categoryId = category.Id;
                    var roomId = room.Id;
                    var imagePath = imageFileName;

                    this.AddingProduct?.Invoke(this, new AddProductEventArgs(name, 
                        price, 
                        discountPercentage, 
                        hasDiscount,
                        description,
                        categoryId,
                        category,
                        roomId,
                        room,
                        imagePath));
                }
                catch (Exception)
                {
                    this.Server.Transfer("~/Errors/InternalServerError.aspx");
                }
            }
    }
}
}