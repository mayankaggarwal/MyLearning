using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ng5Demo.Startup))]
namespace ng5Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
