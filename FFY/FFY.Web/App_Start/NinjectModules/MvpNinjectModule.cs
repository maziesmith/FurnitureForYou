using System;
using System.Linq;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using WebFormsMvp;
using WebFormsMvp.Binder;
using FFY.Web.App_Start.Factories;
using FFY.MVP.Assembly;

namespace FFY.Web.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        private const string ViewConstructorArgumentName = "view";

        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IMvpAssembly>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();
            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();
            this.Bind<IPresenter>()
                .ToMethod(this.GetPresenter)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var constructorParameter = new ConstructorArgument(ViewConstructorArgumentName, viewInstance);

            var presenter = (IPresenter)context.Kernel.Get(presenterType, constructorParameter);
            return presenter;
        }
    }
}