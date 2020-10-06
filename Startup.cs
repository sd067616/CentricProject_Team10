using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CentricProject_Team10.Startup))]
namespace CentricProject_Team10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
