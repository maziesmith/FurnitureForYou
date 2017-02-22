using FFY.MVP.Administration.ProductManagement.AddRoom;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;
using FFY.MVP.Administration.ProductManagement.Utilities;

namespace FFY.Web.Administration.ProductManagement
{
    [PresenterBinding(typeof(AddRoomPresenter))]
    public partial class AddRoom : MvpPage<AddRoomViewModel>, IAddRoomView
    {
        private const string DefaultProductImageFileName = "default-room-image";
        private const string DefaultProductFolderName = "rooms";
        private const string ExistingCategoryErrorMessage = "Room addition was unsuccessful. The room may already exist";

        public event EventHandler<AddRoomEventArgs> AddingRoom;
        public event EventHandler<UploadImageEventArgs> UploadingImage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddRoomClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
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
                    this.AddingRoom?.Invoke(this, new AddRoomEventArgs(name));

                    this.Response.Redirect("~/administration/productManagement/addProduct");
                }
                catch (Exception)
                {
                    this.ErrorMessage.Text = ExistingCategoryErrorMessage;
                }
            }
        }
    }
}