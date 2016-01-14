using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ingresso.Web.Startup))]
namespace Ingresso.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
