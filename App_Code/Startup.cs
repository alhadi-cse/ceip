using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ceip.Startup))]
namespace ceip
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
