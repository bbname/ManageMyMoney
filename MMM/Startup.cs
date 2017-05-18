using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MMM.Startup))]
namespace MMM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
