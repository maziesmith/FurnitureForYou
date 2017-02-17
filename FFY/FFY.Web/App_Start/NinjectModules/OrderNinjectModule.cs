using Ninject.Modules;
using Ninject.Extensions.Conventions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FFY.Order.Assembly;
using FFY.Order.Factories;
using Ninject.Extensions.Factory;

namespace FFY.Web.App_Start.NinjectModules
{
    public class OrderNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IOrderAssembly>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<ICartProductFactory>().ToFactory();
        }
    }
}