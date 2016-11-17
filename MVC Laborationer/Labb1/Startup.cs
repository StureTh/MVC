using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Labb1.Startup))]
namespace Labb1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
