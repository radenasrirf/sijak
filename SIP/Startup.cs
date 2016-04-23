using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIP.Startup))]
namespace SIP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
