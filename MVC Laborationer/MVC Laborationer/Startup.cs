using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Laborationer.Startup))]
namespace MVC_Laborationer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
