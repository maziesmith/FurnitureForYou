using FFY.Models;
using FFY.MVP.Administration.AddRoom;
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
        public event EventHandler<AddRoomEventArgs> AddingRoom;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddRoomClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var room = new Room
                {
                    Name = this.Name.Text,
                };

                this.AddingRoom?.Invoke(this, new AddRoomEventArgs(room));
            }
        }
    }
}