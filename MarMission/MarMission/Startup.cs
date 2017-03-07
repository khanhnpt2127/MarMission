using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarMission.Startup))]
namespace MarMission
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
