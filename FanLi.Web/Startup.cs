using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FanLi.Web.Startup))]
namespace FanLi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
