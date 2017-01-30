using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS420CON.Startup))]
namespace CIS420CON
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
