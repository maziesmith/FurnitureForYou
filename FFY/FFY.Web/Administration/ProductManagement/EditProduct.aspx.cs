using FFY.Models;
using FFY.MVP.Administration.EditProduct;
using System;
using System.IO;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.ProductManagement
{
    [PresenterBinding(typeof(EditProductPresenter))]
    public partial class EditProduct : MvpPage<EditProductViewModel>, IEditProductView
    {
        public event EventHandler<GetProductEventArgs> Initial;
        public event EventHandler<EditProductEventArgs> EdittingProduct;

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

            if (this.Image.HasFile)
            {
                if (this.Image.PostedFile.ContentType == "image/png" || this.Image.PostedFile.ContentType == "image/jpeg")
                {
                    string subPath = @"~\Images\" + category.Name.ToLower().Replace(@"\s+", "");

                    bool exists = Directory.Exists(Server.MapPath(subPath));

                    if (!exists)
                    {
                        Directory.CreateDirectory(Server.MapPath(subPath));
                    }

                    imageFileName = (DateTime.Now - new DateTime(1970, 1, 1)).TotalMinutes.ToString() + Path.GetFileName(Image.FileName);
                    Image.SaveAs(Server.MapPath(subPath + @"\" + imageFileName));
                }
            }

            try
            {
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
                product.ImagePath = imageFileName;

                this.EdittingProduct?.Invoke(this, new EditProductEventArgs(product));
            }
            catch (Exception)
            {
                this.Server.Transfer("~/Errors/InternalServerError.aspx");
            }
        }
    }
}