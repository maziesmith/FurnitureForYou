using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddRoom;
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
    [PresenterBinding(typeof(AddRoomPresenter))]
    public partial class AddRoom : MvpPage<AddRoomViewModel>, IAddRoomView
    {
        private const string ExistingCategoryErrorMessage = "Room addition was unsuccessful. The room may already exist";
        public event EventHandler<AddRoomEventArgs> AddingRoom;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddRoomClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var name = this.Name.Text;

                try
                {
                    this.AddingRoom?.Invoke(this, new AddRoomEventArgs(name));

                }
                catch (Exception)
                {
                    this.ErrorMessage.Text = ExistingCategoryErrorMessage;
                }
            }
        }
    }
}