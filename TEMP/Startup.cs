using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSM.Startup))]
namespace SSM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
