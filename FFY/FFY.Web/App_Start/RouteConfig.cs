using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace FFY.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("FurnitureRooms", 
                "Furniture/{roomName}", 
                "~/Furniture/FurnitureList.aspx");

            routes.MapPageRoute("FurnitureProducts",
                "Furniture/{roomName}/{productId}",
                "~/Furniture/FurnitureDetailed.aspx");
        }
    }
}
