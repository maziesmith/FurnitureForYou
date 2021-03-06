﻿using FFY.MVP.Furniture.FurnitureDetailed;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Furniture
{
    [PresenterBinding(typeof(FurnitureDetailedPresenter))]
    public partial class FurnitureDetailed : MvpPage<FurnitureDetailedViewModel>, IFurnitureDetailedView
    {
        private string userId;
        public event EventHandler<FurnitureDetailedEventArgs> GettingProductById;
        public event EventHandler<AddToShoppingCartEventArgs> AddingToShoppingCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            var productIdParameter = this.Page.RouteData.Values["productId"].ToString();

            int productId;

            if(!(int.TryParse(productIdParameter, out productId)))
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.GettingProductById?.Invoke(this, new FurnitureDetailedEventArgs(productId));

            if(this.Model.Product == null)
            {
                this.Server.Transfer("~/Errors/PageNotFound.aspx");
            }

            this.userId = this.User.Identity.GetUserId();
        }

        protected void AddToCart(object sender, EventArgs e)
        {
            if(!User.Identity.IsAuthenticated)
            {
                this.Response.Redirect($"~/Account/Login?ReturnUrl={HttpContext.Current.Request.Url.AbsolutePath}");
            }

            var quantity = int.Parse(this.AddToCartQuantity.Text);

            this.AddingToShoppingCart?.Invoke(this, 
                new AddToShoppingCartEventArgs(quantity, this.userId));

            this.Cache.Insert($"cart-count-{userId}", this.Model.CartCount);

            this.Response.Redirect("~/users/cart");
        }
    }
}