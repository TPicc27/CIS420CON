using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_2_application.Startup))]
namespace MVC_2_application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
