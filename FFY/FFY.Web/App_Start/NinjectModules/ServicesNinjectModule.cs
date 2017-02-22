using Ninject.Modules;
using Ninject.Extensions.Conventions;
using FFY.Services.Assembly;
using FFY.Services.Handlers;
using Ninject;
using FFY.MVP.Furniture.Products;

namespace FFY.Web.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        private const string AllProductsWithQueryHandlerName = "AllProductsWithQueryHandler";
        private const string AllProductsHandlerName = "AllProductsHandler";
        private const string LatestProductsWithQueryHandlerName = "LatestProductsWithQueryHandler";
        private const string LatestProductsHandlerName = "LatestProductsHandler";
        private const string DiscountProductsWithQueryHandlerName = "DiscountProductsWithQueryHandler";
        private const string DiscountProductsHandlerName = "DiscountProductsHandler";
        private const string ProductsByRoomAndCategoryWithQueryHandlerName = "ProductsByRoomAndCategoryWithQueryHandler";
        private const string ProductsByRoomAndCategoryHandlerName = "ProductsByRoomAndCategoryHandler";


        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IServicesAssembly>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<IHandler>().To<AllProductsWithQueryHandler>().Named(AllProductsWithQueryHandlerName);
            this.Bind<IHandler>().To<AllProductsHandler>().Named(AllProductsHandlerName);
            this.Bind<IHandler>().To<LatestProductsWithQueryHandler>().Named(LatestProductsWithQueryHandlerName);
            this.Bind<IHandler>().To<LatestProductsHandler>().Named(LatestProductsHandlerName);
            this.Bind<IHandler>().To<DiscountProductsWithQueryHandler>().Named(DiscountProductsWithQueryHandlerName);
            this.Bind<IHandler>().To<DiscountProductsHandler>().Named(DiscountProductsHandlerName);
            this.Bind<IHandler>().To<ProductsByRoomAndCategoryWithQueryHandler>().Named(ProductsByRoomAndCategoryWithQueryHandlerName);
            this.Bind<IHandler>().To<ProductsByRoomAndCategoryHandler>().Named(ProductsByRoomAndCategoryHandlerName);

            this.Bind<IHandler>().ToMethod(ctx =>
            {
                var allProductsWithQueryHandler = ctx.Kernel.Get<IHandler>(AllProductsWithQueryHandlerName);
                var allProductsHandler = ctx.Kernel.Get<IHandler>(AllProductsHandlerName);
                var latestProductsWithQueryHandler = ctx.Kernel.Get<IHandler>(LatestProductsWithQueryHandlerName);
                var latestProductsHandler = ctx.Kernel.Get<IHandler>(LatestProductsHandlerName);
                var discountProductsWithQueryHandler = ctx.Kernel.Get<IHandler>(DiscountProductsWithQueryHandlerName);
                var discountProductsHandler = ctx.Kernel.Get<IHandler>(DiscountProductsHandlerName);
                var productsByRoomAndCategoryWithQueryHandler = ctx.Kernel.Get<IHandler>(ProductsByRoomAndCategoryWithQueryHandlerName);
                var productsByRoomAndCategoryHandler = ctx.Kernel.Get<IHandler>(ProductsByRoomAndCategoryHandlerName);

                allProductsWithQueryHandler.SetSuccessor(allProductsHandler);
                allProductsHandler.SetSuccessor(latestProductsWithQueryHandler);
                latestProductsWithQueryHandler.SetSuccessor(latestProductsHandler);
                latestProductsHandler.SetSuccessor(discountProductsWithQueryHandler);
                discountProductsWithQueryHandler.SetSuccessor(discountProductsHandler);
                discountProductsHandler.SetSuccessor(productsByRoomAndCategoryWithQueryHandler);
                productsByRoomAndCategoryWithQueryHandler.SetSuccessor(productsByRoomAndCategoryHandler);

                return allProductsWithQueryHandler;
            })
            .WhenInjectedInto<ProductsPresenter>();
        }
    }
}