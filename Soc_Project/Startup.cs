using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Soc_Project.Startup))]
namespace Soc_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
