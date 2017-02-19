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
                "furniture/{roomName}", 
                "~/Furniture/FurnitureList.aspx");

            routes.MapPageRoute("FurnitureProducts",
                "furniture/product/{productId}",
                "~/Furniture/FurnitureDetailed.aspx");

            routes.MapPageRoute("EditProducts",
                "administration/edit-product/{productId}",
                "~/Administration/ProductManagement/EditProduct.aspx");

            routes.MapPageRoute("Contacts",
                "administration/contacts/{contactId}",
                "~/Administration/ContactManagement/ContactDetailed.aspx");

            routes.MapPageRoute("Orders",
                "administration/orders/{orderId}",
                "~/Administration/OrderManagement/OrderDetailed.aspx");
        }
    }
}
