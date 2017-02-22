using FFY.MVP.Furniture.CategoryByRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Furniture
{
    [PresenterBinding(typeof(CategoryByRoomPresenter))]
    public partial class CategoryList : MvpPage<CategoryByRoomViewModel>, ICategoryByRoomView
    {
        public event EventHandler<CategoryByRoomEventArgs> ListingCategoriesByRoom;

        protected void Page_Load(object sender, EventArgs e)
        {
            var roomParameter = this.Page.RouteData.Values["room"].ToString();

            if(string.IsNullOrEmpty(roomParameter))
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.ListingCategoriesByRoom?.Invoke(this, new CategoryByRoomEventArgs(roomParameter));

            if(this.Model.Categories.Count() == 0)
            {
                // TODO: Display no categories ...
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.Model.Room = roomParameter;

            if (!Page.IsPostBack)
            {
                this.CategoriesList.DataSource = this.Model.Categories;
                this.CategoriesList.DataBind();
            }
        }
    }
}