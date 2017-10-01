using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(zn1Web.Startup))]
namespace zn1Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
