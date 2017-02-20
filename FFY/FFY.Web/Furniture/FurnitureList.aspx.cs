using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FFY.Web.Furniture
{
    public partial class FurnitureList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string room = null;

            if(this.Page.RouteData.Values["room"] != null)
            {
                room = this.Page.RouteData.Values["room"].ToString();
            }

            string category = null;

            if (this.Page.RouteData.Values["category"] != null)
            {
                category = this.Page.RouteData.Values["category"].ToString();
            }

            var routeUrl = HttpContext.Current.Request.Url.AbsolutePath;

        }
    }
}