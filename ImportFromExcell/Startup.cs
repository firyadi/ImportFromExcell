using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImportFromExcell.Startup))]
namespace ImportFromExcell
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
