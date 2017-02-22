using FFY.MVP.Administration.ProductManagement.EditProduct;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using FFY.MVP.Administration.ProductManagement.Utilities;

namespace FFY.Web.Administration.ProductManagement
{
    [PresenterBinding(typeof(EditProductPresenter))]
    public partial class EditProduct : MvpPage<EditProductViewModel>, IEditProductView
    {
        private const string DefaultProductFolderName = "products";

        public event EventHandler<GetProductEventArgs> Initial;
        public event EventHandler<EditProductEventArgs> EdittingProduct;
        public event EventHandler<UploadImageEventArgs> UploadingImage;

        protected void Page_Load(object sender, EventArgs e)
        {
            var productIdParameter = this.Page.RouteData.Values["productId"].ToString();

            int productId;

            if (!(int.TryParse(productIdParameter, out productId)))
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.Initial?.Invoke(this, new GetProductEventArgs(productId));

            if (this.Model.Product == null)
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.Rooms.DataSource = this.Model.Rooms;
            this.Rooms.DataBind();
            this.Rooms.SelectedValue = this.Rooms.Items.FindByText(this.Model.Product.Room.Name).Value;

            this.Categories.DataSource = this.Model.Categories;
            this.Categories.DataBind();
            this.Categories.SelectedValue = this.Categories.Items.FindByText(this.Model.Product.Category.Name).Value;
        }

        protected void EditProductClick(object sender, EventArgs e)
        {
            var selectedRoomId = int.Parse(this.Rooms.SelectedValue);
            var room = this.Model.Rooms.FirstOrDefault(r => r.Id == selectedRoomId);

            var selectedCategoryId = int.Parse(this.Categories.SelectedValue);
            var category = this.Model.Categories.FirstOrDefault(c => c.Id == selectedCategoryId);

            string imageFileName = this.Model.Product.ImagePath;
            string folderName = DefaultProductFolderName;

            this.UploadingImage?.Invoke(this, new UploadImageEventArgs(this.Image,
                Server,
                imageFileName,
                folderName));

            var product = this.Model.Product;
            product.Name = this.Name.Text;
            product.Price = decimal.Parse(this.Price.Text);
            product.DiscountPercentage = int.Parse(DiscountPercentage.Text);
            product.HasDiscount = int.Parse(DiscountPercentage.Text) > 0 ? true : false;
            product.Description = this.Description.Text;
            product.CategoryId = category.Id;
            product.Category = category;
            product.RoomId = room.Id;
            product.Room = room;

            this.EdittingProduct?.Invoke(this, new EditProductEventArgs(product));

            this.Response.Redirect("~/administration/productManagement");
        }
    }
}