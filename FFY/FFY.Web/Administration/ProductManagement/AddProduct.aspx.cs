using FFY.Models;
using FFY.MVP.Administration.AddProduct;
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

        public event EventHandler<AddProductEventArgs> AddingProduct;
        public event EventHandler Initial;

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
                    else
                    {

                    }
                }

                var product = new Product()
                {
                    Name = Name.Text,
                    Price = decimal.Parse(Price.Text),
                    Description = Description.Text,
                    CategoryId = category.Id,
                    Category = category,
                    RoomId = room.Id,
                    Room = room,
                    ImagePath = imageFileName
                };

                this.AddingProduct?.Invoke(this, new AddProductEventArgs(product));
            }
    }
}
}