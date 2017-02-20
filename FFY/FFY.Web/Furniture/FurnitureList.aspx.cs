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
        private const int DefaultFrom = 0;
        private const int DefaultTo = 100000;

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

            string search = null;

            if (!string.IsNullOrEmpty(this.Page.Request.QueryString["search"]))
            {
                search = this.Page.Request.QueryString["search"];
            }

            bool rangeProvided = false;
            int from = DefaultFrom;

            if (!string.IsNullOrEmpty(this.Page.Request.QueryString["from"]))
            {
                rangeProvided = true;
                from = int.Parse(this.Page.Request.QueryString["from"]);
            }

            int to = DefaultFrom;

            if (!string.IsNullOrEmpty(this.Page.Request.QueryString["to"]))
            {
                rangeProvided = true;
                to = int.Parse(this.Page.Request.QueryString["to"]);
            }

            var routeUrl = HttpContext.Current.Request.Url.AbsolutePath;

        }
    }
}