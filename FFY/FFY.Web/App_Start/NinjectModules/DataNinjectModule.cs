using Ninject.Modules;
using Ninject.Extensions.Conventions;

using FFY.Data.Assembly;
using FFY.Data.Contracts;
using FFY.Data;
using Ninject.Web.Common;
using FFY.Data.Factories;
using Ninject.Extensions.Factory;

namespace FFY.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IDataAssembly>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Rebind<IFFYContext>().To<FFYContext>().InRequestScope();
            this.Bind<IContactFactory>().ToFactory();
            this.Bind<IUserFactory>().ToFactory();
            this.Bind<ICategoryFactory>().ToFactory();
            this.Bind<IRoomFactory>().ToFactory();
            this.Bind<IProductFactory>().ToFactory();

        }
    }
}