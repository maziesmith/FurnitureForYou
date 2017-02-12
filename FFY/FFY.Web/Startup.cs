using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FFY.Web.Startup))]
namespace FFY.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
