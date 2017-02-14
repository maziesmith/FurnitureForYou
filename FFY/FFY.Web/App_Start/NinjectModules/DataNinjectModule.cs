using Ninject.Modules;
using Ninject.Extensions.Conventions;

using FFY.Data.Assembly;
using FFY.Data.Contracts;
using FFY.Data;
using Ninject.Web.Common;

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

            // this.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();

            
        }
    }
}