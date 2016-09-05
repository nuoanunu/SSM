using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TEMP.Startup))]
namespace TEMP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
