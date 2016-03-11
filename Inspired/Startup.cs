using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inspired.Startup))]
namespace Inspired
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
