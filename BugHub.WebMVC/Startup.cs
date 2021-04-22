using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BugHub.WebMVC.Startup))]
namespace BugHub.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
