using Ninject.Modules;
using Ninject.Extensions.Conventions;
using FFY.Services.Assembly;
using FFY.Services.Contracts;
using FFY.Services;
using Ninject.Web.Common;
using FFY.Services.Handlers;
using Ninject;
using FFY.MVP.Furniture.Products;

namespace FFY.Web.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        private const string AllProductsHandlerName = "AllProductsHandler";
        private const string LatestProductsHandlerName = "LatestProductsHandler";
        private const string DiscountProductsHandlerName = "DiscountProductsHandler";
        private const string ProductsByRoomAndCategoryHandlerName = "ProductsByRoomAndCategoryHandler";


        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IServicesAssembly>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<IHandler>().To<AllProductsHandler>().Named(AllProductsHandlerName);
            this.Bind<IHandler>().To<LatestProductsHandler>().Named(LatestProductsHandlerName);
            this.Bind<IHandler>().To<DiscountProductsHandler>().Named(DiscountProductsHandlerName);
            this.Bind<IHandler>().To<ProductsByRoomAndCategoryHandler>().Named(ProductsByRoomAndCategoryHandlerName);

            this.Bind<IHandler>().ToMethod(ctx =>
            {
                var allProductsHandler = ctx.Kernel.Get<IHandler>(AllProductsHandlerName);
                var latestProductsHandler = ctx.Kernel.Get<IHandler>(LatestProductsHandlerName);
                var discountProductsHandler = ctx.Kernel.Get<IHandler>(DiscountProductsHandlerName);
                var productsByRoomAndCategoryHandler = ctx.Kernel.Get<IHandler>(ProductsByRoomAndCategoryHandlerName);

                allProductsHandler.SetSuccessor(latestProductsHandler);
                latestProductsHandler.SetSuccessor(discountProductsHandler);
                discountProductsHandler.SetSuccessor(productsByRoomAndCategoryHandler);

                return allProductsHandler;
            })
            .WhenInjectedInto<ProductsPresenter>();
        }
    }
}