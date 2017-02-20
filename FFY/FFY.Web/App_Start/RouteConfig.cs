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

            routes.MapPageRoute("AllFurniture",
                "furniture/all",
                "~/Furniture/FurnitureList.aspx");

            routes.MapPageRoute("FeaturedFurniture",
                "furniture/latest",
                "~/Furniture/FurnitureList.aspx");

            routes.MapPageRoute("DiscountFurniture",
                "furniture/discount",
                "~/Furniture/FurnitureList.aspx");

            routes.MapPageRoute("FurnitureProducts",
                "furniture/product/{productId}",
                "~/Furniture/FurnitureDetailed.aspx");

            routes.MapPageRoute("CategoriesByRooms", 
                "furniture/{room}", 
                "~/Furniture/CategoryList.aspx");

            routes.MapPageRoute("FurnitureByRoomsAndCategory",
                "furniture/{room}/{category}",
                "~/Furniture/FurnitureList.aspx");


            routes.MapPageRoute("EditProducts",
                "administration/edit-product/{productId}",
                "~/Administration/ProductManagement/EditProduct.aspx");

            routes.MapPageRoute("Contacts",
                "administration/contacts/{contactId}",
                "~/Administration/ContactManagement/ContactDetailed.aspx");

            routes.MapPageRoute("OrdersAdministration",
                "administration/orders/{orderId}",
                "~/Administration/OrderManagement/OrderDetailed.aspx");

            routes.MapPageRoute("OrdersUser",
                "user/orders/{orderId}",
                "~/Administration/OrderManagement/OrderDetailed.aspx");
        }
    }
}
